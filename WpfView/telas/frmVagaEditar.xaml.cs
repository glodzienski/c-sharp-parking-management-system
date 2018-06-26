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
    public partial class frmVagaEditar : Window
    {
        VagaController controller = new VagaController();
        VagaTipoController vagaTipoController = new VagaTipoController();
        Vaga vaga;

        public frmVagaEditar(Vaga vaga)
        {
            InitializeComponent();

            this.vaga = vaga;
            edtAndar.Text = vaga.Andar.ToString();
            edtCodigo.Text = vaga.Codigo;

            IList<VagaTipo> listaTiposVagas = vagaTipoController.List();
            cbVagaTipo.Items.Insert(0, "Selecione");
            foreach (VagaTipo vagaTipo in listaTiposVagas)
            {
                cbVagaTipo.Items.Insert(vagaTipo.VagaTipoID, vagaTipo.Descricao);
            }
            cbVagaTipo.SelectedIndex = vaga.VagaTipoID;
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

                this.vaga.Codigo = codigo;
                this.vaga.Andar = andar;
                this.vaga.Ativo = ativo;
                this.vaga.VagaTipoID = vagaTipoId;
                controller.Edit(vaga);

                MessageBox.Show("Vaga atualizada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
