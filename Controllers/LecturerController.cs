using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PROG_POE.Models;
using System.Linq;

namespace PROG_POE.Controllers
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
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Auth");

            var claims = _context.Claims
                .Where(c => c.Username == username)
                .ToList();

            return View(claims);
        }
    }
}
