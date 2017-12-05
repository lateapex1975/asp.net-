<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="OnlineStore_TeamC.code.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
  <link href="../styles/ProductDetail.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
 


      <asp:Panel runat ="server" ID="pnlDetails" Visible="true">

      <div class="container">
        <div class="row row-content">
          <div class="col-xs-12 col-sm-5">
            <div id="imageBook">
              <p><asp:Image runat="server" id="imgBook" Height="400" Width="320"></asp:Image></p>
            </div>
 
          </div>
          <div class="col-xs-12 col-sm-6">
            <div id="bookName">
              <h3><strong>Book Name:</strong> <asp:Label ID="lblName" runat="server"></asp:Label></h3>
            </div>
            <div id="bookDescription">
              <strong>Book Description:</strong> <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </div> 
            
            <p>
              <asp:Panel ID="quantityBox" runat="server">
              Enter Quantity: <asp:TextBox BackColor="DarkGray" ID="txtQty" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQty" ErrorMessage="Number Required" BackColor="Red" EnableClientScript="true"></asp:RequiredFieldValidator>
              <asp:RangeValidator ID="req1" runat="server" ControlToValidate="txtQty" BackColor="Red" ErrorMessage="Enter Valid Number between 1 and 20" MinimumValue="1" MaximumValue="20" Type="Integer" EnableClientScript="true"/><br />
              <asp:Button runat ="server" ID="btnAddToCart" Text="Add" OnClick="btnAddToCart_Click" Visible="true" CssClass="Button" /> <a href="ProductList.aspx">Return to Catalog</a>
              </asp:Panel>
            </p>
          </div>
        </div>
      </div> 


 

    </asp:Panel>

    <asp:Panel runat ="server" ID="pnlNoItem" Visible="false">
      <h3>No Item Selected or bad value passed.</h3>
    </asp:Panel>





</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
