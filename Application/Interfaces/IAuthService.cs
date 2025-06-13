using Application.Features.UserFeatures;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginRequestDto> Login(UserLoginRequestDto dto);
    }
}
