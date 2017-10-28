namespace Visomax
{
    partial class frmInformacoesCartao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformacoesCartao));
            this.gridInformacoesCartoes = new System.Windows.Forms.DataGridView();
            this.clnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnValorRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDataRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCartaoRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.txtValorBruto = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtSequencia = new System.Windows.Forms.TextBox();
            this.txtDataVenda = new System.Windows.Forms.TextBox();
            this.txtDataEfetiva = new System.Windows.Forms.TextBox();
            this.txtAutorizacao = new System.Windows.Forms.TextBox();
            this.btnReceberCartao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridInformacoesCartoes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInformacoesCartoes
            // 
            this.gridInformacoesCartoes.AllowUserToAddRows = false;
            this.gridInformacoesCartoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInformacoesCartoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCliente,
            this.clnDataCriacao,
            this.clnEmissao,
            this.clnVencimento,
            this.clnValor,
            this.clnValorRecebido,
            this.clnDataRecebimento,
            this.clnCartaoRecebido,
            this.clnDescricao});
            this.gridInformacoesCartoes.Location = new System.Drawing.Point(12, 107);
            this.gridInformacoesCartoes.Name = "gridInformacoesCartoes";
            this.gridInformacoesCartoes.Size = new System.Drawing.Size(837, 212);
            this.gridInformacoesCartoes.TabIndex = 0;
            // 
            // clnCliente
            // 
            this.clnCliente.HeaderText = "Cliente";
            this.clnCliente.Name = "clnCliente";
            this.clnCliente.ReadOnly = true;
            this.clnCliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnCliente.Width = 130;
            // 
            // clnDataCriacao
            // 
            this.clnDataCriacao.HeaderText = "Data de criação";
            this.clnDataCriacao.Name = "clnDataCriacao";
            this.clnDataCriacao.ReadOnly = true;
            this.clnDataCriacao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnDataCriacao.Width = 75;
            // 
            // clnEmissao
            // 
            this.clnEmissao.HeaderText = "Emissão";
            this.clnEmissao.Name = "clnEmissao";
            this.clnEmissao.ReadOnly = true;
            this.clnEmissao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnEmissao.Width = 75;
            // 
            // clnVencimento
            // 
            this.clnVencimento.HeaderText = "Vencimento";
            this.clnVencimento.Name = "clnVencimento";
            this.clnVencimento.ReadOnly = true;
            this.clnVencimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnVencimento.Width = 75;
            // 
            // clnValor
            // 
            this.clnValor.HeaderText = "Valor";
            this.clnValor.Name = "clnValor";
            this.clnValor.ReadOnly = true;
            this.clnValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnValor.Width = 75;
            // 
            // clnValorRecebido
            // 
            this.clnValorRecebido.HeaderText = "Valor recebido";
            this.clnValorRecebido.Name = "clnValorRecebido";
            this.clnValorRecebido.ReadOnly = true;
            this.clnValorRecebido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnValorRecebido.Width = 75;
            // 
            // clnDataRecebimento
            // 
            this.clnDataRecebimento.HeaderText = "Data recebimento";
            this.clnDataRecebimento.Name = "clnDataRecebimento";
            this.clnDataRecebimento.ReadOnly = true;
            this.clnDataRecebimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnDataRecebimento.Width = 75;
            // 
            // clnCartaoRecebido
            // 
            this.clnCartaoRecebido.HeaderText = "Cartão recebido";
            this.clnCartaoRecebido.Name = "clnCartaoRecebido";
            this.clnCartaoRecebido.ReadOnly = true;
            this.clnCartaoRecebido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnCartaoRecebido.Width = 75;
            // 
            // clnDescricao
            // 
            this.clnDescricao.HeaderText = "Descrição";
            this.clnDescricao.Name = "clnDescricao";
            this.clnDescricao.ReadOnly = true;
            this.clnDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnDescricao.Width = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sequência:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Autorização:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data de venda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(660, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data efetiva:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Descrição:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Valor bruto:";
            // 
            // txtFilial
            // 
            this.txtFilial.Location = new System.Drawing.Point(50, 22);
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.ReadOnly = true;
            this.txtFilial.Size = new System.Drawing.Size(97, 20);
            this.txtFilial.TabIndex = 8;
            // 
            // txtValorBruto
            // 
            this.txtValorBruto.Location = new System.Drawing.Point(81, 64);
            this.txtValorBruto.Name = "txtValorBruto";
            this.txtValorBruto.ReadOnly = true;
            this.txtValorBruto.Size = new System.Drawing.Size(100, 20);
            this.txtValorBruto.TabIndex = 9;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(289, 64);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(190, 20);
            this.txtDescricao.TabIndex = 10;
            // 
            // txtSequencia
            // 
            this.txtSequencia.Location = new System.Drawing.Point(229, 22);
            this.txtSequencia.Name = "txtSequencia";
            this.txtSequencia.ReadOnly = true;
            this.txtSequencia.Size = new System.Drawing.Size(82, 20);
            this.txtSequencia.TabIndex = 11;
            // 
            // txtDataVenda
            // 
            this.txtDataVenda.Location = new System.Drawing.Point(560, 22);
            this.txtDataVenda.Name = "txtDataVenda";
            this.txtDataVenda.ReadOnly = true;
            this.txtDataVenda.Size = new System.Drawing.Size(84, 20);
            this.txtDataVenda.TabIndex = 12;
            // 
            // txtDataEfetiva
            // 
            this.txtDataEfetiva.Location = new System.Drawing.Point(731, 22);
            this.txtDataEfetiva.Name = "txtDataEfetiva";
            this.txtDataEfetiva.ReadOnly = true;
            this.txtDataEfetiva.Size = new System.Drawing.Size(84, 20);
            this.txtDataEfetiva.TabIndex = 13;
            // 
            // txtAutorizacao
            // 
            this.txtAutorizacao.Location = new System.Drawing.Point(398, 22);
            this.txtAutorizacao.Name = "txtAutorizacao";
            this.txtAutorizacao.ReadOnly = true;
            this.txtAutorizacao.Size = new System.Drawing.Size(66, 20);
            this.txtAutorizacao.TabIndex = 14;
            // 
            // btnReceberCartao
            // 
            this.btnReceberCartao.Location = new System.Drawing.Point(373, 339);
            this.btnReceberCartao.Name = "btnReceberCartao";
            this.btnReceberCartao.Size = new System.Drawing.Size(115, 35);
            this.btnReceberCartao.TabIndex = 15;
            this.btnReceberCartao.Text = "&Receber cartão";
            this.btnReceberCartao.UseVisualStyleBackColor = true;
            this.btnReceberCartao.Click += new System.EventHandler(this.btnReceberCartao_Click);
            // 
            // frmInformacoesCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 391);
            this.Controls.Add(this.btnReceberCartao);
            this.Controls.Add(this.txtAutorizacao);
            this.Controls.Add(this.txtDataEfetiva);
            this.Controls.Add(this.txtDataVenda);
            this.Controls.Add(this.txtSequencia);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtValorBruto);
            this.Controls.Add(this.txtFilial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridInformacoesCartoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInformacoesCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações de cartão";
            this.Load += new System.EventHandler(this.frmInformacoesCartao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInformacoesCartoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridInformacoesCartoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.TextBox txtValorBruto;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtSequencia;
        private System.Windows.Forms.TextBox txtDataVenda;
        private System.Windows.Forms.TextBox txtDataEfetiva;
        private System.Windows.Forms.TextBox txtAutorizacao;
        private System.Windows.Forms.Button btnReceberCartao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnValorRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDataRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCartaoRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDescricao;
    }
}