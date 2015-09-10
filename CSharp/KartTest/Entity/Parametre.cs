using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{
    
    public class Parametre
    {
        public Header Header { get; set; }
        public Operator Operator { get; set; }
        public int MukerrerlikSuresi { get; set; }
        public int AktarmaAlmaSuresi { get; set; }
        public int AktarmaVermeSuresi { get; set; }
        public int AktarmaBaslangicLimitDegeri { get; set; }
        public int TurnikeCalismaModu { get; set; }
        public int GunlukUcretsizGecisLimiti { get; set; }
        public int AylikUcretsizGecisLimiti { get; set; }
        public int GunlukIndirimliGecisLimiti { get; set; }
        public int AylikIndirimliGecisLimiti { get; set; }
        public bool AktarmaAlir { get; set; }
        public bool AktarmaVerir { get; set; }
        public bool KullanAtGecer { get; set; }
        public bool MetalJetonGecer { get; set; }
        public bool RfJetonGecer { get; set; }
        public bool ScadaVarmi { get; set; }
        public bool AbonmanGecer { get; set; }
        public bool IndirimliListesiGecer { get; set; }
        public bool LimitliIndirimliListesiGecer { get; set; }
        public bool UcretsizListesiGecer { get; set; }
        public bool LimitliUcretsizListesiGecer { get; set; }
        public bool Aktif { get; set; }
    }
}
