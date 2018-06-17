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
    class ComandaStatusSeeder
    {
        public static void Run()
        {
            dynamic jsonStatus = JsonConvert.DeserializeObject("{'status':['Reservada', 'Ativa', 'Fechada']}");

            ComandaStatusController controller = new ComandaStatusController();
            foreach (var status in jsonStatus.status)
            {
                ComandaStatus comandaStatus = new ComandaStatus();
                comandaStatus.Descricao = status;
                controller.Store(comandaStatus);
            }
        }
    }
}
