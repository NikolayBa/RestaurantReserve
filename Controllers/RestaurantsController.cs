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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurants.ToListAsync());
            //return View(await _context.ApplicationUser());
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //return View(await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Ownedrestaurants.First().name == "Happy"));
            //return View(await _context.ApplicationUser.First
         

            //var restaurant = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == currentUserID);

            //var currentrestaurant = restaurant.Ownedrestaurants.ToList();
            //return View(currentrestaurant);

            //return View(_context.Restaurants.ToLookup(m => m.))
        }

        public async Task<IActionResult> Tables()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewData["currentUser"] = currentUserID;
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
            //var restaurant = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Ownedrestaurants.First().restaurantId == id);

            //var currentrestaurant = restaurant.Ownedrestaurants.Single(m => m.restaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("restaurantId,address,city,name")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
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
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("restaurantId,address,city,name")] Restaurant restaurant)
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
                return RedirectToAction("Index");
            }
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
            return RedirectToAction("Index");
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.restaurantId == id);
        }
    }
}
