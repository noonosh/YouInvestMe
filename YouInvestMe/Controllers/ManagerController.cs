using Microsoft.AspNetCore.Mvc;
using YouInvestMe.Models;

namespace YouInvestMe.Controllers;

public class ManagerController : Controller
{

    public IActionResult Index()
    {

        return View(new Manager {ID = 2, Name="Ulugbek"});
    }


}

