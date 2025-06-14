namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; } = 0;
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Product>? Products { get; set; }

    }
}