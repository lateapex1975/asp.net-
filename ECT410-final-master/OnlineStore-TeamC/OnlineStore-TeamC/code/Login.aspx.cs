using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace OnlineStore_TeamC.code
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {


      if (Session["LoggedInId"] == null)
      {
        panelLogin.Visible = true;
      }

      if (Request.QueryString["error"] != null)
      {
        lblResults.Text = "You are not authorized to view pages until you login.";   
      }
    }

    protected void DoLogin(object sender, EventArgs e)
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnString"].ConnectionString;
      try
      {
        conn.Open();
        OleDbCommand comm = conn.CreateCommand();
        comm.Connection = conn;
        comm.CommandText = "SELECT UserId,FirstName,LastName FROM Users WHERE Username = ? AND passwd=?";

        OleDbParameter param = comm.CreateParameter();
        param.DbType = DbType.String;
        param.Direction = ParameterDirection.Input;
        param.Value = txtUserName.Text;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.DbType = DbType.String;
        param.Direction = ParameterDirection.Input;
        param.Value = txtPassword.Text;
        comm.Parameters.Add(param);

        OleDbDataReader reader = comm.ExecuteReader();
        if (reader.HasRows)
        {
          reader.Read();
          Session["LoggedInId"] = reader["UserID"];
          Session["FirstName"] = reader["FirstName"];
          Session["LastName"] = reader["LastName"];
          lblResults.Text = "";
          panelLogin.Visible = false;
          Response.Redirect("Cart.aspx");
        }
        else
        {
          lblResults.Text = "User Name or Password are incorrect.";
        }
      }
      catch
      {
        errorMessage.Text = "Database error occured";
      }
      
      finally
      {
        if(conn != null) conn.Close();
      }
    }

    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }

  }
}