<%@ Page Title="Main Menu" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="main-menu.aspx.cs" Inherits="Assignment2.main_menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Main Menu</h1>


    <div class="well">
        <h3>Room Details</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="rooms.aspx">View Room Details</a></li>
            <li class="list-group-item"><a href="room.aspx">Add Room</a></li>
        </ul>
    </div>

        <div class="well">
        <h3>Booking Details</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="bookings.aspx">View Booking Details</a></li>
        </ul>
    </div>

</asp:Content>
