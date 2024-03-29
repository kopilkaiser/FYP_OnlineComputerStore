﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductByCategory.aspx.cs" Inherits="FrontEnd.ProductListCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%@ Import Namespace="ClassLibrary"%> 

    <script runat="server">

        clsCart MyCart = new clsCart();
        clsSecurity Sec;
        string userEmail;
        string category;

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
            lblCartCount.Text = MyCart.Products.Count.ToString();
            category = Convert.ToString(Request.QueryString["Category"].Trim());

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"]= MyCart;
            Session["Sec"] = Sec;
        }
</script>

     <div>
         
        <h2 class="text-center" style="font-family: Corbel; font-weight: normal; font-size: 35px">Browse Store Products Here </h2>

        <p style="font-size: 16px"> You have&nbsp;Total <asp:Label ID="lblCartCount" runat="server" ForeColor="Red" ></asp:Label>&nbsp;items</p>

          <asp:HyperLink ID="hypViewCart" runat="server" NavigateUrl="~/ViewCart.aspx">View My Cart</asp:HyperLink> &nbsp;
            
         <br />
            
         <br />
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Category List" />
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Browse All Store Products" />
         &nbsp;
         <br />
         <br />
    </div>
    
    <div>   
        <%  clsInventoryCollection MyInventories = new clsInventoryCollection();          
            MyInventories.ReportByCategory(category);
            Int32 Index = 0;
            Int32 RecordCount = MyInventories.Count;
        %>
        
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Name");%></td>                         
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Price Per Item");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Category");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><% Response.Write("Description");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Image");%></td>

                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>
                          <td class="auto-style9">
                           <a href="ProductDetails.aspx?InventoryId=<%Response.Write(MyInventories.InventoryList[Index].InventoryId);%>
                            &Price=<%Response.Write(MyInventories.InventoryList[Index].Price);%>
                            &Name=<% Response.Write(MyInventories.InventoryList[Index].Name);%>
                            &ImagePath=<% Response.Write(MyInventories.InventoryList[Index].ImagePath);%>
                            &Description=<% Response.Write(MyInventories.InventoryList[Index].Description);%>
                            &Active=<% Response.Write(MyInventories.InventoryList[Index].Active);%>">
                            <%Response.Write("Select Quantity");%>

                           </a>
                          </td>

                           <td class="auto-style9">
                           <a href="AddReviewForProduct.aspx?InventoryId=<%Response.Write(MyInventories.InventoryList[Index].InventoryId);%>
                            &Price=<%Response.Write(MyInventories.InventoryList[Index].Price);%>
                            &Name=<% Response.Write(MyInventories.InventoryList[Index].Name);%>
                            &ImagePath=<% Response.Write(MyInventories.InventoryList[Index].ImagePath);%>
                            &Description=<% Response.Write(MyInventories.InventoryList[Index].Description);%>">
                            <%Response.Write("Write Review");%>
                           </a>
                          </td>
                          
                          <td class="auto-style4"><%Response.Write(MyInventories.InventoryList[Index].Name);%></td>
                          <td class="auto-style4"><%Response.Write(MyInventories.InventoryList[Index].Price);%></td>
                          <td class="auto-style4"><%Response.Write(MyInventories.InventoryList[Index].Category);%></td> 
                          <td class="auto-style4"><%Response.Write(MyInventories.InventoryList[Index].Description);%></td>  
                          <td><image src='/Catalog/Images/<%Response.Write(MyInventories.InventoryList[Index].ImagePath);%>' width="100" height="100" border="1" /></td>  

                      </tr>
                     <%
                      Index++;
                    }
                    %>

                  </table>

        </div>

</asp:Content>
