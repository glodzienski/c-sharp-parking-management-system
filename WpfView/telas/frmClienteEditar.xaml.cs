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
    public partial class frmClienteEditar : Window
    {
        ClienteController clienteController = new ClienteController();
        Cliente cliente;

        public frmClienteEditar(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            edtCpf.Text = cliente.Cpf;
            edtNome.Text = cliente.Nome;
            edtSobrenome.Text = cliente.Sobrenome;
            edtEmail.Text = cliente.Email;
            chkAtivo.IsChecked = cliente.Ativo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String cpf = TreatCpf(edtCpf.Text);
            String nome = edtNome.Text;
            String sobrenome = edtSobrenome.Text;
            String email = edtEmail.Text;
            Boolean ativo = chkAtivo.IsChecked.Value;

            try
            {
                if (cpf.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo CPF.");
                }
                if (!long.TryParse(cpf, out Int64 n) || cpf.Length != 11)
                {
                    throw new Exception("CPF inválido");
                }
                if (nome.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Nome.");
                }

                this.cliente.Cpf = cpf;
                this.cliente.Nome = nome;
                this.cliente.Sobrenome = sobrenome;
                this.cliente.Email = email;
                this.cliente.Ativo = ativo;

                clienteController.Edit(this.cliente);
                MessageBox.Show("Cliente atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String TreatCpf(String cpf)
        {
            cpf = cpf.Replace(" ","");
            cpf = cpf.Replace("-","");
            cpf = cpf.Replace(".","");
            return cpf;
        }
    }
}
