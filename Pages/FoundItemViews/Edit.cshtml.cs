using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;

namespace LostAndFoundRazorPages.Pages.FoundItemViews
{
    public class EditModel : PageModel
    {
        private readonly LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext _context;

        public EditModel(LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext context)
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

            var founditems =  await _context.FoundItems.FirstOrDefaultAsync(m => m.Id == id);
            if (founditems == null)
            {
                return NotFound();
            }
            FoundItems = founditems;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoundItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoundItemsExists(FoundItems.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoundItemsExists(int id)
        {
            return _context.FoundItems.Any(e => e.Id == id);
        }
    }
}
