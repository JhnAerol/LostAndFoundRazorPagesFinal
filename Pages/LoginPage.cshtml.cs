using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace LostAndFoundRazorPages.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly LostAndFoundRazorPagesContext _context;

        public LoginPageModel(LostAndFoundRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users LoginUser { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (LoginUser.Password == null || LoginUser.UserName == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            var hashed = HashPassword(LoginUser.Password);

            var user = _context.Users
                .FirstOrDefault(u => u.UserName == LoginUser.UserName
                                  && u.Password == hashed);

            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            HttpContext.Session.SetString("Name", user.UserName);

            return RedirectToPage("/Index");
        }

        private string HashPassword(string? password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
