using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspTranscriptGroup
    {
        public string Year { get; set; }
        public int Grade { get; set; }
        public string Building { get; set; }
        public List<EspTranscriptCourse> Courses { get; set; }
        public float? Gpa { get; set; }
        public float TotalCredit { get; set; }
    }
}