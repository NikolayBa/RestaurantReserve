using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantReserve.Models;

namespace RestaurantReserve.Models
{
    public class TableLayoutViewModel
    {
        public Restaurant restaurant { get; set; }
        public ApplicationUser currentUser { get; set; }
    }
}
