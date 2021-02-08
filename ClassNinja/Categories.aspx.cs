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
    public partial class Categories : System.Web.UI.Page
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

            ClassNameHeader.InnerText = espClass.ClassName;
            ClassGradeHeader.InnerText = $"{espClass.Average:0.00}%";

            if (Request.Browser.IsMobileDevice)
            {
                CategoriesTable.Rows[0].Cells[4].Text = "Asmts.";
                CategoriesTable.Rows[0].Cells.RemoveAt(2);
            }

            float totalCategoryWeight = espClass.CalculateTotalCategoryWeight();
            foreach (var category in espClass.AssignmentCategories)
            {
                var row = new TableRow();
                List<EspAssignment> assignments = espClass.Assignments.Where(a => 
                    a.Category.Equals(category.Category) && a.Percentage.HasValue).ToList();
                double deviation = EspAssignment.StdDevOfPercentages(assignments);
                float relativeWeight = (category.CategoryWeight.HasValue ? 
                    category.CategoryWeight.Value : 1) / totalCategoryWeight;
                row.Cells.Add(new TableCell { Text = category.Category });
                row.Cells.Add(new TableCell { Text = category.Percent + "%" });
                if (!Request.Browser.IsMobileDevice) row.Cells.Add(new TableCell { Text = string.Format("{0:0.00}%", deviation) });
                row.Cells.Add(new TableCell { Text = string.Format("{0:0.0}%", relativeWeight * 100) });
                row.Cells.Add(new TableCell { Text = assignments.Count.ToString() });
                CategoriesTable.Rows.Add(row);
            }
        }
    }
}