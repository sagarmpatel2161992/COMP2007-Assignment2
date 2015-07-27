<%@ Page Title="" Language="C#" MasterPageFile="~/travelPlanner.Master" AutoEventWireup="true" CodeBehind="bustype-info.aspx.cs" Inherits="BusTravelPlanner.admin.bustype_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>BusType Information</h1>
    <a href="bustype.aspx">Add BusType</a>

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
        <asp:GridView ID="grdBustype" runat="server" AutoGenerateColumns="false" DataKeyNames="BUSTYPE_ID" 
            OnRowDeleting="grdBustype_RowDeleting" AllowPaging="true" OnPageIndexChanging="grdBustype_PageIndexChanging" 
            PageSize="3" AllowSorting="true" OnSorting="grdBustype_Sorting" OnRowDataBound="grdBustype_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="BUSTYPE_ID" HeaderText="BusType ID" SortExpression="BUSTYPE_ID" />
            <asp:BoundField DataField="BUS_TYPE" HeaderText="Bus Type" SortExpression="BUS_TYPE" />            
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/admin/bustype.aspx.cs" 
                DataNavigateUrlFields="BUSTYPE_ID" DataNavigateUrlFormatString="~/admin/bustype.aspx?BUSTYPE_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
