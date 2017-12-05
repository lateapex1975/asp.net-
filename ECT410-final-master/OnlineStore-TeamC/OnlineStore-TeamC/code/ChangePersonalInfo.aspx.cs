using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace OnlineStore_TeamC.code
{
  public partial class ChangePersonalInfo : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["LoggedInId"] == null)  // the user has not yet logged in.
      {
        //logout.Visible = false;
        Response.Redirect("Login.aspx");
      }
      else
      {
        logout.Visible = true;
      }
    }

    protected void SubmitForm(object sender, EventArgs e)
    {
      if (Page.IsValid)
      {
        changesUserInfo();
        PanelClientInfo.Visible = true;
        panelPersonalInfo.Visible = false;
        lblMessage.Text = "Your personal information has been changed.";
      }
    }


    protected void changesUserInfo()
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings

      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText = "UPDATE Users SET Email=?, Passwd=? WHERE UserID=?";
      OleDbParameter param;

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtEmail.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtPassword.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Session["LoggedInId"];
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();
    }




    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }


  }
}