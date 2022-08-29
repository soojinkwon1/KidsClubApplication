using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidsClubApplication.Data;
using KidsClubApplication.Models;

namespace KidsClubApplication.Controllers
{
    public class CompetionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Competions
        public async Task<IActionResult> Index()
        {
              return _context.Competion != null ? 
                          View(await _context.Competion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Competion'  is null.");
        }

        // GET: Competions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Competion == null)
            {
                return NotFound();
            }

            var competion = await _context.Competion
                .FirstOrDefaultAsync(m => m.CompetionId == id);
            if (competion == null)
            {
                return NotFound();
            }

            return View(competion);
        }

        // GET: Competions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetionId,Title,Descriptino,StartDate,EndDate")] Competion competion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competion);
        }

        // GET: Competions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Competion == null)
            {
                return NotFound();
            }

            var competion = await _context.Competion.FindAsync(id);
            if (competion == null)
            {
                return NotFound();
            }
            return View(competion);
        }

        // POST: Competions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetionId,Title,Descriptino,StartDate,EndDate")] Competion competion)
        {
            if (id != competion.CompetionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetionExists(competion.CompetionId))
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
            return View(competion);
        }

        // GET: Competions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Competion == null)
            {
                return NotFound();
            }

            var competion = await _context.Competion
                .FirstOrDefaultAsync(m => m.CompetionId == id);
            if (competion == null)
            {
                return NotFound();
            }

            return View(competion);
        }

        // POST: Competions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Competion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Competion'  is null.");
            }
            var competion = await _context.Competion.FindAsync(id);
            if (competion != null)
            {
                _context.Competion.Remove(competion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetionExists(int id)
        {
          return (_context.Competion?.Any(e => e.CompetionId == id)).GetValueOrDefault();
        }
    }
}
