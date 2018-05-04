using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Supplier:ModelBase
    {
        public Supplier()
        {
            TableName = "dtSupplier";
        }

        public Supplier(string id, string name, string phone, string alternate, string linkMan, string address, string remark):this()
        {
            ID = id;
            Name = name;
            Phone = phone;
            Alternate = alternate;
            LinkMan = linkMan;
            Address = address;
            Remark = remark;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Alternate { get; set; }
        public string LinkMan { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}
