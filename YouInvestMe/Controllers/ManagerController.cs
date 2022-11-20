using Microsoft.AspNetCore.Mvc;
using YouInvestMe.Models;

namespace YouInvestMe.Controllers;

public class ManagerController : Controller
{

    public IActionResult Index()
    {

        return View(new Manager { Name="John Smith"});
    }
    
    public IActionResult Edit(int some_id) {
        return Content("id is " + some_id);
    }


}

