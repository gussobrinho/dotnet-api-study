using System;
using System.Collections.Generic;
using System.Text;

namespace API.Exceptions.Common
{
    public class CampoObrigatorioException : DomainException
    {
        public CampoObrigatorioException(string message)
            : base(message)
        {

        }
    }
}
