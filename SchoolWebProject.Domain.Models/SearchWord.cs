using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    public class SearchWord
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Word { get; set; }

        public SearchWord()
        {

        }
    }
}
