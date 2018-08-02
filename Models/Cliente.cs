using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Cliente")]
    public class Cliente : Model 
    {
        public int ClienteID { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public bool Ativo { get; set; }

        public string Cpf { get; set; }
    }
}
