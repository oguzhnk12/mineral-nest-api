using Application.Features.UserFeatures;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
        {
            var result = await _service.Login(request);
            return Ok(new ApiResponse<UserLoginResponseDto>(result, "Kullanıcı Başarıyla Oluşturuldu."));
        }
    }
}
