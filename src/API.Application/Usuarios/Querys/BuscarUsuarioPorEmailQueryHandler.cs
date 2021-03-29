using API.Application.Abstraction.Usuarios.Querys;
using API.Application.Abstraction.Usuarios.Response;
using API.Domain.Usuarios;
using API.Exceptions.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Usuarios.Querys
{
    public class BuscarUsuarioPorEmailQueryHandler : IRequestHandler<BuscarUsuarioPorEmailQuery, BuscarUsuarioPorEmailResponse>
    {
        private readonly IUsuarioRepository _repository;
        public BuscarUsuarioPorEmailQueryHandler(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        public async Task<BuscarUsuarioPorEmailResponse> Handle(BuscarUsuarioPorEmailQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new CampoObrigatorioException("Email não informado.");
            }

            var user = await this._repository.FindByEmail(request.Email);

            if(user == null)
            {
                throw new NaoEncontradoException($"Usuário com o email \"{request.Email}\" não foi encontrado.");
            }

            return new BuscarUsuarioPorEmailResponse(user);
        }
    }
}
