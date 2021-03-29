using API.Domain.Usuarios;
using System;

namespace API.Application.Abstraction.Usuarios.Response
{
    public class BuscarUsuarioPorEmailResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid Ticket { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }

        public BuscarUsuarioPorEmailResponse(Usuario usuario)
        {
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
            this.Ticket = usuario.Ticket;
            this.CriadoEm = usuario.CriadoEm;
            this.AtualizadoEm = usuario.AtualizadoEm;
        }
    }
}
