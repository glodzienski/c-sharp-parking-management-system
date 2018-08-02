using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("ComandaStatus")]
    public class ComandaStatus : Model
    {
        public int ComandaStatusID { get; set; }

        public string Descricao { get; set; }
    }
}
