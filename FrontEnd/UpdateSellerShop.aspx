<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateSellerShop.aspx.cs" Inherits="FrontEnd.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div id="header"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Update Your Shop Details</span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-center" colspan="2"><span style="font-size: 20px">&nbsp;&nbsp;&nbsp; Update existing Shop Details below:</span><br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="text-right">Shop ID</td>
                <td>&nbsp;
            <asp:TextBox ID="txtShopId" runat="server" ReadOnly="True" BackColor="Black" ForeColor="White" Width="157px"></asp:TextBox>
                    </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 550px" class="text-right">Email</td>
                <td>
            &nbsp;
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" BackColor="Black" ForeColor="White" Width="202px"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 550px; height: 20px;"></td>
                <td style="height: 20px">
                </td>
                <td style="height: 20px"></td>
            </tr>

            <tr>
                <td style="width: 550px" class="text-right">Rating </td>
                <td>
            &nbsp;
            <asp:TextBox ID="txtRating" runat="server" ReadOnly="True" BackColor="Black" ForeColor="White" Width="65px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 550px" class="text-right">Old Shop Name<br />
                    Enter
                    New Shop Name here</td>
                <td>
            &nbsp;
            <asp:TextBox ID="txtOldShopName" runat="server" BackColor="#333333" ForeColor="White" ReadOnly="True"></asp:TextBox>
                    <br />
&nbsp;<asp:TextBox ID="txtNewShopName" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 45px; width: 550px;" class="text-right">Old Seller Name<br />
                    Enter New Seller Name here</td>
                <td style="height: 45px">
            &nbsp;
            <asp:TextBox ID="txtOldSellerName" runat="server" BackColor="#333333" ForeColor="White" ReadOnly="True"></asp:TextBox>
                &nbsp;<br />
            &nbsp;<asp:TextBox ID="txtNewSellerName" runat="server"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 550px;" class="modal-sm"></td>
                <td style="height: 17px">
                    </td>
                <td style="height: 17px"></td>
            </tr>
            <tr>
                <td style="width: 550px" class="text-right">Shop Opened Date</td>
                <td>
            &nbsp;
            <asp:TextBox ID="txtDateOpened" runat="server" ReadOnly="True" BackColor="Black" ForeColor="White" Width="202px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="modal-sm">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="text-right">
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Shop Details" Height="31px" Width="215px" />
                </td>
                <td>
            &nbsp;
            <asp:Button ID="btnGoBackShop" runat="server" OnClick="btnGoBackShop_Click" Text="Back to Manage Shop" Height="31px" Width="215px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 550px" class="modal-sm">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
