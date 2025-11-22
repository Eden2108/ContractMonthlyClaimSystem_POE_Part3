using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using ContractMonthlyClaimSystem.Helpers;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class AcademicManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AcademicManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var toReview = _context.Claims.Where(c => c.ClaimStatus == "Coordinator Approved").OrderByDescending(c => c.CreatingDate).ToList();
            return View(toReview);
        }

        //Approve Button
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                var old = claim.ClaimStatus;
                claim.ClaimStatus = "Manager Approved";
                _context.SaveChanges();

                HistoryHelper.AddHistory(_context, id, 3, old ?? "Unknown", claim.ClaimStatus, "Approved by Manager");
            }
            TempData["Message"] = "Claim approved (Manager).";
            return RedirectToAction("Index");
        }

        //Reject Button 
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                var old = claim.ClaimStatus;
                claim.ClaimStatus = "Rejected";
                _context.SaveChanges();

                HistoryHelper.AddHistory(_context, id, 3, old ?? "Unknown", claim.ClaimStatus, "Rejected by Manager");
            }
            TempData["Message"] = "Claim rejected (Manager).";
            return RedirectToAction("Index");
        }
    }
}
