using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class PupilPageData
    {
       public IEnumerable<ViewPupil> Pupils { get; set; }
       public int PageCount { get; set; } 
    }
}