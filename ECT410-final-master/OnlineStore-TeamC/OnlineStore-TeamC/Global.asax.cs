using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace OnlineStore_TeamC
{
  public class Global : System.Web.HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
      Application["StartTime"] = DateTime.Now;
      Application["TotalUserSessions"] = 0;

      ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
     new ScriptResourceDefinition
     {
       Path = "~/scripts/jquery-1.9.1.min.js",
       DebugPath = "~/scripts/jquery-1.9.1.min.js",
       CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js",
       CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.js"
     });
    }

    protected void Application_End(object sender, EventArgs e)
    {
      //  Code that runs on application shutdown

    }

    protected void Application_Error(object sender, EventArgs e)
    {
      // Code that runs when an unhandled error occurs

    }

    protected void Session_Start(object sender, EventArgs e)
    {
      Session["StartTime"] = DateTime.Now;
      Application.Lock();
      Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;
      Application.UnLock();

    }

    protected void Session_End(object sender, EventArgs e)
    {
      // Code that runs when a session ends. 
      // Note: The Session_End event is raised only when the sessionstate mode
      // is set to InProc in the Web.config file. If session mode is set to StateServer 
      // or SQLServer, the event is not raised.

    }
  }
}