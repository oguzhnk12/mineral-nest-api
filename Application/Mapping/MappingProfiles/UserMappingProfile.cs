using Application.Features.UserFeatures;
using AutoMapper;
using Domain.Entities;
using Domain.Enumerators;

namespace Application.Mapping.MappingProfiles
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile() {
            CreateMap<AddressCreateRequestDto, Address>();
            CreateMap<UserCreateRequestDto, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
