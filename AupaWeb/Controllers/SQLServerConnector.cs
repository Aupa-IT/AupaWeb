using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AupaWeb.Controllers
{
    public class SQLServerConnector
    {
        private SqlConnection sqlConnection;
        private string actionResult;

        public SQLServerConnector()
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

        public String InsertPostData(PostDataObject postDataObjec)
        {
            String sqlString = "INSERT INTO aaa_file ( " +
                                    " aaa01, aaa02, aaa03, aaa04, aaa05, " +
                                    " aaa06, aaa07, aaa08 " +
                                    ") VALUES ( " +
                                    " @val01, @val02, @val03, @val04, @val05, @val06, " +
                                    " @val07, @val08                                  " +
                                    ")";
            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                sqlCommand.Parameters.AddWithValue("@val01", postDataObjec.Aaa01);
                sqlCommand.Parameters.AddWithValue("@val02", postDataObjec.Aaa02);
                sqlCommand.Parameters.AddWithValue("@val03", postDataObjec.Aaa03);
                sqlCommand.Parameters.AddWithValue("@val04", postDataObjec.Aaa04);
                sqlCommand.Parameters.AddWithValue("@val05", postDataObjec.Aaa05);
                sqlCommand.Parameters.AddWithValue("@val06", postDataObjec.Aaa06);
                sqlCommand.Parameters.AddWithValue("@val07", postDataObjec.Aaa07);
                sqlCommand.Parameters.AddWithValue("@val08", postDataObjec.Aaa08);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
            return actionResult;
        }//End of Insert Into

        public List<PostDataObject> getPostsList()
        {
            String sqlString = "SELECT * FROM aaa_file" +
                               " ORDER BY aaa01 DESC" +
                               "";
            List<PostDataObject> postsList = new List<PostDataObject>();

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
                        PostDataObject postDataObject = new PostDataObject();

                        postDataObject.Aaa01 = dataReader.GetString(dataReader.GetOrdinal("Aaa01"));
                        postDataObject.Aaa02 = dataReader.GetString(dataReader.GetOrdinal("Aaa02"));
                        postDataObject.Aaa03 = dataReader.GetString(dataReader.GetOrdinal("Aaa03"));
                        postDataObject.Aaa04 = dataReader.GetString(dataReader.GetOrdinal("Aaa04"));
                        postDataObject.Aaa05 = dataReader.GetString(dataReader.GetOrdinal("Aaa05"));
                        postDataObject.Aaa06 = dataReader.GetString(dataReader.GetOrdinal("Aaa06"));
                        postDataObject.Aaa07 = dataReader.GetString(dataReader.GetOrdinal("Aaa07"));
                        postDataObject.Aaa08 = dataReader.GetString(dataReader.GetOrdinal("Aaa08"));

                        postsList.Add(postDataObject);
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

            return postsList;
        }//End of getPostsList

        public List<PostDataObject> getTopPostsList(int num)
        {
            String sqlString = "SELECT TOP "+num+
                               "       aaa01, aaa02, aaa03, aaa04, aaa05, "+
                               "       aaa06, aaa07, aaa08 "+
                               " FROM aaa_file "+
                               " ORDER BY aaa01 DESC"+
                               "";
            List<PostDataObject> postsList = new List<PostDataObject>();

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
                        PostDataObject postDataObject = new PostDataObject();

                        postDataObject.Aaa01 = dataReader.GetString(dataReader.GetOrdinal("Aaa01"));
                        postDataObject.Aaa02 = dataReader.GetString(dataReader.GetOrdinal("Aaa02"));
                        postDataObject.Aaa03 = dataReader.GetString(dataReader.GetOrdinal("Aaa03"));
                        postDataObject.Aaa04 = dataReader.GetString(dataReader.GetOrdinal("Aaa04"));
                        postDataObject.Aaa05 = dataReader.GetString(dataReader.GetOrdinal("Aaa05"));
                        postDataObject.Aaa06 = dataReader.GetString(dataReader.GetOrdinal("Aaa06"));
                        postDataObject.Aaa07 = dataReader.GetString(dataReader.GetOrdinal("Aaa07"));
                        postDataObject.Aaa08 = dataReader.GetString(dataReader.GetOrdinal("Aaa08"));

                        postsList.Add(postDataObject);
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

            return postsList;
        }//End of getPostsList

        public List<PostDataObject> getPostsListOnDemand(String sqlCriteria)
        {
            String sqlString = "SELECT * FROM aaa_file WHERE " + sqlCriteria;
            List<PostDataObject> postsList = new List<PostDataObject>();

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
                        PostDataObject postDataObject = new PostDataObject();

                        postDataObject.Aaa01 = dataReader.GetString(dataReader.GetOrdinal("Aaa01"));
                        postDataObject.Aaa02 = dataReader.GetString(dataReader.GetOrdinal("Aaa02"));
                        postDataObject.Aaa03 = dataReader.GetString(dataReader.GetOrdinal("Aaa03"));
                        postDataObject.Aaa04 = dataReader.GetString(dataReader.GetOrdinal("Aaa04"));
                        postDataObject.Aaa05 = dataReader.GetString(dataReader.GetOrdinal("Aaa05"));
                        postDataObject.Aaa06 = dataReader.GetString(dataReader.GetOrdinal("Aaa06"));
                        postDataObject.Aaa07 = dataReader.GetString(dataReader.GetOrdinal("Aaa07"));
                        postDataObject.Aaa08 = dataReader.GetString(dataReader.GetOrdinal("Aaa08"));

                        postsList.Add(postDataObject);
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }

            return postsList;
        }

        public String ConfirmedDelete(String postID)
        {
            String sqlString = "DELETE FROM aaa_file WHERE aaa01 = '" + postID + "'";
            int deletedRows;
            actionResult = "SUCCESS";
            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                deletedRows = sqlCommand.ExecuteNonQuery();
                if (deletedRows == 0)
                {
                    actionResult = "FAIL";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }

            return actionResult;
        }

        public String ConfirmedEdit(PostDataObject postDataObject)
        {
            String sqlString = "UPDATE aaa_file SET aaa05 = @val01," +
                               "                    aaa06 = @val02," +
                               "                    aaa07 = @val03 " +
                               "WHERE aaa01 = @val04 "+
                               "";
            actionResult = "SUCCESS";
            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@val01", postDataObject.Aaa05);
                sqlCommand.Parameters.AddWithValue("@val02", postDataObject.Aaa06);
                sqlCommand.Parameters.AddWithValue("@val03", postDataObject.Aaa07);
                sqlCommand.Parameters.AddWithValue("@val04", postDataObject.Aaa01);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                actionResult = "Fail" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }


            return actionResult;
        }
    }
}