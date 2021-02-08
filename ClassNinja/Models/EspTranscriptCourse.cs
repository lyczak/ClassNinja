using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspTranscriptCourse
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? Percentage { get; set; }
        public string LetterGrade { get; set; }
        public float Credit { get; set; }
    }
}