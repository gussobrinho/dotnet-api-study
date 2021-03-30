using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Authentication.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }

        public TokenConfigurations Define(IConfiguration config)
        {
            var token = new TokenConfigurations();

            this.Audience = config.GetSection("TokenConfiguration:Audience").Value;
            this.Issuer = config.GetSection("TokenConfiguration:Issuer").Value;
            this.Seconds = int.Parse(config.GetSection("TokenConfiguration:Seconds").Value);

            return token;
        }
    }
}
