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
    public class ProductTagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductTag
        public async Task<IActionResult> Index()
        {
              return _context.ProductTag != null ? 
                          View(await _context.ProductTag.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductTag'  is null.");
        }

        // GET: ProductTag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag
                .FirstOrDefaultAsync(m => m.ProductTagId == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // GET: ProductTag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductTagId,Title,Description")] ProductTag productTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTag);
        }

        // GET: ProductTag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag == null)
            {
                return NotFound();
            }
            return View(productTag);
        }

        // POST: ProductTag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductTagId,Title,Description")] ProductTag productTag)
        {
            if (id != productTag.ProductTagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTagExists(productTag.ProductTagId))
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
            return View(productTag);
        }

        // GET: ProductTag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTag == null)
            {
                return NotFound();
            }

            var productTag = await _context.ProductTag
                .FirstOrDefaultAsync(m => m.ProductTagId == id);
            if (productTag == null)
            {
                return NotFound();
            }

            return View(productTag);
        }

        // POST: ProductTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTag == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductTag'  is null.");
            }
            var productTag = await _context.ProductTag.FindAsync(id);
            if (productTag != null)
            {
                _context.ProductTag.Remove(productTag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTagExists(int id)
        {
          return (_context.ProductTag?.Any(e => e.ProductTagId == id)).GetValueOrDefault();
        }
    }
}
