<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchFlight.aspx.cs" Inherits="airlineBookingSystem.booking.searchFlight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-right">
        <asp:Label ID="userL" runat="server" Visible="true">no user</asp:Label>
        <asp:LinkButton ID="logoutButton" OnClick="logoutButton_Click" runat="server">Logout</asp:LinkButton>
    </div>
    <div>
        <h1>AIR Ukraine Booking System</h1>
    </div>

    <div class="form-group">
        <div class="form-group column col-xs-12">
            <div>
                <label for="origin_txtfield">Origin:</label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="origin_txtfield" CssClass="form-control col-xs-4 " />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="origin_txtfield" CssClass="text-danger col-xs-4" ErrorMessage="*" />--%>
            </div>
            <div>
            </div>
        </div>

        <div class="form-group column col-xs-12">
            <div class="pull-right col-xs-12">
                <label for="destination_txtfield">Destination:</label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="destination_txtfield" CssClass="form-control col-xs-4 " />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="destination_txtfield" CssClass="text-danger col-xs-4 " ErrorMessage="*" />
            </div>
        </div>
    </div>

    <div>
        <div class="form-group column">
            <div class="pull-left col-xs-12">
                <label for="departDate_txtfield">Depart Date</label>
                <div>
                    <asp:TextBox class="form-control" runat="server" ID="departDate_txtfield" type="date" />
                </div>
                <label for="returnDate_txtfield">Return Date</label>
                <asp:TextBox class="form-control" runat="server" ID="returnDate_txtfield" type="date" />
            </div>


            <div class=" pull-left col-xs-12">
                <label for="guests_txtfield">Guests</label>
                <div>
                    <asp:TextBox class="form-control  col-xs-4" runat="server" ID="guests_txtfield" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="guests_txtfield" CssClass="text-danger col-xs-4" ErrorMessage="*" />
                </div>

            </div>
        </div>

        <div class="pull-left col-xs-12">
            <asp:Button runat="server" OnClick="search_flight" Text="Search" CssClass="btn btn-warning" />
        </div>
    </div>
    <p>
    </p>
    <div>
        <asp:Image runat="server" ImageUrl="~/image/footer.jpg"></asp:Image>
    </div>
</asp:Content>
