﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseAllSellerProducts.aspx.cs" Inherits="FrontEnd.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <%@ Import Namespace="ClassLibrary"%> 

<script runat="server">

    clsCart MyCart = new clsCart();
    clsSecurity Sec;


    protected void Page_Load(object sender, EventArgs e)
    {
        Sec = (clsSecurity)Session["Sec"];
        //upon loading the page you need to read in the cart from the session object
        MyCart = (clsCart)Session["MyCart"];
        //if the cart is null then we need to initialise it
        if (MyCart == null)
        {
            MyCart = new clsCart();
        }
        //then you can display how many items are in your cart
      
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        //you must also save the cart every time the unload event takes place
        Session["MyCart"] = MyCart;
        Session["Sec"] = Sec;

    }

  </script>

    <div class="text-left">   
        <div class="text-left">
       <% 
            clsSellerShopLineCollection AllSellerShopLines = new clsSellerShopLineCollection();          
            AllSellerShopLines.ReportByEmail("");
            Int32 Index = 0;
            Int32 RecordCount = AllSellerShopLines.Count;
            lblRecordCount.Text = RecordCount.ToString();
            lblCartCount.Text = MyCart.Products.Count.ToString();

       %>
                
                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px"><br />
                    ALL Seller Products in Market<br />
                    </span><br /></div>

             <p style="font-size: 16px"> You have&nbsp;Total <asp:Label ID="lblCartCount" runat="server" ForeColor="Red" ></asp:Label>&nbsp;items</p>

          <asp:HyperLink ID="hypViewCart" runat="server" NavigateUrl="~/ViewCart.aspx">View My Cart</asp:HyperLink> &nbsp;<em><strong>&nbsp;</strong></em><br />
         <br />
                
                 <asp:Label ID="Label2" runat="server" Text="Label">Total Products:</asp:Label>

                 <asp:Label ID="lblRecordCount" runat="server" Text="Label"></asp:Label>
         
                  </div>
         
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>

                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("Product Name");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Seller Email");%></td>                         
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Price");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><% Response.Write("Description");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Quantity");%></td>
           
                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>

                          <td class="auto-style9">
                           <a href="ProductDetails.aspx?InventoryId=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%>
                            &Price=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Price);%>
                            &Name=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%>
                            &Description=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%>
                            &Active=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Active);%>">
                            <%Response.Write("Select Quantity");%>
                           </a>
                          </td>

                           <td class="auto-style9">
                           <a href="AddReviewForProduct.aspx?InventoryId=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%>
                            &ProductName=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%>">
                            <%Response.Write("Write Review");%>
                           </a>
                          </td>

                          <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Email);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Price);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Quantity);%></td>

                      </tr>
                     <%
                      Index++;
                            
                    }
                         
                    %>

                  </table>
                              
        </div>
    <br />
    <br />

    <div>
        <asp:Button ID="btnBrowseSellerShops" runat="server" Text="Browse Seller Shops" OnClick="btnBrowseSellerShops_Click"/>
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <asp:Button ID="btnBrowseMyShop" runat="server" Text="Manage My Shop" OnClick="btnBrowseMyShop_Click"/>

        </div>
</asp:Content>
