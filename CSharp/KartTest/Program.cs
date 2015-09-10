using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    class Program
    {
        static void Main(string[] args)
        {
            KartFactory<KartFactoryDb,Header> kf = new KartFactory<KartFactoryDb,Header>(new KartFactoryDb(),new Header());

            List<Hat> list = new List<Hat>();

            

            Header h = new Header();
            h.HeaderId = new Random().Next(100);
            h.KayitSayisi = new Random().Next(100); ;
            h.Versiyon = "01.00";
            h.TanimlamaTarihi = DateTime.Now;
            h.GecerlilikTarihi = DateTime.Now;
            h.Imza = "01";
            h.DosyaTipi = "Hat";

            Operator op = new Operator();
            op.operatorAdi = "IETT";
            op.operatorId = 130;
            op.abonmanOperatoru = false;
            
            
            Parametre p = new Parametre();
            p.Header = h;
            p.Operator = op;
            p.MukerrerlikSuresi = 100;



            ResultEntity re = kf.GetBytesOfEntity(p);

            byte[] asd = kf.GetBytes(re);

            

            var aaa = kf.GetBytesOfProperty("Versiyon", h.Versiyon);

           
           //  Console.WriteLine(System.Text.Encoding.UTF8.GetString(item)+ " -- "+BitConverter.ToString(item).ToString());
           

            Console.ReadLine();


      
        }
    }
}

    
