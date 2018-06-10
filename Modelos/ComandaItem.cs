using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class ComandaItem : Model
    {
        public int ComandaItemID { get; set; }

        public int ComandaID { get; set; }

        public virtual Comanda _Comanda { get; set; }

        public int ServicoID { get; set; }

        public virtual Servico _Servico { get; set; }

        public int PacoteID { get; set; }

        public virtual Pacote _Pacote { get; set; }

        public int Valor { get; set; }
    }
}
