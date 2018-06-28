using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Veiculo : Model
    {
        public int VeiculoID { get; set; }

        public string Placa { get; set; }

        public int? ClienteID { get; set; }

        public int VeiculoTipoID { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public virtual VeiculoTipo _VeiculoTipo { get; set; }
    }
}
