namespace Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string ImageUrl { get; set; }
        public required bool IsMain{ get; set; }
        public required string AltText { get; set; }
        public required Product Product { get; set; }
    }
}