using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using ContractMonthlyClaimSystem.Helpers;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HRController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all claims ready for payment
        public IActionResult Index()
        {
            var toProcess = _context.Claims
                .Where(c => c.ClaimStatus == "Manager Approved")
                .OrderByDescending(c => c.CreatingDate)
                .ToList();
            return View(toProcess);
        }

        // Mark a claim as Paid
        [HttpPost]
        public IActionResult MarkAsPaid(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                var old = claim.ClaimStatus;
                claim.ClaimStatus = "Paid";
                _context.SaveChanges();

                HistoryHelper.AddHistory(_context, id, 4, old ?? "Unknown", claim.ClaimStatus, "Marked as Paid by HR");
            }
            TempData["Message"] = "Claim marked as Paid.";
            return RedirectToAction("Index");
        }

        // Display an invoice for a claim
        public IActionResult Invoice(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null)
                return NotFound();

            return View(claim);
        }
    }
}
