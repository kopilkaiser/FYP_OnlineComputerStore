<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAReview.aspx.cs" Inherits="FrontEnd.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div id="header" class="text-center"><span style="font-family: Arial; font-size: 30pt; text-transform: uppercase; letter-spacing: 3px">Review Details</span><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px"><br />
                </span><span style="font-family: Arial; font-size: 22pt; letter-spacing: 3px" class="text-uppercase">Review Id:</span><span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px"> <strong>
                <asp:Label ID="lblReviewId" runat="server" style="font-size: 20pt; color: #800000" Text="Label"></asp:Label>
                </strong></span></div>    
   
    <br />
    <div>
        <table class="nav-justified">
            <tr>
                <td class="text-left" colspan="2"><br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right">Reviewed By</td>
                <td>
            &nbsp;
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 386px"><br /></td>
                <td>
                    <br />
                    <span style="font-family: Arial; font-size: medium"><strong>Review Description</strong></span><span style="font-family: Arial; font-size: large"> </span>
                    <br />
            <asp:TextBox ID="txtDescription" runat="server" Height="92px" TextMode="MultiLine" Width="293px" style="resize:none" ReadOnly="True"></asp:TextBox>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 45px; width: 386px;" class="text-right">
                    <br />
                    ProductId</td>
                <td style="height: 45px">
                    <br />
            &nbsp; <asp:TextBox ID="txtProductId" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right">
                    <br />
                    Date Reviewed</td>
                <td>
                    <br />
            &nbsp;
            <asp:TextBox ID="txtDateReviewed" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px" class="text-right"><br />Review Ratings</td>
                <td>
                    <br />
            &nbsp;
            <asp:TextBox ID="txtRating" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 386px; height: 20px;">
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
                <td style="width: 386px">&nbsp;</td>
                <td>
            <asp:Button ID="btnGoBackToReviews" runat="server" OnClick="btnSave_Click" Text="Go Back To All Reviews" />
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
