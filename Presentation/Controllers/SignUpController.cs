﻿using Application.Features.UserFeatures;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController : ControllerBase
    {
        private readonly ICreateUserService _service;

        public SignUpController(ICreateUserService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> SignUp([FromBody] UserCreateRequestDto request)
        {
            var result = await _service.CreateUser(request);
            return Ok(new ApiResponse<object?>(null, "Kullanıcı Başarıyla Oluşturuldu."));
        }
    }
}
