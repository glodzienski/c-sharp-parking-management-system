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
    class VagaSeeder
    {
        public static void Run()
        {
            dynamic vagas = JsonConvert.DeserializeObject("{'conteudo':[{'andar':'A','codigo':'1','vaga_tipo':1},{'andar':'A','codigo':'2','vaga_tipo':1},{'andar':'A','codigo':'3','vaga_tipo':1},{'andar':'A','codigo':'4','vaga_tipo':1},{'andar':'A','codigo':'5','vaga_tipo':1},{'andar':'B','codigo':'1','vaga_tipo':1},{'andar':'B','codigo':'2','vaga_tipo':1},{'andar':'B','codigo':'3','vaga_tipo':1},{'andar':'B','codigo':'4','vaga_tipo':1},{'andar':'B','codigo':'5','vaga_tipo':1},{'andar':'C','codigo':'1','vaga_tipo':1},{'andar':'C','codigo':'2','vaga_tipo':1},{'andar':'C','codigo':'3','vaga_tipo':1},{'andar':'C','codigo':'4','vaga_tipo':1},{'andar':'C','codigo':'5','vaga_tipo':1}]}");

            VagaController controller = new VagaController();
            foreach (var vagaNova in vagas.conteudo)
            {
                Vaga vaga = new Vaga();
                vaga.Andar = vagaNova.andar;
                vaga.Ativo = true;
                vaga.Codigo = vagaNova.codigo;
                vaga.Ocupada = false;
                vaga.VagaTipoID = vagaNova.vaga_tipo;
                controller.Store(vaga);
            }
        }
    }
}
