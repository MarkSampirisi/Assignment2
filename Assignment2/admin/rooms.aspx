<%@ Page Title="Room Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="rooms.aspx.cs" Inherits="Assignment2.admin.rooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Room Details</h1>
    <a href="room.aspx">Add Room</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">   
            <asp:ListItem Value="5" Text="5" />         
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="999999" Text="All" />
        </asp:DropDownList>
    </div>

    <asp:GridView ID="grdRooms" runat="server" AutoGenerateColumns="false" DataKeyNames="RoomID"
         CssClass="table table-striped table-hover" OnRowDeleting="grdRooms_RowDeleting"
         AllowPaging="true" PageSize="10" OnPageIndexChanging="grdRooms_PageIndexChanging"
         AllowSorting="true" OnSorting="grdRooms_Sorting" OnRowDataBound="grdRooms_RowDataBound">
        <Columns>
            <asp:BoundField DataField="RoomID" HeaderText="Room Number" SortExpression="RoomID" />
            <asp:BoundField DataField="Size" HeaderText="Room Size" SortExpression="Size" />
            <asp:BoundField DataField="CostPerDay" HeaderText="Cost Per Day" SortExpression="CostPerDay" DataFormatString="{0:c}" />
            <asp:BoundField DataField="Availability" HeaderText="Availability" SortExpression="Availability" />
            <asp:HyperLinkField Text="Check In" NavigateUrl="checkin.aspx" DataNavigateUrlFields="RoomID"
                 DataNavigateUrlFormatString="checkin.aspx?RoomID={0}" HeaderText="Check Customer In" />
            <asp:HyperLinkField Text="Edit" NavigateUrl="room.aspx" DataNavigateUrlFields="RoomID"
                 DataNavigateUrlFormatString="room.aspx?RoomID={0}" HeaderText="Edit" />
            
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
