using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Url]
        public string pictureUrl { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public virtual ICollection<RestaurantsUser> FavoriteRestaurantsUsers { get; set; }
    }

    public class RestaurantsUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }

}
