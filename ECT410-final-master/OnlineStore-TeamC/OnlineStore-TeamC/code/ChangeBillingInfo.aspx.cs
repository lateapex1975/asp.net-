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
  public partial class ChangeBillingInfo : System.Web.UI.Page
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
      StatesGenerator();
    }

    protected void SubmitForm(object sender, EventArgs e)
    {
      if (Page.IsValid)
      {
        ModifyBillingInfo();
        PanelClientInfo.Visible = true;
        panelBillingInfo.Visible = false;
        lblMessage.Text = "Your billing address has been changed.";
      }
    }

    protected void ModifyBillingInfo()
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText = "UPDATE Users SET Address1=?, Address2=?, City=?, State=?, ZipCode=? WHERE UserID=?";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtAddress1.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtAddress2.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtCity.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = drpStates.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtZipCode.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Session["LoggedInId"];
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();
    }





    protected void StatesGenerator()
    {// This method creates a dropdown list of state name for selection

      String[] states = { "Alabama","Alaska", "Arizona","Arkansas","California","Colorado","Connecticut",
                              "Delaware","Florida","Georgia","Hawaii","Idaho","Illinois","Indiana","Iowa",
                              "Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts","Michigan",
                              "Minnesota","Mississippi","Missouri","Montana","Nebraska","Nevada","New Hampshire",
                              "New Jersey","New Mexico","New York","North Carolina","North Dakota","Ohio",
                              "Oklahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota",
                              "Tennessee","Texas","Utah","Vermont","Virginia","Washington","West Virginia",
                              "Wisconsin","Wyoming"};
      foreach (String state in states)
      {
        drpStates.Items.Add(new ListItem(state, state));
      }
    }

    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }


  }
}