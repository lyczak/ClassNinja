using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassNinja.Models;
using Microsoft.Ajax.Utilities;

namespace ClassNinja
{
    public partial class Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EspClasses"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (string.IsNullOrEmpty(Request.QueryString["ID"])) Response.Redirect("Default.aspx");
            var espClass =
                (Session["EspClasses"] as List<EspClass>).FirstOrDefault(c =>
                    c.ClassId.Equals(Request.QueryString["ID"]));
            if (espClass == null) Response.Redirect("Default.aspx");

            if (Request.Browser.IsMobileDevice)
            {
                AssignmentsTable.Rows[0].Cells.RemoveAt(4);
                AssignmentsTable.Rows[0].Cells[1].Text = "Percent";
            }

            ClassNameHeader.InnerText = espClass.ClassName;
            ClassGradeHeader.InnerText = $"{espClass.Average:0.00}%";

            foreach (var assignment in espClass.Assignments)
            {
                var row = new TableRow();
                string percentage = assignment.Percentage == null ? "N/G" : assignment.Percentage + "%";
                string score = assignment.Score == null ? "N/G" : assignment.Score.ToString();
                row.Cells.Add(new TableCell { Text = assignment.Assignment });
                row.Cells.Add(new TableCell { Text = percentage });
                row.Cells.Add(new TableCell { Text = score });
                row.Cells.Add(new TableCell { Text = assignment.TotalPoints.ToString() });
                if (!Request.Browser.IsMobileDevice) row.Cells.Add(new TableCell { Text = assignment.DateDue });
                AssignmentsTable.Rows.Add(row);
            }
        }

        protected void HideUngradedBtn_Click(object sender, EventArgs e)
        {
            var rowsToRemove = new List<TableRow>();
            foreach (TableRow row in AssignmentsTable.Rows)
            {
                if ("N/G".Equals(row.Cells[1].Text)) // Assignment percentage is at column index 1
                {
                    rowsToRemove.Add(row);
                }
            }
            foreach (TableRow row in rowsToRemove)
            {
                AssignmentsTable.Rows.Remove(row);
            }
        }
    }
}