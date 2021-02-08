using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassNinja.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string EspUsername { get; set; }
        public string Username { get; set; }
        public bool Private { get; set; }
        public ICollection<Student> Friends { get; set; }

        public Student()
        {
            Friends = new List<Student>();
        }

        public bool CanBefriend(Student student)
        {
            return !student.EspUsername.Equals(EspUsername) &&
                   !Friends.Contains(student) &&
                   !student.Private &&
                   !string.IsNullOrEmpty(student.Username);
        }
    }
}