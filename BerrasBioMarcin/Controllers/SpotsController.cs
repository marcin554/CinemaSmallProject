#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBioMarcin.Data;
using BerrasBioMarcin.Models;

namespace BerrasBioMarcin.Controllers
{
    public class SpotsController : Controller
    {
        private readonly BerrasBioMarcinContext _context;

        public SpotsController(BerrasBioMarcinContext context)
        {
            _context = context;
        }

        // GET: Spots
        public async Task<IActionResult> Index()
        {
            var berrasBioMarcinContext = _context.Spot.Include(s => s.Salon).Include(s => s.Shows);
            return View(await berrasBioMarcinContext.ToListAsync());
        }

        // GET: Spots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spot
                .Include(s => s.Salon)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.SpotID == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // GET: Spots/Create
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salon, "SalonId", "SalonId");
            ViewData["ShowId"] = new SelectList(_context.Show, "ShowID", "ShowID");
            return View();
        }

        // POST: Spots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpotID,SpotIsTaken,SalonId,ShowId")] Spot spot)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(spot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salon, "SalonId", "SalonId", spot.SalonId);
            ViewData["ShowId"] = new SelectList(_context.Show, "ShowID", "ShowID", spot.ShowId);
            return View(spot);
        }

        // GET: Spots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spot.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }
            ViewData["SalonId"] = new SelectList(_context.Salon, "SalonId", "SalonId", spot.SalonId);
            ViewData["ShowId"] = new SelectList(_context.Show, "ShowID", "ShowID", spot.ShowId);
            return View(spot);
        }

        // POST: Spots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpotID,SpotIsTaken,SalonId,ShowId")] Spot spot)
        {
            if (id != spot.SpotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotExists(spot.SpotID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salon, "SalonId", "SalonId", spot.SalonId);
            ViewData["ShowId"] = new SelectList(_context.Show, "ShowID", "ShowID", spot.ShowId);
            return View(spot);
        }

        // GET: Spots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spot = await _context.Spot
                .Include(s => s.Salon)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.SpotID == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spot = await _context.Spot.FindAsync(id);
            _context.Spot.Remove(spot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotExists(int id)
        {
            return _context.Spot.Any(e => e.SpotID == id);
        }
    }
}
