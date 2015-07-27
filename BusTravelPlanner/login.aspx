<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BusTravelPlanner.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <div>
        <asp:Label ID="lblStatus" runat="server"/>
    </div>

    <div class="form-group">
        <label for="txtUsername">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" />
    </div>
    <div>
        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login"
             OnClick="btnLogin_Click" />
    </div>

</asp:Content>
