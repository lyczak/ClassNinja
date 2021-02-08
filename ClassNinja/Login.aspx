<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClassNinja.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <h2>Welcome to ClassNinja!</h2>
        <p class="lead">Enter your eSchoolPlus (HAC) credentials to begin.</p>
        <h4 Visible="False" ID="LoginErrorMessage" runat="server" style="color: #ff2200"></h4>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EspUsername" Text="Username: "></asp:Label>
            <asp:TextBox ID="EspUsername" runat="server" CssClass="form-group"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EspPassword" Text="Password: "></asp:Label>
            <asp:TextBox ID="EspPassword" TextMode="Password" runat="server" CssClass="form-group"></asp:TextBox>
        </div>
        <asp:Button ID="LoginBtn" Text="Log In &raquo;" runat="server" OnClick="LoginBtn_OnClick" CssClass="btn btn-primary"/>
    </div>
</asp:Content>
