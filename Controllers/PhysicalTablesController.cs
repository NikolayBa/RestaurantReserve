using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReserve.Data;
using RestaurantReserve.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReserve.Controllers
{
    public class PhysicalTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhysicalTablesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PhysicalTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhysicalTables.ToListAsync());
        }

        public async Task<IActionResult> Redisplay(int? id)
        {
            var applicationDbContext = _context.PhysicalTables;
            var restaurantsDbContext = _context.Restaurants;

            var currentPhysicalTables = applicationDbContext.Where(r => r.restaurantId == id);

            var restaurantName = restaurantsDbContext.SingleOrDefault(re => re.restaurantId == id);
            ViewData["RestaurantName"] = restaurantName.name;
            return View(await currentPhysicalTables.ToListAsync());
        }

        public async Task<IActionResult> AdminRedisplay(int? id)
        {
            var applicationDbContext = _context.PhysicalTables;
            var restaurantsDbContext = _context.Restaurants;

            var currentPhysicalTables = applicationDbContext.Where(r => r.restaurantId == id);

            var restaurantName = restaurantsDbContext.SingleOrDefault(re => re.restaurantId == id);
            ViewData["RestaurantName"] = restaurantName.name;
            return View(await currentPhysicalTables.ToListAsync());

        }

        public async Task<IActionResult> CurrentReservations(int? id)
        {
            var applicationDbContext = _context.PhysicalTables;
            var restaurantsDbContext = _context.Restaurants;

            var currentPhysicalTables = applicationDbContext.Where(r => r.restaurantId == id);

            var restaurantName = restaurantsDbContext.SingleOrDefault(re => re.restaurantId == id);
            ViewData["RestaurantName"] = restaurantName.name;
            return View(await currentPhysicalTables.ToListAsync());
        }

        // GET: PhysicalTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            if (physicalTable == null)
            {
                return NotFound();
            }

           
            return RedirectToAction("Owned","Restaurants");
        }

        // GET: PhysicalTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhysicalTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,isReserved,leftPos,objHeight,objWidth,restaurantId,rotationAng,topPos,type")] PhysicalTable physicalTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(physicalTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(physicalTable);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMyModels(List<PhysicalTable> multipleTables)
        {
            if (ModelState.IsValid)
            {
                foreach (var physTable in multipleTables)
                {
                    _context.Add(physTable);
                    
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: PhysicalTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            if (physicalTable == null)
            {
                return NotFound();
            }
            return View(physicalTable);
        }

        [Authorize]
        public async Task<IActionResult> ReserveSpecific(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            ViewData["currentUserName"] = currentUserName;

            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            if (physicalTable == null)
            {
                return NotFound();
            }
            return View(physicalTable);
        }

        public async Task<IActionResult> ReserveOrFree(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            ViewData["currentUserName"] = currentUserName;

            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            if (physicalTable == null)
            {
                return NotFound();
            }
            return View(physicalTable);
        }

        // POST: PhysicalTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,isReserved,leftPos,objHeight,objWidth,restaurantId,rotationAng,topPos,type,reservedBy")] PhysicalTable physicalTable)
        {
            if (id != physicalTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physicalTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicalTableExists(physicalTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AdminRedisplay", "PhysicalTables", new { id = physicalTable.restaurantId });
            }
            return View(physicalTable);
        }

        public async Task<IActionResult> Reserve(int id, [Bind("Id,isReserved,leftPos,objHeight,objWidth,restaurantId,rotationAng,topPos,type,reservedBy,reservedFor")] PhysicalTable physicalTable)
        {
            if (id != physicalTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physicalTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicalTableExists(physicalTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Redisplay", "PhysicalTables", new { id = physicalTable.restaurantId });
            }
            return View(physicalTable);
        }

        public async Task<IActionResult> ReservationEdit(int id, [Bind("Id,isReserved,leftPos,objHeight,objWidth,restaurantId,rotationAng,topPos,type,reservedBy,reservedFor")] PhysicalTable physicalTable)
        {
            if (id != physicalTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physicalTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicalTableExists(physicalTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CurrentReservations", "PhysicalTables", new { id = physicalTable.restaurantId });
            }
            return View(physicalTable);
        }

        // GET: PhysicalTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            if (physicalTable == null)
            {
                return NotFound();
            }

            return View(physicalTable);
        }

        // POST: PhysicalTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var physicalTable = await _context.PhysicalTables.SingleOrDefaultAsync(m => m.Id == id);
            _context.PhysicalTables.Remove(physicalTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminRedisplay", "PhysicalTables", new { id = physicalTable.restaurantId });
        }

        private bool PhysicalTableExists(int id)
        {
            return _context.PhysicalTables.Any(e => e.Id == id);
        }
    }
}
