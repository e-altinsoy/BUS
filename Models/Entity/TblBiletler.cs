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
    
    public partial class TblBiletler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblBiletler()
        {
            this.TblSepets = new HashSet<TblSepet>();
        }
    
        public int BIletID { get; set; }
        public int MusteriID { get; set; }
        public int SeferID { get; set; }
        public string TC { get; set; }
        public string YolcuAd { get; set; }
        public string YolcuSoyad { get; set; }
        public bool YolcuCinsiyet { get; set; }
        public byte KoltukNo { get; set; }
        public decimal Ucret { get; set; }
        public System.DateTime IslemZamani { get; set; }
    
        public virtual TblMusteriler TblMusteriler { get; set; }
        public virtual TblSeferler TblSeferler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSepet> TblSepets { get; set; }
    }
}
