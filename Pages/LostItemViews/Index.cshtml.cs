using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;

namespace LostAndFoundRazorPages.Pages.LostItemViews
{
    public class IndexModel : PageModel
    {
        private readonly LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext _context;

        public IndexModel(LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext context)
        {
            _context = context;
        }

        public IList<LostItems> LostItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LostItems = await _context.LostItems.ToListAsync();
        }
    }
}
