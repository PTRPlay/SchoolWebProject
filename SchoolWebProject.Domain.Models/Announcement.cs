using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Message { get; set; }
        [MaxLength(50)]
        public string MessageDetails { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public Announcement()
        {

        }
    }
}
