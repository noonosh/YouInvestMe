using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using YouInvestMe.Models;
using YouInvestMe.Data;

namespace YouInvestMe.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        return _context.Idea != null ?
                          View(await _context.Idea.OrderByDescending(x => x.PublishedDate).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Idea'  is null.");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Search(string keyword)
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

