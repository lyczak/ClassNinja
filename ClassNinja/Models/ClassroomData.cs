using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class ClassroomData
    {
        public string RequestId { get; set; }
        public List<ClassroomCourseWork> CourseWork { get; set; }
    }
}