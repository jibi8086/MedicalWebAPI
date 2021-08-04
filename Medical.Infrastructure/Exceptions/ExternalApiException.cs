using System;

namespace Medical.Infrastructure.Exceptions
{
    public class ExternalApiException : Exception
    {
        public ExternalApiException()
        {

        }
        public ExternalApiException(string message) : base(message)
        {

        }
    }
}
