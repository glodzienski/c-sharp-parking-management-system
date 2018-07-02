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
            FuncionarioController controller = new FuncionarioController();

            Funcionario funcionario;

            funcionario = new Funcionario();
            funcionario.Administrador = true;
            funcionario.Ativo = true;
            funcionario.Cpf = "09976494963";
            funcionario.Email = "contato@crystopher.com.br";
            funcionario.Nome = "Crystopher";
            funcionario.Sobrenome = "Glodzienski";
            funcionario.Senha = "1303";
            controller.Store(funcionario);

            funcionario = new Funcionario();
            funcionario.Administrador = true;
            funcionario.Ativo = true;
            funcionario.Cpf = "09976494964";
            funcionario.Email = "teste@teste.com.br";
            funcionario.Nome = "Teste";
            funcionario.Sobrenome = "Teste";
            funcionario.Senha = "123";
            controller.Store(funcionario);
        }
    }
}
