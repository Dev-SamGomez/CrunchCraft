using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CrunchCraft.Models.ViewModels
{
	public class InventoryViewModel
	{
		[Required]
		public string Product { get; set; }
		[Required]
		public decimal Qty { get; set; }
		[Required]
		public decimal PublicPrice { get; set; }
	}
}