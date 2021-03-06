//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RescueHandymans.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Camp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Camp()
        {
            this.CampInCharges = new HashSet<CampInCharge>();
            this.CampRequirements = new HashSet<CampRequirement>();
            this.Discussions = new HashSet<Discussion>();
        }
    
        public int CampsID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public Nullable<int> DistrictID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampInCharge> CampInCharges { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampRequirement> CampRequirements { get; set; }
        public virtual District District { get; set; }
        public virtual Place Place { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
