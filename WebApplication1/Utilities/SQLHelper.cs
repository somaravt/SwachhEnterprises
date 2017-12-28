using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class SQLHelper
    {
        public static string ConnectionString = "Server=localhost;Database=swachhenterprises;Uid=root;Pwd=12345";

        public static string ProductInsertCommand = "Insert into product(ProductId,Name,Category,Quantity,Price,StockAvailable,Description) values(@ProductId,@Name,@Category,@Quantity,@Price,@Stock,@Description)";

        public static string ProductImageInsertCommand = "Insert into productimages(ProductId,productImage,ImageFormat,ProductName) values(@ProductId,@ProductImage,@ImageFormat,@ProductName)";
        
        //Inserting into Database
        public static int Insert(string query,ProductInfo Product)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@ProductId", Product.ProductId);
                        cmd.Parameters.AddWithValue("@Name", Product.ProductName);
                        cmd.Parameters.AddWithValue("@Category", Product.ProductCategory);
                        cmd.Parameters.AddWithValue("@Quantity", Product.Quantity);
                        cmd.Parameters.AddWithValue("@Price", Product.Price);
                        cmd.Parameters.AddWithValue("@Stock", Product.Stock);
                        cmd.Parameters.AddWithValue("@Description", Product.Description);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Add Image
        public static int AddImage(string query,ProductInfo Product)
        {
            try
            {
                byte[] imageBytes;
                using (BinaryReader br = new BinaryReader(Product.ProductImage.InputStream))
                {
                    imageBytes = br.ReadBytes(Product.ProductImage.ContentLength);
                }
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@ProductId", Product.ProductId);
                        cmd.Parameters.AddWithValue("@ProductImage", imageBytes);
                        cmd.Parameters.AddWithValue("@ImageFormat", "jpg");
                        cmd.Parameters.AddWithValue("@ProductName", Product.ProductName);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception)
            {
                return -1;
            }
        }
    }
}