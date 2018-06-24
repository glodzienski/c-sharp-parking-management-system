using Controllers;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StartBD
{
    class FuncionarioSeeder
    {
        public static void Run()
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Administrador = true;
            funcionario.Ativo = true;
            funcionario.Cpf = "09976494963";
            funcionario.Email = "contato@crystopher.com.br";
            funcionario.Nome = "Crystopher";
            funcionario.Sobrenome = "Glodzienski";
            funcionario.Senha = "1303";

            FuncionarioController controller = new FuncionarioController();
            controller.Store(funcionario);
        }
    }
}
