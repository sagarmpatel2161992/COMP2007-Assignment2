<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="busschedule-info.aspx.cs" Inherits="BusTravelPlanner.admin.busschedule_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Bus Schedule Information</h1>
    <a href="busschedule.aspx">Add BusSchedule</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
        </asp:DropDownList>
    </div>

    <div>
        <asp:GridView ID="grdSchedule" runat="server" AutoGenerateColumns="false" DataKeyNames="SCHEDULE_ID" 
            OnRowDeleting="grdSchedule_RowDeleting" AllowPaging="true" OnPageIndexChanging="grdSchedule_PageIndexChanging" 
            PageSize="3" AllowSorting="true" OnSorting="grdSchedule_Sorting" OnRowDataBound="grdSchedule_RowDataBound" >    
        <Columns>
            <asp:BoundField DataField="SCHEDULE_ID" HeaderText="Schedule ID" SortExpression="SCHEDULE_ID" />
            <asp:BoundField DataField="BUS_NO" HeaderText="Bus No" SortExpression="BUS_NO" />            
            <asp:BoundField DataField="DEPARTURE_TIME" HeaderText="Departure Time" SortExpression="DEPARTURE TIME" />            
            <asp:BoundField DataField="ARRIVAL_TIME" HeaderText="Arrival Name" SortExpression="ARRIVAL_TIME" />            
            <asp:BoundField DataField="SEAT_AVAILABILITY" HeaderText="Seat Availability" SortExpression="SEAT_AVAILABILITY" />            
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/admin/busschedule.aspx.cs" 
                DataNavigateUrlFields="SCHEDULE_ID" DataNavigateUrlFormatString="~/admin/busschedule.aspx?SCHEDULE_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    </div>

</asp:Content>
