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
    
    public partial class InventorySKU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventorySKU()
        {
            this.MixCreationDetails = new HashSet<MixCreationDetails>();
            this.SalesOrder = new HashSet<SalesOrder>();
        }
    
        public int SKU { get; set; }
        public Nullable<int> fk_IdPODet { get; set; }
        public Nullable<int> fk_IdInventory { get; set; }
        public string Product { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual PODet PODet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MixCreationDetails> MixCreationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
