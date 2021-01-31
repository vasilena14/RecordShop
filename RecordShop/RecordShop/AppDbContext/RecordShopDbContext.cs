using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop.AppDbContext
{
    public class RecordShopDbContext : IdentityDbContext<IdentityUser>
    {
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options)
        {

        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

    }
}
