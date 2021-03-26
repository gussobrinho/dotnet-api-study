using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.Abstraction.Somas.Querys
{
    public class SomarNumerosQuery : IRequest<int>
    {
        public List<int> Numeros { get; set; }

        public SomarNumerosQuery(List<int> numeros)
        {
            this.Numeros = numeros;
        }
    }
}
