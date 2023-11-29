using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CrunchCraft.Models;
using CrunchCraft.Models.ViewModels;
namespace CrunchCraft.Controllers
{
    public class AccionController : Controller
    {
        // GET: Accion
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Inventory()
        {
            var productos = Test();
            ViewBag.productos = productos;
            return View();
        }
        public ActionResult Sales()
        {
            return View();
        }
        public ActionResult CreatorMix()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddItemsPO(List<PODetViewModel> modelItems)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }
            using (var db = new masterEntities())
            {
                string _Vendor = modelItems.Select(i => i.proveedor).Distinct().First().ToString();
                string _KOI = modelItems.Select(i => i.tipoInventario).Distinct().First().ToString();

                int _IdVendor = Convert.ToInt32(db.Vendors.Where(x => x.Name.Equals(_Vendor)).Select(v => v.Id).First().ToString());
                int _IdKOI = Convert.ToInt32(db.KindOfInventory.Where(x => x.Kind_Inventory.Equals(_KOI)).Select(v => v.Id).First().ToString());


                PO newPO = new PO();
                newPO.fk_IdVendor = _IdVendor;
                newPO.fk_IdKindOfInventory = _IdKOI;
                newPO.Status = true;

                db.PO.Add(newPO);
				db.SaveChanges();

				int _IdPO = Convert.ToInt32(db.PO.Select(v => v.Id).OrderByDescending(x => x).First().ToString());

                foreach (var item in modelItems)
				{
                    PODet newDet = new PODet()
                    {
                        fk_IdPO = _IdPO,
                        Product = item.producto,
                        Qty = item.cantidad,
                        Balance = item.cantidad,
                        Unit = item.unidadMedida,
                        Price = item.precio,
                        CreatedDate = DateTime.Now
                    };
                    db.PODet.Add(newDet);
					db.SaveChanges();
				}
            }
            return Redirect(Url.Content("~/Accion/POandReceipt/"));
        }
        public ActionResult AddItemsPO()
        {
            var dbContext = new masterEntities();
            var oVendors = dbContext.Vendors.Select(v => v.Name).ToList();
            var oProducts = dbContext.Inventory.Select(v => v.Product).ToList();
            var oActiveInventory = dbContext.ActiveInventory.Select(v => v.ProductName).ToList();
            ViewBag.Vendors = oVendors;
            ViewBag.Inventory = oProducts;
            ViewBag.ActiveInv = oActiveInventory;
            return View();
        }
        public ActionResult POandReceipt()
        {
            var context = new masterEntities();
            var result = from po in context.PO
                         join vendor in context.Vendors on po.fk_IdVendor equals vendor.Id
                         join kindOfInventory in context.KindOfInventory on po.fk_IdKindOfInventory equals kindOfInventory.Id
						 where po.Status == true
						 select new POSViewModel
                         {
                             Id = po.Id,
                             Proveedor = vendor.Name,
                             Inventario = kindOfInventory.Kind_Inventory,
                             Status = po.Status == true ? "Abierto" : "Cerrado",
                             Currency = vendor.Currency,
                             FechaCreacion = context.PODet.Where(det => det.fk_IdPO == po.Id).Min(det => det.CreatedDate).ToString(),
                             Total = (decimal)context.PODet.Where(det => det.fk_IdPO == po.Id).Sum(det => det.Price)
                         };
            ViewBag.POS = result.ToList();
            return View();
        }
        
        public ActionResult Vendors()
        {
            var vendors = VendorsList();
            ViewBag.vendors = vendors;
            return View();
        }
        public List<Inventory> Test()
		{
            var dbContext = new masterEntities();
            var productos = dbContext.Inventory.ToList();
            return productos;
        }
        public List<ActiveInventory> ActiveInventoryList()
        {
            var dbContext = new masterEntities();
            var activoFijo = dbContext.ActiveInventory.ToList();
            return activoFijo;
        }
        public List<Vendors> VendorsList()
        {
            var dbContext = new masterEntities();
            var oVendors = dbContext.Vendors.ToList();
            return oVendors;
        }
        [HttpPost]
        public ActionResult Inventory(InventoryViewModel model)
        {
			if (!ModelState.IsValid)
			{
                TempData["AlertMessage"] = $"Los campos Nombre de producto y Precio publico son requeridos.";
                return View(model);
			}
			using (var db = new masterEntities())
			{
                string NameProduct = model.Product;

                NameProduct = NameProduct.Trim();
                NameProduct = Regex.Replace(NameProduct, @"\s+", " ");

                var dbContext = new masterEntities();
                var productos = dbContext.Inventory.ToList();

                bool ResponseExist = false;

                foreach (var producto in productos)
                {
                    if (producto.Product.Equals(NameProduct))
                    {
                        ResponseExist = true;
                        break;
                    }
                }
                if (ResponseExist)
				{
                    TempData["AlertMessage"] = $"El producto {NameProduct} ya se encuentra registrado.";
                }
				else
				{
                    Inventory oInventory = new Inventory();
                    oInventory.Product = NameProduct;
                    oInventory.PublicPrice = model.PublicPrice;
                    db.Inventory.Add(oInventory);
                    db.SaveChanges();
                }
			}
            return Redirect(Url.Content("~/Accion/Inventory/"));
        }
        [HttpPost]
        public ActionResult Vendors(VendorsModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = $"Los campos Nombre y Tipo de Moneda son requeridos.";
                return View(model);
            }
            using (var db = new masterEntities())
            {
                string vName = model.Name;

                vName = vName.Trim();
                vName = Regex.Replace(vName, @"\s+", " ");

                var dbContext = new masterEntities();
                var productos = dbContext.Vendors.ToList();

                bool ResponseExist = false;

                foreach (var producto in productos)
                {
                    if (producto.Name.Equals(vName))
                    {
                        ResponseExist = true;
                        break;
                    }
                }
                if (ResponseExist)
                {
                    TempData["AlertMessage"] = $"El proveedor {vName} ya se encuentra registrado.";
                }
                else
                {
                    Vendors oNewVendor = new Vendors();
                    oNewVendor.Name = vName;
                    oNewVendor.Currency = model.Currency;
                    db.Vendors.Add(oNewVendor);
                    db.SaveChanges();
                }
            }
            return Redirect(Url.Content("~/Accion/Vendors/"));
        }        
    }
}