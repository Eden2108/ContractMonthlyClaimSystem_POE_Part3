using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using System;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Shows register for a new user
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Please complete the form.";
                return View();
            }

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Message = "Email already registered.";
                return View();
            }

            user.Date = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["RegisteredRole"] = user.Role;
            return RedirectToAction("RegistrationSuccess");
        }

        //Shows registration success
        public IActionResult RegistrationSuccess()
        {
            ViewBag.Role = TempData["RegisteredRole"]?.ToString() ?? "User";
            return View();
        }

        //Allows user to login if account already exists
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Message = "Invalid credentials.";
                return View();
            }

            return user.Role switch
            {
                "Lecturer" => RedirectToAction("Index", "Lecturer"),
                "Coordinator" or "ProgrammeCoordinator" => RedirectToAction("Index", "ProgrammeCoordinator"),
                "Manager" or "AcademicManager" => RedirectToAction("Index", "AcademicManager"),
                "HR" => RedirectToAction("Index", "HR"),
                _ => RedirectToAction("Index", "Home")
            };
        }
    }
}
