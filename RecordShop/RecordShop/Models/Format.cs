using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Models
{
    public class Format
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter format")]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
