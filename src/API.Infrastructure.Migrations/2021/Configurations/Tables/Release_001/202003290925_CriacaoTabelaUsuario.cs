using FluentMigrator;

namespace API.Infrastructure.Migrations._2021.Configurations.Tables.Release_001
{
    [Migration(202003290925)]
    public class CriacaoTabelaUsuario : Migration
    {
        public override void Down()
        {
            if (this.Schema.Table("TB_Usuario").Exists())
            {
                this.Delete.Table("TB_Usuario");
            }
        }

        public override void Up()
        {
            if (!this.Schema.Table("TB_Usuario").Exists())
            {
                var tabela = this.Create.Table("TB_Usuario")
                   .WithDescription("Tabela de cadastro de usuarios.");

                tabela.WithColumn("IDUsuario")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey("PK_Usuario")
                    .WithColumnDescription("Identificador usuario.");

                tabela.WithColumn("IDTicket")
                    .AsGuid()
                    .NotNullable()
                    .WithColumnDescription("ID utilizado para identificar o usuário entre os microsserviços");

                tabela.WithColumn("NMUsuario")
                    .AsAnsiString(50)
                    .NotNullable()
                    .WithColumnDescription("Nome do usuario");

                tabela.WithColumn("DSEmail")
                    .AsAnsiString(50)
                    .NotNullable()
                    .WithColumnDescription("Email do usuario");

                tabela.WithColumn("DTCriacao")
                    .AsDateTime()
                    .NotNullable()
                    .WithColumnDescription("Data de criação do registo");

                tabela.WithColumn("DTAtualizacao")
                    .AsDateTime()
                    .Nullable()
                    .WithColumnDescription("Data de atualização do registo");

            }
        }
    }
}
