using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    public class KartEntity 
    {
        public int AlanKodlariId { get; set; }
        public string AlanAdi { get; set; }
        public short AlanKodu { get; set; }
        public int Uzunluk { get; set; }
        public int SiraNo { get; set; }
        public String Type { get; set; }

        public byte[] tag { get; set; }
        public byte[] length { get; set; }
        public byte[] data { get; set; }


        public byte[] GetByte()
        {
            byte[] rv = new byte[tag.Length + length.Length + data.Length];
            System.Buffer.BlockCopy(tag, 0, rv, 0, tag.Length);
            System.Buffer.BlockCopy(length, 0, rv, tag.Length, length.Length);
            System.Buffer.BlockCopy(data, 0, rv, tag.Length + length.Length, data.Length);

            return rv;
        }
    }
}
