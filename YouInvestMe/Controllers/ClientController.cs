using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Data;
using YouInvestMe.Models;

namespace YouInvestMe.Controllers
{
    // Requires the manager role to access anything related to this controller
    [Authorize(Roles = "Manager")]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Imports context for CRUD operations with MySQL database
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Client
        // Returns all of the clients from the database table
        public async Task<IActionResult> Index()
        {
              return _context.Client != null ? 
                          View(await _context.Client.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Client'  is null.");
        }

        // GET: Client/Details/5
        // Returns a more detailed view of a selected client
        public async Task<IActionResult> Details(int? id)
        {
            // Shows an error if the client does not exist
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            var ideas = await _context.Idea.Where(u => u.Clients.Any(i => i.ClientId == id)).ToListAsync();
            ViewBag.Ideas = ideas;
            return View(client);
        }

        // GET: Client/Create
        // Returns the Client/Create view
        public IActionResult Create()
        {
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,Name,Description,Region,RiskLevelId")] Client client)
        {
            // Checks if the inputted values fit the Client Model
            if (ModelState.IsValid)
            {
                // Adds a new client to the database
                _context.Add(client);
                await _context.SaveChangesAsync();
                // Returns the user to /Client/Index
                return RedirectToAction(nameof(Index));
            }
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", client.RiskLevelId);
            return View(client);
        }

        // GET: Client/Edit/5
        // Returns the view for /Client/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            // Shows an error if the client does not exist
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", client.RiskLevelId);
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Takes the values inputted and edits the client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Name,Description,Region,RiskLevelId")] Client client)
        {
            // If the selected id does not match the ClientId return error
            if (id != client.ClientId)
            {
                return NotFound();
            }

            // Checks if the inputted data fits the client model
            if (ModelState.IsValid)
            {
                try
                {
                    // Attempt to update the client info
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Return error if edit tries to change the id to one that already exists
                    if (!ClientExists(client.ClientId))
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
            ViewData["RiskLevelId"] = new SelectList(_context.RiskLevel, "RiskLevelId", "RiskLevelId", client.RiskLevelId);
            return View(client);
        }

        // GET: Client/Delete/5
        // Controller to delete a client from the database
        public async Task<IActionResult> Delete(int? id)
        {
            // Return error if selected client does not exist
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            // Checks if the client instance is not fully null
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        // Controller to complete deletion action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Checks if client is null and returns error if so
            if (_context.Client == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Client' is null.");
            }
            // Deletes the selected client
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Used in edit controller to confirm of the client exists
        private bool ClientExists(int id)
        {
          return (_context.Client?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
