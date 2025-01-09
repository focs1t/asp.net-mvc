using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMVC.Models;
using rest.Models;

namespace StudentMVC.Controllers
{
    public class AttractionsController : Controller
    {
        private readonly StudentDBContext _context;

        public AttractionsController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: Attractions
        public async Task<IActionResult> Index()
        {
              return _context.Attractions != null ? 
                          View(await _context.Attractions.ToListAsync()) :
                          Problem("Entity set 'StudentDBContext.Attractions'  is null.");
        }

        // GET: Attractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attractions == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attractions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attraction == null)
            {
                return NotFound();
            }

            return View(attraction);
        }

        // GET: Attractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Capacity,IsOperational")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attraction);
        }

        // GET: Attractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attractions == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attractions.FindAsync(id);
            if (attraction == null)
            {
                return NotFound();
            }
            return View(attraction);
        }

        // POST: Attractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Capacity,IsOperational")] Attraction attraction)
        {
            if (id != attraction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttractionExists(attraction.Id))
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
            return View(attraction);
        }

        // GET: Attractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attractions == null)
            {
                return NotFound();
            }

            var attraction = await _context.Attractions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attraction == null)
            {
                return NotFound();
            }

            return View(attraction);
        }

        // POST: Attractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attractions == null)
            {
                return Problem("Entity set 'StudentDBContext.Attractions'  is null.");
            }
            var attraction = await _context.Attractions.FindAsync(id);
            if (attraction != null)
            {
                _context.Attractions.Remove(attraction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttractionExists(int id)
        {
          return (_context.Attractions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
