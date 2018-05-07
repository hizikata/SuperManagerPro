using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Associator : ModelBase
    {
        public Associator()
        {
            base.TableName = "dtAssociator";
        }

        public Associator(string id, string employeeID, string name, string gender, string address, string phone,
            string alternate, int integral, DateTime birthday, DateTime registration, string email, string remark)
        {
            ID = id;
            EmployeeID = employeeID;
            Name = name;
            Gender = gender;
            Address = address;
            Phone = phone;
            Alternate = alternate;
            Integral = integral;
            Birthday = birthday;
            Registration = registration;
            Email = email;
            Remark = remark;
            base.TableName = "dtAssociator";
        }

        public string ID { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Alternate { get; set; }
        public int Integral { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Registration { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
    }
}
