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
    /// <summary>
    /// Interação lógica para screenClientes.xam
    /// </summary>
    public partial class screenClientes : UserControl
    {
        ClienteController controller = new ClienteController();
        public screenClientes()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            frmClienteNovo frm = new frmClienteNovo();
            frm.Closed += (s, args) => CarregarClientes();
            frm.Show();
        }

        private void CarregarClientes()
        {
            ClienteController controller = new ClienteController();
            IList<Cliente> lista = controller.List();
            dbGridClientes.ItemsSource = lista;
        }

        private void OnClickExcluirCliente(object sender, RoutedEventArgs e)
        {
            Cliente cliente = ((FrameworkElement)sender).DataContext as Cliente;

            if (Dialog.OnConfirma("Você deseja realmente excluir?", "Excluir"))
            {
                controller.Delete(cliente);
                Dialog.OnInforma("Cliente excluído com sucesso");
                CarregarClientes();
            }
        }

        private void OnClickEditarCliente(object sender, RoutedEventArgs e)
        {
            Cliente cliente = ((FrameworkElement)sender).DataContext as Cliente;
            frmClienteEditar frm = new frmClienteEditar(cliente);
            frm.Closed += (s, args) => CarregarClientes();
            frm.Show();
        }
    }
}
