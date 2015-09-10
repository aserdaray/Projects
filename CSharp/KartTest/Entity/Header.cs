using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartTest
{

    public class Header : KartTest.Entity.IHeader
    {
        [ExceptFromCard]
        public int HeaderId { get; set; }

        public string DosyaTipi { get; set; }
        public string Versiyon { get; set; }
        public DateTime TanimlamaTarihi { get; set; }
        public DateTime GecerlilikTarihi { get; set; }
        public int KayitSayisi { get; set; }
        public string Imza { get; set; }
     
    }
}
