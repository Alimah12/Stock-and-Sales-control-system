using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroCliente;
using SistemaEstoque;

namespace toyLandiaOff
{
    public partial class FormHome : Form
    {
        bool sidebarExpand; 
        public FormHome()
        {
            InitializeComponent();
        }

        private void s(object sender, EventArgs e)
        {
            

            if (sidebarExpand)
            {
                //se a barra lateral estiver expandida, minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
       
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //definindo o intervalo do temporizador para o mínimo para torná-lo mais suave
            sidebarTimer.Start();
        }

            //Funcionalidade aos buttons da home
        private void button1_Click(object sender, EventArgs e)
        {
            FormCaixa Caixaform = new FormCaixa();
            Caixaform.ShowDialog();
        }

        private void Estoque_Click(object sender, EventArgs e)
        {
            FormEstoque Estoqueform = new FormEstoque();
            Estoqueform.ShowDialog();
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            FormCadastroCliente Clienteform = new FormCadastroCliente();
            Clienteform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMudarSenha frmMudarSenha = new FormMudarSenha();
            frmMudarSenha.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormEstoque Estoqueform = new FormEstoque();
            Estoqueform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCadastroCliente Clienteform = new FormCadastroCliente();
            Clienteform.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCadastroUsuario Cadastrousuarioform = new FormCadastroUsuario();
            Cadastrousuarioform.ShowDialog();
        }
    }
}
