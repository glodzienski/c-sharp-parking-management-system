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
    public partial class frmVeiculoEditar : Window
    {
        ClienteController clienteController = new ClienteController();
        VeiculoTipoController veiculoTipoController = new VeiculoTipoController();
        VeiculoController veiculoController = new VeiculoController();
        Veiculo veiculoAtual;

        public frmVeiculoEditar(Veiculo veiculo)
        {
            InitializeComponent();
            this.veiculoAtual = veiculo;
            CarregarClienteCB();
            CarregarVeiculoTipoCB();
            edtPlaca.Text = veiculo.Placa;
            cbCliente.SelectedItem = veiculo._Cliente;
            cbVeiculoTipo
                .SelectedItem = veiculo._VeiculoTipo;
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

                this.veiculoAtual.ClienteID = clienteSelecionado.ClienteID;
                this.veiculoAtual.VeiculoTipoID = veiculoSelecionado.VeiculoTipoID;
                this.veiculoAtual.Placa = placa;
                veiculoController.Edit(veiculoAtual);
                MessageBox.Show("Veículo atualizado com sucesso!");
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
