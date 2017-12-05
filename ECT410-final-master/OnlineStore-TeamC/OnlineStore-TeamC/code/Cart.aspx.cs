using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace OnlineStore_TeamC.code
{
  public partial class Cart : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
            ZeroAmount.Visible = false;
            if (Session["LoggedInId"] == null) {Response.Redirect("Login.aspx"); }
      else  {  logout.Visible = true;  checkout.Visible = true; }
      LoadItem();
    }
        int total;
    protected void LoadItem()
    {           
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;

      comm.CommandText = "SELECT OrderID, ProductName, ProductQty, TotalCost, OrderDate FROM Orders WHERE UserID=? AND IsCart=true ORDER BY OrderDate " ;
      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Session["LoggedInId"].ToString());
      comm.Parameters.Add(param);

      OleDbDataReader reader = comm.ExecuteReader();

      while(reader.Read())
      {
        TableRow row = new TableRow();
        TableCell cell;

        cell = new TableCell();
        cell.Text = reader["ProductName"].ToString();
        cell.CssClass = "column1";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = reader["ProductQty"].ToString();
        cell.CssClass = "column2 center";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "$" +reader["TotalCost"].ToString();
        cell.CssClass = "column3 center";
        row.Cells.Add(cell);        

        cell = new TableCell();
        cell.Text = reader["OrderDate"].ToString();
        cell.CssClass = "column4 center";
        row.Cells.Add(cell);

       // cell = new TableCell();
        total += (Int32.Parse(reader["TotalCost"].ToString()));
     //   cell.Text = total.ToString();
      //  cell.CssClass = "column5 center";
       // row.Cells.Add(cell);

        cell = new TableCell();
        LinkButton btnRemove = new LinkButton();
        btnRemove.CssClass = "button";
        btnRemove.Command += new CommandEventHandler(CancelOrder);
        btnRemove.Text = "Remove";
        btnRemove.CommandName = "Remove";
        btnRemove.CommandArgument = reader["OrderID"].ToString();


        cell.Controls.Add(btnRemove);
        row.Cells.Add(cell);

        tblData.Rows.Add(row);

      }
      conn.Close();
            tblData2.Text = total.ToString();
      }
        
         

    protected void CancelOrder(object sender, CommandEventArgs e)
    {
      LinkButton source = (LinkButton)sender;
      String OrderID = source.CommandArgument;

      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["OnlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;

      comm.CommandText = "DELETE * FROM Orders WHERE OrderID=? AND IsCart=true";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(OrderID);
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();

      conn.Close();

      if(totalCount != 0)
      {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
      }

    }
    protected void CheckOut(object sender, EventArgs e)
    {
        Session["PurchaseTotal"] = total;
        if (total == 0)
            {
                ZeroAmount.Visible = true;
            }
        else
            { Response.Redirect("Payment.aspx"); }
        
    }

    protected void LogOut(object sender, EventArgs e)
    {
      Session.Clear();
      Response.Redirect("Login.aspx");
    }
  }
}