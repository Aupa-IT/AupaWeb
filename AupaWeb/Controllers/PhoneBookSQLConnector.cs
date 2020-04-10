using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AupaWeb.Controllers
{
    public class PhoneBookSQLConnector
    {
        private SqlConnection sqlConnection;
        private string actionResult;

        public PhoneBookSQLConnector()
        {
            Initializer();
        }

        private void Initializer()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "192.168.168.207\\SQLEXPRESS02";
            Builder.InitialCatalog = "aupaweb_base";
            Builder.UserID = "sa";
            Builder.Password = "#Aupa=234";
            String sqlConnectionString = Builder.ConnectionString;
            sqlConnection = new SqlConnection(sqlConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 53:
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.Write("MySqlException :" + ex.Message);
                return false;
            }
        }

        public List<SelectListItem> getOfficeItem()
        {
            string sqlString = "SELECT * " +
                               "  FROM zzb_file "+
                               " ORDER BY zzb01 ASC"+
                               "";
            List<SelectListItem> officeDataItems = new List<SelectListItem>();

            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        officeDataItems.Add(new SelectListItem 
                        { Text= dataReader["Zzb02"].ToString(),
                          Value= dataReader["Zzb01"].ToString() 
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                string v = "FAIL" + ex.Message;
                actionResult = v;
            }
            finally
            {
                CloseConnection();
            }

            return officeDataItems;
        }

        public List<UserBasicDataObject> GetUserBasicData()
        {
            String sqlString = //"SELECT TOP " + num +
                               "SELECT * " +
                               " FROM zza_file " +
                               " ORDER BY zza01 DESC" +
                               "";
            List<UserBasicDataObject> userBasicDataObjectList = new List<UserBasicDataObject>();

            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        UserBasicDataObject userBasicDataObject = new UserBasicDataObject();

                        userBasicDataObject.Zza01 = dataReader["Zza01"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        userBasicDataObject.Zza02 = dataReader["Zza02"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        userBasicDataObject.Zza03 = dataReader["Zza03"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        userBasicDataObject.Zza04 = dataReader["Zza04"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza04"));
                        userBasicDataObject.Zza05 = dataReader["Zza05"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza05"));
                        userBasicDataObject.Zza06 = dataReader["Zza06"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza06"));
                        userBasicDataObject.Zza07 = dataReader["Zza07"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza07"));
                        userBasicDataObject.Zza08 = dataReader["Zza08"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza08"));

                        userBasicDataObjectList.Add(userBasicDataObject);

                    }
                }
            }
            catch (Exception ex)
            {
                string v = "FAIL" + ex.Message;
                actionResult = v;
            }
            finally
            {
                CloseConnection();
            }

            return userBasicDataObjectList;
        }

        public List<UserBasicDataObject> GetUserBasicDataByCriteria(string criteria)
        {
            String sqlString = //"SELECT TOP " + num +
                               "SELECT * " +
                               "  FROM zza_file " +
                               " WHERE " + criteria +
                               " ORDER BY zza01 DESC" +
                               "";
            List<UserBasicDataObject> userBasicDataObjectList = new List<UserBasicDataObject>();

            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        UserBasicDataObject userBasicDataObject = new UserBasicDataObject();

                        userBasicDataObject.Zza01 = dataReader["Zza01"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        userBasicDataObject.Zza02 = dataReader["Zza02"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        userBasicDataObject.Zza03 = dataReader["Zza03"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        userBasicDataObject.Zza04 = dataReader["Zza04"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza04"));
                        userBasicDataObject.Zza05 = dataReader["Zza05"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza05"));
                        userBasicDataObject.Zza06 = dataReader["Zza06"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza06"));
                        userBasicDataObject.Zza07 = dataReader["Zza07"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza07"));
                        userBasicDataObject.Zza08 = dataReader["Zza08"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Zza08"));

                        userBasicDataObjectList.Add(userBasicDataObject);

                    }
                }
            }
            catch (Exception ex)
            {
                string v = "FAIL" + ex.Message;
                actionResult = v;
            }
            finally
            {
                CloseConnection();
            }

            return userBasicDataObjectList;
        }
    }
}