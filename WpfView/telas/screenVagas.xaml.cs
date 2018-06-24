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
    public partial class screenVagas : UserControl
    {
        VagaController controller = new VagaController();

        public screenVagas()
        {
            InitializeComponent();
            CarregarVagas();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            frmVagaNovo frm = new frmVagaNovo();
            frm.Closed += (s, args) => CarregarVagas();
            frm.Show();
        }

        private void CarregarVagas()
        {
            IList<Vaga> lista = controller.List();
            dbGridVagas.ItemsSource = lista;
        }

        private void OnClickExcluirVaga(object sender, RoutedEventArgs e)
        {
            Vaga vaga = ((FrameworkElement)sender).DataContext as Vaga;

            if (Dialog.OnConfirma("Você deseja realmente excluir?", "Excluir"))
            {
                controller.Delete(vaga);
                Dialog.OnInforma("Vaga excluída com sucesso");
                CarregarVagas();
            }
        }

        private void OnClickEditarVaga(object sender, RoutedEventArgs e)
        {
            Vaga vaga = ((FrameworkElement)sender).DataContext as Vaga;
            frmVagaEditar frm = new frmVagaEditar(vaga);
            frm.Closed += (s, args) => CarregarVagas();
            frm.Show();
        }
    }
}
