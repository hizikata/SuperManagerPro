using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Inventory : ModelBase
    {
        public Inventory()
        {
            base.TableName = "dtInventory";
        }

        public Inventory(int id, string merchandiseID, string supplierID, decimal price, int quantity, DateTime purchased, string storage, string remark)
        {
            ID = id;
            MerchandiseID = merchandiseID;
            SupplierID = supplierID;
            Price = price;
            Quantity = quantity;
            Purchased = purchased;
            Storage = storage;
            Remark = remark;
            base.TableName = "dtInventory";
        }

        public int ID { get; set; }
        public string MerchandiseID { get; set; }
        public string SupplierID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Purchased { get; set; }
        public string Storage { get; set; }
        public string Remark { get; set; }
    }
}
