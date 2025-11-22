using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Models;
using System.Linq;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Pending = _context.Claims.Count(c => c.ClaimStatus == "Pending");
            ViewBag.CoordinatorApproved = _context.Claims.Count(c => c.ClaimStatus == "Coordinator Approved");
            ViewBag.ManagerApproved = _context.Claims.Count(c => c.ClaimStatus == "Manager Approved");
            ViewBag.Paid = _context.Claims.Count(c => c.ClaimStatus == "Paid");
            return View();
        }
    }
}
