<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteSellerShop.aspx.cs" Inherits="FrontEnd.WebForm23" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table class="nav-justified">
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="font-size: 22px">Are you sure to Delete the following Shop?</td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 16px; height: 21px;" class="text-center" colspan="2">Shop Name:
                <strong>
                <asp:Label ID="lblShopName" runat="server"></asp:Label>
                </strong>
            </td>

        </tr>
        <tr>
            <td style="width: 655px" class="text-center">&nbsp;</td>

            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: 15px;" class="text-center" colspan="2">Shop ID:
                <strong>
                <asp:Label ID="lblShopId" runat="server"></asp:Label>
                </strong>
            </td>

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
                <asp:Button ID="btnBackToShop" runat="server" OnClick="btnBackToShop_Click" Text="Back to Manage Shop" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete the Shop" />
            </td>
        </tr>
        <tr>
            <td style="width: 655px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
