using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UBH.RWDTemplate.Models;

namespace UBH.RWDTemplate.DAL
{
    public class MenuItemDAL
    {
        private readonly string connString;

        public MenuItemDAL()
        {
            this.connString = WebConfigurationManager.ConnectionStrings["cnUBH_SQL"].ConnectionString;
        }

        public List<MenuItem> GetAll()
        {
            //setup collection to return
            List<MenuItem> itemList = new List<MenuItem>();

            //call the stored procedure
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();
                //call the stored procedure
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_Select"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;

                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    //loop through the menu items returned and build the collection to return
                    while (rdr.Read())
                    {
                        MenuItem newItem = new MenuItem();
                        newItem.Identity = Convert.ToInt32(rdr["miIdentity"]);
                        newItem.MenuName = rdr["miMenuName"].ToString();
                        newItem.Label = rdr["miLabel"].ToString();
                        newItem.ParentId = Convert.ToInt32(rdr["miParentId"]);
                        newItem.SortOrder = Convert.ToInt32(rdr["miSortOrder"]);
                        newItem.URL = rdr["miURL"].ToString();
                        newItem.Class = rdr["miClass"].ToString();
                        newItem.Target = rdr["miTarget"].ToString();
                        newItem.CreatedBy = rdr["CreatedBy"].ToString();
                        newItem.CreatedDate = (DateTime)rdr["CreatedDate"];
                        itemList.Add(newItem);
                    }

                    return itemList;
                }
            }
        }

        public MenuItem GetById(int menuItemId)
        {
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();

                //call the stored procedure
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_Select"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miIdentity", SqlDbType.Int).Value = menuItemId;

                    MenuItem theItem = new MenuItem();
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                theItem.Identity = Convert.ToInt32(dr["miIdentity"]);
                                theItem.MenuName = dr["miMenuName"].ToString();
                                theItem.Label = dr["miLabel"].ToString();
                                theItem.ParentId = Convert.ToInt32(dr["miParentId"]);
                                theItem.SortOrder = Convert.ToInt32(dr["miSortOrder"]);
                                theItem.URL = dr["miURL"].ToString();
                                theItem.Class = dr["miClass"].ToString();
                                theItem.Target = dr["miTarget"].ToString();
                                theItem.CreatedBy = dr["CreatedBy"].ToString();
                                theItem.CreatedDate = (DateTime)dr["CreatedDate"];
                            }
                        }
                        else
                        {
                            theItem.Identity = 0;
                        }

                        return theItem;
                    }
                }
            }
        }

        public List<MenuItem> GetByMenuNameParentId(string menuName, int parentId)
        {
            //setup collection to return
            List<MenuItem> itemList = new List<MenuItem>();

            //call the stored procedure
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();
                //call the stored procedure 
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_SelectByMenuNameParentId"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miMenuName", SqlDbType.VarChar).Value = menuName;
                    sqlCmd.Parameters.Add("@miParentId", SqlDbType.Int).Value = parentId;

                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    //loop through the menu items returned and build the collection to return
                    while (rdr.Read())
                    {
                        MenuItem newItem = new MenuItem();
                        newItem.Identity = Convert.ToInt32(rdr["miIdentity"]);
                        newItem.MenuName = rdr["miMenuName"].ToString();
                        newItem.Label = rdr["miLabel"].ToString();
                        newItem.ParentId = Convert.ToInt32(rdr["miParentId"]);
                        newItem.SortOrder = Convert.ToInt32(rdr["miSortOrder"]);
                        newItem.URL = rdr["miURL"].ToString();
                        newItem.Class = rdr["miClass"].ToString();
                        newItem.Target = rdr["miTarget"].ToString();
                        newItem.CreatedBy = rdr["CreatedBy"].ToString();
                        newItem.CreatedDate = (DateTime)rdr["CreatedDate"];
                        itemList.Add(newItem);
                    }

                    return itemList;
                }
            }

        }

        public List<MenuItem> GetByParentId(int parentId)
        {
            //setup collection to return
            List<MenuItem> itemList = new List<MenuItem>();

            //call the stored procedure
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();
                //call the stored procedure
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_SelectByParentId"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miParentId", SqlDbType.Int).Value = parentId;

                    SqlDataReader rdr = sqlCmd.ExecuteReader();

                    //loop through the menu items returned and build the collection to return
                    while (rdr.Read())
                    {
                        MenuItem newItem = new MenuItem();
                        newItem.Identity = Convert.ToInt32(rdr["miIdentity"]);
                        newItem.MenuName = rdr["miMenuName"].ToString();
                        newItem.Label = rdr["miLabel"].ToString();
                        newItem.ParentId = Convert.ToInt32(rdr["miParentId"]);
                        newItem.SortOrder = Convert.ToInt32(rdr["miSortOrder"]);
                        newItem.URL = rdr["miURL"].ToString();
                        newItem.Class = rdr["miClass"].ToString();
                        newItem.Target = rdr["miTarget"].ToString();
                        newItem.CreatedBy = rdr["CreatedBy"].ToString();
                        newItem.CreatedDate = (DateTime)rdr["CreatedDate"];
                        itemList.Add(newItem);
                    }

                    return itemList;
                }
            }
        }

        public int Insert(string menuName, string label, int parentId, int sortOrder, string url, string cssClass, string target)
        {
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();

                //call the stored procedure to insert the row 
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_Insert"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miMenuName", SqlDbType.VarChar).Value = menuName;
                    sqlCmd.Parameters.Add("@miLabel", SqlDbType.VarChar).Value = label;
                    sqlCmd.Parameters.Add("@miParentId", SqlDbType.Int).Value = parentId;
                    sqlCmd.Parameters.Add("@miSortOrder", SqlDbType.Int).Value = sortOrder;
                    sqlCmd.Parameters.Add("@miURL", SqlDbType.VarChar).Value = url;
                    sqlCmd.Parameters.Add("@miClass", SqlDbType.Int).Value = cssClass;
                    sqlCmd.Parameters.Add("@miTarget", SqlDbType.VarChar).Value = target;

                    int newId = (int)sqlCmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        public void Update(int menuItemId, string menuName, string label, int parentId, int sortOrder, string url, string cssClass, string target)
        {
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();

                //call the stored procedure to insert the row 
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_Update"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miIdentity", SqlDbType.Int).Value = menuItemId;
                    sqlCmd.Parameters.Add("@miMenuName", SqlDbType.VarChar).Value = menuName;
                    sqlCmd.Parameters.Add("@miLabel", SqlDbType.VarChar).Value = label;
                    sqlCmd.Parameters.Add("@miParentId", SqlDbType.Int).Value = parentId;
                    sqlCmd.Parameters.Add("@miSortOrder", SqlDbType.Int).Value = sortOrder;
                    sqlCmd.Parameters.Add("@miURL", SqlDbType.VarChar).Value = url;
                    sqlCmd.Parameters.Add("@miClass", SqlDbType.Int).Value = cssClass;
                    sqlCmd.Parameters.Add("@miTarget", SqlDbType.VarChar).Value = target;

                    sqlCmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int menuItemId)
        {
            //create connection
            using (SqlConnection conn = new SqlConnection(this.connString))
            {
                conn.Open();

                //call the stored procedure to delete the row 
                using (SqlCommand sqlCmd = new SqlCommand("dbo.ubh_sp_MenuItem_Delete"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 9999;
                    sqlCmd.Connection = conn;
                    sqlCmd.Parameters.Add("@miIdentity", SqlDbType.Int).Value = menuItemId;

                    sqlCmd.ExecuteNonQuery();

                }
            }
        }
    }
}