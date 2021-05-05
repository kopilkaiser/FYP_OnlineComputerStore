<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupportReplies.aspx.cs" Inherits="FrontEnd.WebForm24" %>
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
        }
</script>

     <div>
         
      <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Support Replies From Admin</span><br /><br /></div>

        <p style="font-size: 16px"> &nbsp;</p>

         <p style="font-size:16px; font-weight:600 ">&nbsp;</p>
         &nbsp;
            
        &nbsp;
         <br />
         <br />
    </div>
    
    <div>   
        <%  clsReplySupportCollection AllReplies = new clsReplySupportCollection();
            AllReplies.ReportByEmail(userEmail);
            Int32 Index = 0;
            Int32 RecordCount = AllReplies.Count;  %>
        
                  <table border="1" class="auto-style8" style="font-size:large; width: 100%; text-align:center;">
                     <tr>
                     
                     <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("");%></td>
                     <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("ReplySupport-ID");%></td>
                     <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Email");%></td>
                     <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Description");%></td>
                     <td style="font-weight:bold; text-align:center" class="auto-style4"><%Response.Write("Date Replied"); %></td>

                         </tr>
                      
                      <%
                        
                  while(Index<RecordCount)
                  {
                    %>
                      
                      <tr><%
                    %><td class="auto-style9">
                        <a href="ViewSupportReplies.aspx?ReplySupportId=<% Response.Write(AllReplies.ReplySupportList[Index].ReplySupportId);%>
                            &Email=<%Response.Write(AllReplies.ReplySupportList[Index].Email);%>
                            &Description=<% Response.Write(AllReplies.ReplySupportList[Index].Description);%>
                            &DateReplied= <%Response.Write(AllReplies.ReplySupportList[Index].DateReplied.ToString("dd/MM/yyyy"));%> ">
                            <%Response.Write("View");%></a></td>
                          
                          <td class="auto-style4"><%Response.Write(AllReplies.ReplySupportList[Index].ReplySupportId);%></td><%%>
                           <td class="auto-style4"><%Response.Write(AllReplies.ReplySupportList[Index].Email);%></td> 
                           <td class="auto-style4"><%Response.Write("Click 'View' to See More");%></td> 
                            <td class="auto-style4"><%Response.Write(AllReplies.ReplySupportList[Index].DateReplied.ToString("dd/MM/yyyy"));%></td> 


                      </tr>
                      <%
                      Index++;
                    }
                    %>

                  </table>
        </div>
    <div>
        <br />
        <br />

    </div>
</asp:Content>
