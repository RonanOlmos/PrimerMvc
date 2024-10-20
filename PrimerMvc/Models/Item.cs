using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerMvc.Models{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Theme { get; set; }
        public string? ImageUrl { get; set;}

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
