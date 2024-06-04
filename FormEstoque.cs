using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaEstoque
{
    public partial class FormEstoque : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";


        public FormEstoque()
        {
            InitializeComponent();
        }

        private void AdicionarProduto(string nome, int quantidade, decimal preco)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Produtos (Nome, Quantidade, Preco) VALUES (@nome, @quantidade, @preco)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.ExecuteNonQuery();
            }
        }

        private DataTable BuscarProduto(string nome)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Produtos WHERE Nome LIKE @nome";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        private void ExcluirProduto(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
            
                conn.Open();
                string query = "DELETE FROM Produtos WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int quantidade = int.Parse(txtQuantidade.Text);
            decimal preco = decimal.Parse(txtPreco.Text);
            AdicionarProduto(nome, quantidade, preco);
            DataTable dt = BuscarProduto("");
            dataGridView1.DataSource = dt;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string nome = txtNome.Text;
            DataTable dt = BuscarProduto(nome);
            dataGridView1.DataSource = dt;

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormEstoque_Load(object sender, EventArgs e)
        {
            DataTable dt = BuscarProduto("");
            dataGridView1.DataSource = dt;
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            DataTable dt = BuscarProduto("");
            dataGridView1.DataSource = dt;
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdExcluir.Text);
            ExcluirProduto(id);
            MessageBox.Show("Produto excluído com sucesso!");
        }

        private void txtIdExcluir_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
