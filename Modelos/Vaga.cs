using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vaga : Model
    {
        public int VagaID { get; set; }

        public string Codigo { get; set; }

        public string Andar { get; set; }

        public bool Ocupada { get; set; }

        public bool Ativo { get; set; }

        public int VagaTipoID { get; set; }

        public virtual VagaTipo _VagaTipo { get; set; }
    }
}
