using System;

namespace EncoreTix.Core.ApiExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Resource not found.") { }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message) { }
    }
}
