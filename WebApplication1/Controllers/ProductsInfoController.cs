using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsInfoController : Controller
    {
        // GET: ProductsInfo
        public ActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProducts(ProductInfo Product)
        {
            Product.Add(Product);
            Product.CreateImage(Product);
            TempData["Message"] = "Product Added Successfully";
            return RedirectToAction("AddProducts");
        }
    }
}