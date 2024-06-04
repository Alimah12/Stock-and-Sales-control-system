using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toyLandiaOff
{
    public partial class FormMudarSenha : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";

        public FormMudarSenha()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text; // Adicionar campo para o usuário
            string senhaAtual = txtSenhaAtual.Text;
            string novaSenha = txtNovaSenha.Text;
            string confirmarNovaSenha = txtConfirmarNovaSenha.Text;

            if (novaSenha != confirmarNovaSenha)
            {
                MessageBox.Show("A nova senha e a confirmação não correspondem.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(1) FROM usuarios WHERE Usuario = @usuario AND Senha = @senhaAtual";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senhaAtual", senhaAtual);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        string updateQuery = "UPDATE usuarios SET Senha = @novaSenha WHERE Usuario = @usuario";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@usuario", usuario);
                        updateCmd.Parameters.AddWithValue("@novaSenha", novaSenha);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Senha alterada com sucesso!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha atual incorretos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }
    }
}
