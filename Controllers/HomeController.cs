using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
