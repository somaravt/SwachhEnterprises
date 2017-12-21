using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HouseKeepingItems
    {
        public string _id { get; set; }

        public string _itemName { get; set; }

        public int _amount { get; set; }

        public int _count { get; set; }

        public int QuantitesCost { get; set; }

        public HouseKeepingItems(string id,string itemName,int amount)
        {
            _id = id;
            _itemName = itemName;
            _amount = amount;
        }

        public HouseKeepingItems()
        {

        }
    }
}