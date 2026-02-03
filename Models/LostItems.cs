using System.ComponentModel.DataAnnotations;

namespace LostAndFoundRazorPages.Models
{
    public class LostItems
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Length cannot be exceed to 20")]
        public string ItemName { get; set; }

        [Required, MaxLength(40, ErrorMessage = "Length cannot be exceed to 30")]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime DateFound { get; set; }

        public string? ImagePath { get; set; }
    }
}
