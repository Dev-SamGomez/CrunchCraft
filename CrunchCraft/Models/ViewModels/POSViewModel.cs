using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrunchCraft.Models.ViewModels
{
    public class POSViewModel
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public string Inventario { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string FechaCreacion { get; set; }
        public decimal Total { get; set; }
    }

}