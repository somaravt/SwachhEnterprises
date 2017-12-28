using WebApplication1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Items
    {
        public ActionResult Index()
        {
            ViewBag.StationaryItems = stationaryItems;
            ViewBag.HouseKeepingItems = houseKeepingItems;
            HomeModel homeModel = new HomeModel();
            return View(homeModel);
        }

        [HttpPost]
        public ActionResult Index(HomeModel homeModel)
        {
            TempData["HomeModel"] = homeModel;
            return RedirectToAction("Cart","Home");
        }

        public ActionResult Cart()
        {
            HomeModel model = (HomeModel)TempData["HomeModel"];
            List<StationaryItems> OrderedStationaryItems = new List<StationaryItems>();
            List<HouseKeepingItems> OrderedHouseKeepingItems = new List<HouseKeepingItems>();
            for (int Sc = 0; Sc < model.StationaryCount.Length; Sc++)
            {
                stationaryItems[Sc]._count = model.StationaryCount[Sc];
                stationaryItems[Sc].QuantitesCost = stationaryItems[Sc]._count * stationaryItems[Sc]._amount;
                if (stationaryItems[Sc]._count != 0)
                    OrderedStationaryItems.Add(stationaryItems[Sc]);
            }
            for (int Hc = 0; Hc < model.HouseKeepingCount.Length; Hc++)
            {
                houseKeepingItems[Hc]._count = model.HouseKeepingCount[Hc];
                houseKeepingItems[Hc].QuantitesCost = houseKeepingItems[Hc]._count * houseKeepingItems[Hc]._amount;
                if (houseKeepingItems[Hc]._count != 0)
                    OrderedHouseKeepingItems.Add(houseKeepingItems[Hc]);
            }
            ViewBag.StationaryItems = OrderedStationaryItems;
            ViewBag.HouseKeepingItems = OrderedHouseKeepingItems;
            ViewBag.StationaryItemsCost = CalculateOrderedItemsCost(OrderedStationaryItems);
            ViewBag.HouseKeepingItemsCost = CalculateOrderedItemsCost(OrderedHouseKeepingItems);
            ViewBag.TotalCost = ViewBag.StationaryItemsCost + ViewBag.HouseKeepingItemsCost;
            TempData["StationaryItems"] = OrderedStationaryItems;
            TempData["HouseKeepingItems"] = OrderedHouseKeepingItems;
            TempData["TotalCost"] = ViewBag.TotalCost;
            return View();
        }
        
        public ActionResult Order()
        {
            OrderedItems Oi = new OrderedItems((List<StationaryItems>)TempData["StationaryItems"],(List<HouseKeepingItems>)TempData["HouseKeepingItems"],(int)TempData["TotalCost"]);
            Oi.GenerateInvoice(Oi);
            Oi.SendInvoice("Example.pdf");
            return RedirectToAction("Index");
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