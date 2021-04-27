<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowCustomerDetails.aspx.cs" Inherits="FrontEnd.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%@ Import Namespace="ClassLibrary"%> 



    <%
        clsCustomerCollection MyCustomers = new clsCustomerCollection();  
        Int32 Index = 0;
        Int32 RecordCount = MyCustomers.Count; 
        
        %>
    <table class="nav-justified">
        <tr>
            <td class="text-left" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" colspan="2">
                <asp:Label ID="Label1" runat="server" style="font-family: Arial; font-size: 25pt" Text="Profile Name: "></asp:Label>
                <asp:Label ID="lblCustomerName" runat="server" Font-Size="X-Large" style="font-family: Arial; font-size: 35pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Your Profile Id</td>
            <td class="text-left">
                <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Phonenum:</td>
            <td>
                <asp:TextBox ID="txtPhonenum" runat="server" ReadOnly="True" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Email: </td>
            <td class="text-left">
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Account Created</td>
            <td class="text-left">
                <asp:TextBox ID="txtDateJoined" runat="server" ReadOnly="True" style="margin-left: 0"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">Your Account Balance: </td>
            <td class="text-left">
                <asp:TextBox ID="txtAccountBalance" runat="server" ReadOnly="True" style="margin-left: 0"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">
                Your Bio Description<br />
                <br />
                <asp:TextBox ID="txtBio" runat="server" ReadOnly="True" style="margin-left: 0; resize: none" TextMode="MultiLine" Height="100px" Width="287px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 206px">&nbsp;</td>
            <td class="text-left"> 
                        
                           <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Go back to Profile Manage Menu" />
            </td>
        </tr>
    </table>
</asp:Content>
