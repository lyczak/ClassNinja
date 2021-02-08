using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspAssignmentCategory
    {
        public string Category { get; set; }
        public float Points { get; set; }
        public float MaximumPoints { get; set; }
        public float Percent { get; set; }
        public float? CategoryWeight { get; set; }
        public float? CategoryPoints { get; set; }
    }
}