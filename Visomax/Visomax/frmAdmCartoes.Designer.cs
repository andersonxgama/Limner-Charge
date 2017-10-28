namespace Visomax
{
    partial class frmAdmCartoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmCartoes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optRedecard = new System.Windows.Forms.RadioButton();
            this.optCielo = new System.Windows.Forms.RadioButton();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridCielo = new System.Windows.Forms.DataGridView();
            this.cln1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.gridRedecard = new System.Windows.Forms.DataGridView();
            this.clnNumEstabelecimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDataVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDataRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPrazoRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnResumoVendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQtdeVendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBandeiraRedeCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVlrLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCielo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRedecard)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optRedecard);
            this.groupBox1.Controls.Add(this.optCielo);
            this.groupBox1.Controls.Add(this.btnImportar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(265, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Envio de documento";
            // 
            // optRedecard
            // 
            this.optRedecard.AutoSize = true;
            this.optRedecard.Location = new System.Drawing.Point(301, 22);
            this.optRedecard.Name = "optRedecard";
            this.optRedecard.Size = new System.Drawing.Size(72, 17);
            this.optRedecard.TabIndex = 5;
            this.optRedecard.TabStop = true;
            this.optRedecard.Text = "Redecard";
            this.optRedecard.UseVisualStyleBackColor = true;
            this.optRedecard.Click += new System.EventHandler(this.optRedecard_Click);
            // 
            // optCielo
            // 
            this.optCielo.AutoSize = true;
            this.optCielo.Location = new System.Drawing.Point(151, 22);
            this.optCielo.Name = "optCielo";
            this.optCielo.Size = new System.Drawing.Size(48, 17);
            this.optCielo.TabIndex = 4;
            this.optCielo.TabStop = true;
            this.optCielo.Text = "Cielo";
            this.optCielo.UseVisualStyleBackColor = true;
            this.optCielo.Click += new System.EventHandler(this.optCielo_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(209, 91);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(106, 38);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "&Importar dados";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(464, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 36);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(95, 56);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(354, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento:";
            // 
            // gridCielo
            // 
            this.gridCielo.AllowUserToAddRows = false;
            this.gridCielo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCielo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cln1,
            this.cln2,
            this.cln3,
            this.cln4,
            this.cln5,
            this.cln6,
            this.cln7,
            this.cln8,
            this.cln9,
            this.cln10});
            this.gridCielo.Location = new System.Drawing.Point(12, 161);
            this.gridCielo.Name = "gridCielo";
            this.gridCielo.Size = new System.Drawing.Size(1029, 267);
            this.gridCielo.TabIndex = 1;
            // 
            // cln1
            // 
            this.cln1.HeaderText = "Data da venda";
            this.cln1.Name = "cln1";
            this.cln1.ReadOnly = true;
            this.cln1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln1.Width = 90;
            // 
            // cln2
            // 
            this.cln2.HeaderText = "Data efetiva de pgto.";
            this.cln2.Name = "cln2";
            this.cln2.ReadOnly = true;
            this.cln2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln2.Width = 90;
            // 
            // cln3
            // 
            this.cln3.HeaderText = "Descrição";
            this.cln3.Name = "cln3";
            this.cln3.ReadOnly = true;
            this.cln3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln3.Width = 150;
            // 
            // cln4
            // 
            this.cln4.HeaderText = "Resumo";
            this.cln4.Name = "cln4";
            this.cln4.ReadOnly = true;
            this.cln4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln4.Width = 90;
            // 
            // cln5
            // 
            this.cln5.HeaderText = "N° do cartão/TID";
            this.cln5.Name = "cln5";
            this.cln5.ReadOnly = true;
            this.cln5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln5.Width = 120;
            // 
            // cln6
            // 
            this.cln6.HeaderText = "NSU/DOC";
            this.cln6.Name = "cln6";
            this.cln6.ReadOnly = true;
            this.cln6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cln7
            // 
            this.cln7.HeaderText = "Código autorização";
            this.cln7.Name = "cln7";
            this.cln7.ReadOnly = true;
            this.cln7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cln8
            // 
            this.cln8.HeaderText = "Valor bruto";
            this.cln8.Name = "cln8";
            this.cln8.ReadOnly = true;
            this.cln8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln8.Width = 75;
            // 
            // cln9
            // 
            this.cln9.HeaderText = "Rejeitado";
            this.cln9.Name = "cln9";
            this.cln9.ReadOnly = true;
            this.cln9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln9.Width = 75;
            // 
            // cln10
            // 
            this.cln10.HeaderText = "Valor do saque";
            this.cln10.Name = "cln10";
            this.cln10.ReadOnly = true;
            this.cln10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cln10.Width = 80;
            // 
            // btnGravar
            // 
            this.btnGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGravar.Image = ((System.Drawing.Image)(resources.GetObject("btnGravar.Image")));
            this.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravar.Location = new System.Drawing.Point(334, 445);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(133, 35);
            this.btnGravar.TabIndex = 2;
            this.btnGravar.Text = "&Salvar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(588, 445);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(133, 35);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // gridRedecard
            // 
            this.gridRedecard.AllowUserToAddRows = false;
            this.gridRedecard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRedecard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnNumEstabelecimento,
            this.clnDataVenda,
            this.clnDataRecebimento,
            this.clnPrazoRecebimento,
            this.clnResumoVendas,
            this.clnQtdeVendas,
            this.clnBandeiraRedeCard,
            this.clnVlrBruto,
            this.clnVlrLiquido});
            this.gridRedecard.Location = new System.Drawing.Point(12, 161);
            this.gridRedecard.Name = "gridRedecard";
            this.gridRedecard.Size = new System.Drawing.Size(1029, 267);
            this.gridRedecard.TabIndex = 4;
            // 
            // clnNumEstabelecimento
            // 
            this.clnNumEstabelecimento.HeaderText = "Nº do Estabelec.";
            this.clnNumEstabelecimento.Name = "clnNumEstabelecimento";
            this.clnNumEstabelecimento.ReadOnly = true;
            this.clnNumEstabelecimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnNumEstabelecimento.Width = 125;
            // 
            // clnDataVenda
            // 
            this.clnDataVenda.HeaderText = "Data da Venda";
            this.clnDataVenda.Name = "clnDataVenda";
            this.clnDataVenda.ReadOnly = true;
            this.clnDataVenda.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clnDataRecebimento
            // 
            this.clnDataRecebimento.HeaderText = "Data de Receb.";
            this.clnDataRecebimento.Name = "clnDataRecebimento";
            this.clnDataRecebimento.ReadOnly = true;
            this.clnDataRecebimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clnPrazoRecebimento
            // 
            this.clnPrazoRecebimento.HeaderText = "Prazo de Receb.";
            this.clnPrazoRecebimento.Name = "clnPrazoRecebimento";
            this.clnPrazoRecebimento.ReadOnly = true;
            this.clnPrazoRecebimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clnResumoVendas
            // 
            this.clnResumoVendas.HeaderText = "Resumo de Vendas";
            this.clnResumoVendas.Name = "clnResumoVendas";
            this.clnResumoVendas.ReadOnly = true;
            this.clnResumoVendas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnResumoVendas.Width = 125;
            // 
            // clnQtdeVendas
            // 
            this.clnQtdeVendas.HeaderText = "Quantidade de Vendas";
            this.clnQtdeVendas.Name = "clnQtdeVendas";
            this.clnQtdeVendas.ReadOnly = true;
            this.clnQtdeVendas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnQtdeVendas.Width = 92;
            // 
            // clnBandeiraRedeCard
            // 
            this.clnBandeiraRedeCard.HeaderText = "Bandeira";
            this.clnBandeiraRedeCard.Name = "clnBandeiraRedeCard";
            this.clnBandeiraRedeCard.ReadOnly = true;
            this.clnBandeiraRedeCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clnBandeiraRedeCard.Width = 125;
            // 
            // clnVlrBruto
            // 
            this.clnVlrBruto.HeaderText = "Valor Bruto (R$)";
            this.clnVlrBruto.Name = "clnVlrBruto";
            this.clnVlrBruto.ReadOnly = true;
            this.clnVlrBruto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clnVlrLiquido
            // 
            this.clnVlrLiquido.HeaderText = "Valor Líquido (R$)";
            this.clnVlrLiquido.Name = "clnVlrLiquido";
            this.clnVlrLiquido.ReadOnly = true;
            this.clnVlrLiquido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmAdmCartoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 492);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridCielo);
            this.Controls.Add(this.gridRedecard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdmCartoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administração de Cartões";
            this.Load += new System.EventHandler(this.frmAdmCartoes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCielo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRedecard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridCielo;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.RadioButton optRedecard;
        private System.Windows.Forms.RadioButton optCielo;
        private System.Windows.Forms.DataGridView gridRedecard;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln8;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln9;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumEstabelecimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDataVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDataRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrazoRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnResumoVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQtdeVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBandeiraRedeCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVlrLiquido;
    }
}