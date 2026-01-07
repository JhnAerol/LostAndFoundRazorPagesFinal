using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LostAndFoundRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string UserName { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            UserName = HttpContext.Session.GetString("Name");

            if (string.IsNullOrEmpty(UserName))
            {
                return RedirectToPage("/LoginPage");
            }

            return Page();
        }
    }
}
