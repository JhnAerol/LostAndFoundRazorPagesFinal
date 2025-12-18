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
    public class DeleteModel : PageModel
    {
        private readonly LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext _context;

        public DeleteModel(LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founditems = await _context.FoundItems.FindAsync(id);
            if (founditems != null)
            {
                FoundItems = founditems;
                _context.FoundItems.Remove(FoundItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
