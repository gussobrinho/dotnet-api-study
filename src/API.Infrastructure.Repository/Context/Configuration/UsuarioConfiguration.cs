using API.Domain
using API.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Repository.Context.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_Usuario");
            builder.HasKey(b => b.ID);

            builder.Property(b => b.Ticket).HasColumnName("IDTicket");
            builder.Property(b => b.Nome).HasColumnName("NMUsuario");
            builder.Property(b => b.Email).HasColumnName("DSEmail");
            builder.Property(b => b.CriadoEm).HasColumnName("DTCriacao");
            builder.Property(b => b.AtualizadoEm).HasColumnName("DTAtualizacao");
        }
    }
}
