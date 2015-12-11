using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services.Models.ViewModels
{
    public class ViewParent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public ViewGroup Group { get; set; }

        public IEnumerable<ViewPupil> Pupils { get; set; }
    }
}
