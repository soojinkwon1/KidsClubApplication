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
    public class NewsLettersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsLettersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsLetters
        public async Task<IActionResult> Index()
        {
              return _context.NewsLetter != null ? 
                          View(await _context.NewsLetter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NewsLetter'  is null.");
        }

        // GET: NewsLetters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewsLetter == null)
            {
                return NotFound();
            }

            var newsLetter = await _context.NewsLetter
                .FirstOrDefaultAsync(m => m.NewsLetterId == id);
            if (newsLetter == null)
            {
                return NotFound();
            }

            return View(newsLetter);
        }

        // GET: NewsLetters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsLetters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsLetterId,CreateDate")] NewsLetter newsLetter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsLetter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsLetter);
        }

        // GET: NewsLetters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewsLetter == null)
            {
                return NotFound();
            }

            var newsLetter = await _context.NewsLetter.FindAsync(id);
            if (newsLetter == null)
            {
                return NotFound();
            }
            return View(newsLetter);
        }

        // POST: NewsLetters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsLetterId,CreateDate")] NewsLetter newsLetter)
        {
            if (id != newsLetter.NewsLetterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsLetter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsLetterExists(newsLetter.NewsLetterId))
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
            return View(newsLetter);
        }

        // GET: NewsLetters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewsLetter == null)
            {
                return NotFound();
            }

            var newsLetter = await _context.NewsLetter
                .FirstOrDefaultAsync(m => m.NewsLetterId == id);
            if (newsLetter == null)
            {
                return NotFound();
            }

            return View(newsLetter);
        }

        // POST: NewsLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewsLetter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NewsLetter'  is null.");
            }
            var newsLetter = await _context.NewsLetter.FindAsync(id);
            if (newsLetter != null)
            {
                _context.NewsLetter.Remove(newsLetter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsLetterExists(int id)
        {
          return (_context.NewsLetter?.Any(e => e.NewsLetterId == id)).GetValueOrDefault();
        }
    }
}
