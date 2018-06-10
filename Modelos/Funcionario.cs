using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Funcionario : Model
    {
        public int FuncionarioID { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public int Cpf { get; set; }

        public int UsuarioTipoID { get; set; }

        public bool Administrador { get; set; }
    }
}
