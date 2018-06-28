using Controllers;
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
    public partial class frmSystem : Window
    {

        public frmSystem()
        {
            InitializeComponent();
            if (!App.FuncionarioLogado.Administrador)
            {
                itemServicos.Visibility = Visibility.Collapsed;
                itemFuncionario.Visibility = Visibility.Collapsed;
                itemVagas.Visibility = Visibility.Collapsed;
            }
        }

        private void itemComanda_Click(object sender, RoutedEventArgs e)
        {
            tabComanda.IsSelected = true;
        }

        private void itemClientes_Click(object sender, RoutedEventArgs e)
        {
            tabClientes.IsSelected = true;
        }

        private void itemFuncionario_Click(object sender, RoutedEventArgs e)
        {
            tabFuncionarios.IsSelected = true;
        }

        private void itemServicos_Click(object sender, RoutedEventArgs e)
        {
            tabServicos.IsSelected = true;
        }

        private void itemVagas_Click(object sender, RoutedEventArgs e)
        {
            tabVagas.IsSelected = true;
        }

        private void itemSair_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.Show();
            this.Close();
        }

        private void itemVeiculos_Click(object sender, RoutedEventArgs e)
        {
            tabVeiculos.IsSelected = true;
        }
    }
}
