<%@ Page Language="C#" Title="Booking Details" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="bookings.aspx.cs" Inherits="Assignment2.admin.bookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Current Bookings</h1>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
             OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="5" Text="5" />         
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="999999" Text="All" />
        </asp:DropDownList>
    </div>

    <asp:GridView ID="grdBookings" runat="server" AutoGenerateColumns="false" DataKeyNames="BookingID"
         CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdBookings_PageIndexChanging"
         AllowSorting="true" OnSorting="grdBookings_Sorting" OnRowDataBound="grdBookings_RowDataBound">
        <Columns>
            <asp:BoundField DataField="RoomID" HeaderText="Room Number" SortExpression="RoomID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="Size" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="CostPerDay" />
            <asp:BoundField DataField="DaysStaying" HeaderText="Length of Stay (In Days)" SortExpression="Availability" />
            <asp:BoundField DataField="BookDate" HeaderText="Book Date" SortExpression="BookDate" />
            <asp:HyperLinkField Text="Check Out" NavigateUrl="room.aspx" DataNavigateUrlFields="RoomID"
                 DataNavigateUrlFormatString="checkout.aspx?RoomID={0}" HeaderText="Check Customer Out" />            

        </Columns>
    </asp:GridView>
</asp:Content>
