namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;      // Initialize
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;  // Initialize
        public string Category { get; set; } = string.Empty;  // Initialize
    }
}


