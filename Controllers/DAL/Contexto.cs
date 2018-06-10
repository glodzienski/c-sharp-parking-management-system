using System.Data.Entity;
using Models;

namespace Controllers.DAL
{
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }
        public DbSet<ComandaItem> ComandaItem { get; set; }

        public DbSet<ComandaStatus> ComandaStatus { get; set; }

        public DbSet<Comanda> Comanda { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Cliente> Funcionario { get; set; }

        public DbSet<Servico> Servico { get; set; }

        public DbSet<Pacote> Pacote { get; set; }

        public DbSet<PacoteServico> PacoteServico { get; set; }

        public DbSet<VagaTipo> VagaTipo { get; set; }

        public DbSet<Vaga> Vaga { get; set; }

        public DbSet<VeiculoTipo> VeiculoTipo { get; set; }

        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
