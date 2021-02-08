using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspAssignment
    {
        public string DateDue { get; set; }
        public string DateAssigned { get; set; }
        public string Assignment { get; set; }
        public string Category { get; set; }
        public float? Score { get; set; }
        public float TotalPoints { get; set; }
        public float Weight { get; set; }
        public float? WeightedScore { get; set; }
        public float WeightedTotalPoints { get; set; }
        public float? AverageScore { get; set; }
        public float? Percentage { get; set; }

        public static double StdDevOfPercentages(IEnumerable<EspAssignment> assignments)
        {
            if (assignments.Count() <= 1) return 0;
            float sum = 0;
            foreach (var a in assignments)
            {
                sum += a.Percentage.Value;
            }
            float avg = sum / assignments.Count();
            sum = 0;
            foreach (var a in assignments)
            {
                float diff = a.Percentage.Value - avg;
                sum += diff * diff;
            }
            return Math.Sqrt(sum / (assignments.Count() - 1));
        }
    }
}