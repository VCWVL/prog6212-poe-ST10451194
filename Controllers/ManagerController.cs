using Microsoft.AspNetCore.Mvc;
using PROG_POE.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PROG_POE.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard - show Verified claims for approval
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Manager")
                return RedirectToAction("Login", "Auth");

            var claims = _context.Claims
                .Where(c => c.Status == ClaimStatus.Verified)
                .ToList();

            return View(claims);
        }

        // Approve claim
        [HttpGet]
        public IActionResult Approve(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Manager")
                return RedirectToAction("Login", "Auth");

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            return View(claim);
        }

        [HttpPost]
        public IActionResult Approve(Claim model, string actionType)
        {
            if (HttpContext.Session.GetString("Role") != "Manager")
                return RedirectToAction("Login", "Auth");

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == model.ClaimId);
            if (claim != null)
            {
                claim.Status = actionType == "Approve" ? ClaimStatus.Approved : ClaimStatus.Cancelled;
                claim.ManagerComment = model.ManagerComment;
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
    }
}
