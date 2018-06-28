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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfView
{
    public partial class frmVeiculoNovo : Window
    {
        ClienteController clienteController = new ClienteController();
        VeiculoTipoController veiculoTipoController = new VeiculoTipoController();
        VeiculoController veiculoController = new VeiculoController();

        public frmVeiculoNovo()
        {
            InitializeComponent();
            CarregarClienteCB();
            CarregarVeiculoTipoCB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String placa = edtPlaca.Text;
            Cliente clienteSelecionado = cbCliente.SelectedItem as Cliente;
            VeiculoTipo veiculoSelecionado = cbVeiculoTipo.SelectedItem as VeiculoTipo;


            try
            {
                if (placa.Equals(""))
                {
                    throw new Exception("Por favor preencha a placa.");
                }
                if (clienteSelecionado == null)
                {
                    throw new Exception("Por favor, selecione um cliente.");
                }
                if (veiculoSelecionado == null)
                {
                    throw new Exception("Por favor, selecione um cliente.");
                }

                Veiculo veiculo = new Veiculo();
                veiculo.ClienteID = clienteSelecionado.ClienteID;
                veiculo.VeiculoTipoID = veiculoSelecionado.VeiculoTipoID;
                veiculo.Placa = placa;
                veiculoController.Store(veiculo);
                MessageBox.Show("Veículo cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarVeiculoTipoCB()
        {
            IList<VeiculoTipo> lista = veiculoTipoController.List();
            cbVeiculoTipo.ItemsSource = lista;
            cbVeiculoTipo.DisplayMemberPath = "Nome";
        }

        private void CarregarClienteCB()
        {
            IList<Cliente> lista = clienteController.List();
            cbCliente.ItemsSource = lista;
            cbCliente.DisplayMemberPath = "Nome";
        }
    }
}
