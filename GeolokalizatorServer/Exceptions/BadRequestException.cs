using System;
namespace GeolokalizatorServer.Exceptions
{
    public class BadRequestException :Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
