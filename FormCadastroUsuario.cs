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
    public partial class FormCadastroUsuario : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";

        public FormCadastroUsuario()
        {
            InitializeComponent();
        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            string respostaSeguranca = txtRespostaSeguranca.Text;
            string perguntaSeguranca = "Qual o código de segurança?";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO usuarios (Usuario, Senha, PerguntaSeguranca, RespostaSeguranca) VALUES (@usuario, @senha, @perguntaSeguranca, @respostaSeguranca)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@perguntaSeguranca", perguntaSeguranca);
                    cmd.Parameters.AddWithValue("@respostaSeguranca", respostaSeguranca);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário cadastrado com sucesso!");
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }

        private void AtualizarDataGridView()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM usuarios";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewUsuarios.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar usuários: " + ex.Message);
                }
            }
        }

        private DataTable BuscarUsuarios(string nome)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM usuarios WHERE Usuario LIKE @usuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", "%" + nome + "%"); // Usando o parâmetro "nome" corretamente
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void ExcluirUsuario(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                conn.Open();
                string query = "DELETE FROM usuarios WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close(); // Fecha o formulário de cadastro
        }
        private void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtRespostaSeguranca.Text = "";
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtExcluirUsuario.Text);
            ExcluirUsuario(id);
            MessageBox.Show("Produto excluído com sucesso!");
        }

        private void btnCarregarUsuarios_Click(object sender, EventArgs e)
        {
            DataTable dt = BuscarUsuarios("");
            dataGridViewUsuarios.DataSource = dt;
        }
    }
}
    

       
    
