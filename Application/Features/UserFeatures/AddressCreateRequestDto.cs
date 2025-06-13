using Domain.Entities;

namespace Application.Features.UserFeatures
{
    public class AddressCreateRequestDto
    {
        public required string Title { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required string District { get; set; }
        public required string FullAddress { get; set; }
    }
}
