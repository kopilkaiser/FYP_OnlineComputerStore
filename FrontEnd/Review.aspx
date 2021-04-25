<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="FrontEnd.WebForm1" %>
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
            lblCartCount.Text = MyCart.Products.Count.ToString();

            userEmail = Sec.UserEMail;
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"]= MyCart;
            Session["Sec"] = Sec;
        }
</script>

     <div>
         
        <h2>Browse Reviews here. </h2>

        <p style="font-size: 16px"> You have&nbsp;Total <asp:Label ID="lblCartCount" runat="server" ForeColor="Red" ></asp:Label>&nbsp;items</p>

         <p style="font-size:16px; font-weight:600 ">Please Sign In to <span style="font-style:italic; font-size:22px; font-weight:800; color:red;">"View the Cart"</span> option.</p>
          <asp:HyperLink ID="hypViewCart" runat="server" NavigateUrl="~/ViewCart.aspx">View My Cart</asp:HyperLink> &nbsp;
            
        &nbsp;
         <br />
         <br />
    </div>
    
    <div>   
        <%  clsReviewCollection AllReviews = new clsReviewCollection();
            AllReviews.ReportByEmail("");
            Int32 Index = 0;
            Int32 RecordCount = AllReviews.Count;  %>
        
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <%  %> <tr><%  %><td style="font-weight:bold" class="auto-style9"><%
                                         Response.Write("");
                    %></td><%

                    %><td style="font-weight:bold; text-align:center" class="auto-style4">
                        <%Response.Write("ReviewId");%></td><%

                                %><td style="font-weight: bold; text-align: center" class="auto-style4"><% Response.Write("ProductId");%></td><%

                     %><td style="font-weight:bold; text-align:center" class="auto-style4"><%
                     Response.Write("Email");
                     %></td><%
                                 %><td style="font-weight:bold; text-align:center" class="auto-style4"><%
                     Response.Write("Rating");
                     %></td><%
                                         %><td style="font-weight:bold; text-align:center" class="auto-style4"><%
                     Response.Write("DateReviewed");
                     %></td><%
                                         %><td style="font-weight:bold; text-align:center" class="auto-style4"><%
                     Response.Write("Description");
                     %></td><%

                   %></tr><%
                        
                  while(Index<RecordCount)
                  {
                    %><tr><%
                    %><td class="auto-style9">
                        <a href="ProductDetails.aspx?InventoryId=<% Response.Write(AllReviews.ReviewList[Index].ReviewId);%>
                            &Email=<%Response.Write(AllReviews.ReviewList[Index].Email);%>
                            &Description=<% Response.Write(AllReviews.ReviewList[Index].Description);%>
                            &Rating=<% Response.Write(AllReviews.ReviewList[Index].Rating);%>
                            &ProductId=<% Response.Write(AllReviews.ReviewList[Index].ProductId);%>
                            &DateReviewed=<% Response.Write(AllReviews.ReviewList[Index].DateReviewed);%> ">
                            <%   
                     Response.Write("View Full Review");
                    %></a></td><%
                    %><td class="auto-style4"><%
                     Response.Write(AllReviews.ReviewList[Index].ReviewId);
                     %></td><%    

                                %><td class="auto-style4"><%
                                Response.Write(AllReviews.ReviewList[Index].ProductId);
                                                              %></td><%
                                                                                                                                  
                                                                                                                                  
                                   %><td class="auto-style4"><%
                                 Response.Write(AllReviews.ReviewList[Index].Email);
                                  %></td> <%
                                                %><td class="auto-style4"><%
                                 Response.Write(AllReviews.ReviewList[Index].Rating);
                                  %></td> <%

                                %><td class="auto-style4"><%Response.Write(AllReviews.ReviewList[Index].DateReviewed);%></td> <%
                                %><td class="auto-style4"><%Response.Write("Click to View More");%></td><%

                     %> </tr><%
                      Index++;
                    }
                    %></table><%

           
                  %>
        </div>

</asp:Content>
