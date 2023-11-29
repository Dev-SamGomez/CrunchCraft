using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CrunchCraft.Models.ViewModels
{
	public class ActiveInventoryViewModel
	{
		[Required]
		public int fk_IdPO { get; set; }
		[Required]
		public string ProductName { get; set; }
		[Required]
		public decimal Qty { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Unit { get; set; }
	}
}