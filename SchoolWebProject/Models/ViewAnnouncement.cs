using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    public class ViewAnnouncement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string MessageDetails { get; set; }

        public string Image { get; set; }

        public DateTime DataPublished { get; set; }
    }
}