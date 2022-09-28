using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidsClubApplication.Data;
using KidsClubApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace KidsClubApplication.Controllers
{
    public class KCActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KCActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KCActivities
        public async Task<IActionResult> Index()
        {
              return _context.KCActivity != null ? 
                          View(await _context.KCActivity.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.KCActivity'  is null.");
        }

        // GET: KCActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KCActivity == null)
            {
                return NotFound();
            }

            var kCActivity = await _context.KCActivity
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (kCActivity == null)
            {
                return NotFound();
            }

            return View(kCActivity);
        }

        // GET: KCActivities/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: KCActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ActivityId,Title,Description,ActivityDate,MediaType")] KCActivity kCActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kCActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kCActivity);
        }

        // GET: KCActivities/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KCActivity == null)
            {
                return NotFound();
            }

            var kCActivity = await _context.KCActivity.FindAsync(id);
            if (kCActivity == null)
            {
                return NotFound();
            }
            return View(kCActivity);
        }

        // POST: KCActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,Title,Description,ActivityDate,MediaType")] KCActivity kCActivity)
        {
            if (id != kCActivity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kCActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KCActivityExists(kCActivity.ActivityId))
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
            return View(kCActivity);
        }

        // GET: KCActivities/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KCActivity == null)
            {
                return NotFound();
            }

            var kCActivity = await _context.KCActivity
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (kCActivity == null)
            {
                return NotFound();
            }

            return View(kCActivity);
        }

        // POST: KCActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KCActivity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KCActivity'  is null.");
            }
            var kCActivity = await _context.KCActivity.FindAsync(id);
            if (kCActivity != null)
            {
                _context.KCActivity.Remove(kCActivity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KCActivityExists(int id)
        {
          return (_context.KCActivity?.Any(e => e.ActivityId == id)).GetValueOrDefault();
        }
    }
}
