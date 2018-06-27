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
    public partial class frmClienteNovo : Window
    {
        public frmClienteNovo()
        {
            InitializeComponent();
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

                Cliente cliente = new Cliente();
                cliente.Cpf = cpf;
                cliente.Nome = nome;
                cliente.Sobrenome = sobrenome;
                cliente.Email = email;
                cliente.Ativo = ativo;

                ClienteController clienteController = new ClienteController();
                clienteController.Store(cliente);
                MessageBox.Show("Cliente cadastrado com sucesso!");
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
