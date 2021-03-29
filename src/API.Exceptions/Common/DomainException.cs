using System;

namespace API.Exceptions.Common
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }

        public DomainException(string message)
            : base(message)
        {

        }
    }
}
