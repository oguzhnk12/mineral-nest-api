namespace Application.Features.UserFeatures
{
    public class UserLoginResponseDto
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
