<%@ Page Title="Transcript" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transcript.aspx.cs" Inherits="ClassNinja.Transcript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Transcript</h3>
    <asp:Table ID="StatsTable" CssClass="table table-bordered table-hover" runat="server">
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">GPA</asp:TableHeaderCell>
            <asp:TableCell ID="GpaTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">Class Rank</asp:TableHeaderCell>
            <asp:TableCell ID="ClassRankTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">Percentile</asp:TableHeaderCell>
            <asp:TableCell ID="PercentileTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">Total Credit</asp:TableHeaderCell>
            <asp:TableCell ID="TotalCreditTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">Best Year</asp:TableHeaderCell>
            <asp:TableCell ID="BestYearTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableHeaderCell runat="server">Worst Year</asp:TableHeaderCell>
            <asp:TableCell ID="WorstYearTableCell" runat="server"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Panel ID="GroupPanel" runat="server">
        
    </asp:Panel>
</asp:Content>
