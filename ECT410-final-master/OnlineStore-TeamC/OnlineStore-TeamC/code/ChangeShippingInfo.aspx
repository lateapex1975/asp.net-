<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangeShippingInfo.aspx.cs" Inherits="OnlineStore_TeamC.code.ChangeShippingInfo" %>
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
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <div id="logoutBtn">
    <asp:Panel runat ="server" ID="logout" Visible="false">
     
    </asp:Panel>
    </div>

  <asp:Panel runat="server" ID="panelBillingInfo" Visible="true" CssClass="main">


      <div class="message">
        <p  class="message">
          Enter the new shipping below, (*) are required fileds.
        </p>
      </div>          


    <table>
      <tr>
        <td>Address1:(*)</td><td><asp:TextBox  ID ="txtAddress1_Ship" runat="server" AutoCompleteType="BusinessStreetAddress" class="form-control" Columns="13"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator runat="server" ID="reqAddress1" ControlToValidate="txtAddress1_Ship" ErrorMessage="Address1 is required !" ForeColor="Red"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td>Address2:</td><td><asp:TextBox class="form-control" ID ="txtAddress2_Ship" runat="server" Columns="13"></asp:TextBox></td>
        <td></td>      
      </tr>
      <tr>
        <td>City:(*)</td><td><asp:TextBox class="form-control" ID ="txtCity_Ship" runat="server" Columns="13"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator runat="server" ID="reqCity" ControlToValidate="txtCity_Ship" ErrorMessage="City is required !" ForeColor="Red"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td>State:(*)</td><td><asp:DropDownList class="form-control" AutoPostBack="false" ID="drpStates_Ship" runat="server" Column2="13"></asp:DropDownList></td>
        <td><asp:RequiredFieldValidator runat="server" ID="reqStates_Ship" ControlToValidate="drpStates_Ship" ErrorMessage ="Please select your state!" ForeColor="Red"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td>Zip Code:(*)</td><td><asp:TextBox class="form-control" ID ="txtZipCode_Ship" runat="server" AutoCompleteType="BusinessZipCode" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RegularExpressionValidator ID="reqularZip" ControlToValidate="txtZipCode_Ship" ValidationExpression="\d{5}-?(\d{4})?$" EnableClientScript="true" ErrorMessage="ZipCode not in the correct format." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator>
          <asp:RequiredFieldValidator runat="server" ID="reqZipCode_Ship" ControlToValidate="txtZipCode_Ship" ErrorMessage="Zip code is required!" ForeColor="Red"></asp:RequiredFieldValidator>
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
