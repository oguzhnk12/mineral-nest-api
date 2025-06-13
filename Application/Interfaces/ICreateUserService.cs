using Application.Features.UserFeatures;

namespace Application.Interfaces
{
    public interface ICreateUserService
    {
        Task<bool> CreateUser(UserCreateRequestDto dto);
    }
}
