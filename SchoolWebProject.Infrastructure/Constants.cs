using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Infrastructure
{
    public class Constants
    {
        public enum UserRoles { None, Admin, Teacher, Pupil, Parent };

        public static readonly string LoginError = "Wrong login data!";
    }
}
