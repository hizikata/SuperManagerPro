using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Rejected : ModelBase
    {
        public Rejected()
        {
            TableName = "dtRejected";
        }

        public Rejected(int id, string merchandiseID, string associatorID, decimal price, int quantity, DateTime record) : this()
        {
            ID = id;
            MerchandiseID = merchandiseID;
            AssociatorID = associatorID;
            Price = price;
            Quantity = quantity;
            Record = record;
        }

        public int ID { get; set; }
        public string MerchandiseID { get; set; }
        public string AssociatorID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Record { get; set; }
    }
}
