<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewReview.aspx.cs" Inherits="FrontEnd.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="header" class="text-center"><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Add New Review</span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2">Fill up all the fields to add your Review<br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right">Email</td>
                <td>
            &nbsp; <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" Width="145px"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 386px" class="text-right">ProductId</td>
                <td>
            &nbsp; <asp:TextBox ID="txtProductId" runat="server" Width="72px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 386px"><br /></td>
                <td>
                    <br />
                    <span style="font-family: Arial; font-size: large; border-left-color: #A0A0A0; border-right-color: #C0C0C0; border-top-color: #A0A0A0; border-bottom-color: #C0C0C0">Write your Reivew here</span>
                    <br />
            <asp:TextBox ID="txtDescription" runat="server" Height="92px" TextMode="MultiLine" Width="293px" style="resize:none"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 45px; width: 386px;" class="text-right">
                    <br />
                    </td>
                <td style="height: 45px">
                    <br />
            &nbsp;</td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right">
                    <br />
                    Review Date</td>
                <td>
                    <br />
            &nbsp;<asp:TextBox ID="txtDateReviewed" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right"><br />Choose a Rating (1 to 5)</td>
                <td>
                    <br />
                    &nbsp;<asp:DropDownList ID="DDListRating" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
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
                <td style="width: 386px">&nbsp;</td>
                <td>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit Review" />
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
