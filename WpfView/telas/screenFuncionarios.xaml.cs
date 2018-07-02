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
    
    public partial class screenFuncionarios : UserControl
    {
        FuncionarioController controller = new FuncionarioController();

        public screenFuncionarios()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            IList<Funcionario> lista = controller.List();
            dbGridFuncionarios.ItemsSource = lista;
        }

        private void OnClickExcluirFuncionario(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = ((FrameworkElement)sender).DataContext as Funcionario;
            Funcionario funcionarioLogado = App.FuncionarioLogado;

            if(funcionarioLogado == funcionario)
            {
                Dialog.OnInforma("Não é possível excluir o funcionário logado.");
            } else if (Dialog.OnConfirma("Você deseja realmente excluir?", "Excluir"))
            {
                controller.Delete(funcionario);
                Dialog.OnInforma("Funcionário excluído com sucesso");
                CarregarFuncionarios();
            }
        }

        private void OnClickEditarFuncionario(object sender, RoutedEventArgs e)
        {
            Funcionario funcionario = ((FrameworkElement)sender).DataContext as Funcionario;
            frmFuncionarioEditar frm = new frmFuncionarioEditar(funcionario);
            frm.Closed += (s, args) => CarregarFuncionarios();
            frm.Show();
        }

        private void btnNovoFuncionario_Click(object sender, RoutedEventArgs e)
        {
            frmFuncionarioNovo frm = new frmFuncionarioNovo();
            frm.Closed += (s, args) => CarregarFuncionarios();
            frm.Show();
        }
    }
}
