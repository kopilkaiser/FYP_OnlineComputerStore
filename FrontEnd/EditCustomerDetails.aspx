<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCustomerDetails.aspx.cs" Inherits="FrontEnd.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <%@ Import Namespace="ClassLibrary"%> 



                <div ID="PageTitle" class="text-center">  <span style="font-family: Arial; font-size: xx-large; text-transform: uppercase; letter-spacing: 3px">Edit Your Profile</span><br /><br /></div>
        <table class="nav-justified">
        <tr>
            <td class="text-left" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                <strong>
                <asp:Label ID="Label1" runat="server" style="font-family: Arial; font-size: 20pt" Text="Profile Name: "></asp:Label>
                </strong>
                <asp:TextBox ID="txtName" runat="server" BorderStyle="None" Font-Size="20pt" ReadOnly="True" Font-Underline="False" style="text-decoration: underline"></asp:TextBox>
                <br />
                <span style="font-size: 12pt"><strong>Your Account id</strong></span><span style="font-size: 15pt">:
                <asp:TextBox ID="txtCustomerId" runat="server" BorderStyle="None" Font-Size="12pt" ReadOnly="True"></asp:TextBox>
                </span>
            </td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                Please fill up the following fields below to update your existing Profile details:</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px; height: 22px;">New Profile Name:</td>
            <td class="text-left" style="height: 22px">
                &nbsp;
                <asp:TextBox ID="txtNewName" runat="server" Width="177px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">
                <br />
                Phonenum:</td>
            <td>
                &nbsp;
                <br />
&nbsp;<asp:TextBox ID="txtPhonenum" runat="server" style="margin-left: 0" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">
                <br />
                Email: </td>
            <td class="text-left">
                &nbsp;
                <br />
&nbsp;<asp:TextBox ID="txtEmail" runat="server" style="margin-left: 0" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">Account Update Date </td>
            <td class="text-left">
                &nbsp;
                <asp:TextBox ID="txtDateJoined" runat="server" style="margin-left: 0" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">
                <br />
                Your Account Balance: </td>
            <td class="text-left">
                &nbsp;
                <br />
&nbsp;<asp:TextBox ID="txtAccountBalance" runat="server" style="margin-left: 0" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-right" style="width: 206px">Bio Description </td>
            <td class="text-left">
                <br />
&nbsp;<asp:TextBox ID="txtBio" runat="server" style="margin-left: 0; resize: none" TextMode="MultiLine" Height="74px" Width="319px"></asp:TextBox>
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
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
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
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnViewProfile" runat="server" Text="Go Back Profile Manage Menu" OnClick="btnViewProfile_Click" />

            </td>
        </tr>
    </table>
</asp:Content>
