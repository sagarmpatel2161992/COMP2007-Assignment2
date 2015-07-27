<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="station-info.aspx.cs" Inherits="BusTravelPlanner.admin.station_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Station Information</h1>
    <a href="station.aspx">Add Station</a>

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
        <asp:GridView ID="grdStation" runat="server" AutoGenerateColumns="false" DataKeyNames="STATION_ID" 
            OnRowDeleting="grdStation_RowDeleting" AllowPaging="true" OnPageIndexChanging="grdStation_PageIndexChanging" 
            PageSize="3" AllowSorting="true" OnSorting="grdStation_Sorting" OnRowDataBound="grdStation_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="STATION_ID" HeaderText="Station ID" SortExpression="STATION_ID" />
            <asp:BoundField DataField="STATION_NAME" HeaderText="Station Name" SortExpression="STATION_NAME" />            
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/admin/station.aspx" 
                DataNavigateUrlFields="STATION_ID" DataNavigateUrlFormatString="~/admin/station.aspx?STATION_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
