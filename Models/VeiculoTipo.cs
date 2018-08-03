using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("VeiculoTipo")]
    public class VeiculoTipo : Model
    {
        public int VeiculoTipoID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Rodas { get; set; }

        public int Eixos { get; set; }
    }
}
