using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantReserve.Models;

namespace RestaurantReserve.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<RestaurantsUser>().HasKey(x => new { x.RestaurantId, x.UserId });

            builder.Entity<RestaurantsUser>().HasOne(fr => fr.Restaurant)
                .WithMany(r => r.FavoriteRestaurantsUsers)
                .HasForeignKey(fr => fr.RestaurantId);

            builder.Entity<RestaurantsUser>().HasOne(fr => fr.ApplicationUser)
              .WithMany(u => u.FavoriteRestaurantUsers)
              .HasForeignKey(fr => fr.UserId);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
