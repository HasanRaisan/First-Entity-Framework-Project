using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{




    [Table ("StudentsAtts",Schema = "std")]
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string DayName { get; set; }
        [Column("theName", TypeName = "varchar(20)")]
        public string? Name { get; set; }
        [ForeignKey("Student")]
        public int studentId { get; set; }

        public virtual Student student { get; set; }

        [NotMapped]
        public DateTime date_absnes { get; set; }
    }
}

