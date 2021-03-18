<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="FrontEnd.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <h1>Change Password<br />
        </h1>
        <table style="width:100%;">
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCurrentPassword" runat="server" style="margin-left: 0px" TextMode="Password" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" width="283px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change Password" />
    &nbsp;<asp:Button ID="btnDone" runat="server" OnClick="btnCancel_Click" Text="Done" />
</asp:Content>
