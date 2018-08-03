using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Pacote")]
    public class Pacote : Model
    {
        public int PacoteID { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public bool Ativo { get; set; }
    }
}
