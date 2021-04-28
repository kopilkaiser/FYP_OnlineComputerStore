<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateSellerProduct.aspx.cs" Inherits="FrontEnd.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="header"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Update Your Product</span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2">Update existing Product Details below:<br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>&nbsp;</td>
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

                <td style="width: 386px"><br />Product Name<br />
                    New Product Name</td>
                <td>
            <asp:TextBox ID="txtProductName" runat="server" BackColor="#333333" ForeColor="White" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:DropDownList ID="DDListProductName" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Samsung TV</asp:ListItem>
                        <asp:ListItem>LG TV</asp:ListItem>
                        <asp:ListItem>Apple iMAC</asp:ListItem>
                        <asp:ListItem>iPad Pro 2021</asp:ListItem>
                        <asp:ListItem>iPhone 12 MAX PRO</asp:ListItem>
                        <asp:ListItem>Alienware Gaming Desktop</asp:ListItem>
                        <asp:ListItem>SoundCore Boom Speaker</asp:ListItem>
                    </asp:DropDownList>
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
                <td style="height: 45px; width: 386px;">Existing Price<br />
                    Enter new Price here</td>
                <td style="height: 45px">
            <asp:TextBox ID="txtPrice" runat="server" BackColor="#333333" ForeColor="White" ReadOnly="True"></asp:TextBox>
                &nbsp;<br />
            <asp:TextBox ID="txtNewPrice" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 386px;">&nbsp;</td>
                <td style="height: 45px">
                    &nbsp;</td>
                <td style="height: 45px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">Update Description here</td>
                <td>
            <asp:TextBox ID="txtDescription" runat="server" Height="88px" TextMode="MultiLine" Width="273px" style="resize:none"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px"><br />Enter New Quantity
                    <br />
                    </td>
                <td>
                    <br />
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Product Details" />
            <asp:Button ID="btnGoBackShop" runat="server" OnClick="btnGoBackShop_Click" Text="Go Back to My Shop" />
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
