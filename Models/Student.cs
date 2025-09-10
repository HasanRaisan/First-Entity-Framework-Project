using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework.Models
{
    //[Index("Name", "Email")]
    //[Index("Name", Name = "")]
    //[Index("Name", isUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public DateTime Birthdate { get; set; }
        [ForeignKey("Department")]
        public int departmentId { get; set; }
        public virtual Grade grade { get; set; }
        public virtual Department department { get; set; }
        public virtual ICollection<StudentBook> Books { get; set; }
        //[NotMapped]
        public virtual ICollection<Attendance> attendances { get; set; }
    }
}
