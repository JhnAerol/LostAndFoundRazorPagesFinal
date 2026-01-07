using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace LostAndFoundRazorPages.Pages
{
    public class RegistrationPageModel : PageModel
    {
        private readonly LostAndFoundRazorPagesContext _context;

        public RegistrationPageModel(LostAndFoundRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users User { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (_context.Users.Any(u => u.UserName == User.UserName))
            {
                ModelState.AddModelError("", "Username already exists.");
                return Page();
            }

            User.Password = HashPassword(User.Password);

            _context.Users.Add(User);
            _context.SaveChanges();

            return RedirectToPage("/LoginPage");
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
