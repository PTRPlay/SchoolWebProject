using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    [Table("LogInData")]
    public class LogInData
    {
        [Required]
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        [MaxLength(20)]
        public string Login { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string PasswordSalt { get; set; }

        public string PasswordHash { get; set; }

        public virtual User User { get; set; }
    }
}
