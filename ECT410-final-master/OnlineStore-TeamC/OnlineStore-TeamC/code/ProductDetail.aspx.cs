using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace OnlineStore_TeamC.code
{
  public partial class ProductDetail : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

      if(Session["LoggedInId"] == null)
      {
        btnAddToCart.Visible = false;
        quantityBox.Visible = false;
      }

      if (!Page.IsPostBack)
      {
        if (Request.QueryString["id"] == null)
        {
          pnlDetails.Visible = false;
          pnlNoItem.Visible = true;
          quantityBox.Visible = true;
        }
        else
        {
          String id = Request.QueryString["id"].ToString();
          LoadItem(id);
        }
      }
    }

    protected void LoadItem(String id)
    {
      OleDbConnection conn = new OleDbConnection();
      try
      {
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;
        conn.Open();
        OleDbCommand comm = conn.CreateCommand();
        comm.Connection = conn;

        String sql = "";
        sql = "SELECT ProductID, ProductName, ProductDescription FROM Products WHERE ProductID=?";

        comm.CommandText = sql;
        OleDbParameter param = new OleDbParameter();
        param.Direction = ParameterDirection.Input;
        param.DbType = DbType.Int32;
        param.Value = id;

        comm.Parameters.Add(param);

        OleDbDataReader reader = comm.ExecuteReader();

        if (reader.HasRows)
        {
          reader.Read();
          imgBook.ImageUrl = "../Images/" + reader["ProductID"].ToString() + ".jpg";
          lblName.Text = reader["ProductName"].ToString();
          lblDesc.Text = reader["ProductDescription"].ToString();
        }
        else
        {
          pnlDetails.Visible = false;
          pnlNoItem.Visible = true;
        }
      }
      catch (Exception)
      {
        pnlDetails.Visible = false;
        pnlNoItem.Visible = true;
      }
      finally
      {
        conn.Close();
      }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
      //Add Item to current order
      if(Page.IsValid)
      {
        makeOrder();
        updateOrderInfo();
        calculateTotalCost();
        updateOrderDetailInfo();
        Response.Redirect("Cart.aspx");
      }
    }

    // This method update the "Orders" table, by putting the ProductName 
    //and Price of the latest order record into the table
    protected void updateOrderInfo()
    {
      Dictionary<String, String> productInfo = getProductInfo();
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings
      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;
      comm.CommandText = "UPDATE Orders SET ProductName=?, Price=?  WHERE OrderID=(SELECT LAST(OrderID) FROM Orders)";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = productInfo["ProductName"];
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = float.Parse(productInfo["Price"]);
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Request.QueryString["id"].ToString());
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();

    }

    // This method update the "OrderDetail" table by inserting record of the latest order
    protected void updateOrderDetailInfo()
    {

      Dictionary<String, String> orderInfo = getOrderInfo();

      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText = "INSERT INTO OrderDetail (OrderID, ProductID, ProductQty, ProductCost) VALUES(?, ?, ?, ?)";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(orderInfo["OrderID"]);
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(orderInfo["ProductID"]);
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(orderInfo["ProductQty"]);
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = float.Parse(orderInfo["TotalCost"]);
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();

      conn.Close();

    }

    // This method update the Orders table by calculating the TotalCost column.
    protected void calculateTotalCost() 
    {
      //Dictionary<String, String> productInfo = getProductInfo();
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings
      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;
      comm.CommandText = "UPDATE Orders SET TotalCost=Price*ProductQty WHERE OrderID=(SELECT LAST(OrderID) FROM Orders)";
      int totalCount = comm.ExecuteNonQuery();
      conn.Close();
    }

    // This method insert record into the Orders table
    protected void makeOrder()
    {
      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.CommandText = "INSERT INTO Orders (UserID, ProductID, OrderDate, ProductQty, IsCart) VALUES(?, ?, ?, ?, ?)";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Session["LoggedInId"].ToString());
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Request.QueryString["id"].ToString());
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = DateTime.Now.ToString();
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(txtQty.Text);
      comm.Parameters.Add(param);

      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = -1; // IsCart = yes  
      comm.Parameters.Add(param);

      int totalCount = comm.ExecuteNonQuery();
      conn.Close();

    }

    protected Dictionary<String, String> getProductInfo()
    {

      Dictionary<String, String> productInfo = new Dictionary<String, String>();

      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings
      ["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;
      comm.CommandText = "SELECT ProductName, Price FROM Products WHERE ProductID=?";

      OleDbParameter param;
      param = comm.CreateParameter();
      param.DbType = DbType.String;
      param.Direction = ParameterDirection.Input;
      param.Value = Int32.Parse(Request.QueryString["id"].ToString());
      comm.Parameters.Add(param);

      OleDbDataReader reader = comm.ExecuteReader();

      while(reader.Read())
      {
        String temp;

        temp = reader["ProductName"].ToString();
        productInfo.Add("ProductName",temp);

        temp = reader["Price"].ToString();
        productInfo.Add("Price", temp);
      }

      //int totalCount = comm.ExecuteNonQuery();
      conn.Close();

      return productInfo;
    }

    // This method extract OrderID, ProductID, ProductQty, and TotalCost from the "Orders" table
    // In order to update the OrderDetail table
    protected Dictionary<String, String> getOrderInfo()
    {
      Dictionary<String, String> orderInfo = new Dictionary<String, String>();

      OleDbConnection conn = new OleDbConnection();
      conn.ConnectionString = ConfigurationManager.ConnectionStrings["onlineStoreConnString"].ConnectionString;
      conn.Open();
      OleDbCommand comm = conn.CreateCommand();
      comm.Connection = conn;
      comm.CommandText = "SELECT OrderID, ProductID, ProductQty, TotalCost FROM orders WHERE OrderID=(SELECT LAST(OrderID) FROM Orders)";

      OleDbDataReader reader = comm.ExecuteReader();

      while (reader.Read())
      {
        String temp;

        temp = reader["OrderID"].ToString();
        orderInfo.Add("OrderID", temp);

        temp = reader["ProductID"].ToString();
        orderInfo.Add("ProductID", temp);

        temp = reader["ProductQty"].ToString();
        orderInfo.Add("ProductQty", temp);

        temp = reader["TotalCost"].ToString();
        orderInfo.Add("TotalCost", temp);

      }

      conn.Close();

      return orderInfo;
    }


  }
}