using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using secure_programming.Data;
using secure_programming.Models;

namespace secure_programming.Controllers
{
    public class AirplanesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirplanesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airplanes
        public async Task<IActionResult> Index()
        {
              return _context.Airplane != null ? 
                          View(await _context.Airplane.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Airplane'  is null.");
        }

        // GET: Airplanes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Airplane == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane
                .FirstOrDefaultAsync(m => m.AirplaneID == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirplaneID,Name,MaxSeat,FlightID")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airplane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Airplane == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane.FindAsync(id);
            if (airplane == null)
            {
                return NotFound();
            }
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AirplaneID,Name,MaxSeat,FlightID")] Airplane airplane)
        {
            if (id != airplane.AirplaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airplane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirplaneExists(airplane.AirplaneID))
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
            return View(airplane);
        }

        // GET: Airplanes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Airplane == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane
                .FirstOrDefaultAsync(m => m.AirplaneID == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Airplane == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Airplane'  is null.");
            }
            var airplane = await _context.Airplane.FindAsync(id);
            if (airplane != null)
            {
                _context.Airplane.Remove(airplane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirplaneExists(string id)
        {
          return (_context.Airplane?.Any(e => e.AirplaneID == id)).GetValueOrDefault();
        }
    }
}
