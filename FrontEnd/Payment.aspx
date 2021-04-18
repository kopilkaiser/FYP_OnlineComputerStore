<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="FrontEnd.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td class="text-center" colspan="2">&nbsp;</td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="4">Payment Process&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 402px">&nbsp;</td>
            <td style="width: 508px">Enter Shipping Details here:<br />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">
                <br />
                <br />
                <br />
            </td>
            <td class="text-left" style="width: 402px">&nbsp;
                <br />
                <br />
                <br />
&nbsp;</td>
            <td style="width: 508px; border-style: double; border-width: 3px">Street Address <asp:TextBox ID="txtStreet" runat="server" Height="24px" style="margin-bottom: 0" Width="180px"></asp:TextBox>
                <br />
                Post Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPostCode" runat="server" Height="21px" style="margin-bottom: 0" Width="180px"></asp:TextBox>
                <br />
                City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCity" runat="server" Height="22px" style="margin-bottom: 0" Width="178px"></asp:TextBox>
                <br />
                Phonenum&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPhonenum" runat="server" Height="20px" style="margin-bottom: 0" Width="176px"></asp:TextBox>
            </td>
            <td>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">Full Name</td>
            <td style="width: 508px">&nbsp;
                <asp:TextBox ID="txtName" runat="server" style="margin-left: 389"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 22px"></td>
            <td class="text-right" style="height: 22px">Amount to be Paid</td>
            <td style="height: 22px; width: 402px">&nbsp;
                <asp:TextBox ID="txtOrderTotal" runat="server" style="margin-left: 389"></asp:TextBox>
            </td>
            <td style="height: 22px; width: 508px"></td>
        </tr>
        <tr>
            <td style="height: 20px"></td>
            <td class="text-right" style="height: 20px">Card No</td>
            <td style="height: 20px; width: 402px">&nbsp;
                <asp:TextBox ID="txtCardNumber" runat="server" style="margin-left: 389"></asp:TextBox>
            </td>
            <td style="height: 20px; width: 508px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">Email</td>
            <td style="width: 402px">&nbsp;
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" style="margin-left: 389"></asp:TextBox>
            </td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">Method</td>
            <td style="width: 402px">&nbsp;
                <asp:DropDownList ID="DDListMethod" runat="server">
                    <asp:ListItem>Visa Debit</asp:ListItem>
                    <asp:ListItem>Visa Credit</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">Payment Date</td>
            <td style="width: 402px">&nbsp;
                <asp:TextBox ID="txtDatePurchased" runat="server" ReadOnly="True" style="margin-left: 389"></asp:TextBox>
            </td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">&nbsp;</td>
            <td style="width: 402px">&nbsp;</td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-right">&nbsp;</td>
            <td style="width: 402px">
                <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check Out" />
            </td>
            <td style="width: 508px">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-left" colspan="3">
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
