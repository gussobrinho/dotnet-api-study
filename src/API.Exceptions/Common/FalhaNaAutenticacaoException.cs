using System;
using System.Collections.Generic;
using System.Text;

namespace API.Exceptions.Common
{
    public class FalhaNaAutenticacaoException : DomainException
    {
        public FalhaNaAutenticacaoException(string message) : base(message)
        {

        }
    }
}
