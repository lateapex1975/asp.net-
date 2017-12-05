<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OnlineStore_TeamC.code.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
  Product List
</asp:Content>
<asp:Content ContentPlaceHolderID="headContentPlaceHolder" ID="headContent" runat="server">
  <link rel="stylesheet" href="../styles/ProductList.css" />
</asp:Content>


<asp:Content ID="pageTitleContent" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
</asp:Content>


<asp:Content ContentPlaceHolderID="mainContentPlaceHolder" ID="mainContent" runat="server">

    <div id="logoutBtn">
    <asp:Panel runat ="server" ID="logout" Visible="false">
   
    </asp:Panel>
    </div>

  <div class="container">
    <div class="row row-content">
      <div class="col-sm-9 col-sm-offset-1">

	      <h3>Following are our available books.
          Note: you have to login in inorder to add items to your shopping cart.
          Please Go to "Account" page to login to.</h3><br />
	
        <asp:Repeater runat="server" ID="rptCourses" DataSourceID="sDS1">
          <HeaderTemplate>
            <ul id="expandedProductList">
          </HeaderTemplate>
          <ItemTemplate>
    	      <li>
              <span class="bold">Book Name: <I><%#Eval("ProductName")%></I></span><br />
              <span class="bold">Catalog: <I><%#Eval("ProductCatalog")%></span></I> <br />
              <span class="bold">Publisher: <I><%#Eval("Producer")%></span></I> <br />
              <span class="bold">Price: $<%#Eval("Price")%></span> <br />
              <span class="bold">Number in stock: <%#Eval("ProductQty")%></span> <br />
              <span class="bold"><a href='ProductDetail.aspx?id=<%#Eval("ProductID")%>'>Detail</a></span>
    	      </li>
      
          </ItemTemplate>
          <FooterTemplate>
              </ul>
          </FooterTemplate>
      </asp:Repeater>   

        <asp:SqlDataSource ID="sDS1" runat="server"
          ConnectionString="<%$ ConnectionStrings:onlineStoreConnString%>"
          SelectCommand="SELECT ProductID, ProductName, ProductCatalog, Price, ProductQty, Producer, ProductDescription FROM Products ORDER BY ProductID">
        </asp:SqlDataSource>


      </div>
    </div>
  </div>


    
</asp:Content>






<asp:Content ID="Content6" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
