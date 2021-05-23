<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteSellerProduct.aspx.cs" Inherits="FrontEnd.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="nav-justified">
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2">Are you sure to Delete the following Product from your Shop?</td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 655px; height: 20px; font-family: Arial; font-size: 20px;">Product ID: <strong>
                <asp:Label ID="lblProductId" runat="server"></asp:Label>
                </strong></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 655px; font-size: 20px;">Product Name:
                <asp:Label ID="lblProductName" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 655px">
                <asp:Button ID="btnBackToShop" runat="server" OnClick="btnBackToShop_Click" Text="Go Back to Shop" Font-Size="18px" />
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete the Product" BackColor="#990000" Font-Size="18px" ForeColor="White" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
