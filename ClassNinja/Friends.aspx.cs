using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var student = (Student)Session["Student"];
            if (student == null)
            {
                Response.Redirect("Login.aspx");
            }

            var friendName = Request.QueryString["Friend"];
            if (Request.QueryString["Action"] != null && friendName != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var friend = context.Students.FirstOrDefault(s => s.EspUsername.Equals(friendName));
                    if (friend == null) return;
                    student = context.Students.First(s => s.EspUsername.Equals(student.EspUsername));
                    switch (Request.QueryString["Action"])
                    {
                        case "Add":
                            if (!student.CanBefriend(friend)) break;
                            student.Friends.Add(friend);
                            break;
                        case "Remove":
                            student.Friends.Remove(friend);
                            break;
                    }
                    context.SaveChanges();
                    Session["Student"] = student;
                }
            }

            FriendsTable.Rows.Clear();
            if (student.Friends.Count == 0)
            {
                FriendsTable.Rows.Add(new TableRow
                {
                    Cells =
                    {
                        new TableCell
                        {
                            Text = "Search for new friends using the search box."
                        }
                    }
                });
            }
            else
            {
                foreach (var friend in student.Friends)
                {
                    var row = new TableRow();
                    row.Cells.Add(new TableCell {Text = $"{friend.Username} ({friend.EspUsername})"});
                    row.Cells.Add(new TableCell
                    {
                        Controls = { new HyperLink
                            {
                                Text = "Remove Friend",
                                NavigateUrl = "Friends.aspx?Action=Remove&Friend=" + friend.EspUsername
                            }
                        }
                    });
                    FriendsTable.Rows.Add(row);
                }
            }
        }

        protected void SearchBtn_OnClick(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var student = (Student)Session["Student"];

                var qry = SearchTextBox.Text;
                var matches = context.Students.Where(s => s.Username.Contains(qry) ||
                    s.EspUsername.Contains(qry)).ToList();
                foreach (var match in matches)
                {
                    if (!student.CanBefriend(match)) continue;
                    var row = new TableRow();
                    row.Cells.Add(new TableCell { Text = $"{match.Username} ({match.EspUsername})" });
                    row.Cells.Add(new TableCell { Controls = { new HyperLink
                        {
                            Text = "Add Friend",
                            NavigateUrl = "Friends.aspx?Action=Add&Friend=" + match.EspUsername
                        }
                    } });
                    SearchResultsTable.Rows.Add(row);
                }
                SearchResultsDiv.Visible = true;
            }
        }
    }
}