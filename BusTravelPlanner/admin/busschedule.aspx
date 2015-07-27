<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="busschedule.aspx.cs" Inherits="BusTravelPlanner.admin.busschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Bus Schedule Details</h1>

        <div>
            <label for="ddlBus" >Bus No:</label>
            <asp:DropDownList ID="ddlBus" runat="server" 
                 DataTextField="BUS_NO" DataValueField="BUS_ID"></asp:DropDownList>        
        </div>

        <div>
            <label for="cldrDeparture" >Departure DateTime:</label>            
            <asp:Calendar ID="cldrDeparture" runat="server"></asp:Calendar>
        </div>

        <div>
            <label for="cldrArrival" >Arrival DateTime:</label>
            <asp:Calendar ID="cldrArrival" runat="server"></asp:Calendar>
        </div>

        <div>
            <label for="txtSeat" >Total Seat:</label>
            <asp:TextBox ID="txtSeat" runat="server" required TextMode="Number" />
        </div>

        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
        </div>
    </div>


</asp:Content>
