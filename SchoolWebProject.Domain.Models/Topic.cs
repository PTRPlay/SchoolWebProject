using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }

        //public string Poster { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        public DateTime CreationMoment { get; set; }
        [Required]
        public DateTime LastPostAddedMoment { get; set; }

        public int ScoolID { get; set; }
        public virtual School School { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Topic()
        {
            Posts = new HashSet<Post>();
        }
        
    }
}
