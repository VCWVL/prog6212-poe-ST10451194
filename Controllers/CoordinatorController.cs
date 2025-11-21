using Microsoft.AspNetCore.Mvc;
using PROG_POE.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PROG_POE.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoordinatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard - show only Pending claims for verification
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Coordinator")
                return RedirectToAction("Login", "Auth");

            var claims = _context.Claims
                .Where(c => c.Status == ClaimStatus.Pending)
                .ToList();

            return View(claims);
        }

        // Verify claim
        [HttpGet]
        public IActionResult Verify(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Coordinator")
                return RedirectToAction("Login", "Auth");

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            return View(claim);
        }

        [HttpPost]
        public IActionResult Verify(Claim model, string actionType)
        {
            if (HttpContext.Session.GetString("Role") != "Coordinator")
                return RedirectToAction("Login", "Auth");

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == model.ClaimId);
            if (claim != null)
            {
                claim.Status = actionType == "Approve" ? ClaimStatus.Verified : ClaimStatus.Cancelled;
                claim.CoordinatorComment = model.CoordinatorComment;
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
    }
}
