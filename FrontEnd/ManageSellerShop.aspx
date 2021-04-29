<%@Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSellerShop.aspx.cs" Inherits="FrontEnd.ManageSellerShop"%>
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
           
            clsSellerShopCollection AllSellerShops = new clsSellerShopCollection();          
            AllSellerShops.ReportByEmail(userEmail);
            Int32 Index = 0;
            Int32 RecordCount = AllSellerShops.Count;
            lblRecordCount.Text = RecordCount.ToString();
       %>
                
                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Shop Product Management<br />
                    </span><br /></div>
                
            <br />
            <br />
            <asp:Button ID="btnBrowseAllProducts" runat="server" Text="Browse All Seller Products" OnClick="btnBrowseAllProducts_Click"/>

                 <br />
            <br />

                 <asp:Label ID="Label2" runat="server" Text="Label">Total Shops:</asp:Label>

                 <asp:Label ID="lblRecordCount" runat="server" Text="Label"></asp:Label>
         
                  </div>

         
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>
                          
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                           <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                           <td style="font-weight:bold" class="auto-style9"><%Response.Write("Shop Id");%></td>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("Shop Name");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Seller Name");%></td>                         
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Email");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><% Response.Write("Rating");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Date Opened");%></td>
           
                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>

                           <td class="auto-style9">
                           <a href="UpdateSellerShop.aspx?ShopId=<%Response.Write(AllSellerShops.SellerShopList[Index].ShopId);%>&ShopName=<%Response.Write(AllSellerShops.SellerShopList[Index].ShopName);%>&Rating=<%Response.Write(AllSellerShops.SellerShopList[Index].Rating);%>&Email=<%Response.Write(AllSellerShops.SellerShopList[Index].Email);%>
                            &SellerName=<%Response.Write(AllSellerShops.SellerShopList[Index].SellerName);%>&DateOpened=<%Response.Write(AllSellerShops.SellerShopList[Index].DateOpened);%>">
                            <%Response.Write("Update");%>
                           </a>
                          </td>
                           <td class="auto-style9">
                           <a href="DeleteSellerShop.aspx?ShopId=<%Response.Write(AllSellerShops.SellerShopList[Index].ShopId);%>&ShopName=<%Response.Write(AllSellerShops.SellerShopList[Index].ShopName);%>&Rating=<%Response.Write(AllSellerShops.SellerShopList[Index].Rating);%>&Email=<%Response.Write(AllSellerShops.SellerShopList[Index].Email);%>
                            &SellerName=<%Response.Write(AllSellerShops.SellerShopList[Index].SellerName);%>">
                            <%Response.Write("Delete");%>
                           </a>
                          </td>

 
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].ShopId);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].ShopName);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].SellerName);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].Email);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].Rating);%></td>
                          <td class="auto-style4"><%Response.Write(AllSellerShops.SellerShopList[Index].DateOpened.ToString("dd/MM/yyyy"));%></td>

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
                              btnManageSellerProducts.Visible = true;
                          }
                        %>
                  </table>
                              
        </div>
    <br />

    <div>

        <asp:Button ID="btnCreateShop" runat="server" Text="Create My Shop" Visible="False" OnClick="btnCreateShop_Click" />
                <br />
                 <br />
               

        </div>
   <div>    
         <asp:Button ID="btnManageSellerProducts" runat="server" Text="Manage Shop Products" OnClick="btnManageSellerProducts_Click" Visible="False"/> <br />
</div>

</asp:Content>
