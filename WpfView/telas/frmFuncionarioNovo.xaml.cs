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
    public partial class frmFuncionarioNovo : Window
    {
        public frmFuncionarioNovo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String cpf = TreatCpf(edtCpf.Text);
            String nome = edtNome.Text;
            String sobrenome = edtSobrenome.Text;
            String email = edtEmail.Text;
            String senha = edtPassword.Text;
            Boolean ativo = chkAtivo.IsChecked.Value;
            Boolean admin = chkAdmin.IsChecked.Value;

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

                Funcionario funcionario = new Funcionario();
                funcionario.Cpf = cpf;
                funcionario.Nome = nome;
                funcionario.Sobrenome = sobrenome;
                funcionario.Email = email;
                funcionario.Senha = senha;
                funcionario.Ativo = ativo;
                funcionario.Administrador = admin;

                FuncionarioController funcionarioController = new FuncionarioController();
                funcionarioController.Store(funcionario);
                MessageBox.Show("Funcionário cadastrado com sucesso!");
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
