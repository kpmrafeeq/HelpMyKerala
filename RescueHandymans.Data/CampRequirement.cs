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
    
    public partial class CampRequirement
    {
        public int CampRequirementID { get; set; }
        public Nullable<int> CampsID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> Need { get; set; }
        public Nullable<int> Recieved { get; set; }
    
        public virtual Camp Camp { get; set; }
        public virtual Item Item { get; set; }
    }
}
