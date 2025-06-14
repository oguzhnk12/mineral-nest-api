using System.Net;

namespace Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public int StatusCode { get; } = (int)HttpStatusCode.Unauthorized;

        public UnauthorizedException(string message) : base(message) { }
    }
}
