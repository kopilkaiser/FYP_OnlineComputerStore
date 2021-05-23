<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentComplete.aspx.cs" Inherits="FrontEnd.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="font-family: Arial; font-size: x-large" class="text-center">
        Congratulations. Your Payment has been successful!</p>
    <p>
        <span style="font-family: Arial; font-size: large">Your order has been placed successfully and <em>will be shipped in 5-6 working days</em>. <strong>Click</strong> </span>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/OrderHistory.aspx" Font-Size="20px">[View My Order]</asp:HyperLink>
&nbsp;<strong>to show your placed Order details</strong>.</p>
    <p>
        <span style="font-family: Arial; font-size: large">Thank you for shopping with us</span>.</p>
    <p style="font-family: Arial; font-size: medium" class="text-center">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" BackColor="#99CCFF" BorderColor="#CCCCFF" BorderStyle="Solid" Font-Italic="True" Font-Size="18px" ForeColor="Black">Go Back to Home Page</asp:HyperLink>
        &nbsp;</p>
</asp:Content>
