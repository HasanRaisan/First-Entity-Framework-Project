using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Uniform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int DeiveryOrder { get; set; }
    }
}
