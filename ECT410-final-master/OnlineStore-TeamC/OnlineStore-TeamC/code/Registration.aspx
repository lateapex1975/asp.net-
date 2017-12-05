<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineStore_TeamC.code.Registration" %>
<asp:Content ID="titleContent" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
  Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
  <link rel="stylesheet" href="../styles/Registration.css" />

</asp:Content>

<asp:Content ID="pageTitleContent" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
  <asp:Panel runat="server" ID="panelRegistration" Visible="true">
    <div class="message">
      Please fill out the following form carefully. (*) are required fileds. <br/>
    </div>

    <table>
      <tr><td colspan="3"><span class="center">Personal information:</span></td></tr>
      <tr>
        <td>First Name:(*)</td><td><asp:TextBox BackColor="Gray" ID="txtFirstName" runat="server" AutoCompleteType="FirstName" Columns="13"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator runat="server" ID="reqFirstName" ControlToValidate="txtFirstName" ErrorMessage="FirstName is Required!" ForeColor="Red"></asp:RequiredFieldValidator></td>
      </tr>

      <tr>
        <td>Last Name:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtLastName" runat="server" AutoCompleteType="LastName" Columns="13"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator runat="server" ID="reqLastName" ControlToValidate="txtFirstName" ErrorMessage="FirstName is Required!" ForeColor="Red"></asp:RequiredFieldValidator></td>
      </tr>

      <tr>
        <td>Username:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtUsername" runat="server" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqUsername" ControlToValidate="txtUsername" ErrorMessage="Username is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Email Address:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtEmail" runat="server" AutoCompleteType="Email" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqEmail" ControlToValidate="txtEmail" ErrorMessage="Emial address is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="regularEmail" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" EnableClientScript="true" ErrorMessage="Email not in the correct format." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator> 
        </td>
      </tr>
      <tr>
        <td>Password:(*)</td><td><asp:TextBox BackColor="Gray" ID="txtPassword" runat="server" TextMode="Password" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator ID="reqPassword" ControlToValidate="txtPassword" EnableClientScript="true" ErrorMessage="Password Required." runat="server" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Confirm Password(*)</td><td><asp:TextBox BackColor="Gray" ID="txtPasswordConfirm" runat="server" TextMode="Password" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator ID="reqPasswordConfirm" ControlToValidate="txtPasswordConfirm" EnableClientScript="true" ErrorMessage="Password Confirm Required." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="comparePwdValidator" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" EnableClientScript="true" ForeColor="Red" ErrorMessage="Passwords don't match" runat="server"></asp:CompareValidator>
        </td>
      </tr>

      <tr>
        <td>&nbsp;</td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td colspan="3"><span class="center">Billing Address:</span></td>
      </tr>

      <tr>
        <td>Address1:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtAddress1" runat="server" AutoCompleteType="BusinessStreetAddress" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqAddress1" ControlToValidate="txtAddress1" ErrorMessage="Address1 is required !" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Address2:</td><td><asp:TextBox BackColor="Gray" ID ="txtAddress2" runat="server" Columns="13"></asp:TextBox></td>
        <td></td>
      </tr>
      <tr>
        <td>City:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtCity" runat="server" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqCity" ControlToValidate="txtAddress1" ErrorMessage="City is required !" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>State:(*)</td><td><asp:DropDownList BackColor="Gray" AutoPostBack="false" ID="drpStates" runat="server" Columns="13"></asp:DropDownList></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqStates" ControlToValidate="drpStates" ErrorMessage ="Please select your state!" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Zip Code:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtZipCode" runat="server" AutoCompleteType="BusinessZipCode" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqZipCode" ControlToValidate="txtZipCode" ErrorMessage="Zip code is required!" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="reqularZip" ControlToValidate="txtZipCode" ValidationExpression="\d{5}-?(\d{4})?$" EnableClientScript="true" ErrorMessage="ZipCode not in the correct format." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator>
        </td>
      </tr>

      <tr>
        <td>&nbsp;</td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td colspan="3"><span class="center">Shipping address:</span></td>
      </tr>

      <tr>
        <td>Address1:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtAddress1_Ship" runat="server" AutoCompleteType="BusinessStreetAddress" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqAddress1_Ship" ControlToValidate="txtAddress1_Ship" ErrorMessage="Address1 is required !" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Address2:</td><td><asp:TextBox BackColor="Gray" ID ="txtAddress2_Ship" runat="server" Columns="13"></asp:TextBox></td>
        <td></td>
      </tr>
      <tr>
        <td>City:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtCity_Ship" runat="server" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqCity_Ship" ControlToValidate="txtCity_Ship" ErrorMessage="City is required !" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>State:(*)</td><td><asp:DropDownList BackColor="Gray" AutoPostBack="false" ID="drpStates_Ship" runat="server" Column2="13"></asp:DropDownList></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqState_Ship" ControlToValidate="drpStates_Ship" ErrorMessage ="Please select your state!" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>Zip Code:(*)</td><td><asp:TextBox BackColor="Gray" ID ="txtZipCode_Ship" runat="server" AutoCompleteType="BusinessZipCode" Columns="13"></asp:TextBox></td>
        <td>
          <asp:RequiredFieldValidator runat="server" ID="reqZipCode_Ship" ControlToValidate="txtZipCode_Ship" ErrorMessage="Zip code is required!" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="reqularZip_Ship" ControlToValidate="txtZipCode_Ship" ValidationExpression="\d{5}-?(\d{4})?$" EnableClientScript="true" ErrorMessage="ZipCode not in the correct format." ForeColor="Red" runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator>
        </td>
      </tr>

    </table>

    <div class="btn"><p><asp:Button ID="btnSubmit" runat="server" CausesValidation="true" Text="Submit" OnClick="SubmitForm" CssClass="button"></asp:Button></p></div>

  </asp:Panel>


  <div class="container">
    <div class="row row-content">
      <asp:Panel runat="server" ID="PanelClientInfo" Visible="false" CssClass="col-sm-12">
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
      </asp:Panel>
    </div>

  </div>



</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
