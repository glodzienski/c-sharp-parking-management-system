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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String email = edtEmail.Text;
            String password = edtPassword.Password;

            Boolean validated = true;
            String messageToValidate = "";

            if (email.Equals(""))
            {
                messageToValidate += "Por favor preencha seu email.";
                validated = false;
            }
            if (password.Equals(""))
            {
                messageToValidate += "\nPor favor preencha sua senha.";
                validated = false;
            }
            if (!validated)
            {
                MessageBox.Show(messageToValidate);
            }
            else 
            {
                FuncionarioController funcionarioController = new FuncionarioController();
                Funcionario funcionario = funcionarioController.Login(email, password);

                if (funcionario != null)
                {
                    this.Hide();
                    App.FuncionarioLogado = funcionario;
                    frmSystem frm = new frmSystem();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                } else
                {
                    MessageBox.Show("Email ou senha incorretos.");
                }
            }
        }
    }
}
