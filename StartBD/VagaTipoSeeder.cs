using Controllers;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StartBD
{
    class VagaTipoSeeder
    {
        public static void Run()
        {
            dynamic jsonVagaTipo = JsonConvert.DeserializeObject("{'tipos':['Pequena', 'Média', 'Grande', 'Extra Grande']}");

            VagaTipoController controller = new VagaTipoController();
            foreach (var tipo in jsonVagaTipo.tipos)
            {
                VagaTipo vagaTipo = new VagaTipo();
                vagaTipo.Descricao = tipo;
                controller.Store(vagaTipo);
            }
        }
    }
}
