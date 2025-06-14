using System.Net;

namespace Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode { get; } = (int)HttpStatusCode.BadRequest;

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
