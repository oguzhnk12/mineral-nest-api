namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required string District { get; set; }
        public required string FullAddress { get; set; }
        public required User User { get; set; }
    }
}
