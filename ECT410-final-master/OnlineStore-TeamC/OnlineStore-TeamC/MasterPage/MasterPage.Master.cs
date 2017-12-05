using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStore_TeamC.MasterPage
{
  public partial class MasterPage : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["LoggedInId"] == null)
            {
                loggedin.Visible = true;
                loggedout.Visible = false;
                
            }
            else
            {
                loggedin.Visible = false;
                loggedout.Visible = true;
            }
    }

        protected void LogOutNav(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
            loggedin.Visible = true;
            loggedout.Visible = false;
        }
    }
}