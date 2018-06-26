using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando start pack data base");
            Console.WriteLine("Populando tabela VeiculoTipo");
            VeiculoTipoSeeder.Run();
            Console.WriteLine("Populando tabela ComandaStatus");
            ComandaStatusSeeder.Run();
            Console.WriteLine("Populando tabela VagaTipo");
            VagaTipoSeeder.Run();
            Console.WriteLine("Populando tabela Funcionario");
            FuncionarioSeeder.Run();
            Console.WriteLine("Populando tabela de vagas.");
            VagaSeeder.Run();
            Console.WriteLine("Data base populada com sucesso.");
            Console.ReadKey();
        }
    }
}
