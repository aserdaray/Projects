//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvrakTakipDataLayer.DbModel
{
    using System;
    using System.Collections.Generic;
     
    public partial class Evrak 
    {
        public int EvrakId { get; set; }
        public string Tip { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string GelenEvrakBBNo { get; set; }
        public string GidenEvrakKod { get; set; }
        public string SayiNo { get; set; }
        public Nullable<int> GelenEvrakGeldigiBirimId { get; set; }
        public Nullable<int> GidenEvrakHazirlayanBirimId { get; set; }
        public string Konu { get; set; }
        public Nullable<System.DateTime> SonKullanmaTarihi { get; set; }
        public string DosyaAdi { get; set; }
        public byte[] DosyaIcerik { get; set; }
        public Nullable<System.DateTime> EklemeZamani { get; set; }
        public Nullable<int> Ekleyen { get; set; }
        public Nullable<System.DateTime> DegistirmeZamani { get; set; }
        public Nullable<int> Degistiren { get; set; }
        public Nullable<System.DateTime> SilmeZamani { get; set; }
        public Nullable<int> Silen { get; set; }
        public Nullable<bool> SilindiMi { get; set; }
        public Nullable<bool> KapatildiMi { get; set; }
        public Nullable<int> EskiId { get; set; }
        public Nullable<System.DateTime> KapatmaZamani { get; set; }
        public Nullable<int> Kapatan { get; set; }
        public Nullable<System.DateTime> SonBildirimTarihi { get; set; }
    }
}
