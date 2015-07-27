<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BusTravelPlanner.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Register</h1>
    <h6>All fields are required</h6>

    <div>
        <asp:label id="lblStatus" runat="server"/>
    </div>

    <div>
        <label for="txtUsername">Username:</label>
        <asp:textbox id="txtUsername" runat="server" />
    </div>
    <div>
        <label for="txtPassword">Password:</label>
        <asp:textbox id="txtPassword" runat="server" textmode="password" />
    </div>
    <div>
        <label for="txtConfirm" >Confirm:</label>
        <asp:textbox id="txtConfirm" runat="server" textmode="password"></asp:textbox>
        <asp:comparevalidator runat="server" controltovalidate="txtPassword" controltocompare="txtConfirm"
            operator="Equal" errormessage="Passwords must match"/>
    </div>
    <div>
        <asp:button id="btnRegister" runat="server" text="Register" cssclass="btn btn-primary" 
            OnClick="btnRegister_Click" />
    </div>

</asp:Content>
