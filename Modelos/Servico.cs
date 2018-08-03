using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Servico")]
    public class Servico : Model
    {
        public int ServicoID { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public bool Ativo { get; set; }

        public double Valor { get; set; }
    }
}
