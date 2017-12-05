<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePersonalInfo.aspx.cs" Inherits="OnlineStore_TeamC.code.ChangePersonalInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <style>
  
    .main{
      margin: 50px 40px;;
    }


  </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <div id="logoutBtn">
    <asp:Panel runat ="server" ID="logout" Visible="false">
   
    </asp:Panel>
    </div>

  <asp:Panel runat="server" ID="panelPersonalInfo" Visible="true" CssClass="main">
    <div id="message">
      <p>Please enter the new information below, (*) are required fileds.</p>
       
    </div>

    <table>
      <tr>
        <td>Email Address:(*)</td><td><asp:TextBox class="form-control" ID ="txtEmail" runat="server" AutoCompleteType="Email" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqEmail" ControlToValidate="txtEmail" ErrorMessage="Emial address is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="regularEmail" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" EnableClientScript="true" ErrorMessage="Email not in the correct format." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator> 
        </td>
      </tr>
      <tr>
        <td>New Password:(*)</td><td><asp:TextBox class="form-control" ID="txtPassword" runat="server" TextMode="Password" Columns="13"></asp:TextBox></td>
        <td>
           <asp:RequiredFieldValidator ID="reqPassword" ControlToValidate="txtPassword" EnableClientScript="true" ErrorMessage="Password Required." runat="server" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Confirm Password:(*) </td><td><asp:TextBox class="form-control" ID="txtPasswordConfirm" runat="server" TextMode="Password" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator ID="reqPasswordConfirm" ControlToValidate="txtPasswordConfirm" EnableClientScript="true" ErrorMessage="Password Confirm Required." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="comparePwdValidator" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" EnableClientScript="true" ForeColor="Red" ErrorMessage="Passwords don't match" runat="server"></asp:CompareValidator>
        </td>
      </tr>
    </table><p></p>

    <div id="btn"><p><asp:Button ID="btnSubmit" runat="server" CausesValidation="true" Text="Submit" OnClick="SubmitForm" CssClass="btn_logout"></asp:Button></p></div>

  </asp:Panel>


  <asp:Panel runat="server" ID="PanelClientInfo" Visible="false" CssClass="center">
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
  </asp:Panel>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
