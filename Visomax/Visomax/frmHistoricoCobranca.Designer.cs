namespace Visomax
{
    partial class frmHistoricoCobranca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoricoCobranca));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridHistoricoCobranca = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDataExecucao = new System.Windows.Forms.TextBox();
            this.txtDataCriacao = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtBordero = new System.Windows.Forms.TextBox();
            this.txtAutomatico = new System.Windows.Forms.TextBox();
            this.txtPendente = new System.Windows.Forms.TextBox();
            this.txtPortador = new System.Windows.Forms.TextBox();
            this.txtCodigoCobranca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtUsuario2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtCriacao = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.RichTextBox();
            this.txtDataResposta = new System.Windows.Forms.TextBox();
            this.txtResposta = new System.Windows.Forms.TextBox();
            this.txtRespostaUm = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistoricoCobranca)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNomeCliente);
            this.groupBox1.Controls.Add(this.txtCodigoCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(203, 34);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.ReadOnly = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(252, 20);
            this.txtNomeCliente.TabIndex = 3;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(63, 34);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ReadOnly = true;
            this.txtCodigoCliente.Size = new System.Drawing.Size(73, 20);
            this.txtCodigoCliente.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // gridHistoricoCobranca
            // 
            this.gridHistoricoCobranca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistoricoCobranca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.gridHistoricoCobranca.Location = new System.Drawing.Point(12, 98);
            this.gridHistoricoCobranca.Name = "gridHistoricoCobranca";
            this.gridHistoricoCobranca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistoricoCobranca.Size = new System.Drawing.Size(531, 332);
            this.gridHistoricoCobranca.TabIndex = 1;
            this.gridHistoricoCobranca.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistoricoCobranca_CellContentClick);
            this.gridHistoricoCobranca.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistoricoCobranca_CellDoubleClick);
            // 
            // cod
            // 
            this.cod.HeaderText = "Cód. Cobrança";
            this.cod.Name = "cod";
            this.cod.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Filial";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Documento";
            this.Column2.Name = "Column2";
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Parcela/Cheque";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ação de Cobrança";
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Data";
            this.Column5.Name = "Column5";
            this.Column5.Width = 75;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(549, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 421);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtDataExecucao);
            this.tabPage1.Controls.Add(this.txtDataCriacao);
            this.tabPage1.Controls.Add(this.txtUsuario);
            this.tabPage1.Controls.Add(this.txtBordero);
            this.tabPage1.Controls.Add(this.txtAutomatico);
            this.tabPage1.Controls.Add(this.txtPendente);
            this.tabPage1.Controls.Add(this.txtPortador);
            this.tabPage1.Controls.Add(this.txtCodigoCobranca);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cobrança";
            // 
            // txtDataExecucao
            // 
            this.txtDataExecucao.Location = new System.Drawing.Point(22, 320);
            this.txtDataExecucao.Name = "txtDataExecucao";
            this.txtDataExecucao.ReadOnly = true;
            this.txtDataExecucao.Size = new System.Drawing.Size(213, 20);
            this.txtDataExecucao.TabIndex = 15;
            // 
            // txtDataCriacao
            // 
            this.txtDataCriacao.Location = new System.Drawing.Point(22, 263);
            this.txtDataCriacao.Name = "txtDataCriacao";
            this.txtDataCriacao.ReadOnly = true;
            this.txtDataCriacao.Size = new System.Drawing.Size(213, 20);
            this.txtDataCriacao.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(22, 207);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(213, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // txtBordero
            // 
            this.txtBordero.Location = new System.Drawing.Point(265, 150);
            this.txtBordero.Name = "txtBordero";
            this.txtBordero.ReadOnly = true;
            this.txtBordero.Size = new System.Drawing.Size(76, 20);
            this.txtBordero.TabIndex = 12;
            // 
            // txtAutomatico
            // 
            this.txtAutomatico.Location = new System.Drawing.Point(137, 150);
            this.txtAutomatico.Name = "txtAutomatico";
            this.txtAutomatico.ReadOnly = true;
            this.txtAutomatico.Size = new System.Drawing.Size(87, 20);
            this.txtAutomatico.TabIndex = 11;
            // 
            // txtPendente
            // 
            this.txtPendente.Location = new System.Drawing.Point(22, 150);
            this.txtPendente.Name = "txtPendente";
            this.txtPendente.ReadOnly = true;
            this.txtPendente.Size = new System.Drawing.Size(76, 20);
            this.txtPendente.TabIndex = 10;
            // 
            // txtPortador
            // 
            this.txtPortador.Location = new System.Drawing.Point(22, 93);
            this.txtPortador.Name = "txtPortador";
            this.txtPortador.ReadOnly = true;
            this.txtPortador.Size = new System.Drawing.Size(319, 20);
            this.txtPortador.TabIndex = 9;
            // 
            // txtCodigoCobranca
            // 
            this.txtCodigoCobranca.Location = new System.Drawing.Point(22, 36);
            this.txtCodigoCobranca.Name = "txtCodigoCobranca";
            this.txtCodigoCobranca.ReadOnly = true;
            this.txtCodigoCobranca.Size = new System.Drawing.Size(76, 20);
            this.txtCodigoCobranca.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Data da execução:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Data da criação:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Usuário:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Borderô:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Automático:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pendente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Portador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cód. cobrança:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.txtUsuario2);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.btnAlterar);
            this.tabPage2.Controls.Add(this.txtCriacao);
            this.tabPage2.Controls.Add(this.txtObservacao);
            this.tabPage2.Controls.Add(this.txtDataResposta);
            this.tabPage2.Controls.Add(this.txtResposta);
            this.tabPage2.Controls.Add(this.txtRespostaUm);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resposta";
            // 
            // txtUsuario2
            // 
            this.txtUsuario2.Location = new System.Drawing.Point(21, 369);
            this.txtUsuario2.Name = "txtUsuario2";
            this.txtUsuario2.ReadOnly = true;
            this.txtUsuario2.Size = new System.Drawing.Size(213, 20);
            this.txtUsuario2.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 350);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Usuário:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(239, 39);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(100, 30);
            this.btnAlterar.TabIndex = 13;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtCriacao
            // 
            this.txtCriacao.Location = new System.Drawing.Point(21, 320);
            this.txtCriacao.Name = "txtCriacao";
            this.txtCriacao.ReadOnly = true;
            this.txtCriacao.Size = new System.Drawing.Size(196, 20);
            this.txtCriacao.TabIndex = 12;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(21, 167);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ReadOnly = true;
            this.txtObservacao.Size = new System.Drawing.Size(318, 113);
            this.txtObservacao.TabIndex = 11;
            this.txtObservacao.Text = "";
            // 
            // txtDataResposta
            // 
            this.txtDataResposta.Location = new System.Drawing.Point(208, 108);
            this.txtDataResposta.Name = "txtDataResposta";
            this.txtDataResposta.ReadOnly = true;
            this.txtDataResposta.Size = new System.Drawing.Size(134, 20);
            this.txtDataResposta.TabIndex = 10;
            // 
            // txtResposta
            // 
            this.txtResposta.Location = new System.Drawing.Point(21, 108);
            this.txtResposta.Name = "txtResposta";
            this.txtResposta.ReadOnly = true;
            this.txtResposta.Size = new System.Drawing.Size(162, 20);
            this.txtResposta.TabIndex = 9;
            // 
            // txtRespostaUm
            // 
            this.txtRespostaUm.Location = new System.Drawing.Point(21, 45);
            this.txtRespostaUm.Name = "txtRespostaUm";
            this.txtRespostaUm.ReadOnly = true;
            this.txtRespostaUm.Size = new System.Drawing.Size(46, 20);
            this.txtRespostaUm.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Criação:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Observação:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(208, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Data:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Resposta:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Resposta:";
            // 
            // frmHistoricoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 436);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gridHistoricoCobranca);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistoricoCobranca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de Cobrança";
            this.Load += new System.EventHandler(this.frmHistoricoCobranca_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistoricoCobranca)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridHistoricoCobranca;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBordero;
        private System.Windows.Forms.TextBox txtAutomatico;
        private System.Windows.Forms.TextBox txtPendente;
        private System.Windows.Forms.TextBox txtPortador;
        private System.Windows.Forms.TextBox txtCodigoCobranca;
        private System.Windows.Forms.TextBox txtDataExecucao;
        private System.Windows.Forms.TextBox txtDataCriacao;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRespostaUm;
        private System.Windows.Forms.TextBox txtDataResposta;
        private System.Windows.Forms.TextBox txtResposta;
        private System.Windows.Forms.TextBox txtCriacao;
        private System.Windows.Forms.RichTextBox txtObservacao;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox txtUsuario2;
        private System.Windows.Forms.Label label16;
    }
}