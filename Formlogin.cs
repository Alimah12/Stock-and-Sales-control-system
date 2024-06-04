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
    public partial class Formlogin : Form
    {
        string connectionString = "server=localhost;database=sistemaestoque;uid=root;pwd=pizza2021;";
        public Formlogin()
        {
            InitializeComponent();
        }

        private void BtnAcesso_Click(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text;
            string password = TxtSenha.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(1) FROM usuarios WHERE Usuario = @usuario AND Senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", username);
                    cmd.Parameters.AddWithValue("@senha", password);


                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Acesso Liberado!");
                        FormHome FrmMain = new FormHome();
                        FrmMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!");
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
                
            }



        }

        private void Formlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMudarSenha_Click_1(object sender, EventArgs e)
        {
            FormRecuperarSenha frmMudarSenha = new FormRecuperarSenha();
            frmMudarSenha.ShowDialog();
        }
    }
}
