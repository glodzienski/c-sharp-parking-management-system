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
            CarregarComandas(ComandaStatusEnum.Ativa);
            CarregarVagas(false);
        }

        private void CarregarComandas(int status)
        {            
            IList<Comanda> listaComandas = (status == 0) ? comandaController.List() : comandaController.FindByStatus(status);
            dbGridComandas.ItemsSource = listaComandas;
        }

        private void CarregarVagas(bool ocupadas, bool todas = false)
        {
            IList<Vaga> listaVagas = (todas) ? vagaController.List() : vagaController.List(ocupadas);
            dbGridVagasDisponiveis.ItemsSource = listaVagas;
        }

        private void OnAbrirNovaComanda(object sender, RoutedEventArgs e)
        {
            Vaga vaga = ((FrameworkElement)sender).DataContext as Vaga;
            if (vaga.Ocupada)
            {
                Dialog.OnInforma("A vaga " + vaga.Andar + vaga.Codigo + " já está ocupada");
            } else
            {
                frmComandaNova frm = new frmComandaNova(vaga);
                frm.Closed += (s, args) =>
                {
                    CarregarComandas(ComandaStatusEnum.Ativa);
                    CarregarVagas(false);
                };
                frm.Show();
            }            
        }

        private void OnFecharComanda(object sender, RoutedEventArgs e)
        {
            Comanda comanda = ((FrameworkElement)sender).DataContext as Comanda;

            if (comanda.ComandaStatusID == ComandaStatusEnum.Fechada)
            {
                Dialog.OnInforma("Comanda já esta fechada");
            }
            else if (Dialog.OnConfirma("Você deseja fechar essa comanda?", "Fechar"))
            {
                comandaController.Fechar(comanda);

                Vaga vaga = comanda._Vaga;
                vaga.Ocupada = false;
                vagaController.Edit(vaga);

                CarregarVagas(false);
                CarregarComandas(ComandaStatusEnum.Ativa);

                Dialog.OnInforma("Comanda fechada com sucesso");
            }
        }

        private void btnTodosStatus_Click(object sender, RoutedEventArgs e)
        {
            CarregarComandas(ComandaStatusEnum.Todas);
        }

        private void btnAtivas_Click(object sender, RoutedEventArgs e)
        {
            CarregarComandas(ComandaStatusEnum.Ativa);
        }

        private void btnReservadas_Click(object sender, RoutedEventArgs e)
        {
            CarregarComandas(ComandaStatusEnum.Reservada);
        }

        private void btnFechadas_Click(object sender, RoutedEventArgs e)
        {
            CarregarComandas(ComandaStatusEnum.Fechada);
        }

        private void btnVagasTodas_Click(object sender, RoutedEventArgs e)
        {
            CarregarVagas(false, true);
        }

        private void btnVagasLivres_Click(object sender, RoutedEventArgs e)
        {
            CarregarVagas(false, false);
        }

        private void btnOcupadas_Click(object sender, RoutedEventArgs e)
        {
            CarregarVagas(true, false);
        }
    }
}
