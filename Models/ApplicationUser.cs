using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RestaurantReserve.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Restaurant> Ownedrestaurants { get; set; }

        public ICollection<RestaurantsUser> FavoriteRestaurantUsers { get; set; }
    }
}
