using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrunchCraft.Models.ViewModels
{
	public class POViewModel
	{
		[Required]
		public int fk_IdVendor { get; set; }
		[Required]
		public int fk_IdKindOfInventory { get; set; }
		[Required]
		public bool Status { get; set; }
	}
}