using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Repository
    {
        #region Events
        public event EventHandler<ModelAddedEventArgs> ModelAdded;
        public event EventHandler<ModelDeletedEventArgs> ModelDeleted;
        #endregion
        #region Properties

        #endregion Properties
        #region PublicMethods
        public void Add(ModelBase model)
        {
            
            
        }
        #endregion
        #region Methods
        public List<Supplier> GetSupplier(string fieldName, string fieldValue)
        {
            List<Supplier> results = new List<Supplier>();
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(fieldName) && string.IsNullOrEmpty(fieldValue))
                dt = SqlHepler.GetDataTable(new Supplier().TableName);
            else if (fieldName == "Name")
                dt = SqlHepler.GetDataTable1(new Supplier(), fieldName, fieldValue);
            else
                dt = SqlHepler.GetDataTable(new Supplier(), fieldName, fieldValue);
            foreach (DataRow dr in dt.Rows)
                results.Add(
                    new Supplier(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString()
                        ));
            return results;
        }

        #endregion  
        #region PrivateMethods

        #endregion
    }
    public class ModelAddedEventArgs : EventArgs
    {
        public ModelAddedEventArgs(ModelBase model)
        {
            this.NewModel = model;
        }
        public ModelBase NewModel
        {
            get;
            private set;
        }
    }
    public class ModelDeletedEventArgs : EventArgs
    {
        public ModelDeletedEventArgs(ModelBase model)
        {
            this.NewModel = model;
        }
        public ModelBase NewModel
        {
            get;
            private set;
        }
    }
}
