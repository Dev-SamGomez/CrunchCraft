//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrunchCraft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PO()
        {
            this.ActiveInventory = new HashSet<ActiveInventory>();
            this.PODet = new HashSet<PODet>();
        }
    
        public int Id { get; set; }
        public Nullable<int> fk_IdVendor { get; set; }
        public Nullable<int> fk_IdKindOfInventory { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActiveInventory> ActiveInventory { get; set; }
        public virtual KindOfInventory KindOfInventory { get; set; }
        public virtual Vendors Vendors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PODet> PODet { get; set; }
    }
}
