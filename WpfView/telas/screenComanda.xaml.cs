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
    public partial class screenComanda : UserControl
    {
        ComandaController comandaController = new ComandaController();
        VagaController vagaController = new VagaController();

        public screenComanda()
        {
            InitializeComponent();
            CarregarComandas();
            CarregarVagas(false);
        }

        private void CarregarComandas()
        {
            IList<Comanda> listaComandas = comandaController.List();
            dbGridComandas.ItemsSource = listaComandas;
        }

        private void CarregarVagas(bool ocupadas)
        {
            IList<Vaga> listaVagas = vagaController.List(ocupadas);
            dbGridVagasDisponiveis.ItemsSource = listaVagas;
        }

        private void OnAbrirNovaComanda(object sender, RoutedEventArgs e)
        {
            Vaga vaga = ((FrameworkElement)sender).DataContext as Vaga;
            frmComandaNova frm = new frmComandaNova(vaga);
            frm.Closed += (s, args) =>
            {
                CarregarComandas();
                CarregarVagas(false);
            };
            frm.Show();
        }

        private void OnFecharComanda(object sender, RoutedEventArgs e)
        {
            Comanda comanda = ((FrameworkElement)sender).DataContext as Comanda;

            if (Dialog.OnConfirma("Você deseja fechar essa comanda?", "Fechar"))
            {
                comandaController.Fechar(comanda);

                Vaga vaga = comanda._Vaga;
                vaga.Ocupada = false;
                vagaController.Edit(vaga);

                CarregarVagas(false);
                CarregarComandas();

                Dialog.OnInforma("Comanda fechada com sucesso");
            }
        }
    }
}
