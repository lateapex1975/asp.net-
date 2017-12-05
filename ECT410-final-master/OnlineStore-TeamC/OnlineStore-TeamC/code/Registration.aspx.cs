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
  public partial class Registration : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["LoggedInId"] != null)
      {

        PanelClientInfo.Visible = true;
        panelRegistration.Visible = false;
        lblMessage.Text = "You are already logged in.";
      }

      StatesGenerator();
    }

    protected void SubmitForm(object sender, EventArgs e)
    {   // This is a method that triggered by the onSubmit event
      if (Page.IsValid)
      {
        addUser();
        PanelClientInfo.Visible = true;
        panelRegistration.Visible = false;
        lblMessage.Text = "Thank you for your registration! Please login and start your shopping.";
      }
    }

    protected void addUser()
    { // This is a method that insert user information into the database
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings

      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText =
      "INSERT INTO Users (FirstName,LastName, Address1, Address2, City, State, ZipCode, Username, Email, Passwd, Address1_Ship, Address2_Ship, City_Ship, State_Ship, ZipCode_Ship) VALUES(?, ?, ?, ?, ?, ?, ?, ?,?, ?, ?,?,?,?,?)";

      // Step5: Setting all the parameters
      OleDbParameter param;
      Dictionary<String, String> clientInfomation = getClientInfomation();
      foreach (KeyValuePair<String, String> pair in clientInfomation)
      {
        param = comm.CreateParameter();
        param.DbType = DbType.String;
        param.Direction = ParameterDirection.Input;

        if (pair.Key == "ZipCode" || pair.Key == "ZipCode_Ship")
        {
          param.Value = Int32.Parse(clientInfomation[pair.Key]);
        }
        else
        {
          param.Value = clientInfomation[pair.Key];
        }

        comm.Parameters.Add(param);
      }

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();

    } // End of addUseer()


    protected Dictionary<String, String> getClientInfomation()
    {
      /* this method returns a doctionary that contains all the information obtain from client*/
      Dictionary<String, String> clientInfomation = new Dictionary<String,String>();

      String txt_Address2 = "";
      if (txtAddress2.Text != null) { txt_Address2 += txtAddress2.Text; }
      clientInfomation.Add("FirstName", txtFirstName.Text);
      clientInfomation.Add("LastName", txtLastName.Text);
      clientInfomation.Add("Address1", txtAddress1.Text);
      clientInfomation.Add("Address2", txt_Address2);
      clientInfomation.Add("City", txtCity.Text);
      clientInfomation.Add("State", drpStates.Text);
      clientInfomation.Add("ZipCode", txtZipCode.Text);
      clientInfomation.Add("Username", txtUsername.Text);
      clientInfomation.Add("Email", txtEmail.Text);
      clientInfomation.Add("Passwd", SecuredPassword.GenerateHash(txtPassword.Text));
      String txt_Address2_Ship = "";
      if (txtAddress2.Text != null) { txt_Address2_Ship += txtAddress2_Ship.Text; }
      clientInfomation.Add("Address1_Ship", txtAddress1_Ship.Text);
      clientInfomation.Add("Address2_Ship", txt_Address2_Ship);
      clientInfomation.Add("City_Ship", txtCity_Ship.Text);
      clientInfomation.Add("State_Ship", drpStates_Ship.Text);
      clientInfomation.Add("ZipCode_Ship", txtZipCode_Ship.Text);
      return clientInfomation;
    }
    protected void StatesGenerator()
    {// This method creates a dropdown list of state name for selection

      String[] states = { "Alabama","Alaska","Arizona","Arkansas","California","Colorado",
                          "Connecticut", "Delaware","Florida","Georgia","Hawaii","Idaho",
                          "Illinois","Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine",
                          "Maryland","Massachusetts","Michigan","Minnesota","Mississippi",
                          "Missouri","Montana","Nebraska","Nevada","NewHampshire","New Jersey",
                          "New Mexico","New York","North Carolina","North Dakota","Ohio","Oklahoma",
                          "Oregon","Pennsylvania","RhodeIsland","South Carolina",
                          "South Dakota","Tennessee","Texas","Utah","Vermont",
                          "Virginia","Washington","West Virginia","Wisconsin","Wyoming"};
      drpStates.Items.Add(new ListItem(null, null));
      drpStates_Ship.Items.Add(new ListItem(null, null));
      foreach (String state in states)
      {
        drpStates.Items.Add(new ListItem(state, state));
        drpStates_Ship.Items.Add(new ListItem(state, state));
      }
    }
  }
}