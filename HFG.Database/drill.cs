//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HFG.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class drill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public drill()
        {
            this.conns = new HashSet<conn>();
        }
    
        public int drill_id { get; set; }
        public Nullable<int> drill_speed { get; set; }
        public Nullable<int> drill_storage { get; set; }
        public Nullable<int> drill_fuel { get; set; }
        public Nullable<int> drill_score { get; set; }
        public Nullable<int> drill_y { get; set; }
        public Nullable<int> drill_x { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conn> conns { get; set; }
    }
}
