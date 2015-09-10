using KartTest.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace KartTest
{
    /// <summary>
    /// KartFactory sınıfı IKartFactoryDb interface'inden türemiş bir sınıf ile yapılandırılmak zorundadır. 
    /// Bu sınıfın sağladığı veriler baz alınarak, parametre olarak alınan veriler ile bir kart datası hesaplaması yapmaktadır.
    /// </summary>
    /// <typeparam name="T">IKartFactoryDb'den türemiş bir nesne kullanılmalıdır.</typeparam>
    public class KartFactory<T, K>
        where T : IKartFactoryDb
        where K : IHeader
    {
        private IKartFactoryDb db;
        private IHeader header;
        public List<byte[]> headerList { get; set; }

        public KartFactory(T t, K k)
        {
            this.db = t;
            this.header = k;
            this.headerList = new List<byte[]>();

        }


        /// <summary>
        /// Entity içerisindeki property değerlerini okumak için kullanılır.
        /// </summary>
        /// <param name="obj">Entity'deki bir property objesini ifade eder.</param>
        /// <param name="propertyName">Property'nin entity içerisindeki adını ifade eder.</param>
        /// <returns>Property'e set edilmiş değeri döndürür</returns>
        private object GetPropertyValue(object obj, string propertyName)
        {
            var objType = obj.GetType();
            var prop = objType.GetProperty(propertyName);

            return prop.GetValue(obj, null);
        }

        /// <summary>
        /// IKartFactoryDb tarafından sağlanan key değerleri baz alınarak gönderilen property'nin byte karşılığı hesaplanır.
        /// </summary>
        /// <param name="key">Property Adı yani, IKartFactoryDb'deki key alanını ifade eder.</param>
        /// <param name="value">Property'e set edilmiş değeri ifade eder.</param>
        /// <returns></returns>
        public KartEntity GetBytesOfProperty(string key, object value)
        {
            if (value == null) return null;

            //  IKartFactoryDb db = new KartFactoryDb();

            if (db.KeyCheck(key))
            {
                List<byte[]> data1 = new List<byte[]>();
                KartEntity ike = db.Get(key);
                int length = ike.Uzunluk;
                short tag = ike.AlanKodu;
                String type = ike.Type;

                //Hesaplama Kısmı 
                //TODO : Güncel Excel datasına göre hesaplama sistemi gözden geçirilecek.

                ike.tag = BitConverter.GetBytes(tag);

                if (type == typeof(Boolean).ToString())
                {
                    ike.length = BitConverter.GetBytes((short)length);
                    ike.data = BitConverter.GetBytes(Convert.ToBoolean(value));

                }
                else if (type == typeof(DateTime).ToString())
                {

                    ike.length = BitConverter.GetBytes((short)length);
                    
                    var x = ((DateTime)value).ToString("yy.MM.dd.HH.mm.ss").Split('.');
                    List<byte> list = new List<byte>();
                    foreach (var item in x)
                    {
                        list.Add(Convert.ToByte(item));
                    }
                    
                    ike.data = list.ToArray();


                }
                else if (type == typeof(int).ToString())
                {
                    ike.length = BitConverter.GetBytes((short)length);
                    ike.data = (BitConverter.GetBytes(Convert.ToUInt16(value)));
                }
                else if (type == typeof(UInt32).ToString())
                {
                    ike.length = (BitConverter.GetBytes((short)length));
                    ike.data = (BitConverter.GetBytes(Convert.ToUInt32(value)));
                }
                else
                {
                    ike.length = (BitConverter.GetBytes((short)System.Text.ASCIIEncoding.UTF8.GetBytes(value.ToString()).Length));
                    ike.data = (System.Text.ASCIIEncoding.UTF8.GetBytes(value.ToString()));
                }




                return ike;
            }

            return null;
        }

        private byte[] Combine(byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        private byte[] OrganizeHeader(List<byte[]> list)
        {
            byte[] headerData = Combine(list.ToArray());
            byte[] header = new byte[128];

            int sifirSayisi = header.Length - headerData.Length - 8 - 4;

            db.EditSize("Reserve", (short)sifirSayisi);
            byte[] reserve = GetBytesOfProperty("Reserve", 0).GetByte();


            Array.Copy(headerData, 0, header, 0, headerData.Length);
            Array.Copy(reserve, 0, header, headerData.Length, reserve.Length);
            return header;


        }


        public ResultEntity ReOrder(ResultEntity res)
        {
            ResultEntity r = new ResultEntity();
            foreach (var item in res.map)
            {
                var sorted = from x in item.Value orderby x.SiraNo ascending select x;
                List<KartEntity> sortedList = sorted.ToList();

               
                r.map.Add(item.Key, sortedList);
            }

            return r;
        }

        public byte[] GetBytes(ResultEntity res)
        {
            res = ReOrder(res);

            byte[] imzasiz = new byte[0];
            foreach (var item in res.map)
            {
                List<byte[]> headerList = GetBytesOfEntity(item.Key, new List<byte[]>());

                byte[] header = OrganizeHeader(headerList);

                byte[] veri = item.Value.SelectMany(k => k.GetByte()).ToArray();

                imzasiz = new byte[header.Length + veri.Length];
                header.CopyTo(imzasiz, 0);
                veri.CopyTo(imzasiz, header.Length);

                uint imza = CRC32.Get(imzasiz);

                item.Key.Imza = imza.ToString();
                byte[] imzaPaket = GetBytesOfProperty("Imza", item.Key.Imza).GetByte();

                //İmzalanıyor
                Array.Copy(imzaPaket, 0, imzasiz, 124, imzaPaket.Length);
            }

            return imzasiz;

        }

        /// <summary>
        /// Gönderilen entity üzerinde dallanara ilerler ve entitylerin property haritasını sıralı olarak çıkarır.
        /// </summary>
        /// <param name="obj">Entity objesini ifade eder.</param>
        /// <param name="isUnique">True ; Harita üzerinde farklı alanlarda tekrar eden aynı propertylerin isimlerini ikinci bir defa yazılmamasını sağlar.</param>
        /// <returns></returns>
        public List<string> GetFieldList(object obj, bool isUnique)
        {
            return GetFieldList(obj, new List<string>(), isUnique);
        }

        private List<string> GetFieldList(object obj, List<string> list, bool isUnique)
        {
            if (obj == null) return null;
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!IsMarkedAsExcept(property))
                {
                    try
                    {
                        object propValue = property.GetValue(obj, null);
                        if (property.PropertyType.Namespace.Contains("System.Collections"))
                        {
                            var o2 = propValue as IEnumerable;
                            foreach (var item in o2)
                            {
                                GetFieldList(item, list, isUnique);
                            }
                        }

                        if (property.PropertyType.Assembly == objType.Assembly)
                        {
                            GetFieldList(propValue, list, isUnique);
                        }
                        else
                        {
                            //     Console.WriteLine(property.Name + " - " + propValue);
                            if (isUnique)
                            {
                                if (!list.Contains(property.Name))
                                {
                                    list.Add(property.Name);
                                }

                            }
                            else
                            {
                                list.Add(property.Name);
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return list;

        }

        /// <summary>
        /// Verilen entity objesi için toplam byte değerini hesaplar.
        /// </summary>
        /// <param name="obj">Bir entity objesini ifade eder.</param>
        public ResultEntity GetBytesOfEntity(object obj)
        {
            return GetBytesOfEntity(obj, new ResultEntity());
        }

        public ResultEntity GetBytesOfEntity(object obj, ResultEntity result)
        {
            if (obj == null) return null;

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {

                if (!IsMarkedAsExcept(property))
                {
                    object propValue = property.GetValue(obj, null);
                    if (property.PropertyType.Namespace.Contains("System.Collections"))
                    {
                        var propCollection = propValue as IEnumerable;
                        foreach (var item in propCollection)
                        {
                            GetBytesOfEntity(item, result);
                        }
                    }
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        if (property.PropertyType == this.header.GetType())
                        {
                            //List<byte[]> head = GetBytesOfEntity(propValue, result);
                            //byte[] header = OrganizeHeader(head);
                            //list.Clear();
                            //headerList.Add(header);
                            object headerInstance = property.GetValue(obj);
                            //    Header head = (Header)headerInstance.GetType().GetField(property.Name).GetValue(headerInstance);
                            MapObjects(headerInstance, this.header);

                        }
                        else
                        {
                            GetBytesOfEntity(propValue, result);
                        }

                    }
                    else
                    {
                        try
                        {
                            KartEntity ke = new KartEntity();
                            ke = GetBytesOfProperty(property.Name, propValue);

                            if (ke.GetByte() != null)
                            {
                                result.list.Add(ke);
                            }
                        }
                        catch (Exception)
                        {


                        }

                    }
                }

            }


            result.Add(this.header, result.list);

            return result;
        }


        public List<byte[]> GetBytesOfEntity(object obj, List<byte[]> list)
        {
            if (obj == null) return null;

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var asd = IsMarkedAsExcept(property);
                if (!IsMarkedAsExcept(property))
                {
                    object propValue = property.GetValue(obj, null);
                    if (property.PropertyType.Namespace.Contains("System.Collections"))
                    {
                        var propCollection = propValue as IEnumerable;
                        foreach (var item in propCollection)
                        {
                            GetBytesOfEntity(item, list);
                        }
                    }
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        GetBytesOfEntity(propValue, list);
                    }
                    else
                    {
                        try
                        {
                            KartEntity ke = GetBytesOfProperty(property.Name, propValue);
                            byte[] xx = ke.GetByte();
                            if (xx != null)
                            {
                                //Console.Write(property.Name + "\t " + propValue);

                               
                                Console.WriteLine();
                                Console.WriteLine();
                                list.Add(xx);

                            }
                        }
                        catch (Exception)
                        {


                        }

                    }
                }
            }
            return list;
        }


        public void MapObjects(object source, object destination)
        {
            Type sourcetype = source.GetType();
            Type destinationtype = destination.GetType();

            var sourceProperties = sourcetype.GetProperties();
            var destionationProperties = destinationtype.GetProperties();

            var commonproperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };

            foreach (var match in commonproperties)
            {
                match.dp.SetValue(destination, match.sp.GetValue(source, null), null);
            }
        }

        private bool IsMarkedAsExcept(PropertyInfo prop)
        {
            return prop.GetCustomAttributes(typeof(ExceptFromCardAttribute), true).Any();
        }

        /*
        public Type ListArgumentOrSelf(Type type)
        {
            if (!type.IsGenericType)
                return type;
            if (type.GetGenericTypeDefinition() != typeof(List<>))
                throw new Exception("Only List<T> are allowed");
            return type.GetGenericArguments()[0];
        }*/
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class ExceptFromCardAttribute : Attribute
    { }

}

