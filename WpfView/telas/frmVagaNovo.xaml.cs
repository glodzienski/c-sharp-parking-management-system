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
using System.Windows.Shapes;

namespace WpfView
{
    public partial class frmVagaNovo : Window
    {
        VagaController controller = new VagaController();

        public frmVagaNovo()
        {
            InitializeComponent();

            VagaTipoController vagaTipoController = new VagaTipoController();
            IList<VagaTipo> listaTiposVagas = vagaTipoController.List();
            cbVagaTipo.Items.Insert(0, "Selecione");
            foreach (VagaTipo vaga in listaTiposVagas)
            {
                cbVagaTipo.Items.Insert(vaga.VagaTipoID, vaga.Descricao);
            }
            cbVagaTipo.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String codigo = edtCodigo.Text;
            String andar = edtAndar.Text;
            Boolean ativo = chkAtivo.IsChecked.Value;
            int vagaTipoId = cbVagaTipo.SelectedIndex;

            try
            {
                if (codigo.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Código.");
                }
                if (andar.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Andar.");
                }
                if (vagaTipoId == 0)
                {
                    throw new Exception("Por favor selecione um tipo de vaga");
                }

                Vaga vaga = new Vaga();
                vaga.Codigo = codigo;
                vaga.Andar = Convert.ToInt32(andar);
                vaga.Ativo = ativo;
                vaga.VagaTipoID = vagaTipoId;
                vaga.Ocupada = false;

                controller.Store(vaga);
                MessageBox.Show("Vaga criada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
