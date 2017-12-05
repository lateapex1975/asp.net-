<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="OnlineStore_TeamC.code.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
     <asp:Table ID="OrderTransaction" runat="server" >
         <asp:TableHeaderRow>
				  <asp:TableHeaderCell CssClass="column1">Book name</asp:TableHeaderCell>
				  <asp:TableHeaderCell CssClass="column2">Price</asp:TableHeaderCell>
                  <asp:TableHeaderCell CssClass="column3">Date of order</asp:TableHeaderCell>
                 
		</asp:TableHeaderRow>

     </asp:Table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
