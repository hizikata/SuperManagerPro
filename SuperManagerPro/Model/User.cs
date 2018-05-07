using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class User : ModelBase
    {
        public User()
        {
            base.TableName = "dtUser";
        }

        public User(int id, string employeeID, string password, string isAdmin)
        {
            ID = id;
            EmployeeID = employeeID;
            Password = password;
            IsAdmin = isAdmin;
            base.TableName = "dtUser";
        }

        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public string Password { get; set; }
        public string IsAdmin { get; set; }
    }
}
