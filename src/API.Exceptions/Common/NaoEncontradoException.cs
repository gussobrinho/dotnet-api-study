using System;
using System.Collections.Generic;
using System.Text;

namespace API.Exceptions.Common
{
    public class NaoEncontradoException : DomainException
    {
        public NaoEncontradoException(string message)
        : base(message)
        {
        }
    }
}
