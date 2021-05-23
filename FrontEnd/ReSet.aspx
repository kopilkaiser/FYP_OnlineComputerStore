<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReSet.aspx.cs" Inherits="FrontEnd.ReSet " %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
        <h1>Re-Set Password<br />
        </h1>
        <asp:Label ID="lblEMail" runat="server" Text="E Mail Address"></asp:Label>
        &nbsp;<asp:TextBox ID="txtEMail" runat="server" Width="283px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        &nbsp;</div>
    &nbsp;&nbsp;<asp:Button ID="btnReSet" runat="server" OnClick="btnReSet_Click" Text="Re-Set Password" />
&nbsp;<asp:Button ID="btnDone" runat="server" OnClick="btnDone_Click" Text="Done" />
    &nbsp;<asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View Email" />
    </div>
</asp:Content>
