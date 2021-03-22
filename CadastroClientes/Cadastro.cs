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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            tbNome.Enabled = false;
            tbSobrenome.Enabled = false;
            tbNascimento.Enabled = false;
            tbCPF.Enabled = false;
            tbEmail.Enabled = false;
            tbIdade.Enabled = false;
            tbMatricula.Enabled = false;
            tbProfissao.Enabled = false;
            tbSenha.Enabled = false;
        }

        private void tbPesquisar_TextChanged(object sender, EventArgs e)
        {
            tbPesquisar.Text = "";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void Cadastro_Load_1(object sender, EventArgs e)
        {

        }
    }
}
