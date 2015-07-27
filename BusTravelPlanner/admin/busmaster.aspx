<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="busmaster.aspx.cs" Inherits="BusTravelPlanner.admin.busmaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Bus Details</h1>

        <div>
            <label for="txtBusno" >Bus No:</label>
            <asp:TextBox ID="txtBusno" runat="server" required MaxLength="50" />
        </div>
        <div>            
            <label for="ddlBustype">Bus Type:</label>
            <asp:DropDownList ID="ddlBustype" runat="server"  
                 DataTextField="BUS_TYPE" DataValueField="BUSTYPE_ID"></asp:DropDownList>        
        </div>        

        <div>            
            <label for="ddlSource">Source Station Name:</label>
            <asp:DropDownList ID="ddlSource" runat="server" 
                 DataTextField="STATION_NAME" DataValueField="STATION_ID"></asp:DropDownList>        
        </div>        

        <div>            
            <label for="ddlDestination">Destination Station Name:</label>
            <asp:DropDownList ID="ddlDestination" runat="server"  
                 DataTextField="STATION_NAME" DataValueField="STATION_ID"></asp:DropDownList>        
        </div>        

        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
        </div>
    </div>

</asp:Content>
