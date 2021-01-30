using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name of album")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Year of release")]
        [Range(1800, 2021, ErrorMessage = "Not in the valid year range.")]
        public int Year { get; set; }
        public Artist Artist { get; set; }
        public int ArtistID { get; set; }
    }
}
