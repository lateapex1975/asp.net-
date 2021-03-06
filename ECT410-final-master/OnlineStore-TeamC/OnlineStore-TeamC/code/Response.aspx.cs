﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace OnlineStore_TeamC
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = Request.QueryString["TransId"].ToString();

            //To be safe, you shoudl check the value from the DB.
            //String AppTransAmount = "12.50";
            String AppTransAmount = Session["PurchaseTotal"].ToString();

            String status = Request.QueryString["StatusCode"].ToString();
            String hash = Request.QueryString["AppHash"].ToString();

            if (CreditAuthorizationClient.VerifyServerResponseHash(hash, SharedKey, AppId, AppTransId, AppTransAmount, status))
            {
                switch (status)
                {
                    case ("A"): lblStatus.Text = "Transaction Approved!";
                        if (Session["LoggedInId"] == null)
                        {
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            /*
                            int sessionName = (int)Session["LoggedInId"];
                            //Open a Connection
                            OleDbConnection conn = new OleDbConnection();

                            //Assign a Connection String
                            conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;

                            //Connection Open
                            conn.Open();

                            //Initialize a Command
                            OleDbCommand comm = conn.CreateCommand();
                            //Tell the command which connection it will use
                            comm.Connection = conn;
                            //Give the command SQL to execute

                            //comm.CommandText = "Select StudentToCourse.CourseId, Courses.CourseName from Courses INNER JOIN StudentToCourse ON StudentToCourse.CourseID = Courses.ID WHERE StudentID=?";


                            comm.CommandText = "SELECT ProductName, Price, OrderDate from Orders WHERE UserID = ? AND IsCart = False";
                            OleDbParameter param;
                            param = comm.CreateParameter();
                            param.DbType = DbType.String;
                            param.Direction = ParameterDirection.Input;
                            param.Value = sessionName;
                            comm.Parameters.Add(param);

                            //Execute the command and get back the results via a reader
                            OleDbDataReader reader = comm.ExecuteReader();

                            //While we get results from the DB, add a row to the Table
                            while (reader.Read())
                            {
                                TableRow row = new TableRow();
                                TableCell cell;

                                cell = new TableCell();
                                cell.Text = reader["ProductName"].ToString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = reader["Price"].ToString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = reader["OrderDate"].ToString();
                                row.Cells.Add(cell);

                                OrderTransaction.Rows.Add(row);
                            }
                            //Free up the connection
                            conn.Close();
                            */
                        }
                        break;
                    case ("D"): lblStatus.Text = "Transaction Denied!"; break;
                    case ("C"):
                        lblStatus.Text = "Transaction Cancelled!"; break;
                        

                        
                }
            }
            else
            {
                lblStatus.Text = "Hash Verification failed... something went wrong.";
            }

        }

    }
}