<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="selectFlight.aspx.cs" Inherits="airlineBookingSystem.booking.selectFlight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-right">
        <asp:Label ID="userL" runat="server" Visible="true">no user</asp:Label>
        <asp:LinkButton ID="logoutButton" OnClick="logoutButton_Click" runat="server">Logout</asp:LinkButton>
    </div>
    <h3>Depart Flights</h3>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %> " OnSelected="SqlDataSource1_Selected"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="flight_id" DataSourceID="SqlDataSource1" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="flight_id" HeaderText="flight_id" ReadOnly="True" SortExpression="flight_id" />
                <asp:BoundField DataField="airline_name" HeaderText="airline_name" SortExpression="airline_name" />
                <asp:BoundField DataField="departure_location" HeaderText="departure_location" SortExpression="departure_location" />
                <asp:BoundField DataField="destinatioin_location" HeaderText="destinatioin_location" SortExpression="destinatioin_location" />
                <asp:BoundField DataField="departure_time" HeaderText="departure_time" SortExpression="departure_time" />
                <asp:BoundField DataField="arrival_time" HeaderText="arrival_time" SortExpression="arrival_time" />
                <asp:BoundField DataField="total_seats" HeaderText="total_seats" SortExpression="total_seats" />
                <asp:CommandField ButtonType="Button" HeaderText="Select Flight" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <asp:Label runat="server" ID="depart_table_lbl" Visible="true"></asp:Label>
        <asp:Label runat="server" ID="selected_flight_departTable_lbl" Visible="true"></asp:Label>
    </div>
    <h3>Return Flights
    </h3>

    <div>
        <div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %>" OnSelected="SqlDataSource2_Selected"></asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="SqlDataSource2" GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="flight_id" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="flight_id" HeaderText="flight_id" ReadOnly="True" SortExpression="flight_id" />
                    <asp:BoundField DataField="airline_name" HeaderText="airline_name" SortExpression="airline_name" />
                    <asp:BoundField DataField="departure_location" HeaderText="departure_location" SortExpression="departure_location" />
                    <asp:BoundField DataField="destinatioin_location" HeaderText="destinatioin_location" SortExpression="destinatioin_location" />
                    <asp:BoundField DataField="departure_time" HeaderText="departure_time" SortExpression="departure_time" />
                    <asp:BoundField DataField="arrival_time" HeaderText="arrival_time" SortExpression="arrival_time" />
                    <asp:BoundField DataField="total_seats" HeaderText="total_seats" SortExpression="total_seats" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <asp:Label runat="server" ID="return_table_lbl" Visible="true"></asp:Label>
            <asp:Label runat="server" ID="selected_flight_returnTable_lbl" Visible="true"></asp:Label>
        </div>
        <p>

        </p>
        <div>
            <asp:Button runat="server" ID="Book_Flight_btn" OnClick="Book_Flight" Text="Confirm Booking" css="btn btn-warning" Visible="false"/>
        </div>
        <p>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %>"></asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %>" OnSelected="SqlDataSource4_Selected"></asp:SqlDataSource>
        </p>
        <asp:Label runat="server" ID="lbl" Visible="true"></asp:Label>
        <asp:Image runat="server" ImageUrl="~/image/footer.jpg"></asp:Image>
    </div>
</asp:Content>
