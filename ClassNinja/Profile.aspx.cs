using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var student = (Student)Session["Student"];
            if (student == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (string.IsNullOrEmpty(UsernameTextBox.Text)) UsernameTextBox.Text = student.Username;
        }

        protected void UpdateBtn_OnClick(object sender, EventArgs e)
        {
            if (Regex.IsMatch(UsernameTextBox.Text, "^[a-zA-Z]+$"))
            {
                using (var context = new ApplicationDbContext())
                {
                    if (context.Students.FirstOrDefault(s => s.Username.Equals(UsernameTextBox.Text)) == null)
                    {
                        var student = (Student)Session["Student"];
                        student = context.Students.First(s => s.EspUsername.Equals(student.EspUsername));
                        student.Username = UsernameTextBox.Text;
                        context.SaveChanges();
                        Session["Student"] = student;
                        return;
                    }
                    else
                    {
                        FormErrorMessage.InnerText = "That username is already taken.";
                    }
                }
            }
            else
            {
                FormErrorMessage.InnerText = "Usernames may contain only letters.";
            }
            FormErrorMessage.Visible = true;
        }
    }
}