using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using ContractMonthlyClaimSystem.Helpers;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ProgrammeCoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProgrammeCoordinatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pending = _context.Claims.Where(c => c.ClaimStatus == "Pending").OrderByDescending(c => c.CreatingDate).ToList();
            return View(pending);
        }

        //Approve button
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim != null)
            {
                var old = claim.ClaimStatus;
                claim.ClaimStatus = "Coordinator Approved";
                _context.SaveChanges();

                HistoryHelper.AddHistory(_context, id, 2, old ?? "Unknown", claim.ClaimStatus, "Approved by Coordinator");
            }
            TempData["Message"] = "Claim approved (Coordinator).";
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

                HistoryHelper.AddHistory(_context, id, 2, old ?? "Unknown", claim.ClaimStatus, "Rejected by Coordinator");
            }
            TempData["Message"] = "Claim rejected (Coordinator).";
            return RedirectToAction("Index");
        }
    }
}
