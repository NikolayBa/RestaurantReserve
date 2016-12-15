using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReserve.Data;
using RestaurantReserve.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReserve.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public RestaurantsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Restaurants
        public async Task<IActionResult> Owned()
        {
             ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationDbContext = _context.Restaurants.Include(r => r.User);

            var ownedRestaurants = applicationDbContext.Where(r => r.UserId == currentUserID);

            return View(await ownedRestaurants.ToListAsync());
        }

        public async Task<IActionResult> Index()
        {
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var applicationDbContext = _context.Restaurants.Include(r => r.User);

            //var ownedRestaurants = applicationDbContext.Where(r => r.UserId == currentUserID);

            return View(await _context.Restaurants.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        public async Task<IActionResult> Redisplay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var applicationDbContext = _context.PhysicalTables;

            var currentPhysicalTables = applicationDbContext.Where(r => r.restaurantId == id);

            return View(await currentPhysicalTables.ToListAsync());
        }

        // GET: Restaurants/Create
        [Authorize]
        public IActionResult Create()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["UserId"] = currentUserID;
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("restaurantId,address,city,name,pictureUrl,UserId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Owned", "Restaurants");
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", restaurant.UserId);


            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", restaurant.UserId);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["UserId"] = currentUserID;
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("restaurantId,UserId,address,city,name,pictureUrl")] Restaurant restaurant)
        {
            if (id != restaurant.restaurantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.restaurantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Owned", "Restaurants");
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", restaurant.UserId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(m => m.restaurantId == id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Owned", "Restaurants");
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.restaurantId == id);
        }
    }
}
