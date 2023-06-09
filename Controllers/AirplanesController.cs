﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // Links to database
        public AirplanesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airplanes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return _context.Airplane != null ?
                        View(await _context.Airplane.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Airplane'  is null.");
        }

        // GET: Airplanes/SearchPlanes
        [Authorize]
        public async Task<IActionResult> SearchPlanes()
        {
            return View();
        }

        // POST: Airplanes/search
        [Authorize]
        public async Task<IActionResult> SearchResults(String SearchPlane)
        {
            return _context.Airplane != null ?
                          View("Index", await _context.Airplane.Where(a => a.AirplaneID.Contains(SearchPlane)).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Airplane'  is null.");
        }

        // GET: Airplanes/Details/5
        [Authorize]
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
        [Authorize(Roles = "StaffMember")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "StaffMember")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirplaneID,Name,MaxSeat,FlightID,AirportDestination,AirportOrigin,Assigned")] Airplane airplane)
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
        [Authorize(Roles = "StaffMember")]
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
        [Authorize(Roles = "StaffMember")]
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
        [Authorize(Roles = "StaffMember")]
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
        [Authorize(Roles = "StaffMember")]
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
