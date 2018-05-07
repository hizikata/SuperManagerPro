using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Sale : ModelBase
    {
        public Sale()
        {
            TableName = "dtSale";
        }

        public Sale(int id, string merchandiseID, string employeeID, decimal price, int quantity, DateTime record)
        {
            ID = id;
            MerchandiseID = merchandiseID;
            EmployeeID = employeeID;
            Price = price;
            Quantity = quantity;
            Record = record;
            TableName = "dtSale";
        }

        public int ID { get; set; }
        public string MerchandiseID { get; set; }
        public string EmployeeID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Record { get; set; }
    }
}
