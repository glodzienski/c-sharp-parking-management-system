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
    class VeiculoTipoSeeder
    {
        public static void Run()
        {
            dynamic jsonVeiculos = JsonConvert.DeserializeObject("{'tipos':[{'Nome':'Bicicleta','Descricao':'','Eixos':1,'Rodas':2},{'Nome':'Ciclomotor','Descricao':'','Eixos':1,'Rodas':2},{'Nome':'Motoneta','Descricao':'','Eixos':1,'Rodas':2},{'Nome':'Motocicleta','Descricao':'','Eixos':1,'Rodas':2},{'Nome':'Triciclo','Descricao':'','Eixos':2,'Rodas':3},{'Nome':'Quadriciclo','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Microônibus','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Onibus','Descricao':'','Eixos':2,'Rodas':6},{'Nome':'Charrete','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Caminhão','Descricao':'','Eixos':3,'Rodas':10},{'Nome':'Automobilístico','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Trator','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Especial','Descricao':'','Eixos':2,'Rodas':4},{'Nome':'Coleção','Descricao':'','Eixos':2,'Rodas':4}]}");

            VeiculoTipoController controller = new VeiculoTipoController();
            foreach (var veiculoTipo in jsonVeiculos.tipos)
            {
                VeiculoTipo veiculoTipoNovo = new VeiculoTipo();
                veiculoTipoNovo.Nome = veiculoTipo.Nome;
                veiculoTipoNovo.Descricao = veiculoTipo.Descricao;
                veiculoTipoNovo.Eixos = veiculoTipo.Eixos;
                veiculoTipoNovo.Rodas = veiculoTipo.Rodas;
                controller.Store(veiculoTipoNovo);
            }
        }
    }
}
