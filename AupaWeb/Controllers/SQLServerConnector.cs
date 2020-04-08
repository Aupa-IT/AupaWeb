using AupaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public int GetTotalCount()
        {
            String sqlString = "SELECT * FROM aaa_file " +
                               "";
            OpenConnection();
            actionResult = "SUCCESS";
            int rowcount = 0;
            try
            {
                DataTable dataTable = new DataTable();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                rowcount = dataTable.Rows.Count;
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
            return rowcount;
        }

        public UserBasicObject GetUserBasicData(UserBasicObject user)
        {
            UserBasicObject userBasicObject = new UserBasicObject();

            String sqlString = "SELECT * FROM aba_file " +
                               " WHERE aba01 = '" + user.Aba01 + "'" +
                               "   AND aba03 = '" + user.Aba03 + "'" +
                               "";
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
                        userBasicObject.Aba01 = dataReader.GetString(dataReader.GetOrdinal("Aba01"));
                        userBasicObject.Aba02 = dataReader.GetString(dataReader.GetOrdinal("Aba02"));
                        userBasicObject.Aba03 = dataReader.GetString(dataReader.GetOrdinal("Aba03"));
                        userBasicObject.Aba04 = dataReader.GetString(dataReader.GetOrdinal("Aba04"));
                        userBasicObject.Aba05 = dataReader.GetString(dataReader.GetOrdinal("Aba05"));
                        userBasicObject.Aba06 = dataReader.GetString(dataReader.GetOrdinal("Aba06"));
                        userBasicObject.Aba07 = dataReader.GetString(dataReader.GetOrdinal("Aba07"));
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


            return userBasicObject;
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

        public List<PostDataObject> GetPostsList()
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

        public List<PostDataObject> GetTopPostsList(int num)
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
        }//End of getTOPPostsList

        public List<PostDataObject> GetLimitPostsList(String str, String end)
        {
            String sqlString = "SELECT * FROM aaa_file" +
                               " ORDER BY aaa01 DESC" +
                               " OFFSET " + str + " ROWS FETCH NEXT " + end + " ROWS ONLY " +
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
        }//End of getLimitPostsList

        public List<PostDataObject> GetPostsListOnDemand(String sqlCriteria)
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
                actionResult = "FAIL" + ex.Message;
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

        /***** Carousel ******/

        public List<CarouselDataObject> GetCarouselList()
        {
            String sqlString = //"SELECT TOP " + num +
                               "SELECT " + 
                               "       aaz01, aaz02, aaz03, aaz05  " +
                               " FROM aaz_file " +
                               " ORDER BY aaz01 DESC" +
                               "";
            List<CarouselDataObject> carouselsList = new List<CarouselDataObject>();

            OpenConnection();
            actionResult = "SUCCESS";
            int carousel_flag = 1;

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
                        CarouselDataObject carouselDataObject = new CarouselDataObject();

                        carouselDataObject.Aaz01 = dataReader.GetString(dataReader.GetOrdinal("Aaz01"));
                        carouselDataObject.Aaz02 = dataReader.GetString(dataReader.GetOrdinal("Aaz02"));
                        carouselDataObject.Aaz03 = dataReader["Aaz03"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Aaz03"));
                        carouselDataObject.Aaz05 = dataReader.GetString(dataReader.GetOrdinal("Aaz05"));

                        carouselsList.Add(carouselDataObject);
                        if (carousel_flag == 1)
                        {
                            carouselDataObject.Active = true;
                        }
                        else
                        {
                            carouselDataObject.Active = false;
                        }
                        carousel_flag++;
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

            return carouselsList;
        }//End of Carousel


        /***** Announcement ****/
        public String InsertAnnouncementData(AnnouncementDataObject announcementData )
        {
            String sqlString = "INSERT INTO aay_file ( " +
                                    " aay01, aay02, aay03, aay04 " +
                                    ") VALUES ( " +
                                    " @val01, @val02, @val03, @val04 " +
                                    ")";
            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                sqlCommand.Parameters.AddWithValue("@val01", announcementData.Aay01);
                sqlCommand.Parameters.AddWithValue("@val02", announcementData.Aay02);
                sqlCommand.Parameters.AddWithValue("@val03", announcementData.Aay03);
                sqlCommand.Parameters.AddWithValue("@val04", announcementData.Aay04);

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
        public List<AnnouncementDataObject> GetFirstAnnouncement()
        {
            String sqlString = //"SELECT TOP " + num +
                               "SELECT TOP 1 aay03  " +
                               "  FROM aay_file " +
                               " ORDER BY aay01 DESC" +
                               "";
            List<AnnouncementDataObject> announcementDataObjects = new List<AnnouncementDataObject>();

            OpenConnection();
            actionResult = "SUCCESS";
            int carousel_flag = 1;

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
                        AnnouncementDataObject announcementDataObject = new AnnouncementDataObject();

                        announcementDataObject.Aay03 = dataReader["Aay02"] == DBNull.Value ? "" :
                            dataReader.GetString(dataReader.GetOrdinal("Aay02"));

                        announcementDataObjects.Add(announcementDataObject);
                        carousel_flag++;
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

            return announcementDataObjects;
        }//End of Announcement

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

        public List<UserBasicDataObject> GetUserBasicDataByCriteria(string criteriaSql)
        {
            String sqlString = //"SELECT TOP " + num +
                               "SELECT * " +
                               "  FROM zza_file " +
                               " WHERE " + criteriaSql +
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