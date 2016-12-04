using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReserve.Models
{
    public class Restaurant
    {
        public int restaurantId { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public virtual List<Table> tables { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
        public virtual ICollection<RestaurantsUser> FavoriteRestaurantsUsers { get; set; }
    }

    public class Table
    {
        public int tableId { get; set; }
        public string type { get; set; }
        public double leftPos { get; set; }
        public double topPos { get; set; }
        public double objHeight { get; set; }
        public double objWidth { get; set; }
        public int rotationAng { get; set; }
        public bool isReserved { get; set; }
    }


    public class RestaurantsUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }

}
