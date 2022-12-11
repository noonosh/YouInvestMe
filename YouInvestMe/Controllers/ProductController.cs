using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Data;
using YouInvestMe.Models;

namespace YouInvestMe.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Create context for CRUD operations with MySQL database
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        // Return all products from database
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.RiskLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        // Gets the {id} from the route in URL
        public async Task<IActionResult> Details(int? id)
        {
            // If there is no product id, return 404 Not Found
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.RiskLevel)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            // If there is no product details, return 404 Not Found
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        //Show the form for displaying the 
        public IActionResult Create()
        {
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,InternalInstrumentId,InstrumentDisplayName,InstrumentName,AssetType,Region,Country,PriceCurrency,ClosingPrice,RiskLevelId")] Product product)
        {
            // Check if the Model state is valid
            if (ModelState.IsValid)
            {
                // Add record to the database
                _context.Add(product);
                // Maps to SQL query as: "INSERT INTO Product (...) VALUES (...)"
                // (...) is what comes in the arguments of this function

                // Asynchronously save changes to the database
                await _context.SaveChangesAsync();

                // Return to the index page of all products
                return RedirectToAction(nameof(Index));
            }
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", product.RiskLevelId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // If there is no product to edit, return 404 Not Found
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            // If there is no product to edit, return 404 Not Found
            if (product == null)
            {
                return NotFound();
            }
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", product.RiskLevelId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,InternalInstrumentId,InstrumentDisplayName,InstrumentName,AssetType,Region,Country,PriceCurrency,ClosingPrice,RiskLevelId")] Product product)
        {
            // If there is no product to edit, return 404 Not Found
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the database with new records
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Return Index view at the end
                return RedirectToAction(nameof(Index));
            }
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", product.RiskLevelId);
            return View(product);
        }

        // GET: Product/Delete/5
        // Returns to confirmation view that the product with id given in the /{id} part of the URL
        // is going to be deleted.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.RiskLevel)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                // Delete operation with Entity Framework
                // Binds to SQL query -> DELETE FROM Product WHERE ProductId = id; 
                _context.Product.Remove(product);
            }

            // Update the database with new changes
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper function that checks whether the product with the given id exists or not
        // Return type `bool`
        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
