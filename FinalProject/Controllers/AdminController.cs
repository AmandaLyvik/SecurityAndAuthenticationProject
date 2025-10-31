using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using FinalProject.Helpers;
using FinalProject.Services;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthService _authService;

        public AdminController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpGet("/admin")]
        public IActionResult AdminDashboard()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username) || !_authService.IsUserAdmin(username))
            {
                return Unauthorized(); // or RedirectToAction("Index", "Home")
            }

            return View("AdminDashboard");
        }
    }
}