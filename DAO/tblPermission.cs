//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Product.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPermission()
        {
            this.tblPerRelationship = new HashSet<tblPerRelationship>();
        }
    
        public int permissionId { get; set; }
        public string permissionName { get; set; }
        public string permissionAccess { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPerRelationship> tblPerRelationship { get; set; }
    }
}