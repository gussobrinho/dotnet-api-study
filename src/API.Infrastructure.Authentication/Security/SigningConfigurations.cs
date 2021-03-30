using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace API.Infrastructure.Authentication.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                this.Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            this.SigningCredentials = new SigningCredentials(this.Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
