<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="airlineBookingSystem.user_management.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>AIR Ukraine Booking System</h3>
    </div>
    <div>
        <asp:Image runat="server" ImageUrl="~/image/AirlinerWall.jpg" ImageAlign="Middle" Width="1000" Height="350"></asp:Image>
    </div>
    <p>
    </p>
    <div>
    <div class="row">
        <div class="btn-group btn btn-default pull-left">
            <button type="button" class="btn btn-warning">Login/Register</button>
            <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown">
                <span class="caret"></span>
            </button>
            <ul class="dropdown-menu" role="menu">
                <li><a href="/user_management/register">Register</a></li>
                <li><a href="/user_management/login">Login</a></li>
            </ul>
        </div>
    </div>
        </div>
    <div class="col-xs-12">
    </div>
    <p>
    </p>
</asp:Content>
