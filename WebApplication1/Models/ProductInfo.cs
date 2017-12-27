using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwachhEnterprises.Models
{
    public class ProductInfo
    {
        public string ProductName { get; set; }

        public Category ProductCategory { get; set; } 
    }

    public enum Category
    {
        StationaryItem,
        HouseKeepingItem
    }
}