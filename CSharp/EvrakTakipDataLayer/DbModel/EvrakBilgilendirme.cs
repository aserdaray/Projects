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
     
    public partial class EvrakBilgilendirme 
    {
        public int idEvrakBilgilendirme { get; set; }
        public Nullable<int> idEvrak { get; set; }
        public Nullable<int> idUser { get; set; }
        public string Tip { get; set; }
    }
}
