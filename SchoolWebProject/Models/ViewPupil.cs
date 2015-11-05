using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewPupil
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string middleName { get; set; }

        public string phoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }

   //     public string School { get; set; }

        public int LogInDataId { get; set; }
    }
}