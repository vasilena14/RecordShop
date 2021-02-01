using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RecordShop.Extensions;

namespace RecordShop.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [DisplayName("Name of album")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter year of release")]
        [DisplayName("Year of release")]
        [YearRange(1900, ErrorMessage = "Not in the valid year range.")]
        public int Year { get; set; }
        public Artist Artist { get; set; }
        [RegularExpression("[1-9]*$", ErrorMessage = "Select Artist")]
        public int ArtistID { get; set; }
    }
}
