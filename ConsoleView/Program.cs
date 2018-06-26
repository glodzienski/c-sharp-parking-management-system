using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            Vaga vaga = new Vaga();
            vaga.Andar = "1";
            vaga.Ativo = true;
            vaga.Codigo = "teste";
            vaga.Ocupada = false;

            VagaController controller = new VagaController();
            controller.Store(vaga);
        }
    }
}
