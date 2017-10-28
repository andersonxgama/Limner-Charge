namespace Visomax
{
    partial class frmConsultaRecebimentoLoja
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCanceladoMotivo = new System.Windows.Forms.TextBox();
            this.txtCancelado = new System.Windows.Forms.TextBox();
            this.txtCriadoEm = new System.Windows.Forms.TextBox();
            this.txtDataPgto = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCaixa = new System.Windows.Forms.TextBox();
            this.txtLoja = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridParcelas = new System.Windows.Forms.DataGridView();
            this.clnSequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrJuros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrDescontos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrPgto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridNumerarios = new System.Windows.Forms.DataGridView();
            this.clnNumSequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumIdNumerario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumVlrNumerario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumAdmCartao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumCpfCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumDtNumerario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.txtJuros = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtPagamento = new System.Windows.Forms.TextBox();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.txtRecebido = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNumerarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCanceladoMotivo);
            this.groupBox1.Controls.Add(this.txtCancelado);
            this.groupBox1.Controls.Add(this.txtCriadoEm);
            this.groupBox1.Controls.Add(this.txtDataPgto);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.txtCaixa);
            this.groupBox1.Controls.Add(this.txtLoja);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(69, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recebimento";
            // 
            // txtCanceladoMotivo
            // 
            this.txtCanceladoMotivo.Location = new System.Drawing.Point(487, 46);
            this.txtCanceladoMotivo.Name = "txtCanceladoMotivo";
            this.txtCanceladoMotivo.ReadOnly = true;
            this.txtCanceladoMotivo.Size = new System.Drawing.Size(214, 20);
            this.txtCanceladoMotivo.TabIndex = 12;
            // 
            // txtCancelado
            // 
            this.txtCancelado.Location = new System.Drawing.Point(440, 46);
            this.txtCancelado.Name = "txtCancelado";
            this.txtCancelado.ReadOnly = true;
            this.txtCancelado.Size = new System.Drawing.Size(41, 20);
            this.txtCancelado.TabIndex = 11;
            // 
            // txtCriadoEm
            // 
            this.txtCriadoEm.Location = new System.Drawing.Point(339, 46);
            this.txtCriadoEm.Name = "txtCriadoEm";
            this.txtCriadoEm.ReadOnly = true;
            this.txtCriadoEm.Size = new System.Drawing.Size(85, 20);
            this.txtCriadoEm.TabIndex = 10;
            // 
            // txtDataPgto
            // 
            this.txtDataPgto.Location = new System.Drawing.Point(238, 46);
            this.txtDataPgto.Name = "txtDataPgto";
            this.txtDataPgto.ReadOnly = true;
            this.txtDataPgto.Size = new System.Drawing.Size(85, 20);
            this.txtDataPgto.TabIndex = 9;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(147, 46);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(75, 20);
            this.txtId.TabIndex = 8;
            // 
            // txtCaixa
            // 
            this.txtCaixa.Location = new System.Drawing.Point(104, 46);
            this.txtCaixa.Name = "txtCaixa";
            this.txtCaixa.ReadOnly = true;
            this.txtCaixa.Size = new System.Drawing.Size(27, 20);
            this.txtCaixa.TabIndex = 7;
            // 
            // txtLoja
            // 
            this.txtLoja.Location = new System.Drawing.Point(61, 46);
            this.txtLoja.Name = "txtLoja";
            this.txtLoja.ReadOnly = true;
            this.txtLoja.Size = new System.Drawing.Size(27, 20);
            this.txtLoja.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cancelado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Criado em:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data pgto.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Caixa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loja:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridParcelas);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(872, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parcelas:";
            // 
            // gridParcelas
            // 
            this.gridParcelas.AllowUserToAddRows = false;
            this.gridParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSequencial,
            this.clnCodCliente,
            this.clnFilial,
            this.clnDocumento,
            this.clnParcela,
            this.clnCliente,
            this.clnVencimento,
            this.clnVlrParcela,
            this.clnVlrJuros,
            this.clnVlrDescontos,
            this.clnVlrPgto});
            this.gridParcelas.Location = new System.Drawing.Point(9, 19);
            this.gridParcelas.Name = "gridParcelas";
            this.gridParcelas.Size = new System.Drawing.Size(853, 140);
            this.gridParcelas.TabIndex = 0;
            // 
            // clnSequencial
            // 
            this.clnSequencial.HeaderText = "Sequencial";
            this.clnSequencial.Name = "clnSequencial";
            this.clnSequencial.ReadOnly = true;
            this.clnSequencial.Width = 70;
            // 
            // clnCodCliente
            // 
            this.clnCodCliente.HeaderText = "Cód. cliente";
            this.clnCodCliente.Name = "clnCodCliente";
            this.clnCodCliente.ReadOnly = true;
            this.clnCodCliente.Width = 90;
            // 
            // clnFilial
            // 
            this.clnFilial.HeaderText = "Filial";
            this.clnFilial.Name = "clnFilial";
            this.clnFilial.ReadOnly = true;
            this.clnFilial.Width = 45;
            // 
            // clnDocumento
            // 
            this.clnDocumento.HeaderText = "Documento";
            this.clnDocumento.Name = "clnDocumento";
            this.clnDocumento.Width = 75;
            // 
            // clnParcela
            // 
            this.clnParcela.HeaderText = "Parcela";
            this.clnParcela.Name = "clnParcela";
            this.clnParcela.ReadOnly = true;
            this.clnParcela.Width = 50;
            // 
            // clnCliente
            // 
            this.clnCliente.HeaderText = "Cliente";
            this.clnCliente.Name = "clnCliente";
            this.clnCliente.ReadOnly = true;
            // 
            // clnVencimento
            // 
            this.clnVencimento.HeaderText = "Vencimento";
            this.clnVencimento.Name = "clnVencimento";
            this.clnVencimento.ReadOnly = true;
            this.clnVencimento.Width = 75;
            // 
            // clnVlrParcela
            // 
            this.clnVlrParcela.HeaderText = "Vlr. parcela";
            this.clnVlrParcela.Name = "clnVlrParcela";
            this.clnVlrParcela.ReadOnly = true;
            this.clnVlrParcela.Width = 75;
            // 
            // clnVlrJuros
            // 
            this.clnVlrJuros.HeaderText = "Vlr. juros";
            this.clnVlrJuros.Name = "clnVlrJuros";
            this.clnVlrJuros.ReadOnly = true;
            this.clnVlrJuros.Width = 75;
            // 
            // clnVlrDescontos
            // 
            this.clnVlrDescontos.HeaderText = "Vlr. descontos";
            this.clnVlrDescontos.Name = "clnVlrDescontos";
            this.clnVlrDescontos.ReadOnly = true;
            this.clnVlrDescontos.Width = 75;
            // 
            // clnVlrPgto
            // 
            this.clnVlrPgto.HeaderText = "Vlr. pgto.";
            this.clnVlrPgto.Name = "clnVlrPgto";
            this.clnVlrPgto.ReadOnly = true;
            this.clnVlrPgto.Width = 75;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridNumerarios);
            this.groupBox3.Location = new System.Drawing.Point(12, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(872, 188);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Numerários";
            // 
            // gridNumerarios
            // 
            this.gridNumerarios.AllowUserToAddRows = false;
            this.gridNumerarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNumerarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnNumSequencial,
            this.clnNumIdNumerario,
            this.clnNumVlrNumerario,
            this.clnNumAdmCartao,
            this.clnNumBanco,
            this.clnNumAgencia,
            this.clnNumConta,
            this.clnNumCheque,
            this.clnNumCpfCnpj,
            this.clnNumDtNumerario});
            this.gridNumerarios.Location = new System.Drawing.Point(9, 19);
            this.gridNumerarios.Name = "gridNumerarios";
            this.gridNumerarios.Size = new System.Drawing.Size(853, 163);
            this.gridNumerarios.TabIndex = 1;
            // 
            // clnNumSequencial
            // 
            this.clnNumSequencial.HeaderText = "Sequencial";
            this.clnNumSequencial.Name = "clnNumSequencial";
            this.clnNumSequencial.ReadOnly = true;
            // 
            // clnNumIdNumerario
            // 
            this.clnNumIdNumerario.HeaderText = "Numerário";
            this.clnNumIdNumerario.Name = "clnNumIdNumerario";
            this.clnNumIdNumerario.ReadOnly = true;
            // 
            // clnNumVlrNumerario
            // 
            this.clnNumVlrNumerario.HeaderText = "Valor";
            this.clnNumVlrNumerario.Name = "clnNumVlrNumerario";
            this.clnNumVlrNumerario.ReadOnly = true;
            // 
            // clnNumAdmCartao
            // 
            this.clnNumAdmCartao.HeaderText = "Cartão";
            this.clnNumAdmCartao.Name = "clnNumAdmCartao";
            this.clnNumAdmCartao.ReadOnly = true;
            // 
            // clnNumBanco
            // 
            this.clnNumBanco.HeaderText = "Banco";
            this.clnNumBanco.Name = "clnNumBanco";
            this.clnNumBanco.ReadOnly = true;
            // 
            // clnNumAgencia
            // 
            this.clnNumAgencia.HeaderText = "Agência";
            this.clnNumAgencia.Name = "clnNumAgencia";
            this.clnNumAgencia.ReadOnly = true;
            // 
            // clnNumConta
            // 
            this.clnNumConta.HeaderText = "Conta";
            this.clnNumConta.Name = "clnNumConta";
            this.clnNumConta.ReadOnly = true;
            // 
            // clnNumCheque
            // 
            this.clnNumCheque.HeaderText = "Cheque";
            this.clnNumCheque.Name = "clnNumCheque";
            this.clnNumCheque.ReadOnly = true;
            // 
            // clnNumCpfCnpj
            // 
            this.clnNumCpfCnpj.HeaderText = "CPF/CNPJ";
            this.clnNumCpfCnpj.Name = "clnNumCpfCnpj";
            this.clnNumCpfCnpj.ReadOnly = true;
            // 
            // clnNumDtNumerario
            // 
            this.clnNumDtNumerario.HeaderText = "Cheque (bom para):";
            this.clnNumDtNumerario.Name = "clnNumDtNumerario";
            this.clnNumDtNumerario.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 471);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Parcelas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Juros:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 471);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Desconto:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Pagamento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(671, 471);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Recebido:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 471);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Troco:";
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(141, 487);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.ReadOnly = true;
            this.txtParcelas.Size = new System.Drawing.Size(85, 20);
            this.txtParcelas.TabIndex = 9;
            // 
            // txtJuros
            // 
            this.txtJuros.Location = new System.Drawing.Point(247, 487);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.ReadOnly = true;
            this.txtJuros.Size = new System.Drawing.Size(85, 20);
            this.txtJuros.TabIndex = 10;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(353, 487);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ReadOnly = true;
            this.txtDesconto.Size = new System.Drawing.Size(85, 20);
            this.txtDesconto.TabIndex = 11;
            // 
            // txtPagamento
            // 
            this.txtPagamento.Location = new System.Drawing.Point(459, 487);
            this.txtPagamento.Name = "txtPagamento";
            this.txtPagamento.ReadOnly = true;
            this.txtPagamento.Size = new System.Drawing.Size(85, 20);
            this.txtPagamento.TabIndex = 12;
            // 
            // txtTroco
            // 
            this.txtTroco.Location = new System.Drawing.Point(565, 487);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(85, 20);
            this.txtTroco.TabIndex = 13;
            // 
            // txtRecebido
            // 
            this.txtRecebido.Location = new System.Drawing.Point(671, 487);
            this.txtRecebido.Name = "txtRecebido";
            this.txtRecebido.ReadOnly = true;
            this.txtRecebido.Size = new System.Drawing.Size(85, 20);
            this.txtRecebido.TabIndex = 14;
            // 
            // frmConsultaRecebimentoLoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 523);
            this.Controls.Add(this.txtRecebido);
            this.Controls.Add(this.txtTroco);
            this.Controls.Add(this.txtPagamento);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtJuros);
            this.Controls.Add(this.txtParcelas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConsultaRecebimentoLoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Recebimento em Loja";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNumerarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCanceladoMotivo;
        private System.Windows.Forms.TextBox txtCancelado;
        private System.Windows.Forms.TextBox txtCriadoEm;
        private System.Windows.Forms.TextBox txtDataPgto;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtCaixa;
        private System.Windows.Forms.TextBox txtLoja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridParcelas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridNumerarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.TextBox txtPagamento;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.TextBox txtRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSequencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrJuros;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrDescontos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrPgto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumSequencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumIdNumerario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumVlrNumerario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumAdmCartao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumCpfCnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumDtNumerario;
    }
}