using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class StationaryItems
    {
        public string _id { get; set; }

        public string _itemName { get; set; }

        public int _amount { get; set; }

        public int _count { get; set; }

        public StationaryItems(string id,string itemName,int amount)
        {
            _id = id;
            _amount = amount;
            _itemName = itemName;
        }
        public StationaryItems()
        {

        }

    }
}