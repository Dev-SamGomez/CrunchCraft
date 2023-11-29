using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrunchCraft.Models.ViewModels
{
	public class PODetViewModel
	{
		//public int fk_IdPO { get; set; }
		
		[Required]
		public string producto { get; set; } //
		[Required]
		public string tipoInventario { get; set; }
		[Required]
		public string proveedor { get; set; }//
		[Required]
		public decimal cantidad { get; set; }//
		[Required]
		public string unidadMedida { get; set; }//
		[Required]
		public decimal precio { get; set; }//
		//[Required]
		public string CreatedDate { get; set; }


		//public string nombreArticulo { get; set; }
		//[Required]
	}
}