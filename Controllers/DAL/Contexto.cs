using System.Data.Entity;
using Models;

namespace Controllers.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
            // Se não existir a base, cria
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());

            // Apaga e recria 
            //Database.SetInitializer(new DropCreateDatabaseAlways<Contexto>());

            // Apaga e recria a base de dados cada vez que houver alteração nas model
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<ComandaStatus> ComandaStatus { get; set; }

        public DbSet<Comanda> Comanda { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<Servico> Servico { get; set; }

        public DbSet<Pacote> Pacote { get; set; }

        public DbSet<PacoteServico> PacoteServico { get; set; }

        public DbSet<VagaTipo> VagaTipo { get; set; }

        public DbSet<Vaga> Vaga { get; set; }

        public DbSet<VeiculoTipo> VeiculoTipo { get; set; }

        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
