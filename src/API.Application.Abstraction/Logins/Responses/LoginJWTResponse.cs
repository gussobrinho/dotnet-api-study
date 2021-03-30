using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.Abstraction.Logins.Responses
{
    public class LoginJWTResponse
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

        public LoginJWTResponse(bool authenticated, string created, string expirationDate, string accessToken, string username, string message)
        {
            this.Authenticated = authenticated;
            this.Created = created;
            this.ExpirationDate = expirationDate;
            this.AccessToken = accessToken;
            this.UserName = username;
            this.Message = message;
        }
    }
}
