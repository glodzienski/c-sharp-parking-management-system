using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class VeiculoTipo : Model
    {
        public int VeiculoTipoID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Rodas { get; set; }

        public int Eixos { get; set; }
    }
}
