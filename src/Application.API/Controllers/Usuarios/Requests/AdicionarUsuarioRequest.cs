using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.API.Controllers.Usuarios.Requests
{
    public class AdicionarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
