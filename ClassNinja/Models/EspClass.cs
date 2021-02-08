using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class EspClass
    {
        public string ClassName { get; set; }
        public string ClassId { get; set; }
        public float Average { get; set; }
        public List<EspAssignment> Assignments { get; set; }
        public List<EspAssignmentCategory> AssignmentCategories { get; set; }

        public float CalculateTotalCategoryWeight()
        {
            float total = 0;
            foreach (var category in AssignmentCategories)
            {
                if (category.CategoryWeight.HasValue)
                {
                    total += category.CategoryWeight.Value;
                }
                else
                {
                    total = AssignmentCategories.Count;
                    break;
                }
            }
            return total;
        }
    }
}