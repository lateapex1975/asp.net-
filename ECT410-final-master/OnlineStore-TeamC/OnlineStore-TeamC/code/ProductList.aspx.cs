using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace OnlineStore_TeamC.code
{
  public partial class ProductList : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["LoggedInId"] == null)  // the user has not yet logged in.
      {
        logout.Visible = false;
      }
      else
      {
        logout.Visible = true;
      }

      sDS1.ProviderName = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ProviderName;
    }

    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }
  }
}