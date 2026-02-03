using LostAndFoundRazorPages.Data;
using LostAndFoundRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFoundRazorPages.Pages.LostItemViews
{
    public class CreateModel : PageModel
    {
        private readonly LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(LostAndFoundRazorPages.Data.LostAndFoundRazorPagesContext context,
        IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LostItems LostItems { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";

                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                LostItems.ImagePath = $"uploads/{fileName}";
            }

            LostItems.DateFound = DateTime.Now;

            _context.LostItems.Add(LostItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
