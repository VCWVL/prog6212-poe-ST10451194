using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PROG_POE.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PROG_POE.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            string username = model.Username?.Trim() ?? "";
            string password = model.Password?.Trim() ?? "";

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            if (!VerifyPassword(password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Incorrect password");
                return View(model);
            }

            // Store session
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            // Redirect to dashboard based on role
            return user.Role switch
            {
                "Lecturer" => RedirectToAction("Index", "Lecturer"),
                "Coordinator" => RedirectToAction("Index", "Coordinator"),
                "Manager" => RedirectToAction("Index", "Manager"),
                _ => RedirectToAction("Login")
            };
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hash = Convert.ToBase64String(hashBytes);
            return hash == storedHash;
        }
    }
}
