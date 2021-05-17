<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCategoryList.aspx.cs" Inherits="FrontEnd.ProductCategories" %>
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
        lblCartCount.Text = MyCart.Products.Count.ToString();
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
            
        &nbsp;
         <br />
         <br />
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Browse All Store Products" />
         <br />
         <br />
    </div>
    
    <div>   
        <%  clsInventoryCollection MyInventories = new clsInventoryCollection();          
            MyInventories.ReportByCategory("");
            Int32 Index = 0;
            Int32 RecordCount = MyInventories.Count;
        %>
        
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>
                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>

                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Category");%></td>


                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>
                          <td class="auto-style9">
                           <a href="ProductByCategory.aspx?InventoryId=<%Response.Write(MyInventories.InventoryList[Index].InventoryId);%>
                            &Category=<%Response.Write(MyInventories.InventoryList[Index].Category);%>">
                            <%Response.Write("Show Products");%>
                           </a>
                          </td>

                       
                          <td class="auto-style4"><%Response.Write(MyInventories.InventoryList[Index].Category);%></td> 
   
  

                      </tr>
                     <%
                      Index++;
                    }
                    %>

                  </table>

        </div>
</asp:Content>
