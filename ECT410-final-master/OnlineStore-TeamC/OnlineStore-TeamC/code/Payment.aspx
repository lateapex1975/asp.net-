<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="OnlineStore_TeamC.code.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">

 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
   <h3>The total cost of your order will be: </h3>
     $<asp:Label runat="server" ID="win"></asp:Label>
    <br />


        <asp:SqlDataSource ID="sDS1" runat="server"
          ConnectionString="<%$ ConnectionStrings:onlineStoreConnString%>"
          SelectCommand="SELECT ProductID, ProductName, ProductCatalog, Price, ProductQty, Producer, ProductDescription FROM Products ORDER BY ProductID">
        </asp:SqlDataSource>
    <asp:Button ID="testButton" runat="server" OnClick="SubmitPayment" Text="Submit Payment" CssClass="logBtn" />
    
</asp:Content>

    