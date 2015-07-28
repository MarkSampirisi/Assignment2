<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site.Master" CodeBehind="checkin.aspx.cs" Inherits="Assignment2.admin.checkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Customer Details</h1>

        <h5>All fields are required. Maximum length of stay is 28 days.</h5>

    <fieldset>
        <label for="txtLastName" class="col-sm-2">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtFirstName" class="col-sm-2">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required MaxLength="50" />
    </fieldset>


        <fieldset>
         <label for="txtDaysStaying" class="col-sm-2">Length of Stay (In Days):</label>
        <asp:TextBox ID="txtDaysStaying" runat="server" required MaxLength="2" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Max 28 Days"
            ControlToValidate="txtDaysStaying" CssClass="alert alert-danger" Type="Integer"
            MinimumValue="1" MaximumValue="28"></asp:RangeValidator>
    </fieldset>
        <div class="col-sm-2 col-sm-offset-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
        </div>
    </div>

</asp:Content>