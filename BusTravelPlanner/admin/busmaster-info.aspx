<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="busmaster-info.aspx.cs" Inherits="BusTravelPlanner.admin.busmaster_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bus Information</h1>
    <a href="busmaster.aspx">Add BusInformation</a>

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
        <asp:GridView ID="grdBus" runat="server" AutoGenerateColumns="false" DataKeyNames="BUS_ID" 
            OnRowDeleting="grdBus_RowDeleting" AllowPaging="true" OnPageIndexChanging="grdBus_PageIndexChanging" 
            PageSize="3" AllowSorting="true" OnSorting="grdBus_Sorting" OnRowDataBound="grdBus_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="BUS_ID" HeaderText="Bus ID" SortExpression="BUS_ID" />
            <asp:BoundField DataField="BUS_NO" HeaderText="Bus No" SortExpression="BUS_NO" />            
            <asp:BoundField DataField="BUS_TYPE" HeaderText="Bus Type" SortExpression="BUS_TYPE" />            
            <asp:BoundField DataField="s1" HeaderText="Source Station Name" SortExpression="s1" />            
            <asp:BoundField DataField="s2" HeaderText="Destination Station Name" SortExpression="s2" />            
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/admin/busmaster.aspx" 
                DataNavigateUrlFields="BUS_ID" DataNavigateUrlFormatString="~/admin/busmaster.aspx?BUS_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
