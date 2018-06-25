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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            tabClientes.IsSelected = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            tabFuncionarios.IsSelected = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            tabVagas.IsSelected = true;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            tabServicos.IsSelected = true;
        }
    }
}
