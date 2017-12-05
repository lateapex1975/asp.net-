<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="OnlineStore_TeamC.Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <Link rel="stylesheet" href="../styles/Response.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
     <asp:Label id="lblStatus" runat="server"></asp:Label>
    <br />
   <div id="OrderView">
       <p>Would you like to view your <a href="OrderHistory.aspx">order history</a>?</p>

   </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
