﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid E-mail Address")]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual LogInData LogInData { get; set; }

        public virtual Online Online { get; set; }

        public User()
        {
            Announcements = new HashSet<Announcement>();
            Topics = new HashSet<Topic>();
            Posts = new HashSet<Post>();
        }
    }
}
