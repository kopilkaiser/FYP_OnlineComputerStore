<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="FrontEnd.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <%@ Import Namespace="ClassLibrary"%>


          <article style="justify-content:center;">
         <div class="auto-style11" style="text-align:center">

               <%     clsInventoryCollection MyInventories = new clsInventoryCollection();
                      MyInventories.ReportByCategory("");
                      Int32 Index = 0;
                      Int32 RecordCount = MyInventories.Count; %>
        
                           <strong>
                           <br />
                           <br />
                            <br />
               
               <br />
                           <asp:Label ID="Label1" runat="server" Text="Name" CssClass="auto-style10"></asp:Label>
                           </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server" ReadOnly="True" CssClass="auto-style12" BackColor="#333333" ForeColor="White"></asp:TextBox>
                           <br />
             <br />
                           <strong>
        <asp:Label ID="Label3" runat="server" Text="Price" CssClass="auto-style10"></asp:Label>
                           </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrice" runat="server" ReadOnly="True" CssClass="auto-style13" BackColor="#333333" ForeColor="White"></asp:TextBox>
                           <br />
                           <strong>
        <asp:Label ID="Label2" runat="server" Text="Quantity" CssClass="auto-style10"></asp:Label>
                           </strong>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtQuantity" runat="server" CssClass="auto-style14">1</asp:TextBox>
                           <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Add to Cart" CssClass="auto-style3" Height="40px" Width="151px" />
   

       
                           <br />
                           <br />
                           <br />
&nbsp;&nbsp;&nbsp;&nbsp;
           

       
             </div>
   

       
           </article>
</asp:Content>
