<%@ Page Title="Profile Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ClassNinja.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4 Visible="False" ID="FormErrorMessage" runat="server" style="color: #ff2200"></h4>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="UsernameTextBox" Text="Username: "></asp:Label>
        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-group"></asp:TextBox>
        <p>This is your ClassNinja username. It can be different from your eSchoolPlus username and should help your friends to find you. Please use only letters and numbers in your username.</p>
    </div>
    <asp:Button ID="UpdateBtn" Text="Update Profile" OnClick="UpdateBtn_OnClick" runat="server" CssClass="btn btn-warning"/>
</asp:Content>
