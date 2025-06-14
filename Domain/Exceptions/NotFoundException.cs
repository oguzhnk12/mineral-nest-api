using System.Net;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; } = (int)HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
