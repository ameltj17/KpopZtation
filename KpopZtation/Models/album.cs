//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KpopZtation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public album()
        {
            this.carts = new HashSet<cart>();
            this.transactionDetails = new HashSet<transactionDetail>();
        }
    
        public int albumId { get; set; }
        public int artistId { get; set; }
        public string albumName { get; set; }
        public string albumImage { get; set; }
        public int albumPrice { get; set; }
        public int albumStock { get; set; }
        public string albumDescription { get; set; }
    
        public virtual artist artist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cart> carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transactionDetail> transactionDetails { get; set; }
    }
}