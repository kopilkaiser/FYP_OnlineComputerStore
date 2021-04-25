<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="FrontEnd.WebForm9" %>
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
        Session["MyCart"]= MyCart;
        Session["Sec"] = Sec;
        userEmail = Sec.UserEMail;
    }
</script>

                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">My Order History</span><br /><br /></div>

    
    <div>   
        <%  clsOrderCollection MyOrders = new clsOrderCollection();          
            MyOrders.ReportByEmail(userEmail);
            Int32 Index = 0;
            Int32 RecordCount = MyOrders.Count;
            lblRecordCount.Text = RecordCount.ToString();

        %>
       <asp:Label ID="Label1" runat="server" Text="Total Orders:"></asp:Label> <asp:Label ID="lblRecordCount" runat="server" Text=""></asp:Label>
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>

                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("Order-ID");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Email");%></td>                         
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Order Total");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Shipping Address");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><% Response.Write("Phonenum");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Order Date");%></td>

                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>
       
                          
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].OrderId);%></td>
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].Email);%></td>
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].TotalPrice);%></td> 
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].ShippingAddress);%></td>  
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].Phonenum);%></td>  
                          <td class="auto-style4"><%Response.Write(MyOrders.OrderList[Index].DateOrdered);%></td>  


                      </tr>
                     <%
                      Index++;
                    }
                    %>

                  </table>

        </div>
    <br />

    <div>
        <asp:Button ID="btnBack" runat="server" Text="Go Back Manage Page" OnClick="btnBack_Click" /></div>

</asp:Content>
