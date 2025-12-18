using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;

namespace LostAndFoundRazorPages.Pages.FoundItemViews
{
    public class DetailsModel : PageModel
    {
        private readonly LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext _context;

        public DetailsModel(LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext context)
        {
            _context = context;
        }

        public FoundItems FoundItems { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founditems = await _context.FoundItems.FirstOrDefaultAsync(m => m.Id == id);

            if (founditems is not null)
            {
                FoundItems = founditems;

                return Page();
            }

            return NotFound();
        }
    }
}
