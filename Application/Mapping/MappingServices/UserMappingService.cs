using Application.Features.UserFeatures;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping.MappingServices
{
    internal class UserMappingService
    {
        private readonly IMapper _mapper;

        public UserMappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User MapToUser(UserCreateRequestDto dto)
        {
            return _mapper.Map<User>(dto);
        }

        public Address MapToAddress(AddressCreateRequestDto dto)
        {
            return _mapper.Map<Address>(dto);
        }
    }
}
