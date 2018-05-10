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
            if (model is Inventory)
            {
                if (((Inventory)model).ID == 0)
                {
                    SqlHepler.Execute(SqlHepler.InsertSQL(model));
                    if (this.ModelAdded != null)
                        this.ModelAdded(this, new ModelAddedEventArgs(model));
                }
                else
                    SqlHepler.Execute(SqlHepler.UpdateSQL(model));
            }
            else if (model is Sale)
            {
                if (((Sale)model).ID == 0)
                {
                    SqlHepler.Execute(SqlHepler.InsertSQL(model));
                    if (this.ModelAdded != null)
                        this.ModelAdded(this, new ModelAddedEventArgs(model));
                }
                else
                {
                    SqlHepler.Execute(SqlHepler.UpdateSQL(model));
                    //更新商品库存
                }
            }
            else
            {
                if (AlreadyExisting(model))
                    SqlHepler.Execute(SqlHepler.UpdateSQL(model));
                else
                {
                    SqlHepler.Execute(SqlHepler.InsertSQL(model));
                    if (model is Employee)
                    {
                        User user = new User();
                        user.EmployeeID = ((Employee)model).ID;
                        user.Password = "1234";
                        user.IsAdmin = "0";
                        SqlHepler.Execute(SqlHepler.InsertSQL(user));
                    }
                    if (this.ModelAdded != null)
                        this.ModelAdded(this, new ModelAddedEventArgs(model));
                }
            }
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

        internal void Delete(object v)
        {
            throw new NotImplementedException();
        }

        internal List<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }

        internal object GetAssociator(string iD)
        {
            throw new NotImplementedException();
        }

        internal void Update(Associator model)
        {
            throw new NotImplementedException();
        }

        internal object GetSupplier(string iD)
        {
            throw new NotImplementedException();
        }

        internal object GetEmployee(string iD)
        {
            throw new NotImplementedException();
        }

        internal object GetMerchandise(string iD)
        {
            throw new NotImplementedException();
        }

        internal IList<Merchandise> GetMerchandise(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal object GetSale(int iD)
        {
            throw new NotImplementedException();
        }

        internal IList<Associator> GetAssociator()
        {
            throw new NotImplementedException();
        }

        internal object GetRejected(int iD)
        {
            throw new NotImplementedException();
        }
        public bool AlreadyExisting(ModelBase model)
        {
            if (model is Associator && this.GetAssociator(((Associator)model).ID) != null)
                return true;
            else if (model is Employee && this.GetEmployee(((Employee)model).ID) != null)
                return true;
            else if (model is Supplier && this.GetSupplier(((Supplier)model).ID) != null)
                return true;
            else if (model is Merchandise && this.GetMerchandise(((Merchandise)model).ID) != null)
                return true;
            else if (model is Rejected && this.GetRejected(((Rejected)model).ID) != null)
                return true;
            else
                return false;
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
