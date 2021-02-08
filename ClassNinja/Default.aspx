<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClassNinja._Default" %>
<%@ Import Namespace="ClassNinja.Models" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div ID="DashboardDiv" class="container" runat="server">
        <div class="row">
            <h3>Class Grades this Marking Period</h3>
            <asp:Table ID="ClassesTable" CssClass="table table-bordered table-hover" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Class</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Grade</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Deviation</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Grades/Total</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
<%--
    <script>
        function fetchClassroomClasses() {
            var classroomFetchUrl =
                'https://script.google.com/a/pvsd.org/macros/s/AKfycbzaoI_XP0TWFN2v7TvtYBU9gdaGIxbBSAGDp79qFsxrEDfZQL3L/exec?requestId=' + '<%: ((ClassroomData) Session["ClassroomData"]).RequestId %>';
            window.open(classroomFetchUrl, '_blank');
        }

        jQuery(document).ready(function() {
            <%: ((ClassroomData)Session["ClassroomData"]).CourseWork == null ? "fetchClassroomClasses();" : "" %>
        });
    </script>
--%>
</asp:Content>
