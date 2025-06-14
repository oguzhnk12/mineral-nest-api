using Application.Features.UserFeatures;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class DumbController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetDumbData()
        {
            return Ok((new ApiResponse<string>("This is a dummy response", "Dummy data retrieved successfully.")));
        }
    }
}
