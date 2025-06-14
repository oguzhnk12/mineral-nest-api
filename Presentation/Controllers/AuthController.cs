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

        private readonly HttpClient _httpClient;

        public AuthController(IAuthService service, HttpClient httpClient)
        {
            _service = service;
            _httpClient = httpClient;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
        {
            var result = await _service.Login(request);
            if (result != null)
            {
                return Ok(new ApiResponse<UserLoginResponseDto>(result, "Kullanıcı Başarıyla Oluşturuldu."));
            }
            return StatusCode(500, new ApiResponse<string?>(null, "Beklenmeyen Bir Hata Oluştu"));
        }
    }
}
