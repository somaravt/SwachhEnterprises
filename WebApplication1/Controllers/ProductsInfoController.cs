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
            int value = Product.Add(Product);
            //Product.CreateImage(Product);
            if (value == 1)
            {
                TempData["Message"] = "Product Added Successfully";
                return RedirectToAction("AddProducts");
            }
            else if (value == 0)
            {
                TempData["Message"] = "Error while Inserting the Product";
                return View();
            }
            else
            {
                TempData["Message"] = "Error while Adding Product Image";
                return View();
            }
        }
    }
}