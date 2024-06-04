using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace toyLandiaOff
{
    public partial class FormRecuperarSenha : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";

        public FormRecuperarSenha()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT PerguntaSeguranca FROM usuarios WHERE Usuario = @usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        txtPerguntaSeguranca.Text = result.ToString();
                        MessageBox.Show("Pergunta de segurança encontrada com sucesso.");
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void btnRedefinirSenha_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string respostaSeguranca = txtRespostaSeguranca.Text;
            string novaSenha = txtNovaSenha.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM usuarios WHERE Usuario = @usuario AND RespostaSeguranca = @respostaSeguranca";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", username);
                    cmd.Parameters.AddWithValue("@respostaSeguranca", respostaSeguranca);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        query = "UPDATE usuarios SET Senha = @novaSenha WHERE Usuario = @usuario";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@novaSenha", novaSenha);
                        cmd.Parameters.AddWithValue("@usuario", username);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Senha redefinida com sucesso!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Resposta de segurança incorreta.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void FormRecuperarSenha_Load(object sender, EventArgs e)
        {
            // Inicializa componentes se necessário
        }
    }
}
