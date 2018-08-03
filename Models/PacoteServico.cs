using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("PacoteServico")]
    public class PacoteServico : Model
    {
        public int PacoteServicoID { get; set; }

        public int ServicoID { get; set; }

        public virtual Servico _Servico { get; set; }
    }
}
