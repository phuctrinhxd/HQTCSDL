//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            this.CTHDs = new HashSet<CTHD>();
            this.DIENNUOCs = new HashSet<DIENNUOC>();
            this.PHIEUTHANHTOANs = new HashSet<PHIEUTHANHTOAN>();
        }
    
        public string maPhong { get; set; }
        public string tenPhong { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public Nullable<decimal> giaPhong { get; set; }
        public string maNhaTro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIENNUOC> DIENNUOCs { get; set; }
        public virtual NHATRO NHATRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHANHTOAN> PHIEUTHANHTOANs { get; set; }
    }
}
