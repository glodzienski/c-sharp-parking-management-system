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
    public partial class frmFuncionarioEditar : Window
    {
        FuncionarioController controller = new FuncionarioController();
        Funcionario funcionario;

        public frmFuncionarioEditar(Funcionario funcionario)
        {
            InitializeComponent();

            this.funcionario = funcionario;
            edtCpf.Text = funcionario.Cpf;
            edtNome.Text = funcionario.Nome;
            edtSobrenome.Text = funcionario.Sobrenome;
            edtEmail.Text = funcionario.Email;
            chkAtivo.IsChecked = funcionario.Ativo;
            chkAdmin.IsChecked = funcionario.Administrador;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String cpf = edtCpf.Text;
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
                if (nome.Equals(""))
                {
                    throw new Exception("Por favor preencha o campo Nome.");
                }

                this.funcionario.Cpf = TreatCpf(cpf);
                this.funcionario.Nome = nome;
                this.funcionario.Sobrenome = sobrenome;
                this.funcionario.Email = email;
                this.funcionario.Senha = senha;
                this.funcionario.Ativo = ativo;
                this.funcionario.Administrador = admin;

                controller.Edit(this.funcionario);
                MessageBox.Show("Funcionário atualizado com sucesso!");
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
