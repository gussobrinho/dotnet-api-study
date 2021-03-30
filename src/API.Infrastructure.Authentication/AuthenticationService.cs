using API.Domain.Usuarios;
using API.Infrastructure.Authentication.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace API.Infrastructure.Authentication
{
    public class AuthenticationService
    {
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfiguration;
        private IConfiguration _configuration { get; }

        public AuthenticationService(IConfiguration configuration, SigningConfigurations signingConfigurations,
                        TokenConfigurations tokenConfigurations)
        {
            this._signingConfigurations = signingConfigurations;
            this._tokenConfiguration = tokenConfigurations;
            this._configuration = configuration;
        }

        public async Task<JWTResponse> DoLogin(Usuario usuario)
        {
            if (usuario == null)
            {
                return  new JWTResponse(false, null, null,
                null, usuario.Email, "Falha na autenticação.");
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                    });

                var createDate = DateTime.Now;
                var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();

                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token, usuario.Email);
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private JWTResponse SuccessObject(DateTime createDate, DateTime expirationDate, string token, string email)
        {
            return new JWTResponse(true, createDate.ToString("dd/MM/yyyy HH:mm:ss"), expirationDate.ToString("dd/MM/yyyy HH:mm:ss"),
                token, email, "Usuario logado com sucesso.");
        }
    }
}
