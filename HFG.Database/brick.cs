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
    
    public partial class brick
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brick()
        {
            this.conns = new HashSet<conn>();
        }
    
        public int brick_id { get; set; }
        public string brick_type { get; set; }
        public Nullable<int> brick_x { get; set; }
        public Nullable<int> brick_y { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conn> conns { get; set; }
    }
}
