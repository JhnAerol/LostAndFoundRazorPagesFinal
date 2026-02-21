using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LostAndFoundRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LostAndFoundRazorPagesContext _context;


        public string UserName { get; set; }
        public IList<FoundItems> FoundItems { get; set; }
        public IList<LostItems> LostItems { get; set; }


        public IndexModel(ILogger<IndexModel> logger, LostAndFoundRazorPagesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UserName = HttpContext.Session.GetString("Name");

            if (string.IsNullOrEmpty(UserName))
            {
                return RedirectToPage("/LoginPage");
            }

            // Get 2 most recent FoundItems
            FoundItems = await _context.FoundItems
                .OrderByDescending(f => f.Id)
                .Take(2)
                .ToListAsync();

            // Get 2 most recent LostItems
            LostItems = await _context.LostItems
                .OrderByDescending(l => l.Id)
                .Take(2)
                .ToListAsync();

            return Page();
        }
    }
}
