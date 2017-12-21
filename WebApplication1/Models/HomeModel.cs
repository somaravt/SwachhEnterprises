using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HomeModel
    {
        public List<StationaryItems> stationaryItems { get; set; }//{ return new List<StationaryItems>(); } }//= new List<StationaryItems>();

        public List<HouseKeepingItems> houseKeepingItems { get; set; }// { return new List<HouseKeepingItems>(); } } //= new List<HouseKeepingItems>();

        public int[] StationaryCount { get; set; }

        public int[] HouseKeepingCount { get; set; }
        public HomeModel()
        {
            ////this.stationaryItems = new List<StationaryItems>();
            //this.houseKeepingItems = new List<HouseKeepingItems>();
        }
    }
}