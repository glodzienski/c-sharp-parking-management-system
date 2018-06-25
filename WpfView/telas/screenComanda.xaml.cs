using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfView.common;

namespace WpfView.telas
{
    public partial class screenComanda : UserControl
    {
        ComandaController comandaController = new ComandaController();
        ClienteController clienteController = new ClienteController();
        VagaController vagaController = new VagaController();
        ServicoController servicoController = new ServicoController();

        public screenComanda()
        {
            InitializeComponent();
            CarregarClientes();
            CarregarServicos();
            CarregarVagas();
        }

        private void CarregarClientes()
        {
            IList<Cliente> listaClientes = clienteController.List();
        }

        private void CarregarVagas()
        {
            IList<Vaga> listaVagas = vagaController.List();
        }

        private void CarregarServicos()
        {
            IList<Servico> listaServicos = servicoController.List();
        }
    }
}
