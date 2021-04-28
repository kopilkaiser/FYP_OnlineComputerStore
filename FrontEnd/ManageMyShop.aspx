<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageMyShop.aspx.cs" Inherits="FrontEnd.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="ClassLibrary"%> 

<script runat="server">
    
    clsCart MyCart = new clsCart();
    clsSecurity Sec;
    string userEmail;
    
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

            userEmail = Sec.UserEMail;
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
                
                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Browsing My Shop<br />
                    </span><br /></div>
                
            <br />
            <br />
                 <asp:Label ID="Label2" runat="server" Text="Label">Total Products:</asp:Label>

                 <asp:Label ID="lblRecordCount" runat="server" Text="Label"></asp:Label>
         
                  </div>

         
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>
                          
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                           <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                           <td style="font-weight:bold" class="auto-style9"><%Response.Write("Product Id");%></td>
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
                           <a href="UpdateSellerProduct.aspx?SellerShopLineId=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%>&ProductName=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%>&Price=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Price);%>&Email=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Email);%>
                            &Description=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%>&Quantity=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%>">
                            <%Response.Write("Update");%>
                           </a>
                          </td>
                           <td class="auto-style9">
                           <a href="DeleteSellerProduct.aspx?SellerShopLineId=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%>&ProductName=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].ProductName);%>&Price=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Price);%>&Email=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Email);%>
                            &Description=<%Response.Write(AllSellerShopLines.SellerShopLineList[Index].Description);%>">
                            <%Response.Write("Delete");%>
                           </a>
                          </td>

 
                           <td class="auto-style4"><%Response.Write(AllSellerShopLines.SellerShopLineList[Index].SellerShopLineId);%></td>
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

                      <%
                          //Make 
                          if (RecordCount == 0)
                          {
                              btnCreateShop.Visible = true;
                              
                          }
                          else
                          {
                              btnAddProductToShop.Visible = true;
                          }
                        %>
                  </table>
                              
        </div>
    <br />

    <div>

        <asp:Button ID="btnCreateShop" runat="server" Text="Create My Shop" Visible="False" OnClick="btnCreateShop_Click" />
                <asp:Button ID="btnAddProductToShop" runat="server" Text="Add new Product To Shop" OnClick="btnAddProductToShop_Click" Visible="False"/> 
                        <asp:Button ID="Button1" runat="server" Text="Button" Visible="False" />

        </div>
    <div>            <br /><asp:Button ID="btnBrowseAllProducts" runat="server" Text="Browse All Seller Products" OnClick="btnBrowseAllProducts_Click"/>
</div>

</asp:Content>
