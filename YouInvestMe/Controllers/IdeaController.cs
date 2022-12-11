using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using YouInvestMe.Data;
using YouInvestMe.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YouInvestMe.Controllers
{
    [Authorize]
    public class IdeaController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Create context for CRUD operations with MySQL database
        public IdeaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Idea    
        // Return all ideas from database

        // However, if there is a certain search string,
        // return only matches against title from database
        public async Task<IActionResult> Index(string searchString)
        {

            if (_context.Idea == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Idea'  is null.");
            }
            var ideas = from i in _context.Idea
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                ideas = ideas.Where(s => s.Title!.Contains(searchString));
            }

            return View(await ideas.OrderByDescending(x => x.PublishedDate).ToListAsync());
        }


        // GET: Idea/Details/5
        // Expanded version of the idea record in the database
        // Returns 404 Not Found if the record does not exist

        // Gets the {id} from the route in URL
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
        public async Task<IActionResult> Create([Bind("IdeaId,Title,Abstract,PublishedDate,ExpiriesDate,ProductType,Instruments,Currency,Region,Country,UserID")] Idea idea)
        {
            // Check if the Model state is valid
            if (ModelState.IsValid)
            {
                // Set published date attribute to current date today.
                idea.PublishedDate = DateTime.Now;

                // Identify who created the idea and set it as UserID
                idea.UserID = User.Identity.Name;

                // Add record to the database
                _context.Add(idea);
                // Maps to SQL query as: "INSERT INTO Ideas (...) VALUES (...)"
                // (...) is what comes in the arguments of this function

                // Asynchronously save changes to the database
                await _context.SaveChangesAsync();

                // Return to the index page of all ideas
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

        [Authorize(Roles = "Manager")] // Only managers can assign Client to the idea
        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null || _context.Idea == null)
            {
                return NotFound();
            }

            var idea = await _context.Client.ToListAsync();
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
        public async Task<IActionResult> Edit(int id, [Bind("IdeaId,Title,Abstract,ExpiriesDate,ProductType,Instruments,Currency,Region,Country")] Idea idea)
        {
            // If there is no idea to edit, return 404 Not Found
            if (id != idea.IdeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the database with new records
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
                // Return Index view at the end
                return RedirectToAction(nameof(Index));
            }
            return View(idea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        // Validating roles and http-form-post attacks (brute force, DoS)
        public async Task<IActionResult> Assign(int id, int clientid, ClientIdea ct)
        {
            if (ModelState.IsValid)
            {
                ct.IdeaId = id;
                ct.ClientId = clientid;

                // TODO: Prevent from assigning the same client to the idea TWICE

                // var matching = _context.ClientIdea.Where(x => x == ct).ToListAsync();
                // if (matching == null)
                // {

                // Assign client to the current idea
                _context.ClientIdea.Add(ct);
                await _context.SaveChangesAsync();
                // }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Idea/Delete/5
        // Returns to confirmation view that the idea with id given in the /{id} part of the URL
        // is going to be deleted.
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
                // Delete operation with Entity Framework
                // Binds to SQL query -> DELETE FROM Ideas WHERE IdeaId = id; 
                _context.Idea.Remove(idea);
            }

            // Update the database with new changes
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Helper function that checks whether the idea with the given id exists or not
        // Return type `bool`
        private bool IdeaExists(int id)
        {
            return (_context.Idea?.Any(e => e.IdeaId == id)).GetValueOrDefault();
        }
    }
}
