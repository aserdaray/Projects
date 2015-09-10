using System;
namespace KartTest.Entity
{
    public interface IHeader
    {
        string DosyaTipi { get; set; }
        DateTime GecerlilikTarihi { get; set; }
        int HeaderId { get; set; }
        string Imza { get; set; }
        int KayitSayisi { get; set; }
        DateTime TanimlamaTarihi { get; set; }
        string Versiyon { get; set; }
        
    }
}
