using MagicBricksWebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicBricksWebAPI.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Property> properties { get; set; }
        public DbSet<PropertyDetail> propertyDetails { get; set; }
        public DbSet<BookMark> bookMarks { get; set; }
        // public DbSet<Category> categories { get; set; }





    }

}
