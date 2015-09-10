using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    public class KartFactoryDb : IKartFactoryDb
    {
        Dictionary<string, KartEntity> map = new Dictionary<string, KartEntity>();


        public KartFactoryDb()
        {

            
            this.map.Add("DosyaTipi",                    new KartEntity() { AlanKodu = 1,    SiraNo= 1,  Uzunluk = 0, AlanAdi = "DosyaTipi" ,Type = "System.String"});

            this.map.Add("Versiyon",                     new KartEntity() { AlanKodu = 2,    SiraNo= 2,  Uzunluk = 5, AlanAdi = "Versiyon",                  Type = "System.String" });
            this.map.Add("TanimlamaTarihi",              new KartEntity() { AlanKodu = 3,    SiraNo= 3,  Uzunluk = 6, AlanAdi = "TanimlamaTarihi",           Type = "System.DateTime" });
            this.map.Add("GecerlilikTarihi",             new KartEntity() { AlanKodu = 4,    SiraNo= 4,  Uzunluk = 6, AlanAdi = "GecerlilikTarihi",          Type = "System.DateTime" });
            this.map.Add("KayitSayisi",                  new KartEntity() { AlanKodu = 5,    SiraNo= 5,  Uzunluk = 2, AlanAdi = "KayitSayisi",               Type = "System.Int16" });
            this.map.Add("Reserve",                      new KartEntity() { AlanKodu = 6,    SiraNo= 6,  Uzunluk = 0, AlanAdi = "Reserve",                   Type = "System.String" });
            this.map.Add("Imza",                         new KartEntity() { AlanKodu = 31,   SiraNo= 7,  Uzunluk = 4, AlanAdi = "Imza",                      Type = "System.UInt32" });

            this.map.Add("AktarmaAlir",                  new KartEntity() { AlanKodu = 72,   SiraNo= 9,  Uzunluk = 1, AlanAdi = "AktarmaAlir",               Type = "System.String" });
            this.map.Add("AktarmaVerir",                 new KartEntity() { AlanKodu = 73,   SiraNo= 8,  Uzunluk = 1, AlanAdi = "AktarmaVerir",              Type = "System.String" });
            this.map.Add("AktarmaAlmaSuresi",            new KartEntity() { AlanKodu = 78,   SiraNo= 10,  Uzunluk = 2, AlanAdi = "AktarmaAlmaSuresi",         Type = "System.String" });
            this.map.Add("AktarmaVermeSuresi",           new KartEntity() { AlanKodu = 79,   SiraNo= 11,  Uzunluk = 2, AlanAdi = "AktarmaVermeSuresi",        Type = "System.String" });
            this.map.Add("ScadaVarmi",                   new KartEntity() { AlanKodu = 153,  SiraNo= 12,  Uzunluk = 1, AlanAdi = "ScadaVarmi",                Type = "System.String" });
            this.map.Add("KullanAtGecer",                new KartEntity() { AlanKodu = 149,  SiraNo= 13,  Uzunluk = 1, AlanAdi = "KullanAtGecer",             Type = "System.String" });
            this.map.Add("MukerrerlikSuresi",            new KartEntity() { AlanKodu = 77,   SiraNo= 14,  Uzunluk = 2, AlanAdi = "MukerrerlikSuresi",         Type = "System.String" });
            this.map.Add("GunlukUcretsizGecisLimiti",    new KartEntity() { AlanKodu = 35,   SiraNo= 15,  Uzunluk = 1, AlanAdi = "GunlukUcretsizGecisLimiti", Type = "System.String" });
            this.map.Add("GunlukIndirimliGecisLimiti",   new KartEntity() { AlanKodu = 44,   SiraNo= 16,  Uzunluk = 1, AlanAdi = "GunlukIndirimliGecisLimiti",Type = "System.String" });
            this.map.Add("AylikIndirimliGecisLimiti",    new KartEntity() { AlanKodu = 45,   SiraNo= 17,  Uzunluk = 2, AlanAdi = "AylikIndirimliGecisLimiti", Type = "System.String" });
            this.map.Add("IndirimliListesi",             new KartEntity() { AlanKodu = 70,   SiraNo= 18,  Uzunluk = 0, AlanAdi = "IndirimliListesi",          Type = "System.String" });




        }


        public bool KeyCheck(string key)
        {
            return this.map.ContainsKey(key);
        }


        public bool Add(string key, KartEntity value)
        {
            this.map.Add(key, value);
            return true;
        }

        public KartEntity Get(string key)
        {
            KartEntity ret;
            this.map.TryGetValue(key, out ret);
            return ret;
        }


        public void EditSize(string key, short value)
        {
            KartEntity ent;
            map.TryGetValue(key, out ent);
            map.Remove(key);
            ent.Uzunluk = value;
            map.Add(key, ent);

        }

        public void Edit(string key, KartEntity value)
        {
            map.Remove(key);
            map.Add(key, value);
        }




    }
}
