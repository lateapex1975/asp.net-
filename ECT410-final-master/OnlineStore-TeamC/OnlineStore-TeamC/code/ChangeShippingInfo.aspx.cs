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
  public partial class ChangeShippingInfo : System.Web.UI.Page
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
        ModifyShippingInfo();
        PanelClientInfo.Visible = true;
        panelBillingInfo.Visible = false;
        lblMessage.Text = "Your shipping address has been changed.";
      }
    }

    protected void ModifyShippingInfo()
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings

      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText = "UPDATE Users SET Address1_Ship=?, Address2_Ship=?, City_Ship=?, State_Ship=?, ZipCode_Ship=? WHERE UserID=?";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtAddress1_Ship.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtAddress2_Ship.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtCity_Ship.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = drpStates_Ship.Text;
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = txtZipCode_Ship.Text;
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
        drpStates_Ship.Items.Add(new ListItem(state, state));
      }
    }

    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }


  }
}