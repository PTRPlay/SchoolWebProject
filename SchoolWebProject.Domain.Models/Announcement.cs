using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Message { get; set; }

        public string MessageDetails { get; set; }

       public string Image { get; set; }

        public DateTime DataPublished { get; set; }

        //// public int UserId { get; set; }

        //// public virtual User User { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
