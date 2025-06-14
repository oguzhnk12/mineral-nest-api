using System.Net;

namespace Domain.Exceptions
{
    public class DuplicateException : Exception
    {
        public int StatusCode { get; } = (int)HttpStatusCode.Conflict;

        public DuplicateException(string message) : base(message)
        {
        }
    }
}

