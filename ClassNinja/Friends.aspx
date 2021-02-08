<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="ClassNinja.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <h3>My Friends</h3>
        <asp:Table ID="FriendsTable" CssClass="table table-bordered table-hover" runat="server">
            
        </asp:Table>
        <div class="row">
            <div class="input-group col-sm-4">
                <asp:TextBox ID="SearchTextBox" runat="server" CssClass="form-group"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="SearchBtn" Text="Search for Friends" OnClick="SearchBtn_OnClick" runat="server" CssClass="btn btn-default"/>
                </span>
            </div>
        </div>
        <div ID="SearchResultsDiv" Visible="False" runat="server">
            <h3>Search Results</h3>
            <asp:Table ID="SearchResultsTable" CssClass="table table-bordered table-hover" runat="server">
            
            </asp:Table>
        </div>
    </div>
</asp:Content>
