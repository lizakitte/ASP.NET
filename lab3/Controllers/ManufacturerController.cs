using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace lab3_App.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly AppDbContext _context;

        public ManufacturerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manufacturer
        public async Task<IActionResult> Index()
        {
              return _context.Manufacturers != null ? 
                          View(await _context.Manufacturers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Manufacturers'  is null.");
        }

        // GET: Manufacturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.ManufacturerId == id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }

            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ManufacturerId,Name")] ManufacturerEntity manufacturerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers.FindAsync(id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }
            return View(manufacturerEntity);
        }

        // POST: Manufacturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManufacturerId,Name")] ManufacturerEntity manufacturerEntity)
        {
            if (id != manufacturerEntity.ManufacturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerEntityExists(manufacturerEntity.ManufacturerId))
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
            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.ManufacturerId == id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }

            return View(manufacturerEntity);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manufacturers == null)
            {
                return Problem("Entity set 'AppDbContext.Manufacturers'  is null.");
            }
            var manufacturerEntity = await _context.Manufacturers.FindAsync(id);
            if (manufacturerEntity != null)
            {
                _context.Manufacturers.Remove(manufacturerEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerEntityExists(int id)
        {
          return (_context.Manufacturers?.Any(e => e.ManufacturerId == id)).GetValueOrDefault();
        }
    }
}
