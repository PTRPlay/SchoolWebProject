using System;
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

        [MinLength(3)]
        [MaxLength(30)]
        public string MiddleName { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid E-mail Address")]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual List<Announcement> Announcements { get; set; }

        public virtual List<Topic> Topics { get; set; }

        public virtual List<Post> Posts { get; set; }

        public int? LogInDataId { get; set; }

        public virtual LogInData LogInData { get; set; }

        public int? OnlineId { get; set; }

        public virtual Online Online { get; set; }
    }
}
