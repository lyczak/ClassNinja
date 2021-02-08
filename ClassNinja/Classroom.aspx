<%@ Page Title="Google Classroom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Classroom.aspx.cs" Inherits="ClassNinja.Classroom" %>
<%@ Import Namespace="ClassNinja.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Recent on Google Classroom</h3>
    <asp:Table ID="ClassroomAssignmentsTable" Visible="False" CssClass="table table-bordered table-hover" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Assignment</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <button id="FetchClassroomAssignments" class="btn btn-default" onclick="fetchClassroomAssignments">Fetch</button>
    <button ID="ReloadClassroomAssignments" class="btn btn-default" OnServerClick="ReloadClassroomAssignments_OnServerClick" runat="server">Refresh</button>
    <script>
        function fetchClassroomAssignments() {
            var classroomFetchUrl =
                'https://script.google.com/a/pvsd.org/macros/s/AKfycbzaoI_XP0TWFN2v7TvtYBU9gdaGIxbBSAGDp79qFsxrEDfZQL3L/exec?requestId=' + '<%: ((ClassroomData) Session["ClassroomData"]).RequestId %>';
            window.open(classroomFetchUrl, '_blank');
        }
    </script>
</asp:Content>
