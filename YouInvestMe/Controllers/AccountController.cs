using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Data;
using YouInvestMe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace YouInvestMe.Controllers
{
    public class AccountController : Controller
    {
        // Bandaid patch until I find a better way to do this
        public static class DbContextHelper
        {
            public static DbContextOptions<ApplicationDbContext> GetDbContextOptions()
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();


                return new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseSqlServer(new SqlConnection(configuration.GetConnectionString("local"))).Options;

            }
        }

        public const string UserID = "";
        public const string Username = "";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Register Account
        public IActionResult Register(Account account)
        {
            var dbContextOptions = DbContextHelper.GetDbContextOptions();
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext(dbContextOptions))
                {
                    db.Account.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " successfully registered.";
            }
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Login
        public IActionResult Login(Account user)
        {
            var dbContextOptions = DbContextHelper.GetDbContextOptions();
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext(dbContextOptions))
                {
                    var usr = db.Account.Single(u => u.Username == user.Username && u.Password == user.Password);
                    if (usr != null)
                    {
                        HttpContext.Session.SetString(UserID, usr.UserId.ToString());
                        HttpContext.Session.SetString(Username, usr.Username.ToString());
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong.");
                    }
                }
            }
            return View();
        }

        public IActionResult LoggedIn()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UserID)))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
