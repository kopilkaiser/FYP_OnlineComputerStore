<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontEnd._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div>
      <h2 style="text-align:center; font-family: 'Bahnschrift Light Condensed';">  <em>
          <asp:Label ID="Label1" runat="server" Text="Please Sign In to use our Website Full Features "></asp:Label>
          </em>  </h2>   

    </div>

        <br />
        <br />
        <br />

   <div class="jumbotron" style="background-image: url(/Catalog/Images/computer1.jpg); background-size: cover; height: 600px; opacity: 0.9">
        <h1 style="font-style: oblique; color:aliceblue">Exclusive <br />Tech-Products</h1>
        <p style="color:black; font-style:oblique; font-weight: 600; background-color: beige; width: 30%" class="lead">Our products are brand new,<br /> with good service warranty,<br /> the quality is well-built</p>

        <p><a href="Product.aspx" class="btn btn-primary btn-lg" id="btnAllProducts" runat="server">Browse All Products &raquo;</a></p>
         <p><a href="BrowseSellerShops.aspx" class="btn btn-primary btn-lg" id="btnSellerShops" runat="server">Browse Seller Shops &raquo;</a></p>
         <p><a href="BrowseAllSellerProducts.aspx" class="btn btn-primary btn-lg" id="btnAllSellerProducts" runat="server">Browse All Seller Products &raquo;</a></p>

    </div>


</asp:Content>
