using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("VagaTipo")]
    public class VagaTipo : Model
    {
        public int VagaTipoID { get; set; }

        public string Descricao { get; set; }
    }
}
