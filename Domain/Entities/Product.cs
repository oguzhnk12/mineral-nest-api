namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public required int Stock { get; set; }
        public required int Weight { get; set; }
        public required string Category { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<ProductImage>? Images { get; set; } 
        public ICollection<Category>? Categories { get; set; }
    }
}
