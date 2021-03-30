using API.Application.Abstraction.Logins.Commands;
using API.Application.Abstraction.Logins.Responses;
using API.Domain.Usuarios;
using API.Infrastructure.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using API.Exceptions.Common;

namespace API.Application.Logins.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginJWTResponse>
    {
        private readonly AuthenticationService _service;
        private readonly IUsuarioRepository _repository;
        public LoginCommandHandler(AuthenticationService service, IUsuarioRepository repository)
        {
            this._service = service;
            this._repository = repository;
        }

        public async Task<LoginJWTResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email))
            {
                throw new CampoObrigatorioException("O Email é obrigatório.");
            }
            
            var usuario = await this._repository.FindByEmail(request.Email);

            if(usuario == null)
            {
                throw new NaoEncontradoException("Usuario não encontrado.");
            }
            
            var result = await this._service.DoLogin(usuario);

            if(result == null)
            {
                throw new FalhaNaAutenticacaoException("Falha na autenticação.");
            }

            return new LoginJWTResponse(result.Authenticated, result.Created, result.ExpirationDate, result.AccessToken, result.UserName, result.Message);
        }
    }
}
