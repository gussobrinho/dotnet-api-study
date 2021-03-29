﻿using API.Application.Abstraction.Usuarios.Commands;
using API.Domain.Usuarios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Usuarios.Commands
{
    public class AdicionarUsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, bool>
    {
        private readonly UsuarioService _service;

        public AdicionarUsuarioCommandHandler(UsuarioService service)
        {
            this._service = service;
        }

        public async Task<bool> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._service.AdicionarUsuario(request.Nome, request.Email);

            return result;
        }
    }
}