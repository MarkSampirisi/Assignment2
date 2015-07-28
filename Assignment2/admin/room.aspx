<%@ Page Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="room.aspx.cs" Inherits="Assignment2.admin.room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Room Details</h1>

        <div>
        <label for="ddlRoomSize">Room Size:</label>
        <asp:DropDownList ID="ddlRoomSize" runat="server" AutoPostBack="false">
            <asp:ListItem Value="Small" Text="Small" />
            <asp:ListItem Value="Medium" Text="Medium" />
            <asp:ListItem Value="Large" Text="Large" />
        </asp:DropDownList>
    </div>

        <div class="form-group">
            <label for="txtCostPerDay" class="control-label col-sm-2">Cost Per Day:</label>
            <asp:TextBox ID="txtCostPerDay" runat="server" required TextMode="Number" />
        </div>

        <div class="col-sm-2 col-sm-offset-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
        </div>
    </div>

</asp:Content>