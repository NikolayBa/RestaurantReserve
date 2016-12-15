using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RestaurantReserve.Data.ApplicationDbContext;

namespace RestaurantReserve.Models
{
    public class PhysicalTable
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
        public double leftPos { get; set; }
        public double topPos { get; set; }
        public double objHeight { get; set; }
        public double objWidth { get; set; }
        public int rotationAng { get; set; }
        public bool isReserved { get; set; }
        public int restaurantId { get; set; }
        public string reservedBy { get; set; }
        public string reservedFor { get; set; }
    }
}

