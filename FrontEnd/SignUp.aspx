<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FrontEnd.SignUp"%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       


    <table class="nav-justified">
        <tr>
            <td style="width: 513px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="3" style="font-size: xx-large">Sign Up</td>
        </tr>
        <tr>
            <td style="width: 513px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Email Address</td>
            <td>&nbsp;
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Password</td>
            <td>&nbsp;
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Confirm Password</td>
            <td>&nbsp;
                <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: x-large; width: 513px">Enter your Personal Details Below</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: x-large; width: 513px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Name</td>
            <td>
                &nbsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Phonenum</td>
            <td>
                &nbsp;
            <asp:TextBox ID="txtPhonenum" runat="server"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Tell us About Yourself</td>
            <td>
                &nbsp;
            <asp:TextBox ID="txtBio" runat="server" Height="75px" TextMode="MultiLine" Width="233px" style="resize:none"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">Free £50 Balance added</td>
            <td>
                &nbsp;
            <asp:TextBox ID="txtAccountBalance" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="font-family: Arial; font-weight: bold; font-size: medium; " colspan="2">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="font-family: Arial; font-weight: bold; font-size: medium; width: 513px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click1" Text="Sign Up" />
                <asp:Button ID="btnView" runat="server" OnClick="btnView_Click1" Text="View Email" />
                <asp:Button ID="btnReSend" runat="server" OnClick="btnReSend_Click1" Text="Re-Set Password" />
                <asp:Button ID="btnDone" runat="server" OnClick="btnDone_Click1" Text="Done" />
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 513px">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 513px">&nbsp;</td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 513px">&nbsp;</td>
            <td>
          &nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
