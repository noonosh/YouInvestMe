using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Data;
using YouInvestMe.Models;

namespace YouInvestMe.Controllers
{
    public class IdeaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Idea
        public async Task<IActionResult> Index()
        {
              return _context.Idea != null ? 
                          View(await _context.Idea.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Idea'  is null.");
        }

        // GET: Idea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Idea == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .FirstOrDefaultAsync(m => m.IdeaId == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // GET: Idea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Idea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeaId,Title,Abstract,PublishedDate,ExpiriesDate,ProductType,Instruments,Currency,Region,Country")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idea);
        }

        // GET: Idea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Idea == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea.FindAsync(id);
            if (idea == null)
            {
                return NotFound();
            }
            return View(idea);
        }

        // POST: Idea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdeaId,Title,Abstract,PublishedDate,ExpiriesDate,ProductType,Instruments,Currency,Region,Country")] Idea idea)
        {
            if (id != idea.IdeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaExists(idea.IdeaId))
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
            return View(idea);
        }

        // GET: Idea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Idea == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .FirstOrDefaultAsync(m => m.IdeaId == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Idea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Idea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Idea'  is null.");
            }
            var idea = await _context.Idea.FindAsync(id);
            if (idea != null)
            {
                _context.Idea.Remove(idea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaExists(int id)
        {
          return (_context.Idea?.Any(e => e.IdeaId == id)).GetValueOrDefault();
        }
    }
}
