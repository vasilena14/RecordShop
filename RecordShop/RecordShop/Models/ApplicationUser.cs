﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RecordShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Office Phone Number")]
        public string PhoneNumber2 { get; set; }
        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}
