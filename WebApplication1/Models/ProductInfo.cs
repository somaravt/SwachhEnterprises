using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Utilities;

namespace WebApplication1.Models
{
    public class ProductInfo
    {
        [Required]
        public string ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public Category ProductCategory { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public HttpPostedFileBase ProductImage { get; set; }

        public ProductInfo()
        {

        }
        
        //Adding Product to Database
        public int Add(ProductInfo Product)
        {
            int data = SQLHelper.Insert(SQLHelper.ProductInsertCommand,Product);
            int image = SQLHelper.AddImage(SQLHelper.ProductImageInsertCommand, Product);
            if (data > 0 && image > 0)
                return 1;
            else if (data <= 0)
                return 0;
            else
                return -1;
        }


        //public void CreateImage(ProductInfo Product)
        //{
        //    byte[] bytes;
        //    using (BinaryReader br = new BinaryReader(Product.ProductImage.InputStream))
        //    {
        //        bytes = br.ReadBytes(Product.ProductImage.ContentLength);
        //    }
        //    //File.Create("C:\\Temp\temp.png");
        //    FileStream f = new FileStream("C:\\Temp\\temp.jpg",FileMode.CreateNew);
        //    f.Write(bytes, 0, bytes.Length);
        //}
    }

    public enum Category
    {
        Stationary,
        HouseKeeping
    }
}