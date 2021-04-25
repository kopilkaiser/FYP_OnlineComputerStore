<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindCustomer.aspx.cs" Inherits="FrontEnd.WebForm8" %>
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
        userEmail = "Laptop";
    }
</script>

    <div class="text-left">   
        <div class="text-left">
        <%  clsCustomerCollection MyCustomers = new clsCustomerCollection();          
            MyCustomers.ReportByEmail(userEmail);
            Int32 Index = 0;
            Int32 RecordCount = MyCustomers.Count;
            lblRecordCount.Text = RecordCount.ToString();
        %>
                
                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Profile Manage Menu</span><br /><br /></div>

                 <asp:Label ID="Label2" runat="server" Text="Label">No of Record:</asp:Label>

         <asp:Label ID="lblRecordCount" runat="server" Text="Label"></asp:Label>
         
                  </div>
         
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>

                          <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                         <td style="font-weight:bold" class="auto-style9"><%Response.Write("");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("CustomerId");%></td>                         
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Email");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Name");%></td>
                          <td style="font-weight:bold; text-align:center" class="auto-style4"><% Response.Write("");%></td>
 

                     </tr>
                      
                      <%                      
                  while(Index<RecordCount)
                  {
                    %>
                      <tr>
                          <td class="auto-style9">
                           <a href="ShowCustomerDetails.aspx?
                            CustomerID=<%Response.Write(MyCustomers.CustomerList[Index].CustomerId);%>
                            &Name=<%Response.Write(MyCustomers.CustomerList[Index].Name);%>
                            &Phonenum=<% Response.Write(MyCustomers.CustomerList[Index].Phonenum);%>
                            &Email=<% Response.Write(MyCustomers.CustomerList[Index].Email);%>
                            &DateJoined=<% Response.Write(MyCustomers.CustomerList[Index].DateJoined);%>
                            &Bio=<% Response.Write(MyCustomers.CustomerList[Index].Bio);%>
                            &AccountBalance=<% Response.Write(MyCustomers.CustomerList[Index].AccountBalance);%>">
                            <%Response.Write("Show My Profile");%>
                           </a>
                          </td>

                          <td class="auto-style9">
                           <a href="EditCustomerDetails.aspx?
                            CustomerId=<%Response.Write(MyCustomers.CustomerList[Index].CustomerId);%>
                            &Name=<%Response.Write(MyCustomers.CustomerList[Index].Name);%>
                            &Phonenum=<% Response.Write(MyCustomers.CustomerList[Index].Phonenum);%>
                            &Email=<% Response.Write(MyCustomers.CustomerList[Index].Email);%>
                            &DateJoined=<% Response.Write(MyCustomers.CustomerList[Index].DateJoined);%>
                            &Bio=<% Response.Write(MyCustomers.CustomerList[Index].Bio);%>
                            &AccountBalance=<% Response.Write(MyCustomers.CustomerList[Index].AccountBalance);%>">
                            <%Response.Write("Edit my Profile");%>
                           </a>
                          </td>

                          <td class="auto-style4"><%Response.Write(MyCustomers.CustomerList[Index].CustomerId);%></td>
                          <td class="auto-style4"><%Response.Write(MyCustomers.CustomerList[Index].Email);%></td>
                          <td class="auto-style4"><%Response.Write(MyCustomers.CustomerList[Index].Name);%></td>
                          <td class="auto-style4"><%Response.Write("Click 'Show My Profile' to View More");%></td>
                      </tr>
                     <%
                      Index++;
                    }
                    %>

                  </table>

        </div>
    <br />

    <div>
        <asp:Button ID="btnPaymentHistory" runat="server" Text="Show Payment History" OnClick="btnPaymentHistory_Click1" />
        <asp:Button ID="btnOrderHistory" runat="server" Text="Show Order History" OnClick="btnOrderHistory_Click" />
        </div>
</asp:Content>
