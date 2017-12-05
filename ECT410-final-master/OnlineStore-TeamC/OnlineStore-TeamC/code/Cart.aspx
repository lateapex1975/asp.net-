<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="OnlineStore_TeamC.code.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
  <link rel="stylesheet" href="../styles/Cart.css" type="text/css" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id ="checkoutBtn">
        <asp:Panel runat ="server" ID="checkout" Visible="false">
      <asp:Button ID="btnCheckout" runat="server" Text="Check Out" OnClick="CheckOut" CssClass="btn_logout"></asp:Button>
    </asp:Panel>
    </div>
    <div id="logoutBtn">
    <asp:Panel runat ="server" ID="logout" Visible="false">
    
    </asp:Panel>
    </div>


  <div class="container">
    <div class="row row-content">
      <h3>List of orders in your shopping cart.</h3>

	    <asp:Table ID="tblData" runat="server" CssClass="container">
			  <asp:TableHeaderRow>
				  <asp:TableHeaderCell CssClass="column1">Book name</asp:TableHeaderCell>
				  <asp:TableHeaderCell CssClass="column2 center">Quantity</asp:TableHeaderCell>
				  <asp:TableHeaderCell CssClass="column3 center">Total Cost</asp:TableHeaderCell>
          <asp:TableHeaderCell CssClass="column4 center">Date of order</asp:TableHeaderCell>
          <asp:TableHeaderCell CssClass="column5 center">Cart Total</asp:TableHeaderCell>
			  </asp:TableHeaderRow>
		  </asp:Table>
        <asp:Textbox BackColor="Azure" ID="tblData2" runat="server" ></asp:Textbox>
        <asp:Label Id="ZeroAmount" Text ="You need to add a product to your cart first" runat="server"></asp:Label>

    </div>
  </div>

  	






</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
