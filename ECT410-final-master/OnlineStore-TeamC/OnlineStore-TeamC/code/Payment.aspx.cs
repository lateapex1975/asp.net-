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
  public partial class Payment : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
          
           win.Text = Session["PurchaseTotal"].ToString();
           
    }

    protected void SubmitPayment(object sender, EventArgs e)
    {
           
            clearShoppingCart();
     
            //Assign the values for the properties we need to pass to the service
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = "20";
            String AppTransAmount = Session["PurchaseTotal"].ToString();

            // Hash the values so the server can verify the values are original
            String hash = HttpUtility.UrlEncode(CreditAuthorizationClient.GenerateClientRequestHash(SharedKey, AppId, AppTransId, AppTransAmount));

            //Create the URL and  concatenate  the Query String values
            String url = "http://ectweb2.cs.depaul.edu/ECTCreditGateway/Authorize.aspx";
            url = url + "?AppId=" + AppId;
            url = url + "&TransId=" + AppTransId;
            url = url + "&AppTransAmount=" + AppTransAmount;
            url = url + "&AppHash=" + hash;

            //Redirect the User to the Service
            Response.Redirect(url);
        
       // Response.Redirect("OrderHistory.aspx");
    }

    protected void clearShoppingCart()
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;

      comm.CommandText = "UPDATE Orders SET IsCart=False WHERE UserID=?";
      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Session["LoggedInId"].ToString());
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();
    }

    protected void updateProductQuantity()
    {
            //not needed
    }

       
   }
   
}