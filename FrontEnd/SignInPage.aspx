<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignInPage.aspx.cs" Inherits="FrontEnd.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
       
        .newStyle1 {
            background-color: #C4E3F3;
            table-layout: auto;
            empty-cells: show;
        }
        .auto-style16 {
            width: 100%;
            
        }
        .auto-style17 {
            height: 17px;
        }
        .auto-style18 {
            text-align: right;
            font-size: large;
            width: 532px;
        }
        .auto-style19 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style20 {
            width: 532px;
        }
        .auto-style21 {
            height: 17px;
            width: 532px;
        }
    </style>
    <div>

        <table class="auto-style16">
            <tr>
                <td class="auto-style19" colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19" colspan="2">Sign In</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style20">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">Email</td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" Height="24px" Width="172px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">Password</td>
                <td>&nbsp;&nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" Height="23px" Width="172px" TabIndex="1" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">&nbsp;</td>
                <td class="auto-style17">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" Height="25px"  Width="70px" TabIndex="2" OnClick="btnSignIn_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="25px" Width="70px" TabIndex="3" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnReSend" runat="server" Text="Re-Set Password" Height="25px" Width="130px" TabIndex="4" OnClick="btnReSend_Click" />
                </td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style20">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    <div>


       


    </div>

</asp:Content>
