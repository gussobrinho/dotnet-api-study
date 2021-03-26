using API.Application.Abstraction.Somas.Querys;
using API.Domain.Somas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Somas.Querys
{
    public class SomarNumerosQueryHandler : IRequestHandler<SomarNumerosQuery, int>
    {
        private readonly SomaService _somaService;

        public SomarNumerosQueryHandler(SomaService somaService)
        {
            this._somaService = somaService;
        }

        public async Task<int> Handle(SomarNumerosQuery query, CancellationToken cancellationToken)
        {
            return this._somaService.SomarValores(query.Numeros);
        }
    }
}
