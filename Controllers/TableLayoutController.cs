using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReserve.Data;
using Microsoft.AspNetCore.Identity;
using RestaurantReserve.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestaurantReserve.Controllers
{
    public class TableLayoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TableLayoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            /* ClaimsPrincipal currentUser = this.User;
             var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
             ViewData["currentUser"] = currentUserID;*/

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            //return View(restaurant);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewData["restauranId"] = id;
            ViewData["currentUser"] = currentUserID;
            return View();
        }



        [HttpPost]
        public ActionResult CreateSchema(List<string> tableJson)
        {
            foreach(var a in tableJson)
            {
                PhysicalTable x = new PhysicalTable();
              
                x.isReserved = false;
            }
            return View("~/Restaurants/Index.cshtml");
        }
        public async Task<IActionResult> TestAction([FromBody]List<PhysicalTable> PhyiscalT)
        {
            foreach (var a in PhyiscalT)
            {
                _context.Add(a);
            }
            await _context.SaveChangesAsync();

            return Json("ok");
        }
    }
}