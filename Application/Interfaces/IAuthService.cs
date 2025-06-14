using Application.Features.UserFeatures;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponseDto> Login(UserLoginRequestDto dto);
    }
}
