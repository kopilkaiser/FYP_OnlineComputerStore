<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSellerProduct.aspx.cs" Inherits="FrontEnd.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="header"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Add Product to Market</span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2">Add Product Details below:<br />
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

                <td style="width: 386px"><br />Product Name</td>
                <td>
                    <br />
                    <asp:DropDownList ID="DDListProductName" runat="server">
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
                <td style="height: 45px; width: 386px;">Price</td>
                <td style="height: 45px">
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 386px">Product Description</td>
                <td>
            <asp:TextBox ID="txtDescription" runat="server" Height="58px" TextMode="MultiLine" Width="227px" style="resize:none"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px"><br />How much Quantity
                    <br />
                    Available?</td>
                <td>
                    <br />
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px; height: 40px;">
                    <br />
                    Turn on Age Verification(Tick box if &quot;Yes&quot;)</td>
                <td style="height: 40px">
                    <asp:CheckBox ID="chkVerifyAge" runat="server" />
                </td>
                <td style="height: 40px"></td>
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
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add Products to the Market" />
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
