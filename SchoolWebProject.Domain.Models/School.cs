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
        public String City { get; set; }
        public String Address { get; set; }
        public int PhoneNumber { get; set; }

        public virtual List<Announcement> Announcements { get; set; }

        public virtual List<Topic> Topics { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<Group> Groups { get; set; }

        public virtual List<ClassRoom> ClassRooms { get; set; }

        public virtual List<Schedule> Schedules { get; set; }

        public virtual List<Mark> Marks { get; set; }

        public virtual List<LessonDetail> LessonDetails { get; set; }

        public School()
        {
        }
    }
}
