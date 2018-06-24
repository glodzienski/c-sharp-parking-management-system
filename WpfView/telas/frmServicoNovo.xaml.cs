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
    public partial class frmServicoNovo : Window
    {
        ServicoController controller = new ServicoController();

        public frmServicoNovo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nome = edtNome.Text;
            String codigo = edtCodigo.Text;
            Double valor = Convert.ToDouble(edtValor.Text);
            Boolean ativo = chkAtivo.IsChecked.Value;

            try
            {
                if (nome.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Nome.");
                }
                if (codigo.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Codigo.");
                }
                if (valor < 0 )
                {
                    throw new Exception("Por favor preencha o campo Valor com um valor maior ou igual a zero.");
                }

                Servico servico = new Servico();
                servico.Nome = nome;
                servico.Codigo = codigo;
                servico.Valor = valor;
                servico.Ativo = ativo;

                controller.Store(servico);
                MessageBox.Show("Serviço cadastrado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
