using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LostAndFoundRazorPages.Models;

namespace LostAndFoundRazorPages.Data
{
    public class LostAndFoundRazorPagesContext : DbContext
    {
        public LostAndFoundRazorPagesContext (DbContextOptions<LostAndFoundRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<FoundItems> FoundItems { get; set; } = default!;
        public DbSet<LostItems> LostItems { get; set; } = default!;
        public DbSet<RecentItemViewModel> RecentItems { get; set; } = default!;

        public DbSet<Users> Users { get; set; } = default!;
    }
}
