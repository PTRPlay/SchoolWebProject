using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewTeacher
    {
        public byte[] Img { get; set;}

        public string FirstName { get; set;}

        public string MiddleName { get; set;}

        public string LastName { get; set; }

        //public string Email { get; set; }

        public ViewTeacherCategory Category { get; set; }

        public int Degree { get; set; }

        public DateTime WorkStart { get; set; }

        public IEnumerable<string> Subjects { get; set; }

    }
}