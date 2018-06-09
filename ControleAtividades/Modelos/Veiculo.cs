using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Veiculo : Model
    {
        public int VeiculoID { get; set; }

        public string Placa { get; set; }

        public int VeiculoTipoID { get; set; }

        public virtual VeiculoTipo _VeiculoTipo { get; set; }
    }
}
