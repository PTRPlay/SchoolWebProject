﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual List<Teacher> Teachers { get; set; }

        public virtual List<Schedule> Schedules { get; set; } 
    }
}
