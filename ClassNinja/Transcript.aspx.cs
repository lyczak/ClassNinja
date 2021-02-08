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
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class Transcript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EspClasses"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["EspTranscript"] == null)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Login.EspApiUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        username = Session["EspUsername"],
                        password = Session["EspPassword"],
                        request = "transcript"
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseBody = streamReader.ReadToEnd();
                    Session["EspTranscript"] = new JavaScriptSerializer().Deserialize<EspTranscript>(responseBody);
                }
            }

            var transcript = (EspTranscript) Session["EspTranscript"];

            GpaTableCell.Text = $"{transcript.Gpa:0.000}";
            ClassRankTableCell.Text = $"{transcript.Rank}/{transcript.RankOutOf}";
            var percentile = ((float) transcript.Rank / (float) transcript.RankOutOf) * 100;
            PercentileTableCell.Text = percentile <= 50 ? $"Top {percentile:00}%" :
                $"Bottom {(100 - percentile):00}%";
            float totalCredit = 0;
            transcript.Groups.ForEach(g => totalCredit += g.TotalCredit);
            TotalCreditTableCell.Text = $"{totalCredit:0.000}";
            BestYearTableCell.Text = transcript.Groups.Aggregate((a, n) => n.Gpa.HasValue &&
                n.Gpa.Value > (a.Gpa ?? 0) ? n : a).Year;
            WorstYearTableCell.Text = transcript.Groups.Aggregate((a, n) => n.Gpa.HasValue &&
                n.Gpa.Value < (a.Gpa ?? 5) ? n : a).Year;

            foreach (var group in Enumerable.Reverse(transcript.Groups))
            {
                if (!group.Gpa.HasValue) continue;
                var table = new Table();
                table.CssClass = "table table-bordered table-hover";
                var headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell { Text = "Description" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Percentage" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Letter Grade" });
                headerRow.Cells.Add(new TableHeaderCell { Text = "Credit" });
                table.Rows.Add(headerRow);
                foreach (var course in group.Courses)
                {
                    var row = new TableRow();
                    row.Cells.Add(new TableCell { Text = course.Description });
                    var percentageString = course.Percentage.HasValue ? course.Percentage.Value + "%" : "";
                    row.Cells.Add(new TableCell { Text = percentageString });
                    row.Cells.Add(new TableCell { Text = course.LetterGrade });
                    row.Cells.Add(new TableCell { Text = string.Format("{0:0.000}", course.Credit) });
                    table.Rows.Add(row);
                }
                var titleControl = new HtmlGenericControl("h4");
                titleControl.InnerText = string.Format("{0} ({1:0.000} GPA)", group.Year, group.Gpa.Value);
                GroupPanel.Controls.Add(titleControl);
                GroupPanel.Controls.Add(table);
            }
        }
    }
}