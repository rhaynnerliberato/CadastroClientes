using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes
{
    public partial class frmLogin : Form
    {
        /*usuário e senha pré-definidos*/
        private string user = "admin";
        private string pass = "adm";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();

            /*validação de usuário e senha*/
            if(tbUsuario.Text == user && tbSenha.Text == pass)
            {
                cadastro.ShowDialog();
            }
            MessageBox.Show("Usuário ou Senha Inválida");
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
