using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Clientes
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();

            tbPesquisar.Enabled = true;
            tbNome.Enabled = false;
            tbEmail.Enabled = false;
            tbCPF.Enabled = false;
            tbIdade.Enabled = false;
            tbMatricula.Enabled = false;
            tbNascimento.Enabled = false;
            tbProfissao.Enabled = false;
            tbSobrenome.Enabled = false;
            tbSenha.Enabled = false;
        }

        /*paramtros de conexão com o banco de dados bancocrud*/
        SqlConnection conexaoSql = null;
        private string strConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=bancocrud;Data Source=DESKTOP-L3VAJUM";
        private string comandoSql = string.Empty;



        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            /*declarando comando sql insersão de valor nos campos da tabela cliente*/
            comandoSql = "insert into Cliente(Nome,Sobrenome,Email,Nascimento,CPF,Matricula,Idade,Profissao,Senha)values(@Nome,@Sobrenome,@Email,@Nascimento,@CPF,@Matricula,@Idade,@Profissao,@Senha)";
            /*Instanciando uma conexão sql informando os parâmetros de conexão com o banco declarados no inicio*/
            conexaoSql = new SqlConnection(strConexao);
            /*instanciando "comando" para conversão dos valores dos campos para as variaveis utilizadas no comando sql*/
            SqlCommand comando = new SqlCommand(comandoSql, conexaoSql);

            /*converão de valores dos textbox para as variaveis utlizadas no comando sql*/
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = tbNome.Text;
            comando.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = tbSobrenome.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            comando.Parameters.Add("@Nascimento", SqlDbType.Date).Value = Convert.ToDateTime(tbNascimento.Text);
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = tbCPF.Text;
            comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = tbMatricula.Text;
            comando.Parameters.Add("@Idade", SqlDbType.VarChar).Value = tbIdade.Text;
            comando.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = tbProfissao.Text;
            comando.Parameters.Add("@Senha", SqlDbType.VarChar).Value = tbSenha.Text;


            try
            {
                /*abrindo conexao com banco*/
                conexaoSql.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro salvo com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexaoSql.Close();
            }

            tbPesquisar.Clear();
            tbNome.Clear();
            tbEmail.Clear();
            tbCPF.Clear();
            tbIdade.Clear();
            tbMatricula.Clear();
            tbNascimento.Clear();
            tbProfissao.Clear();
            tbSobrenome.Clear();
            tbSenha.Clear();

            tbPesquisar.Enabled = true;
            tbNome.Enabled = false;
            tbEmail.Enabled = false;
            tbCPF.Enabled = false;
            tbIdade.Enabled = false;
            tbMatricula.Enabled = false;
            tbNascimento.Enabled = false;
            tbProfissao.Enabled = false;
            tbSobrenome.Enabled = false;
            tbSenha.Enabled = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbPesquisar.Enabled = false;
            tbNome.Enabled = true;
            tbEmail.Enabled = true;
            tbCPF.Enabled = true;
            tbIdade.Enabled = true;
            tbMatricula.Enabled = true;
            tbNascimento.Enabled = true;
            tbProfissao.Enabled = true;
            tbSobrenome.Enabled = true;
            tbSenha.Enabled = true;
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;

            tbPesquisar.Clear();
            tbNome.Clear();
            tbEmail.Clear();
            tbCPF.Clear();
            tbIdade.Clear();
            tbMatricula.Clear();
            tbNascimento.Text = "01011900";
            tbProfissao.Clear();
            tbSobrenome.Clear();
            tbSenha.Clear();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

                        
            /*declarando comando sql leitura da tabela cliente*/
            comandoSql = "select * from Cliente where Nome=@Pesquisar";
            /*Instanciando uma conexão sql informando os parâmetros de conexão com o banco declarados no inicio*/
            conexaoSql = new SqlConnection(strConexao);
            /*instanciando "comando" para conversão dos valores dos campos para as variaveis utilizadas no comando sql*/
            SqlCommand comando = new SqlCommand(comandoSql, conexaoSql);

            /*converão de valores dos textbox para as variaveis utlizadas no comando sql*/
            comando.Parameters.Add("@Pesquisar", SqlDbType.VarChar).Value = tbPesquisar.Text;
            //comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = tbMatricula.Text;
            


            try
            {
                if(tbPesquisar.Text == String.Empty)
                {
                    MessageBox.Show("Primeiro digite um nome ou matrícula.");
                }
                /*abrindo conexao com banco*/
                conexaoSql.Open();

                SqlDataReader lerDados = comando.ExecuteReader();

                if(lerDados.HasRows == false)
                {
                    throw new Exception("Cliente não cadastrado.");
                }
                else
                {
                    tbPesquisar.Clear();
                    tbPesquisar.Enabled = false;
                    tbNome.Enabled = true;
                    tbEmail.Enabled = true;
                    tbCPF.Enabled = true;
                    tbIdade.Enabled = true;
                    tbMatricula.Enabled = true;
                    tbNascimento.Enabled = true;
                    tbProfissao.Enabled = true;
                    tbSobrenome.Enabled = true;
                    tbSenha.Enabled = true;
                    btnSalvar.Enabled = false;
                    btnAlterar.Enabled = true;
                }

                lerDados.Read();
                /*converter dados para leitura do sql*/
                tbNome.Text = Convert.ToString(lerDados["Nome"]);
                tbSobrenome.Text = Convert.ToString(lerDados["Sobrenome"]);
                tbEmail.Text = Convert.ToString(lerDados["Email"]);
                tbNascimento.Text = Convert.ToString(lerDados["Nascimento"]);
                tbCPF.Text = Convert.ToString(lerDados["CPF"]);
                tbMatricula.Text = Convert.ToString(lerDados["Matricula"]);
                tbIdade.Text = Convert.ToString(lerDados["Idade"]);
                tbProfissao.Text = Convert.ToString(lerDados["Profissao"]);
                tbSenha.Text = Convert.ToString(lerDados["Senha"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexaoSql.Close();

            }

            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            /*comando sql para alteração da tabela Cliente*/
            comandoSql = "update Cliente set Nome=@Nome, Email=@Email, CPF=@CPF, Idade=@Idade, Matricula=@Matricula, Nascimento=@Nascimento, Profissao=@Profissao, Sobrenome=@Sobrenome, Senha=@Senha";
            /*Abrindo uma conexão com banco de dados informando a string de conexão com o bancocrud*/
            conexaoSql = new SqlConnection(strConexao);
            /**/
            SqlCommand comando = new SqlCommand(comandoSql, conexaoSql);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = tbNome.Text;
            comando.Parameters.Add("@Sobrenome", SqlDbType.VarChar).Value = tbSobrenome.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = tbEmail.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = tbCPF.Text;
            comando.Parameters.Add("@Idade", SqlDbType.VarChar).Value = tbIdade.Text;
            comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = tbMatricula.Text;
            comando.Parameters.Add("@Nascimento", SqlDbType.Date).Value = tbNascimento.Text;
            comando.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = tbProfissao.Text;
            comando.Parameters.Add("@Senha", SqlDbType.VarChar).Value = tbSenha.Text;

            try
            {
                /*abrir conexão com banco*/
                conexaoSql.Open();
                /*executando a query no banco*/
                comando.ExecuteNonQuery();
                /*retornar msg pro usuário*/
                MessageBox.Show("Dados alterados.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
            tbPesquisar.Clear();
            tbNome.Clear();
            tbEmail.Clear();
            tbCPF.Clear();
            tbIdade.Clear();
            tbMatricula.Clear();
            tbNascimento.Clear();
            tbProfissao.Clear();
            tbSobrenome.Clear();
            tbSenha.Clear();

            tbPesquisar.Enabled = true;
            tbNome.Enabled = false;
            tbEmail.Enabled = false;
            tbCPF.Enabled = false;
            tbIdade.Enabled = false;
            tbMatricula.Enabled = false;
            tbNascimento.Enabled = false;
            tbProfissao.Enabled = false;
            tbSobrenome.Enabled = false;
            tbSenha.Enabled = false;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /*comando sql para exclusão da tabela Cliente*/
            comandoSql = "delete Cliente where Nome=@Nome and CPF=@CPF and Matricula=@Matricula";
            /*Abrindo uma conexão com banco de dados informando a string de conexão com o bancocrud*/
            conexaoSql = new SqlConnection(strConexao);
            /**/
            SqlCommand comando = new SqlCommand(comandoSql, conexaoSql);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = tbNome.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = tbCPF.Text;
            comando.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = tbMatricula.Text;
            

            try
            {
                conexaoSql.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Apagado.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexaoSql.Close();

                tbPesquisar.Clear();
                tbNome.Clear();
                tbEmail.Clear();
                tbCPF.Clear();
                tbIdade.Clear();
                tbMatricula.Clear();
                tbNascimento.Clear();
                tbProfissao.Clear();
                tbSobrenome.Clear();
                tbSenha.Clear();

                tbPesquisar.Enabled = true;
                tbNome.Enabled = false;
                tbEmail.Enabled = false;
                tbCPF.Enabled = false;
                tbIdade.Enabled = false;
                tbMatricula.Enabled = false;
                tbNascimento.Enabled = false;
                tbProfissao.Enabled = false;
                tbSobrenome.Enabled = false;
                tbSenha.Enabled = false;

            }
        }
    }
}
