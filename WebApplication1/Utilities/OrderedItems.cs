using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication1.Models;

namespace SwachhEnterprises.Utilities
{
    public class OrderedItems
    {
        public List<StationaryItems> OrderdStationaryItems;

        public List<HouseKeepingItems> OrderedHouseKeepingItems;

        public int TotalCost;

        public int count = 0;
        public OrderedItems(List<StationaryItems> OrderdStationaryItems, List<HouseKeepingItems> OrderedHouseKeepingItems,int TotalCost)
        {
            this.OrderdStationaryItems = OrderdStationaryItems;
            this.OrderedHouseKeepingItems = OrderedHouseKeepingItems;
            this.TotalCost = TotalCost;
            count = 0;
        }

        //Generate Invoice
        public bool GenerateInvoice(OrderedItems items)
        {
            Document OrderInvoice = new Document(PageSize.A4,25,10,25,10);
            MemoryStream stream = new System.IO.MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(OrderInvoice,stream);
            PdfPTable table = new PdfPTable(5);
            PdfPCell SI = new PdfPCell(new Phrase("Stationary Items"));
            SI.Colspan = 5;
            SI.HorizontalAlignment = Element.ALIGN_CENTER;
            table = GetColumnHeadings(table);
            table.AddCell(SI);
            table = AddItems(table,items.OrderdStationaryItems);
            PdfPTable staionaryItems = new PdfPTable(5);
            PdfPCell HKI = new PdfPCell(new Phrase("HouseKeeping Items"));
            HKI.Colspan = 5;
            HKI.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(HKI);
            table = AddItems(table, items.OrderedHouseKeepingItems);
            PdfPCell TC = new PdfPCell(new Phrase { "" });
            TC.Colspan = 3;
            table.AddCell(TC);
            table.AddCell("Total Cost of Items");
            table.AddCell(items.TotalCost.ToString());
            OrderInvoice.Open();
            OrderInvoice.Add(table);
            OrderInvoice.Close();
            CreateAPDFFile(stream.ToArray());
            return true;
        }

        //Adding Table Column Headings
        public PdfPTable GetColumnHeadings(PdfPTable ItemsList)
        {
            ItemsList.AddCell("Sl. no.");
            ItemsList.AddCell("Item Name");
            ItemsList.AddCell("Amount");
            ItemsList.AddCell("Quantity");
            ItemsList.AddCell("Total Cost");
            return ItemsList;
        }

        //Adding Stationary Items to invoice
        public PdfPTable AddItems(PdfPTable ItemsList,List<StationaryItems> items)
        {
            foreach (StationaryItems item in items)
            {
                ++count;
                ItemsList.AddCell(count.ToString());
                ItemsList.AddCell(item._itemName);
                ItemsList.AddCell(item._amount.ToString());
                ItemsList.AddCell(item._count.ToString());
                ItemsList.AddCell(item.QuantitesCost.ToString());
            }
            return ItemsList;
        }

        //Adding HouseKeeping Items to Invoice
        public PdfPTable AddItems(PdfPTable ItemsList, List<HouseKeepingItems> items)
        {
            foreach (HouseKeepingItems item in items)
            {
                ++count;
                ItemsList.AddCell(count.ToString());
                ItemsList.AddCell(item._itemName);
                ItemsList.AddCell(item._amount.ToString());
                ItemsList.AddCell(item._count.ToString());
                ItemsList.AddCell(item.QuantitesCost.ToString());
            }
            return ItemsList;
        }

        //Creating PDF file
        public void CreateAPDFFile(byte[] content)
        {
            using (FileStream fs = File.Create("C:\\Temp\\Example.pdf"))
            {
                fs.Write(content,0,(int)content.Length);
            }
        }


        //Send Invoice
        public void SendInvoice(string InvoiceName)
        {
            MailMessage mail = new MailMessage();
            //Attachment attach = new Attachment();
            mail.To.Add("swachhenterprises17@gmail.com");
            mail.From = new MailAddress("somaravi.teja95@gmail.com");
            mail.Subject = "Order from Raviteja";
            String Body = "Hi,\n\t This is Raviteja Soma. I have ordered some of the products from your website and request to deliver them as early as possible.";
            mail.Body = Body;
            mail.Attachments.Add(new Attachment("C:\\Temp\\"+InvoiceName));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("somaravi.teja95@gmail.com","R@viteja3");
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
    }
}