using Presentation.Models;
namespace Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message;
                context.Response.ContentType = "application/json";
                if (ex.GetType().GetProperty("StatusCode") != null)
                {
                    context.Response.StatusCode = (int)ex.GetType().GetProperty("StatusCode")!.GetValue(ex)!;
                    message = ex.Message;
                    _logger.LogError($"❌ Exception occured: {ex.Message}");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    message = "Beklenmeyen bir Hata Oluştu.";
                    _logger.LogError($"❌ Unexpected error: {ex}");
                }
                await context.Response.WriteAsJsonAsync(new ApiResponse<object>(message));
            }
        }
    }
}
