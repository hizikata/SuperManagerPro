using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class SqlHepler
    {
        #region ConnectionString

        readonly static string _connectionString = "Server=127.0.0.1;Database=dbSuperManager; User ID=sa;Pwd=sa2017;";

        #endregion

        #region Insert()

        public static string InsertSQL(ModelBase model)
        {
            string sql = "insert into " + model.TableName;
            if (model is Associator)
            {
                sql += "(ID,EmployeeID,Name,Gender,Address,Phone,Alternate,Integral,Birthday,Registration,Email,Remark) values(";
                sql += "'" + ((Associator)model).ID + "',";
                sql += "'" + ((Associator)model).EmployeeID + "',";
                sql += "'" + ((Associator)model).Name + "',";
                sql += "'" + ((Associator)model).Gender + "',";
                sql += "'" + ((Associator)model).Address + "',";
                sql += "'" + ((Associator)model).Phone + "',";
                sql += "'" + ((Associator)model).Alternate + "',";
                sql += "'" + ((Associator)model).Integral + "',";
                sql += "'" + ((Associator)model).Birthday + "',";
                sql += "'" + ((Associator)model).Registration + "',";
                sql += "'" + ((Associator)model).Email + "',";
                sql += "'" + ((Associator)model).Remark + "')";
            }
            else if (model is Employee)
            {
                sql += "(ID,Name,Phone,Alternate,Education,Address,Email,Remark) values(";
                sql += "'" + ((Employee)model).ID + "',";
                sql += "'" + ((Employee)model).Name + "',";
                sql += "'" + ((Employee)model).Phone + "',";
                sql += "'" + ((Employee)model).Alternate + "',";
                sql += "'" + ((Employee)model).Education + "',";
                sql += "'" + ((Employee)model).Address + "',";
                sql += "'" + ((Employee)model).Email + "',";
                sql += "'" + ((Employee)model).Remark + "')";
            }
            else if (model is User)
            {
                sql += "(EmployeeID,Password,IsAdmin) values(";
                sql += "'" + ((User)model).EmployeeID + "',";
                sql += "'" + ((User)model).Password + "',";
                sql += "'" + ((User)model).IsAdmin + "')";
            }
            else if (model is Supplier)
            {
                sql += "(ID,Name,Phone,Alternate,LinkMan,Address,Remark) values(";
                sql += "'" + ((Supplier)model).ID + "',";
                sql += "'" + ((Supplier)model).Name + "',";
                sql += "'" + ((Supplier)model).Phone + "',";
                sql += "'" + ((Supplier)model).Alternate + "',";
                sql += "'" + ((Supplier)model).LinkMan + "',";
                sql += "'" + ((Supplier)model).Address + "',";
                sql += "'" + ((Supplier)model).Remark + "')";
            }
            else if (model is Merchandise)
            {
                sql += "(ID,Name,Type,Picture,Remark) values(";
                sql += "'" + ((Merchandise)model).ID + "',";
                sql += "'" + ((Merchandise)model).Name + "',";
                sql += "'" + ((Merchandise)model).Type + "',";
                sql += "'" + ((Merchandise)model).Picture + "',";
                sql += "'" + ((Merchandise)model).Remark + "')";
            }
            else if (model is Inventory)
            {
                sql += "(MerchandiseID,SupplierID,Price,Quantity,Purchased,Storage,Remark) values(";
                sql += "'" + ((Inventory)model).MerchandiseID + "',";
                sql += "'" + ((Inventory)model).SupplierID + "',";
                sql += "'" + ((Inventory)model).Price + "',";
                sql += "'" + ((Inventory)model).Quantity + "',";
                sql += "'" + ((Inventory)model).Purchased + "',";
                sql += "'" + ((Inventory)model).Storage + "',";
                sql += "'" + ((Inventory)model).Remark + "')";
            }
            else if (model is Sale)
            {
                sql += "(MerchandiseID,EmployeeID,Price,Quantity,Record) values(";
                sql += "'" + ((Sale)model).MerchandiseID + "',";
                sql += "'" + ((Sale)model).EmployeeID + "',";
                sql += "'" + ((Sale)model).Price + "',";
                sql += "'" + ((Sale)model).Quantity + "',";
                sql += "'" + ((Sale)model).Record + "')";
            }
            else if (model is Rejected)
            {
                sql += "(MerchandiseID,AssociatorID,Price,Quantity,Record) values(";
                sql += "'" + ((Rejected)model).MerchandiseID + "',";
                sql += "'" + ((Rejected)model).AssociatorID + "',";
                sql += "'" + ((Rejected)model).Price + "',";
                sql += "'" + ((Rejected)model).Quantity + "',";
                sql += "'" + ((Rejected)model).Record + "')";
            }
            return sql;
        }

        #endregion

        #region Update()

        public static string UpdateSQL(ModelBase model)
        {
            string sql = "update " + model.TableName + " set ";
            if (model is Associator)
            {
                sql += "EmployeeID='" + ((Associator)model).EmployeeID + "',Name=";
                sql += "'" + ((Associator)model).Name + "',Gender=";
                sql += "'" + ((Associator)model).Gender + "',Address=";
                sql += "'" + ((Associator)model).Address + "',Phone=";
                sql += "'" + ((Associator)model).Phone + "',Alternate=";
                sql += "'" + ((Associator)model).Alternate + "',Integral=";
                sql += "'" + ((Associator)model).Integral + "',Birthday=";
                sql += "'" + ((Associator)model).Birthday + "',Registration=";
                sql += "'" + ((Associator)model).Registration + "',Email=";
                sql += "'" + ((Associator)model).Email + "',Remark=";
                sql += "'" + ((Associator)model).Remark + "'";
            }
            else if (model is Employee)
            {
                sql += "Name='" + ((Employee)model).Name + "',Phone=";
                sql += "'" + ((Employee)model).Phone + "',Alternate=";
                sql += "'" + ((Employee)model).Alternate + "',Education=";
                sql += "'" + ((Employee)model).Education + "',Address=";
                sql += "'" + ((Employee)model).Address + "',Email=";
                sql += "'" + ((Employee)model).Email + "',Remark=";
                sql += "'" + ((Employee)model).Remark + "'";
            }
            else if (model is Supplier)
            {
                sql += "Name='" + ((Supplier)model).Name + "',Phone=";
                sql += "'" + ((Supplier)model).Phone + "',Alternate=";
                sql += "'" + ((Supplier)model).Alternate + "',LinkMan=";
                sql += "'" + ((Supplier)model).LinkMan + "',Address=";
                sql += "'" + ((Supplier)model).Address + "',Remark=";
                sql += "'" + ((Supplier)model).Remark + "'";
            }
            else if (model is Merchandise)
            {
                sql += "Name='" + ((Merchandise)model).Name + "',Type=";
                sql += "'" + ((Merchandise)model).Type + "',Picture=";
                sql += "'" + ((Merchandise)model).Picture + "',Remark=";
                sql += "'" + ((Merchandise)model).Remark + "'";
            }
            else if (model is Sale)
            {
                sql += "MerchandiseID='" + ((Sale)model).MerchandiseID + "',EmployeeID=";
                sql += "'" + ((Sale)model).EmployeeID + "',Price=";
                sql += "'" + ((Sale)model).Price + "',Quantity=";
                sql += "'" + ((Sale)model).Quantity + "',Record=";
                sql += "'" + ((Sale)model).Record + "'";
            }
            else if (model is Rejected)
            {
                sql += "MerchandiseID='" + ((Rejected)model).MerchandiseID + "',AssociatorID=";
                sql += "'" + ((Rejected)model).AssociatorID + "',Price=";
                sql += "'" + ((Rejected)model).Price + "',Quantity=";
                sql += "'" + ((Rejected)model).Quantity + "',Record=";
                sql += "'" + ((Rejected)model).Record + "'";
            }
            else if (model is User)
            {
                sql += "IsAdmin='" + ((User)model).IsAdmin + "'";
            }
            sql += GetWhere(model);
            return sql;
        }

        public static string UpdateSQL(string tableName, string fieldName, string newValue, string whereName, string whereValue)
        {
            return "update " + tableName + " set " + fieldName + "='" + newValue + "' where " + whereName + "='" + whereValue + "'";
        }

        #endregion

        #region Delete()

        public static string DeleteSQL(ModelBase model)
        {
            return "delete from " + model.TableName + GetWhere(model);
        }

        #endregion

        #region GetWhere()

        static string GetWhere(ModelBase model)
        {
            string sql = " where ID=";
            if (model is Associator)
                sql += "'" + ((Associator)model).ID + "'";
            else if (model is Employee)
                sql += "'" + ((Employee)model).ID + "'";
            else if (model is Supplier)
                sql += "'" + ((Supplier)model).ID + "'";
            else if (model is Merchandise)
                sql += "'" + ((Merchandise)model).ID + "'";
            else if (model is Sale)
                sql += "'" + ((Sale)model).ID + "'";
            else if (model is Rejected)
                sql += "'" + ((Rejected)model).ID + "'";
            else if (model is User)
                sql += "'" + ((User)model).ID + "'";
            return sql;
        }

        #endregion

        #region GetDateTable()

        public static DataTable GetDataTable(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("select * from " + tableName, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                try
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dataAdapter.Fill(dt);
                    return dt;
                }
                catch (SqlException se)
                {
                    throw se;
                }
        }

        public static DataTable GetDataTable(ModelBase model, string fieldName, string fieldValue)
        {
            string sql = "select * from " + model.TableName;
            sql += " where " + fieldName + "='" + fieldValue + "'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                try
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dataAdapter.Fill(dt);
                    return dt;
                }
                catch (SqlException se)
                {
                    throw se;
                }
        }

        public static DataTable GetDataTable1(ModelBase model, string fieldName, string fieldValue)
        {
            string sql = "select * from " + model.TableName;
            sql += " where " + fieldName + " like '%" + fieldValue + "%'";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                try
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dataAdapter.Fill(dt);
                    return dt;
                }
                catch (SqlException se)
                {
                    throw se;
                }
        }

        #endregion

        #region GetServerTime()

        public static DateTime GetServerTime()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("select GetDate()", connection))
                try
                {
                    connection.Open();
                    return (DateTime)command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
        }

        #endregion

        #region Execute()

        public static int Execute(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
        }

        #endregion
    }
}
