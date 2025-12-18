using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LostAndFoundRazorPages.Models
{
    public class FoundItems
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public DateTime DateFound { get; set; }
    }
}
