﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class masterEntities : DbContext
    {
        public masterEntities()
            : base("name=masterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountsPayable> AccountsPayable { get; set; }
        public virtual DbSet<ActiveInventory> ActiveInventory { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryAdjustements> InventoryAdjustements { get; set; }
        public virtual DbSet<InventorySKU> InventorySKU { get; set; }
        public virtual DbSet<KindOfInventory> KindOfInventory { get; set; }
        public virtual DbSet<MixCreation> MixCreation { get; set; }
        public virtual DbSet<MixCreationDetails> MixCreationDetails { get; set; }
        public virtual DbSet<PO> PO { get; set; }
        public virtual DbSet<PODet> PODet { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
    }
}
