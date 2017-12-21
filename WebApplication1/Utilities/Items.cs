using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class Items : Controller
    {
        public StationaryItems[] stationaryItems;

        public HouseKeepingItems[] houseKeepingItems;

        public Items()
        {
            stationaryItems = new StationaryItems[3];
            stationaryItems[0] = new StationaryItems("1", "SItem1", 100);
            stationaryItems[1] = new StationaryItems("2", "SItem2", 100);
            stationaryItems[2] = new StationaryItems("3", "SItem3", 100);

            houseKeepingItems = new HouseKeepingItems[3];
            houseKeepingItems[0] = new HouseKeepingItems("1", "HItem1", 100);
            houseKeepingItems[1] = new HouseKeepingItems("2", "HItem2", 100);
            houseKeepingItems[2] = new HouseKeepingItems("3", "HItem3", 100);
        }
    }
}