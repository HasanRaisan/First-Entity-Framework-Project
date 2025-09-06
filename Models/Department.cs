using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter The Name")]
        public string Name { get; set; }
        //[Required]
        [MaxLength(50, ErrorMessage = "Maximum Lenth is 10 charchters")]
        public string? desc { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
