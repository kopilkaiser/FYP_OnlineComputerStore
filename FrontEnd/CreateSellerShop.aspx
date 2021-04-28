<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateSellerShop.aspx.cs" Inherits="FrontEnd.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="header"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Open Your Shop</span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2">Add Shop Details below:<br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 386px">Email</td>
                <td>
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 386px">Your Full Name </td>
                <td>
            <asp:TextBox ID="txtSellerName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 386px"><br />Shop Name</td>
                <td>
                    <br />
            <asp:TextBox ID="txtShopName" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 45px; width: 386px;">
                    <br />
                    Rating</td>
                <td style="height: 45px">
                    <br />
                    <asp:DropDownList ID="DDListProductName0" runat="server" Height="16px" Width="58px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">Date of Opening</td>
                <td>
            <asp:TextBox ID="txtDateOpened" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px"><br /></td>
                <td>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
            <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>
            <asp:Button ID="btnCreateShop" runat="server" OnClick="btnCreateShop_Click" Text="Create My Shop" />
            <asp:Button ID="btnAddSellerProduct" runat="server" OnClick="btnAddSellerProduct_Click" Text="Add Product to Shop" Visible="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    
</asp:Content>
