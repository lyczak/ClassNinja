<%@ Page Title="Class" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="ClassNinja.Class" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 ID="ClassNameHeader" runat="server"></h3>
    <h2 ID="ClassGradeHeader" runat="server"></h2>
    <asp:Table ID="AssignmentsTable" CssClass="table table-bordered table-hover" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Assignment</asp:TableHeaderCell>
            <asp:TableHeaderCell>Percentage</asp:TableHeaderCell>
            <asp:TableHeaderCell>Score</asp:TableHeaderCell>
            <asp:TableHeaderCell>Total Points</asp:TableHeaderCell>
            <asp:TableHeaderCell>Date Due</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <asp:Button ID="HideUngradedBtn" Text="Hide Ungraded/Excused Assignments" runat="server" OnClick="HideUngradedBtn_Click" CssClass="btn btn-info"/>
</asp:Content>
