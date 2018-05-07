using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Merchandise : ModelBase
    {
        public Merchandise()
        {
            base.TableName = "dtMerchandise";
        }

        public Merchandise(string id, string name, string type, string picture, string remark)
        {
            ID = id;
            Name = name;
            Type = type;
            Picture = picture;
            Remark = remark;
            base.TableName = "dtMerchandise";
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Picture { get; set; }
        public string Remark { get; set; }
    }
}
