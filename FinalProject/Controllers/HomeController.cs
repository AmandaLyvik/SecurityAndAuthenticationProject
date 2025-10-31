using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("Username");
        ViewData["Username"] = username;
        return View();
    }

    [HttpPost("/")]
    public IActionResult Logout(string action)
    {
        if (action == "logout")
        {
            HttpContext.Session.Clear();
        }

        var username = HttpContext.Session.GetString("Username");
        ViewData["Username"] = username;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
