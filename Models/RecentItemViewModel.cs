namespace LostAndFoundRazorPages.Models
{
    public class RecentItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } 
        public DateTime DateReported { get; set; }
    }
}
