using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SchoolWebProject.Domain.Models
{
    [Table("Holidays")]
    public class Holidays
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDay { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDay { get; set; }

        public Holidays()
        {

        }
    }
}
