using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Employee : ModelBase
    {
        public Employee()
        {
            base.TableName = "dtEmployee";
        }

        public Employee(string id, string name, string phone, string alternate,
            string education, string address, string email, string remark)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Alternate = alternate;
            Education = education;
            Address = address;
            Email = email;
            Remark = remark;
            base.TableName = "dtEmployee";
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Alternate { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
    }
}
