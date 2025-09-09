using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public string customerTitle { get; set; }
        public string customerName { get; set; }
        //public string fullName => customerTitle + " " + customerName; // not mapped by default
        public string fullName {  get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; } = 1; // default = 0 
        //public decimal total => price * quantity; // not mapped by default
        public string total {  get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
