using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comanda : Model
    {
        public int ComandaID { get; set; }

        public double Total { get; set; }

        public int ComandaStatusID { get; set; }

        public int ServicoID { get; set; }

        public int VagaID { get; set; }

        public virtual Vaga _Vaga { get; set; }

        public virtual Servico _Servico { get; set; }

        public virtual ComandaStatus _ComandaStatus { get; set; }

        public int ClienteID { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public int FuncionarioID { get; set; }

        public virtual Funcionario _Funcionario { get; set; }

        public int VeiculoID { get; set; }

        public virtual Veiculo _Veiculo { get; set; }
    }
}
