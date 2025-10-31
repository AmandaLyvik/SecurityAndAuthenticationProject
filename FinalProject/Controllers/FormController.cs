using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using FinalProject.Helpers;
using FinalProject.Services;

namespace FinalProject.Controllers
{
    public class FormController : Controller
    {
        private readonly AuthService _authService;

        public FormController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
            var users = _authService.GetAllUsers();
            ViewData["Users"] = users;
            return View(new UserInput());
        }

        [HttpPost("/")]
        public IActionResult Submit(UserInput input)
        {
            if (!InputValidator.IsValidInput(input.Username, "@#$") ||
                !InputValidator.IsValidInput(input.Email, "@._"))
            {
                ModelState.AddModelError("", "Invalid input: disallowed characters or potential XSS detected.");
                ViewData["Users"] = _authService.GetAllUsers();
                return View("Index", input);
            }

            _authService.StoreUser(input);
            ModelState.Clear();
            ViewData["Users"] = _authService.GetAllUsers();
            return View("Index", new UserInput());
        }
    }
}
