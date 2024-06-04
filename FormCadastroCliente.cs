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
    public partial class FormCadastroCliente : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";
        MySqlConnection conn;

        public FormCadastroCliente()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text;
            string nome = txtNome.Text;
            string sexo = cmbSexo.SelectedItem?.ToString(); // Use "?" para evitar erro se nenhum item estiver selecionado
            string endereco = txtEndereco.Text;
            string bairro = txtBairro.Text;
            string municipio = txtMunicipio.Text;
            string estado = txtEstado.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO Clientes (CPF, Nome, Sexo, Endereco, Bairro, Municipio, Estado) VALUES (@cpf, @nome, @sexo, @endereco, @bairro, @municipio, @estado)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@sexo", sexo);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@municipio", municipio);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!");
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message);
                }
                finally
                {
                    conn.Close();   
                }
            }
        }

        private void LimparCampos()
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            cmbSexo.SelectedIndex = -1;
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close(); // Fecha o formulário de cadastro
        }

        private void AtualizarDataGridView()
        {
            try
            {
                conn.Open();
                string query = "SELECT CPF, Nome, Sexo, Endereco, Bairro, Municipio, Estado FROM Clientes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void FormCadastroCliente_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExcluirCliente(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                conn.Open();
                string query = "DELETE FROM clientes WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)

        {
            int id = int.Parse(txtIdCliente.Text);
            ExcluirCliente(id);
            MessageBox.Show("excluído com sucesso!");
        }

        private DataTable BuscarClientes(string nome)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM clientes WHERE Nome LIKE @nome";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        private void Atualizar_Click(object sender, EventArgs e)
        {
            DataTable dt = BuscarClientes("");
            dataGridViewClientes.DataSource = dt;
        }
    }
}
