//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bus.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblKullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKullanicilar()
        {
            this.TblSepets = new HashSet<TblSepet>();
        }
    
        public int KullaniciID { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
        public string AdSoyad { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSepet> TblSepets { get; set; }
    }
}
