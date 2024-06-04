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
    public partial class FormCaixa : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";
        DataTable dtCarrinho = new DataTable();
        decimal descontoCupom = 0;

        public FormCaixa()
        {
            InitializeComponent();
            CarregarProdutos();
            ConfigurarCarrinho();
            ConfigurarPagamento();
        }

        private void CarregarProdutos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Nome FROM Produtos";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbProdutos.Items.Add(reader["Nome"].ToString());
                }
            }
        }

        private void ConfigurarCarrinho()
        {
            dtCarrinho.Columns.Add("Produto");
            dtCarrinho.Columns.Add("Quantidade", typeof(int));
            dtCarrinho.Columns.Add("Preco", typeof(decimal));
            dtCarrinho.Columns.Add("Total", typeof(decimal));

            dgvCarrinho.DataSource = dtCarrinho;
        }

        private void ConfigurarPagamento()
        {
            cmbPagamento.Items.Add("Dinheiro");
            cmbPagamento.Items.Add("Cartão de Crédito");
            cmbPagamento.Items.Add("Cartão de Débito");
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cmbProdutos.SelectedItem == null || string.IsNullOrEmpty(txtQuantidade.Text))
            {
                MessageBox.Show("Selecione um produto e insira a quantidade.");
                return;
            }

            string nomeProduto = cmbProdutos.SelectedItem.ToString();
            int quantidade = int.Parse(txtQuantidade.Text);
            decimal preco = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Preco FROM Produtos WHERE Nome = @nome";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nomeProduto);
                preco = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            decimal total = preco * quantidade;
            dtCarrinho.Rows.Add(nomeProduto, quantidade, preco, total);
        }

        private void btnAplicarCupom_Click(object sender, EventArgs e)
        {
            string cupom = txtCupom.Text;

            // Verificar se o cupom é válido
            if (cupom == "DESCONTO10")
            {
                descontoCupom = 0.1m; // 10% de desconto
                MessageBox.Show("Cupom aplicado com sucesso! Desconto de 10%.");
            }
            else
            {
                descontoCupom = 0;
                MessageBox.Show("Cupom inválido.");
            }
        }

        
        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            dtCarrinho.Clear();
            MessageBox.Show("Venda cancelada!");
        }

        private void btnFinalizarVenda_Click_1(object sender, EventArgs e)
        {
            decimal totalVenda = 0;

            foreach (DataRow row in dtCarrinho.Rows)
            {
                totalVenda += (decimal)row["Total"];
            }

            if (descontoCupom > 0)
            {
                totalVenda *= (1 - descontoCupom); // Aplicar desconto
            }

            string metodoPagamento = cmbPagamento.SelectedItem?.ToString() ?? "Não especificado";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Atualizar o estoque diretamente
                foreach (DataRow row in dtCarrinho.Rows)
                {
                    string nomeProduto = row["Produto"].ToString();
                    int quantidadeVendida = (int)row["Quantidade"];

                    string getProductIdQuery = "SELECT Id FROM Produtos WHERE Nome = @nome"; // Atualize para usar a tabela correta
                    MySqlCommand getProductIdCmd = new MySqlCommand(getProductIdQuery, conn);
                    getProductIdCmd.Parameters.AddWithValue("@nome", nomeProduto);
                    int produtoId = Convert.ToInt32(getProductIdCmd.ExecuteScalar());

                    string updateEstoqueQuery = "UPDATE Produtos SET Quantidade = Quantidade - @quantidade WHERE Id = @id"; // Atualize para usar a tabela correta
                    MySqlCommand updateEstoqueCmd = new MySqlCommand(updateEstoqueQuery, conn);
                    updateEstoqueCmd.Parameters.AddWithValue("@quantidade", quantidadeVendida);
                    updateEstoqueCmd.Parameters.AddWithValue("@id", produtoId);
                    updateEstoqueCmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"Venda finalizada! Total: {totalVenda:C}\nPagamento: {metodoPagamento}");
            dtCarrinho.Clear();
        }






        private void btnMostrarTotal_Click(object sender, EventArgs e)
        {
            decimal totalVenda = 0;

            foreach (DataRow row in dtCarrinho.Rows)
            {
                totalVenda += (decimal)row["Total"];
            }

            if (descontoCupom > 0)
            {
                totalVenda *= (1 - descontoCupom); // Aplicar desconto
            }

            MessageBox.Show($"Total do Carrinho: {totalVenda:C}");
           }
    }
}
    


