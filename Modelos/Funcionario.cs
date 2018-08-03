using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Funcionario")]
    public class Funcionario : Model
    {
        public int FuncionarioID { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public string Cpf { get; set; }

        [DefaultValue(false)]
        public bool Administrador { get; set; }
    }
}
