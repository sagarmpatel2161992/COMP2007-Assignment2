<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="station.aspx.cs" Inherits="BusTravelPlanner.admin.station" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Station Details</h1>

        <div>
            <label for="txtStation">Station Name:</label>
            <asp:TextBox ID="txtStation" runat="server" required MaxLength="50" />
        </div>        
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
        </div>
    </div>

</asp:Content>
