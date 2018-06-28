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
    public partial class screenVeiculos : UserControl
    {
        VeiculoController controller = new VeiculoController();

        public screenVeiculos()
        {
            InitializeComponent();
            CarregarVeiculos();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            frmVeiculoNovo frm = new frmVeiculoNovo();
            frm.Closed += (s, args) => CarregarVeiculos();
            frm.Show();
        }

        private void CarregarVeiculos()
        {
            IList<Veiculo> lista = controller.List();
            dbGridVeiculos.ItemsSource = lista;
        }

        private void btnExcluirVeiculo_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ((FrameworkElement)sender).DataContext as Veiculo;

            if (Dialog.OnConfirma("Você deseja realmente excluir?", "Excluir"))
            {
                controller.Delete(veiculo);
                Dialog.OnInforma("Veículo excluída com sucesso");
                CarregarVeiculos();
            }
        }

        private void btnEditarVeiculo_Click(object sender, RoutedEventArgs e)
        {
            Veiculo veiculo = ((FrameworkElement)sender).DataContext as Veiculo;
            frmVeiculoEditar frm = new frmVeiculoEditar(veiculo);
            frm.Closed += (s, args) => CarregarVeiculos();
            frm.Show();
        }
    }
}
