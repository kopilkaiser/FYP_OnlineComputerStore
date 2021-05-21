	<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="FrontEnd.ViewCart" %>
	<%@ Import Namespace="ClassLibrary"%>

	<script runat="server">

        clsCart MyCart = new clsCart();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (MyCart == null)
            {
                MyCart = new clsCart();
            }
            //upon loading the page you need to read in the cart from the session object
            MyCart = (clsCart)Session["MyCart"];
            //display the cart contents

            if (MyCart.Products.Count == 0)
            {
                Label1.Text = "Your Shopping Cart seems Empty! Please add some Products to proceed to Check Out";
            }

            else
            {
                Label1.Text = "Your Shopping Cart";
            }

            if(MyCart.Products.Count == 0)
            {
				hypCheckOut.Visible = false;
				Label1.Visible = true;
            }

            else
            {
				hypCheckOut.Visible = true;
				Label1.Visible = false;
            }

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            //you must also save the cart every time the unload event takes place
            Session["MyCart"] = MyCart;
        }
	</script>



	<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
		<br />
        <p></p>
        <p class="text-center">
            <asp:Label ID="Label1" runat="server" style="font-size: 20px; font-family: Bahnschrift"></asp:Label>
      <br />
        <p class="text-center">
            &nbsp;</p>
        <p></p>
        <div class="auto-style8">

			<%
                decimal OrderTotal = 0;
                Int32 Index = 0;
                Int32 Count = MyCart.Products.Count;

					  %>

	
			
			<table border="1" class="auto-style2" style="font-size: larger; width: 100%; text-align:center;">
						   <tr><% 

						%><td style="font-weight:bold" class="auto-style13"><%
											 Response.Write("Product Id"); 
						%></td><%
							   
						%><td style="font-weight:bold; text-align:center" class="auto-style13"><%
						 Response.Write("Product Name");
						 %></td><%

						 %><td style="font-weight:bold; text-align:center" class="auto-style13"><%
						 Response.Write("Quantity");
						 %></td><%

									 %><td style="font-weight:bold; text-align:center; width: 102px;" class="auto-style13"><%
						 Response.Write("Unit Price");
						 %></td><%
									 %><td style="font-weight:bold; text-align:center; width: 96px;" class="auto-style13"><%
						 Response.Write("Total Price");
						 %></td><%

									 %><td style="font-weight:bold; text-align:center; width: 78px;" class="modal-sm"><%
						 Response.Write("");
						 %></td><%

					   %></tr>
						  
						  <%
						
					  while(Index<Count)
					  {
						%>
						<tr>

						<td class="auto-style10"><%Response.Write(MyCart.Products[Index].InventoryId);%></td>
					    <td class="auto-style10"><%Response.Write(MyCart.Products[Index].Name);%></td>
					    <td class="auto-style10"><%Response.Write(MyCart.Products[Index].QTY);%></td>
					    <td class="auto-style10" style="width: 102px"><%Response.Write(MyCart.Products[Index].Price);%></td>
						<td class="auto-style10" style="width: 96px"><%Response.Write(MyCart.Products[Index].TotalPrice);%></td>
						<% OrderTotal = OrderTotal + MyCart.Products[Index].TotalPrice;%>
						
						<td class="modal-sm" style="width: 78px">
						<a href="RemoveCartItem.aspx?Index=<% Response.Write(Index);%>">
						<span class="auto-style7"><%Response.Write("Remove Item");%></span></a>
						</td>
						
						</tr>

						<%
						  Index++;
						}

						%></table>
			
						<%
							Session["Ordertotal"] = OrderTotal;
							txtOrderTotal.Text = OrderTotal.ToString();
						%>

			<br />
			<div style="float:right;">
			  <asp:Label runat="server" style="font-weight:700; font-size:medium;">SubTotal: </asp:Label><asp:TextBox ID="txtOrderTotal" runat="server" ReadOnly="True" CssClass="auto-style13" BackColor="#333333" ForeColor="White"></asp:TextBox>
						 <br /><br />
		   </div>
			<br />
			<br />
			<p></p>
				<div style="text-align:center; font-size: larger; font-weight:600;">
				<asp:HyperLink ID="hypBrowseProducts" runat="server" NavigateUrl="~/Product.aspx" CssClass="auto-style12" BorderStyle="solid" >Continue Shopping</asp:HyperLink>
				&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
				<asp:HyperLink ID="hypCheckOut" runat="server" NavigateUrl="~/Payment.aspx" CssClass="auto-style12" BorderStyle="solid">CheckOut</asp:HyperLink>
		        </div>

		
			  
			<br />
 
	  
			<br />
			<br />
	   
		</div>
	</asp:Content>
