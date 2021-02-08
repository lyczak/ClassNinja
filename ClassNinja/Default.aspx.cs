using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EspClasses"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (ClassesTable.Rows.Count <= 1)
            {
                if (Request.Browser.IsMobileDevice)
                {
                    ClassesTable.Rows[0].Cells.RemoveAt(3);
                    ClassesTable.Rows[0].Cells.RemoveAt(2);
                }
                foreach (var espClass in (List<EspClass>) Session["EspClasses"])
                {
                    var gradedAssignments = espClass.Assignments.Where(a => a.Percentage.HasValue);

                    TableRow classRow = new TableRow();
                    TableCell nameCell = new TableCell();
                    nameCell.Controls.Add(new HyperLink
                    {
                        Text = espClass.ClassName,
                        NavigateUrl = "Class.aspx?ID=" + espClass.ClassId
                    });

                    classRow.Cells.Add(nameCell);
                    classRow.Cells.Add(new TableCell { Text = (espClass.Average + "%") });
                    if (!Request.Browser.IsMobileDevice)
                    {
                        classRow.Cells.Add(new TableCell
                        {
                            Text =
                                string.Format("{0:0.00}%", EspAssignment.StdDevOfPercentages(gradedAssignments))
                        });
                        classRow.Cells.Add(new TableCell
                        {
                            Text =
                                (gradedAssignments.Count() + "/" + espClass.Assignments.Count())
                        });
                    }

                    ClassesTable.Rows.Add(classRow);
                }
            }
        }
    }
}