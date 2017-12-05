<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineStore_TeamC.code.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
  Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
  <Link rel="stylesheet" href="../styles/Login.css">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">


    
        
  <div class="container">
    <div class="row">
      <asp:Panel ID="panelLogin" Visible="false" runat="server" CssClass="LoginPanel">
        <p>Username:</p> <asp:TextBox ID="txtUserName" runat="server"  class="form-control" ></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
       <p> Password:</p> <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
        <p><asp:Button runat="server" ID="btnLogin" OnClick="DoLogin" Text="Login" CssClass="logBtn"></asp:Button> </p>
        <asp:Label runat="server" ID="lblResults" BackColor="Red"></asp:Label>
        <asp:Label id="errorMessage" runat="server" style="background-color:red"></asp:Label>
        <div>
          <p> If you do not have an account, please <u><a href="Registration.aspx">sign up</a></u>.</p>
        </div>
      </asp:Panel>
    </div>
  </div>
      





</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
