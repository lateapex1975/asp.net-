<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OnlineStore_TeamC.code.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTitleContentPlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/index.css"/>
  <script type="text/javascript" src="../scripts/jquery.js"></script>
  <script type="text/javascript" src="../scripts/index.js"></script>
  <script type="text/javascript" src="../scripts/move.js"></script>
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="logoutBtn">
    <asp:Panel runat ="server" ID="logout" Visible="false">
     
    </asp:Panel>
    </div>

      <div class="container">
      <div class="row row-content">
        <div class="col-xs-12 col-sm-5">
          <div id="photo_box">  
		        <ul>
		          <li><img src="../Images/1.jpg" alt=""/></li> 
              <li><img src="../Images/2.jpg" alt=""/></li>
		          <li><img src="../Images/3.jpg" alt=""/></li>
		          <li><img src="../Images/4.jpg" alt=""/></li>
		          <li><img src="../Images/5.jpg" alt=""/></li>
		          <li><img src="../Images/6.jpg" alt=""/></li> 
              <li><img src="../Images/7.jpg" alt=""/></li>
		          <li><img src="../Images/8.jpg" alt=""/></li>
		          <li><img src="../Images/9.jpg" alt=""/></li>
		          <li><img src="../Images/10.jpg" alt=""/></li>
		        </ul>
            <ol>
              <li class="active">1</li>
              <li>2</li>
              <li>3</li>
              <li>4</li>
              <li>5</li>
              <li>6</li>
              <li>7</li>
              <li>8</li>
              <li>9</li>
              <li>10</li>
            </ol>
	        </div> 
        </div>

        <div class="col-xs-12 col-sm-7">
          <div class="text">
            <h2 class="welcomeMessage">Welcome to BooksForYou!</h2>
              Browse over 60,000 second-hand, antique and new books available to buy online. 
              We have everything from the latest fire-side fiction, super sci-fi, travel and 
            history books through to our extensive rare and antiquarian collection. If you can 
            not find what you want from our list, you can also contact us.
          </div>
        </div>



      </div>     
    </div>

  	




</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
