using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudIceTaskOne.Data;
using CloudIceTaskOne.Models;

namespace CloudIceTaskOne.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly CloudIceTaskOneContext _context;

        public CarModelsController(CloudIceTaskOneContext context)
        {
            _context = context;
        }

        // GET: CarModels
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.CarModels == null)
            {
                return Problem("Entity set 'CloudIceTaskOneContext.CarModels'  is null.");
            }

            var movies = from m in _context.CarModels
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.CarType.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // GET: CarModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarType,CarModel,ReleaseDate,Price,NumberOfPayments")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModels);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels.FindAsync(id);
            if (carModels == null)
            {
                return NotFound();
            }
            return View(carModels);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarType,CarModel,ReleaseDate,Price,NumberOfPayments")] CarModels carModels)
        {
            if (id != carModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelsExists(carModels.Id))
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
            return View(carModels);
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModels = await _context.CarModels.FindAsync(id);
            if (carModels != null)
            {
                _context.CarModels.Remove(carModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelsExists(int id)
        {
            return _context.CarModels.Any(e => e.Id == id);
        }
    }
}
