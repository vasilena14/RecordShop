using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Models
{
    public class RecordAd
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        [RegularExpression("[1-9]*$", ErrorMessage = "Select Artist")]
        public int ArtistID { get; set; }
        public Album Album { get; set; }
        [RegularExpression("[1-9]*$", ErrorMessage = "Select Album")]
        public int AlbumID { get; set; }
        [Required]
        [DisplayName("Release Country")]
        public string Country { get; set; }
        [Required]
        public string Format { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        [DisplayName("Seller Name")]
        public string SellerName { get; set; }
        [Required]
        [DisplayName("Seller Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string SellerEmail { get; set; }
        [Required]
        [DisplayName("Seller Phone Number")]
        public string SellerPhone { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]*$", ErrorMessage = "Select Currency")]
        public string Currency { get; set; }
    }
}
