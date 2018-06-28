using Controllers;
using Enumerable;
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
using WpfView.common;

namespace WpfView
{
    public partial class frmComandaNova : Window
    {
        ComandaController comandaController = new ComandaController();
        ClienteController clienteContrller = new ClienteController();
        ServicoController servicoController = new ServicoController();
        VagaController vagaController = new VagaController();
        VeiculoController veiculoController = new VeiculoController();
        Vaga vaga;

        public frmComandaNova(Vaga vaga)
        {
            InitializeComponent();
            this.vaga = vaga;
            CarregarComboBoxCliente();
            CarregarComboBoxServico();
            CarregarComboBoxVeiculos();
        }

        private void CarregarComboBoxServico()
        {
            IList<Servico> listaServicos = servicoController.List();
            cbServico.ItemsSource = listaServicos;
            cbServico.DisplayMemberPath = "Nome";
        }

        private void CarregarComboBoxCliente()
        {
            IList<Cliente> listaClientes = clienteContrller.List();
            cbCliente.ItemsSource = listaClientes;
            cbCliente.DisplayMemberPath = "Nome";
        }

        private void CarregarComboBoxVeiculos()
        {
            IList<Veiculo> lista = veiculoController.List();
            cbVeiculos.ItemsSource = lista;
            cbVeiculos.DisplayMemberPath = "Placa";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = cbCliente.SelectedItem as Cliente;
            Servico servico = cbServico.SelectedItem as Servico;
            Veiculo veiculoSelecionado = cbVeiculos.SelectedItem as Veiculo;
            bool reserved = chkReserved.IsChecked.Value;

            try
            {
                if (cliente == null)
                {
                    throw new Exception("Por favor, selecione um Cliente");
                }
                if (servico == null)
                {
                    throw new Exception("Por favor, selecione um Serviço");
                }
                if (veiculoSelecionado == null)
                {
                    throw new Exception("Por favor, selecione um Veículo");
                }

                Comanda comanda = new Comanda();
                comanda.ClienteID = cliente.ClienteID;
                comanda.ServicoID = servico.ServicoID;
                comanda.VagaID = vaga.VagaID;
                comanda.VeiculoID = veiculoSelecionado.VeiculoID;
                comanda.FuncionarioID = App.FuncionarioLogado.FuncionarioID;
                comanda.ComandaStatusID = reserved ? ComandaStatusEnum.Reservada : ComandaStatusEnum.Ativa;
                comanda.Total = servico.Valor;
                comandaController.Store(comanda);

                Vaga vagaOcupada = vagaController.FindById(vaga.VagaID);
                vagaOcupada.Ocupada = true;
                vagaController.Edit(vagaOcupada);

                MessageBox.Show("Comanda criada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoVeiculo_Click(object sender, RoutedEventArgs e)
        {
            frmVeiculoNovo frm = new frmVeiculoNovo();
            frm.Closed += (s, args) => CarregarComboBoxVeiculos();
            frm.Show();
        }
    }
}
