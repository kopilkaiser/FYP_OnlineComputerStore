<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupportReplies.aspx.cs" Inherits="FrontEnd.WebForm25" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div id="header" class="text-center"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Support Reply Details<br />
          </span><span style="font-family: Arial; font-size: 20pt; text-transform: uppercase; letter-spacing: 3px">Reply-Support Id :</span><strong>
          <asp:Label ID="lblReplySupportId" runat="server" style="font-family: Arial; font-size: 18pt; color: #800000" Text="Label"></asp:Label>
          </strong></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2"><br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 494px" class="text-right">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 494px" class="text-right">Email of User</td>
                <td>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" Width="256px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 494px" class="modal-lg"><br /></td>
                <td>
                    <br />
                    <span style="font-family: Arial; font-size: medium"><strong>Reply Description</strong></span><span style="font-family: Arial; font-size: large"> </span>
                    <br />
            <asp:TextBox ID="txtDescription" runat="server" Height="92px" TextMode="MultiLine" Width="293px" style="resize:none" ReadOnly="True"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 494px" class="text-right">
                    <br />
                    Date Replied</td>
                <td>
                    <br />
            &nbsp;
            <asp:TextBox ID="txtDateReplied" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 494px" class="text-right">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 494px; height: 20px;">
                    </td>
                <td style="height: 20px"></td>
                <td style="height: 20px"></td>
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
                <td style="width: 494px" class="modal-lg">&nbsp;</td>
                <td>
            <asp:Button ID="btnGoBackToSupportReplies" runat="server" OnClick="btnSave_Click" Text="Go Back to Support Replies" style="height: 26px" />
                &nbsp;
            <asp:Button ID="btnAddSupport" runat="server" OnClick="btnAddSupport_Click" Text="Write a New Support" style="height: 26px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 494px" class="modal-lg">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>
