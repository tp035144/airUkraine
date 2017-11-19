<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receipt.aspx.cs" Inherits="airlineBookingSystem.user_management.receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>receipt page
    </h3>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %>" OnUpdating="SqlDataSource1_Updating" OnSelecting="SqlDataSource1_Selecting"
        SelectCommand=" select * from ticket_details,flight  where ticket_details.flight_id = flight.flight_id and customer_ID= @c_ID "
        updateCommand="UPDATE [ticket_details] set [Payment_Status] =@status where [ticket_id] = @ticket_id">
        <SelectParameters>
            <asp:Parameter Name="c_ID" Type="String" />
        </SelectParameters>
        <updateParameters>
            <asp:Parameter Name="ticket_id" Type="String" />
            <asp:Parameter Name="status" Type="String" />
        </updateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="ticket_id,flight_id1" DataSourceID="SqlDataSource1" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ticket_id" HeaderText="ticket_id" ReadOnly="True" SortExpression="ticket_id" />
            <asp:BoundField DataField="customer_ID" HeaderText="customer_ID" SortExpression="customer_ID" />
            <asp:BoundField DataField="flight_id" HeaderText="flight_id" SortExpression="flight_id" />
            <asp:BoundField DataField="flight_date" HeaderText="flight_date" SortExpression="flight_date" />
            <asp:BoundField DataField="Payment_Status" HeaderText="Payment_Status" SortExpression="Payment_Status" />
            <asp:BoundField DataField="flight_id1" HeaderText="flight_id1" SortExpression="flight_id1" ReadOnly="True" />
            <asp:BoundField DataField="airline_name" HeaderText="airline_name" SortExpression="airline_name" />
            <asp:BoundField DataField="departure_location" HeaderText="departure_location" SortExpression="departure_location" />
            <asp:BoundField DataField="destinatioin_location" HeaderText="destinatioin_location" SortExpression="destinatioin_location" />
            <asp:BoundField DataField="departure_time" HeaderText="departure_time" SortExpression="departure_time" />
            <asp:BoundField DataField="arrival_time" HeaderText="arrival_time" SortExpression="arrival_time" />
            <asp:BoundField DataField="total_seats" HeaderText="total_seats" SortExpression="total_seats" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowHeader="True" ShowSelectButton="True" />
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
    <p>
    </p>
    <div>
        <asp:Label runat="server" ID="cancel_flight_lbl" Visible="true"></asp:Label>
    </div>

    <div>
        <asp:Button runat="server" ID="cancel_Flight_btn" OnClick="cancel_book_flight" Text="Cancel Booking" css="btn btn-warning" CommandName="Update" />
    </div>

</asp:Content>
