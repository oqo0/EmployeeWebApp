using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}