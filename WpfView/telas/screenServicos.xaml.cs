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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfView.common;

namespace WpfView.telas
{
    public partial class screenServicos : UserControl
    {
        ServicoController controller = new ServicoController();

        public screenServicos()
        {
            InitializeComponent();
            CarregarServicos();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            frmServicoNovo frm = new frmServicoNovo();
            frm.Closed += (s, args) => CarregarServicos();
            frm.Show();
        }

        private void CarregarServicos()
        {
            IList<Servico> lista = controller.List();
            dbGridServicos.ItemsSource = lista;
        }

        private void OnClickExcluirServico(object sender, RoutedEventArgs e)
        {
            Servico servico = ((FrameworkElement)sender).DataContext as Servico;

            if (Dialog.OnConfirma("Você deseja realmente excluir?", "Excluir"))
            {
                controller.Delete(servico);
                Dialog.OnInforma("Serviço excluído com sucesso");
                CarregarServicos();
            }
        }

        private void OnClickEditarServico(object sender, RoutedEventArgs e)
        {
            Servico servico = ((FrameworkElement)sender).DataContext as Servico;
            frmServicoEditar frm = new frmServicoEditar(servico);
            frm.Closed += (s, args) => CarregarServicos();
            frm.Show();
        }
    }
}
