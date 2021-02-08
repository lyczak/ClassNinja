using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassNinja.Models;

namespace ClassNinja.Controllers.Api
{
    public class ClassroomController : ApiController
    {
        public void Post(ClassroomData data)
        {
            System.Web.HttpContext.Current.Application.Lock();
            ((List<ClassroomData>) System.Web.HttpContext.Current.Application["ClassroomResponses"]).Add(data);
            System.Web.HttpContext.Current.Application.UnLock();
        }
    }
}
