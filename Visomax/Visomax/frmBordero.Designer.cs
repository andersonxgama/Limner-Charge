namespace Visomax
{
    partial class frmBordero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBordero));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarBordero = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtQtdeDocumentos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBordero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAcaoCobranca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeCobradora = new System.Windows.Forms.TextBox();
            this.txtNumeroCobradora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridBordero = new System.Windows.Forms.DataGridView();
            this.clnFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBordero)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarBordero);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.txtQtdeDocumentos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBordero);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAcaoCobranca);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNomeCobradora);
            this.groupBox1.Controls.Add(this.txtNumeroCobradora);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações:";
            // 
            // btnBuscarBordero
            // 
            this.btnBuscarBordero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarBordero.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarBordero.Image")));
            this.btnBuscarBordero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarBordero.Location = new System.Drawing.Point(319, 97);
            this.btnBuscarBordero.Name = "btnBuscarBordero";
            this.btnBuscarBordero.Size = new System.Drawing.Size(125, 30);
            this.btnBuscarBordero.TabIndex = 12;
            this.btnBuscarBordero.Text = "&Buscar Borderô";
            this.btnBuscarBordero.UseVisualStyleBackColor = true;
            this.btnBuscarBordero.Click += new System.EventHandler(this.btnBuscarBordero_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(293, 27);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 11;
            // 
            // txtQtdeDocumentos
            // 
            this.txtQtdeDocumentos.Location = new System.Drawing.Point(401, 64);
            this.txtQtdeDocumentos.Name = "txtQtdeDocumentos";
            this.txtQtdeDocumentos.ReadOnly = true;
            this.txtQtdeDocumentos.Size = new System.Drawing.Size(76, 20);
            this.txtQtdeDocumentos.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantidade de documentos:";
            // 
            // txtBordero
            // 
            this.txtBordero.Location = new System.Drawing.Point(69, 100);
            this.txtBordero.Name = "txtBordero";
            this.txtBordero.ReadOnly = true;
            this.txtBordero.Size = new System.Drawing.Size(168, 20);
            this.txtBordero.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Borderô:";
            // 
            // txtAcaoCobranca
            // 
            this.txtAcaoCobranca.Location = new System.Drawing.Point(120, 64);
            this.txtAcaoCobranca.Name = "txtAcaoCobranca";
            this.txtAcaoCobranca.ReadOnly = true;
            this.txtAcaoCobranca.Size = new System.Drawing.Size(117, 20);
            this.txtAcaoCobranca.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ação de cobrança:";
            // 
            // txtNomeCobradora
            // 
            this.txtNomeCobradora.Location = new System.Drawing.Point(122, 27);
            this.txtNomeCobradora.Name = "txtNomeCobradora";
            this.txtNomeCobradora.ReadOnly = true;
            this.txtNomeCobradora.Size = new System.Drawing.Size(115, 20);
            this.txtNomeCobradora.TabIndex = 4;
            // 
            // txtNumeroCobradora
            // 
            this.txtNumeroCobradora.Location = new System.Drawing.Point(81, 27);
            this.txtNumeroCobradora.Name = "txtNumeroCobradora";
            this.txtNumeroCobradora.ReadOnly = true;
            this.txtNumeroCobradora.Size = new System.Drawing.Size(37, 20);
            this.txtNumeroCobradora.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cobradora:";
            // 
            // gridBordero
            // 
            this.gridBordero.AllowUserToAddRows = false;
            this.gridBordero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBordero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnFilial,
            this.clnDocumento,
            this.clnCodigo,
            this.clnCliente});
            this.gridBordero.Location = new System.Drawing.Point(12, 160);
            this.gridBordero.Name = "gridBordero";
            this.gridBordero.Size = new System.Drawing.Size(538, 192);
            this.gridBordero.TabIndex = 1;
            // 
            // clnFilial
            // 
            this.clnFilial.HeaderText = "Filial";
            this.clnFilial.Name = "clnFilial";
            this.clnFilial.ReadOnly = true;
            this.clnFilial.Width = 40;
            // 
            // clnDocumento
            // 
            this.clnDocumento.HeaderText = "Documento";
            this.clnDocumento.Name = "clnDocumento";
            this.clnDocumento.ReadOnly = true;
            this.clnDocumento.Width = 75;
            // 
            // clnCodigo
            // 
            this.clnCodigo.HeaderText = "Código";
            this.clnCodigo.Name = "clnCodigo";
            this.clnCodigo.ReadOnly = true;
            this.clnCodigo.Width = 65;
            // 
            // clnCliente
            // 
            this.clnCliente.HeaderText = "Cliente";
            this.clnCliente.Name = "clnCliente";
            this.clnCliente.ReadOnly = true;
            this.clnCliente.Width = 295;
            // 
            // frmBordero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 371);
            this.Controls.Add(this.gridBordero);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBordero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borderô";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBordero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCobradora;
        private System.Windows.Forms.TextBox txtNumeroCobradora;
        private System.Windows.Forms.TextBox txtQtdeDocumentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBordero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAcaoCobranca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridBordero;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnBuscarBordero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCliente;
    }
}