using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }

        public School()
        {
            Announcements = new HashSet<Announcement>();
            Topics = new HashSet<Topic>();
            Posts = new HashSet<Post>();
            Users = new HashSet<User>();
            Groups = new HashSet<Group>();
            ClassRooms = new HashSet<ClassRoom>();
        }
    }
}
