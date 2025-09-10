using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public string physics { get; set; }
        public string chemistry { get; set; }
        public string programming { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        //[Required]
        public virtual Student Student { get; set; }
    }
}
