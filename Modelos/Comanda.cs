using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Comanda : Model
    {
        public int ComandaID { get; set; }

        public float Total { get; set; }

        public int ComandaStatusID { get; set; }

        public virtual ComandaStatus _ComandaStatus { get; set; }

        public int ClienteID { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public int FuncionarioID { get; set; }

        public virtual Funcionario _Funcionario { get; set; }
    }
}
