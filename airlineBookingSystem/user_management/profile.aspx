<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="airlineBookingSystem.user_management.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="text-right">
        <asp:Label ID="userL" runat="server" Visible="true">no user</asp:Label>
        <asp:LinkButton ID="logoutButton" OnClick="logoutButton_Click" runat="server">Logout</asp:LinkButton>
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="customer_ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="customer_ID" HeaderText="customer_ID" ReadOnly="True" SortExpression="customer_ID" />
            <asp:BoundField DataField="customer_Fname" HeaderText="customer_Fname" SortExpression="customer_Fname" />
            <asp:BoundField DataField="customer_Lname" HeaderText="customer_Lname" SortExpression="customer_Lname" />
            <asp:BoundField DataField="customer_pwd" HeaderText="customer_pwd" SortExpression="customer_pwd" />
            <asp:BoundField DataField="customer_email" HeaderText="customer_email" SortExpression="customer_email" />
        </Columns>
     </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:airlineBookingDBConnectionString %>" SelectCommand="SELECT [customer_ID], [customer_Fname], [customer_Lname], [customer_pwd], [customer_email] FROM [customer] where customer_ID=@c_ID" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="c_ID" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
     
</asp:Content>
