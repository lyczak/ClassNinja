using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassNinja.Models;

namespace ClassNinja
{
    public partial class Login : System.Web.UI.Page
    {
        public const string EspApiUrl = "http://192.168.1.2:3000/esp/api";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
        }

        protected void LoginBtn_OnClick(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(EspApiUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    username = EspUsername.Text,
                    password = EspPassword.Text
                });

                streamWriter.Write(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseBody = streamReader.ReadToEnd();
                    Session["EspClasses"] = new JavaScriptSerializer().Deserialize<List<EspClass>>(responseBody);
                    Session["EspUsername"] = EspUsername.Text;
                    Session["EspPassword"] = EspPassword.Text;

                    using (var context = new ApplicationDbContext())
                    {
                        var student = context.Students.FirstOrDefault(s => EspUsername.Text.Equals(s.EspUsername));
                        if (student == null)
                        {
                            Session["Student"] = context.Students.Add(new Student
                            {
                                EspUsername = EspUsername.Text
                            });
                            context.SaveChanges();
                        }
                        else
                        {
                            Session["Student"] = student;
                        }
                    }

                    Response.Redirect("Default.aspx");;
                }
            }
            catch (WebException ex)
            {
                var httpResponse = (HttpWebResponse)ex.Response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseBody = streamReader.ReadToEnd();
                    string errorMessage = new JavaScriptSerializer().Deserialize<EspApiError>(responseBody).ErrorMessage;
                    LoginErrorMessage.Visible = true;
                    LoginErrorMessage.InnerText = errorMessage;
                }
            }
        }
    }
}