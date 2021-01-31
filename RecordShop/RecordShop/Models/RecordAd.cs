using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Models
{
    public class RecordAd
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public int ArtistID { get; set; }
        public Album Album { get; set; }
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
        [DisplayName("Seller Email")]
        public string SellerEmail { get; set; }
        [Required]
        [DisplayName("Seller Phone Number")]
        public string SellerPhone { get; set; }
        [Required] 
        public int Price { get; set; }
        [Required] 
        public string Currency { get; set; }
        public string ImagePath { get; set; }
    }
}
