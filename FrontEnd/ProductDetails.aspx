<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="FrontEnd.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <%@ Import Namespace="ClassLibrary"%>


          <article style="justify-content:center;">
   

       
           </article>
    <div>

        <table class="nav-justified">
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
        
                           <strong>
                           <asp:Label ID="Label1" runat="server" Text="Name" CssClass="auto-style10"></asp:Label>
                           </strong></td>
                <td>&nbsp; <asp:TextBox ID="txtName" runat="server" ReadOnly="True" CssClass="auto-style12" BackColor="#333333" ForeColor="White" Height="28px" Width="178px"></asp:TextBox>
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
                           <strong>
                           <br />
        <asp:Label ID="Label3" runat="server" Text="Price" CssClass="auto-style10"></asp:Label>
                           </strong></td>
                <td>&nbsp; 
                    <br />
&nbsp; <asp:TextBox ID="txtPrice" runat="server" ReadOnly="True" CssClass="auto-style13" BackColor="#333333" ForeColor="White" Height="26px" Width="145px"></asp:TextBox>
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
                           <strong>
                           <br />
                           Select
        <asp:Label ID="Label2" runat="server" Text="Quantity" CssClass="auto-style10"></asp:Label>
                           </strong></td>
                <td>&nbsp; 
                    <br />
&nbsp; <asp:TextBox ID="txtQuantity" runat="server" CssClass="auto-style14">1</asp:TextBox>
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
               <strong>
                    Product
        <asp:Label ID="Label4" runat="server" Text="Description" CssClass="auto-style10"></asp:Label>
                           </strong></td>
                <td>&nbsp; <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True" CssClass="auto-style13" BackColor="#333333" ForeColor="White" Height="112px" Width="339px" TextMode="MultiLine" style="resize:none"></asp:TextBox>
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-right">
                    <asp:CheckBox ID="chkAge" runat="server" />
                </td>
                <td>&nbsp;&nbsp;<asp:Label ID="lblError" runat="server"></asp:Label>
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td class="text-left" colspan="2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="modal-sm" style="width: 268px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
        <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Add to Cart" CssClass="auto-style3" Height="40px" Width="151px" />
   

       
                           </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
