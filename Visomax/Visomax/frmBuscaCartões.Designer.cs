namespace Visomax
{
    partial class frmBuscaCartões
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaCartões));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gridBuscaCartoes = new System.Windows.Forms.DataGridView();
            this.Filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autorizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEfetiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rejeitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscaCartoes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dtDataFinal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtDataInicial);
            this.groupBox1.Location = new System.Drawing.Point(259, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(238, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtDataFinal
            // 
            this.dtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataFinal.Location = new System.Drawing.Point(137, 32);
            this.dtDataFinal.Name = "dtDataFinal";
            this.dtDataFinal.Size = new System.Drawing.Size(79, 20);
            this.dtDataFinal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "/";
            // 
            // dtDataInicial
            // 
            this.dtDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataInicial.Location = new System.Drawing.Point(34, 32);
            this.dtDataInicial.Name = "dtDataInicial";
            this.dtDataInicial.Size = new System.Drawing.Size(79, 20);
            this.dtDataInicial.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(393, 365);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 35);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gridBuscaCartoes
            // 
            this.gridBuscaCartoes.AllowUserToAddRows = false;
            this.gridBuscaCartoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBuscaCartoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filial,
            this.Sequencia,
            this.Autorizacao,
            this.Venda,
            this.DataEfetiva,
            this.Descricao,
            this.ValorBruto,
            this.Rejeitado});
            this.gridBuscaCartoes.Location = new System.Drawing.Point(14, 133);
            this.gridBuscaCartoes.Name = "gridBuscaCartoes";
            this.gridBuscaCartoes.Size = new System.Drawing.Size(858, 205);
            this.gridBuscaCartoes.TabIndex = 7;
            this.gridBuscaCartoes.DoubleClick += new System.EventHandler(this.gridBuscaCartoes_DoubleClick);
            // 
            // Filial
            // 
            this.Filial.HeaderText = "Filial";
            this.Filial.Name = "Filial";
            this.Filial.ReadOnly = true;
            this.Filial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Filial.Width = 90;
            // 
            // Sequencia
            // 
            this.Sequencia.HeaderText = "Sequência";
            this.Sequencia.Name = "Sequencia";
            this.Sequencia.ReadOnly = true;
            this.Sequencia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sequencia.Width = 90;
            // 
            // Autorizacao
            // 
            this.Autorizacao.HeaderText = "Autorização";
            this.Autorizacao.Name = "Autorizacao";
            this.Autorizacao.ReadOnly = true;
            this.Autorizacao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Autorizacao.Width = 80;
            // 
            // Venda
            // 
            this.Venda.HeaderText = "Data da Venda";
            this.Venda.Name = "Venda";
            this.Venda.ReadOnly = true;
            this.Venda.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Venda.Width = 80;
            // 
            // DataEfetiva
            // 
            this.DataEfetiva.HeaderText = "Data Efetiva";
            this.DataEfetiva.Name = "DataEfetiva";
            this.DataEfetiva.ReadOnly = true;
            this.DataEfetiva.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataEfetiva.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Descricao.Width = 215;
            // 
            // ValorBruto
            // 
            this.ValorBruto.HeaderText = "Valor Bruto";
            this.ValorBruto.Name = "ValorBruto";
            this.ValorBruto.ReadOnly = true;
            this.ValorBruto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorBruto.Width = 80;
            // 
            // Rejeitado
            // 
            this.Rejeitado.HeaderText = "Rejeitado";
            this.Rejeitado.Name = "Rejeitado";
            this.Rejeitado.ReadOnly = true;
            this.Rejeitado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rejeitado.Width = 80;
            // 
            // lblAguarde
            // 
            this.lblAguarde.AutoSize = true;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.ForeColor = System.Drawing.Color.Red;
            this.lblAguarde.Location = new System.Drawing.Point(322, 100);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(243, 17);
            this.lblAguarde.TabIndex = 8;
            this.lblAguarde.Text = "Carregando os dados...aguarde!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(652, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total (valor bruto):";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(747, 368);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(86, 20);
            this.txtTotal.TabIndex = 10;
            // 
            // frmBuscaCartões
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 415);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAguarde);
            this.Controls.Add(this.gridBuscaCartoes);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaCartões";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca de Cartões";
            this.Load += new System.EventHandler(this.frmBuscaCartões_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscaCartoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtDataFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDataInicial;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView gridBuscaCartoes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblAguarde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autorizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEfetiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rejeitado;
    }
}