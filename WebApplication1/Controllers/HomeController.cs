using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class HomeController : Items
    {
        public ActionResult Index()
        {
            TempData["stationayItems"] = new StationaryItems[3];
            TempData["houseKeepingItems"] = new HouseKeepingItems[3];

            

            ViewBag.StationaryItems = stationaryItems;

            ViewBag.HouseKeepingItems = houseKeepingItems;
            HomeModel homeModel = new HomeModel();
            homeModel.stationaryItems = new List<StationaryItems>();
            homeModel.houseKeepingItems = new List<HouseKeepingItems>();
            return View(homeModel);
        }

        [HttpPost]
        public ActionResult Index(HomeModel homeModel)
        {
            //stationaryItems = ViewBag.StationaryItems;
            //houseKeepingItems = ViewBag.HouseKeepingItems;
            //Console.WriteLine(stationaryItems);
            //Console.WriteLine(houseKeepingItems);
            //for(int Sc=0; Sc<homeModel.StationaryCount.Length;Sc++)
            //{
            //    stationaryItems[Sc]._count = homeModel.StationaryCount[Sc];
            //}
            //for (int Hc = 0; Hc < homeModel.HouseKeepingCount.Length; Hc++)
            //{
            //    stationaryItems[Hc]._count = homeModel.StationaryCount[Hc];
            //}
            TempData["HomeModel"] = homeModel;
            return RedirectToAction("Cart","Home");
        }

        public ActionResult Cart()
        {
            HomeModel model = (HomeModel)TempData["HomeModel"];
            for (int Sc = 0; Sc < model.StationaryCount.Length; Sc++)
            {
                stationaryItems[Sc]._count = model.StationaryCount[Sc];
            }
            for (int Hc = 0; Hc < model.HouseKeepingCount.Length; Hc++)
            {
                houseKeepingItems[Hc]._count = model.HouseKeepingCount[Hc];
            }
            ViewBag.StationaryItems = stationaryItems;
            ViewBag.HouseKeepingItems = houseKeepingItems;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}