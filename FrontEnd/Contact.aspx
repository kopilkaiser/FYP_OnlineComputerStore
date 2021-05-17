<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FrontEnd.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      
    <!-- Container (Contact Section) -->
<div id="contact" class="container-fluid bg-grey">
  <h2 class="text-center">Contact US</h2>
    <p class="text-center">
        <asp:Label ID="Label2" runat="server" style="font-size: large" Text="Please Sign In to able to Submit Questions" Visible="False"></asp:Label>
    </p>
    <br />
    <br />
  <div class="row">
    <div class="col-sm-6" style="text-align: left">
        <br />
        <br />
      <p>Contact us and we'll get back to you within 24 hours.</p>
      <p><span class="glyphicon glyphicon-map-marker"></span> Leicester, United Kingdom</p>
      <p><span class="glyphicon glyphicon-phone"></span>  +44 5599 90910</p>
      <p><span class="glyphicon glyphicon-envelope"></span> p17511696@my365.dmu.ac.uk</p>
    </div>
    <div class="col-sm-6 slideanim">
              <h4><span class="glyphicon glyphicon-alert"></span>&nbsp&nbspPlease Fill up the following fields:</h4>
      <div class="row">
        <div class="col-sm-6 form-group">
            <asp:TextBox ID="txtName" placeholder="Enter your Name here" runat="server" Height="33px" Width="190px" BorderColor="White" BorderStyle="Groove" BorderWidth="1px"></asp:TextBox>
        </div>

         <div class="col-sm-12 form-group">
            <asp:TextBox ID="txtEmail" runat="server" Height="33px" Width="228px" BorderColor="White" BorderStyle="Groove" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
        </div>    
          
         <div class="col-sm-12 form-group">
             <asp:TextBox ID="txtPhonenum" placeholder="Enter your Contact number here" runat="server" Height="33px" Width="227px" BorderColor="White" BorderStyle="Groove" BorderWidth="1px"></asp:TextBox>
         </div>

         <div class="col-sm-6 form-group">
            <asp:Label ID="Label1" runat="server" Text="Date of Submission"></asp:Label>
            <asp:TextBox ID="txtDateSubmitted" runat="server" Height="29px" Width="157px" BorderColor="White" BorderStyle="Groove" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
        </div>

      <div class="col-sm-12 form-group">
        <asp:TextBox ID="txtDescription" placeholder="Please tell us more about your Issue" runat="server" Height="148px" Width="353px" BorderColor="White" BorderStyle="Groove" BorderWidth="1px" TextMode="MultiLine" style="resize:none"></asp:TextBox>
      </div>

          <div class="col-sm-12 form-group">
              <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>

      </div>

      <div class="row">
        <div class="col-sm-12 form-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-default pull-center" OnClick="btnSubmit_Click" />
        </div>
      </div>

    </div>
  </div>
</div>

<!-- Image of location/map -->
<img src="/Catalog/Images/map.jpg" class="w3-image w3-greyscale-min" style="width:100%">

<footer class="container-fluid text-center">
  <a href="#myPage" title="To Top">
    <span class="glyphicon glyphicon-chevron-up"></span>
  </a>
</footer>
</asp:Content>
