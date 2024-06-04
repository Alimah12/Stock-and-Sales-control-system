namespace toyLandiaOff
{
    partial class FormCaixa
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
            this.cmbProdutos = new System.Windows.Forms.ComboBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtCupom = new System.Windows.Forms.TextBox();
            this.btnAplicarCupom = new System.Windows.Forms.Button();
            this.cmbPagamento = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnMostrarTotal = new System.Windows.Forms.Button();
            this.dgvCarrinho = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProdutos
            // 
            this.cmbProdutos.FormattingEnabled = true;
            this.cmbProdutos.Location = new System.Drawing.Point(79, 76);
            this.cmbProdutos.Name = "cmbProdutos";
            this.cmbProdutos.Size = new System.Drawing.Size(144, 21);
            this.cmbProdutos.TabIndex = 0;
            this.cmbProdutos.Text = "Selecione um Produto";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(79, 120);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(144, 20);
            this.txtQuantidade.TabIndex = 1;
            this.txtQuantidade.Text = "Quantidade";
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(79, 208);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.Size = new System.Drawing.Size(144, 20);
            this.txtCupom.TabIndex = 2;
            this.txtCupom.Text = "Digite o Cupom Promocional\n";
            // 
            // btnAplicarCupom
            // 
            this.btnAplicarCupom.Location = new System.Drawing.Point(98, 234);
            this.btnAplicarCupom.Name = "btnAplicarCupom";
            this.btnAplicarCupom.Size = new System.Drawing.Size(94, 23);
            this.btnAplicarCupom.TabIndex = 3;
            this.btnAplicarCupom.Text = "Aplicar Cupom";
            this.btnAplicarCupom.UseVisualStyleBackColor = true;
            this.btnAplicarCupom.Click += new System.EventHandler(this.btnAplicarCupom_Click);
            // 
            // cmbPagamento
            // 
            this.cmbPagamento.FormattingEnabled = true;
            this.cmbPagamento.Location = new System.Drawing.Point(79, 335);
            this.cmbPagamento.Name = "cmbPagamento";
            this.cmbPagamento.Size = new System.Drawing.Size(144, 21);
            this.cmbPagamento.TabIndex = 4;
            this.cmbPagamento.Text = "Método de Pagamento\n";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(79, 163);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(144, 23);
            this.btnAdicionar.TabIndex = 5;
            this.btnAdicionar.Text = "Adicionar Produto\n";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Location = new System.Drawing.Point(406, 335);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(113, 23);
            this.btnFinalizarVenda.TabIndex = 6;
            this.btnFinalizarVenda.Text = "Finalizar Venda";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click_1);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.Location = new System.Drawing.Point(406, 374);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(113, 23);
            this.btnCancelarVenda.TabIndex = 7;
            this.btnCancelarVenda.Text = "Cancelar Venda\n";
            this.btnCancelarVenda.UseVisualStyleBackColor = true;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // btnMostrarTotal
            // 
            this.btnMostrarTotal.Location = new System.Drawing.Point(79, 280);
            this.btnMostrarTotal.Name = "btnMostrarTotal";
            this.btnMostrarTotal.Size = new System.Drawing.Size(144, 23);
            this.btnMostrarTotal.TabIndex = 8;
            this.btnMostrarTotal.Text = "Mostrar Total";
            this.btnMostrarTotal.UseVisualStyleBackColor = true;
            this.btnMostrarTotal.Click += new System.EventHandler(this.btnMostrarTotal_Click);
            // 
            // dgvCarrinho
            // 
            this.dgvCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrinho.Location = new System.Drawing.Point(283, 76);
            this.dgvCarrinho.Name = "dgvCarrinho";
            this.dgvCarrinho.Size = new System.Drawing.Size(377, 253);
            this.dgvCarrinho.TabIndex = 9;
            // 
            // FormCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCarrinho);
            this.Controls.Add(this.btnMostrarTotal);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cmbPagamento);
            this.Controls.Add(this.btnAplicarCupom);
            this.Controls.Add(this.txtCupom);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.cmbProdutos);
            this.Name = "FormCaixa";
            this.Text = "FormCaixa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProdutos;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtCupom;
        private System.Windows.Forms.Button btnAplicarCupom;
        private System.Windows.Forms.ComboBox cmbPagamento;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnMostrarTotal;
        private System.Windows.Forms.DataGridView dgvCarrinho;
    }
}