//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mesajlar
    {
        public int Id { get; set; }
        public string Gonderen { get; set; }
        public string Alici { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    }
}
