<%@ Page Title="Customer Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userHomePage.aspx.cs" Inherits="airlineBookingSystem.user_management.userHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-right">
        <asp:Label ID="userL" runat="server" Visible="true">no user</asp:Label>
        <asp:LinkButton ID="logoutButton" OnClick="logoutButton_Click" runat="server">Logout</asp:LinkButton>
    </div>
    <h3>
        User Home Page
    </h3>
    <p>
        <a class="btn btn-primary" runat="server" href="~/booking/searchFlight">Choose Flight &raquo;</a>
    </p>
    <p>
        <a class="btn btn-primary" runat="server" href="~/user_management/receipt">Flight History &raquo;</a>
    </p>
    <p>
        <a class="btn btn-primary" runat="server" href="~/user_management/profile">User Profile &raquo;</a>
    </p>
</asp:Content>
