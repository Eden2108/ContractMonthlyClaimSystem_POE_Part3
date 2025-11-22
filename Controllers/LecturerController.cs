using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using System;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Shows the submit claim form for the lecturer
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Please complete all required fields.";
                return View("Index");
            }

            claim.LecturerID = 1; // demo lecturer ID
            claim.LecturerName = _context.Users.Where(u => u.UserID == claim.LecturerID).Select(u => u.FullNames).FirstOrDefault() ?? "Lecturer";
            claim.TotalAmount = claim.NumberOfHours * claim.HourlyRate * claim.NumberOfSessions;
            claim.CreatingDate = DateTime.Now;
            claim.ClaimStatus = "Pending";

            _context.Claims.Add(claim);
            _context.SaveChanges();

            ViewBag.Message = "Claim submitted successfully.";
            return View("Index");
        }

        //Allows use to track their claim 
        public IActionResult TrackClaim()
        {
            var claims = _context.Claims.Where(c => c.LecturerID == 1).OrderByDescending(c => c.CreatingDate).ToList();
            return View(claims);
        }
    }
}
