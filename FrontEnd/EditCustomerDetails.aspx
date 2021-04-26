<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCustomerDetails.aspx.cs" Inherits="FrontEnd.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <%@ Import Namespace="ClassLibrary"%> 



                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Edit Profile</span><br /><br /></div>
        <table class="nav-justified">
        <tr>
            <td class="text-left" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                <asp:Label ID="Label1" runat="server" style="font-family: Arial; font-size: 25pt" Text="Profile Name: "></asp:Label>
                <asp:TextBox ID="txtName" runat="server" BorderStyle="None" Font-Size="20pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px; height: 22px;">Your Profile Id</td>
            <td class="text-left" style="height: 22px">
                <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>
                <asp:Label ID="lblCustomerId" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Phonenum:</td>
            <td>
                <asp:TextBox ID="txtPhonenum" runat="server" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Email: </td>
            <td class="text-left">
                <asp:TextBox ID="txtEmail" runat="server" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Account Created</td>
            <td class="text-left">
                <asp:TextBox ID="txtDateJoined" runat="server" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Your Account Balance: </td>
            <td class="text-left">
                <asp:TextBox ID="txtAccountBalance" runat="server" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Bio</td>
            <td class="text-left">
                <asp:TextBox ID="txtBio" runat="server" style="margin-left: 0; resize: none" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left"> 
                        
               <asp:Button ID="btnUpdate" runat="server" Text="Update My Profile" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
