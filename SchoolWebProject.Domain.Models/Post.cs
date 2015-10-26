using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]        
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public int ShoolId { get; set; }
        public virtual School School { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Post()
        {

        }
    }
}
