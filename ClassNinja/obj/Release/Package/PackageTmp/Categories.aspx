<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ClassNinja.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 ID="ClassNameHeader" runat="server"></h3>
    <h2 ID="ClassGradeHeader" runat="server"></h2>
    <asp:Table ID="CategoriesTable" CssClass="table table-bordered table-hover" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Category</asp:TableHeaderCell>
            <asp:TableHeaderCell>Percentage</asp:TableHeaderCell>
            <asp:TableHeaderCell>Deviation</asp:TableHeaderCell>
            <asp:TableHeaderCell>Relative Weight</asp:TableHeaderCell>
            <asp:TableHeaderCell>Assignments</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
