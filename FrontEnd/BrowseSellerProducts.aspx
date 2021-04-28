<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseSellerProducts.aspx.cs" Inherits="FrontEnd.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="ClassLibrary"%> 

<script runat="server">

    clsCart MyCart = new clsCart();
    clsSecurity Sec;
    string userEmail;
    string sellerName;
    string shopName;
    string rating;

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

        userEmail = Convert.ToString(Request.QueryString["Email"].Trim());
        sellerName = Convert.ToString(Request.QueryString["SellerName"].Trim());
        shopName = Convert.ToString(Request.QueryString["ShopName"].Trim());
        rating = Convert.ToString(Request.QueryString["Rating"].Trim());


        lblSellerName.Text = Convert.ToString(sellerName);
        lblShopName.Text = Convert.ToString(shopName);
        lblRating.Text = Convert.ToString(rating);

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
            AllSellerShopLines.ReportByEmail(userEmail);
            Int32 Index = 0;
            Int32 RecordCount = AllSellerShopLines.Count;
            lblRecordCount.Text = RecordCount.ToString();
       %>
                
                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: x-large; text-transform: uppercase; letter-spacing: 3px">Browsing <strong> <asp:Label ID="lblSellerName" runat="server" style="color: #800000"></asp:Label> </strong>&#39;s&nbsp;Shop</span><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px"><br />
                    </span><span style="font-family: Arial; font-size: x-large">
                    <span>Shop Name: </span><strong><asp:Label ID="lblShopName" runat="server" Text=""></asp:Label>
                    </strong>&nbsp;|  
                    </span>
                    <span style="font-family: Arial; font-size: large">
                    Rating: <asp:Label ID="lblRating" runat="server" Text=""></asp:Label> 
                    </span>
                    <br /><br /></div>
                
                 <asp:Label ID="Label2" runat="server" Text="Label">Total Products:</asp:Label>

                 <asp:Label ID="lblRecordCount" runat="server" Text="Label"></asp:Label>
         
                  </div>
         
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>

                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("Product Name");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Email");%></td>                         
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
                           <a href="ProductDetails.aspx?
                            InventoryId=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%>
                            &Price=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Price);%>
                            &Name=<% Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%>
                            &Description=<% Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%>">
                            <%Response.Write("Select Quantity");%>
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
        
        </div>
</asp:Content>
