namespace CadastroClientes
{
    partial class Cadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Cadastro
            // 
            this.ClientSize = new System.Drawing.Size(314, 251);
            this.Name = "Cadastro";
            this.Load += new System.EventHandler(this.Cadastro_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbSobrenome;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbIdade;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.TextBox tbProfissao;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.MaskedTextBox tbNascimento;
        private System.Windows.Forms.MaskedTextBox tbCPF;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox tbPesquisar;
    }
}