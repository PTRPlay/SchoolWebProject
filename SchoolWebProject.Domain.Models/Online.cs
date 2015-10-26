using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    [Table("Online")]
    public class Online
    {
        [Required]
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime LoggingTime { get; set; }
        public int Idle { get; set; }
        public DateTime LastPostTime { get; set; }
        public DateTime LastSearchTime { get; set; }

        public virtual User User { get; set; }

        public Online()
        {

        }
    }
}
