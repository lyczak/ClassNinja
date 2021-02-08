using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspTranscript
    {
        public float Gpa { get; set; }
        public int Rank { get; set; }
        public int RankOutOf { get; set; }
        public List<EspTranscriptGroup> Groups { get; set; }
    }
}