using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class Classroom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClassroomData"] == null)
            {
                var random = new Random();
                string classroomRequestId = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmonpqrstuvwxyz", 8)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                Session["ClassroomData"] = new ClassroomData { RequestId = classroomRequestId };
            }
            if (((ClassroomData)Session["ClassroomData"]).CourseWork != null &&
                ClassroomAssignmentsTable.Rows.Count <= 1)
                ClassroomAssignmentsTable_Load();
        }

        protected void ClassroomAssignmentsTable_Load()
        {
            foreach (var assignment in ((ClassroomData)Session["ClassroomData"]).CourseWork)
            {
                var row = new TableRow();
                TableCell cell = new TableCell();
                cell.Controls.Add(new HyperLink
                {
                    Text = assignment.Title,
                    NavigateUrl = assignment.AlternateLink
                });
                row.Cells.Add(cell);
                ClassroomAssignmentsTable.Rows.Add(row);
            }
            ReloadClassroomAssignments.Visible = false;
        }

        protected void ReloadClassroomAssignments_OnServerClick(object sender, EventArgs e)
        {
            var classroomData = (ClassroomData)Session["ClassroomData"];
            var classroomResponses = (List<ClassroomData>)Application["ClassroomResponses"];
            var responseData = classroomResponses.FirstOrDefault(
                r => r.RequestId.Equals(classroomData.RequestId));
            if (responseData != null)
            {
                classroomData.CourseWork = responseData.CourseWork;
                classroomResponses.Remove(responseData);
                ClassroomAssignmentsTable.Visible = true;
            }
        }
    }
}