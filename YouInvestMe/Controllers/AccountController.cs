using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouInvestMe.Data;
using YouInvestMe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;

namespace YouInvestMe.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        // Imports config for dependencies 
        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        // Returns the view for /Account/Index
        public IActionResult Index()
        {
            return View();
        }

        // Returns the view for /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Takes the values inputted to the Register Form and creates an account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel userModel)
        {
            // Checks if the inputted values fit the UserRegistration model
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            // Maps the variables to fit the User model
            var user = _mapper.Map<User>(userModel);

            // Creates a new account using the AspNetCore.Identity framework
            var result = await _userManager.CreateAsync(user, userModel.Password);
            
            // If an account cannot be created returns relevant errors
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userModel);
            }

            // Assigns a role to the new account based on if the user has a youinvest.me domain email
            string domain = userModel.Email.Substring(userModel.Email.LastIndexOf('@') + 1);

            if (domain.ToLower() == "youinvest.me")
            {
                await _userManager.AddToRoleAsync(user, "Manager");
            }
            
            else 
            { 
                await _userManager.AddToRoleAsync(user, "Creator"); 
            }
            

            // If all is successful redirect to the home page
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // Returns the view for /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Stores the url the user came from so they can be returned there
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // Takes the values inputted into the login form and validates
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel, string returnUrl = null)
        {
            // Checks if the inputted values fit the UserLogin model
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            // Attempts to sign in using AspNetCore.Identity framework
            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            // If login is successful redirect to where the user came from
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            // If login fails display below message
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
        }

        // Controller for logout button action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Signs user out using AspNetCore.Identity framework
            await _signInManager.SignOutAsync();

            // Returns user to home page
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // Used in the login action to redirect user back to their return url
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
