namespace Visomax
{
    partial class frmConsultaParcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaParcelas));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbdata = new System.Windows.Forms.CheckBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlanilha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.txtAberto = new System.Windows.Forms.TextBox();
            this.txtRecebido = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(986, 189);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Filial";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Documento";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Parc./Cheque";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Código";
            this.Column4.Name = "Column4";
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cliente";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Emissão";
            this.Column6.Name = "Column6";
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Venc.";
            this.Column7.Name = "Column7";
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Vlr. Parcela";
            this.Column8.Name = "Column8";
            this.Column8.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Pagamento";
            this.Column9.Name = "Column9";
            this.Column9.Width = 75;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Valor Pagamento";
            this.Column10.Name = "Column10";
            this.Column10.Width = 90;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Parcelamento";
            this.Column11.Name = "Column11";
            this.Column11.Width = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbdata);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPlanilha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFilial);
            this.groupBox1.Controls.Add(this.cmbFilial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar parcelas";
            // 
            // chbdata
            // 
            this.chbdata.AutoSize = true;
            this.chbdata.Location = new System.Drawing.Point(594, 72);
            this.chbdata.Name = "chbdata";
            this.chbdata.Size = new System.Drawing.Size(82, 17);
            this.chbdata.TabIndex = 10;
            this.chbdata.Text = "Liberar data";
            this.chbdata.UseVisualStyleBackColor = true;
            // 
            // dtpData
            // 
            this.dtpData.Enabled = false;
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(594, 46);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(101, 20);
            this.dtpData.TabIndex = 9;
            this.dtpData.Value = new System.DateTime(2014, 4, 11, 0, 0, 0, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(815, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 30);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data da emissão:";
            // 
            // txtPlanilha
            // 
            this.txtPlanilha.Location = new System.Drawing.Point(325, 63);
            this.txtPlanilha.Name = "txtPlanilha";
            this.txtPlanilha.Size = new System.Drawing.Size(100, 20);
            this.txtPlanilha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Planilha:";
            // 
            // txtFilial
            // 
            this.txtFilial.Enabled = false;
            this.txtFilial.Location = new System.Drawing.Point(135, 63);
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.Size = new System.Drawing.Size(121, 20);
            this.txtFilial.TabIndex = 4;
            // 
            // cmbFilial
            // 
            this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(61, 63);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(68, 21);
            this.cmbFilial.TabIndex = 3;
            this.cmbFilial.SelectedIndexChanged += new System.EventHandler(this.cmbFilial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filial:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(61, 26);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(364, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quantidade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Vlr. total de parcelas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Vlr. total aberto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Vlr. total recebido:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Location = new System.Drawing.Point(96, 333);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(57, 20);
            this.txtQuantidade.TabIndex = 8;
            this.txtQuantidade.Text = "0";
            // 
            // txtParcelas
            // 
            this.txtParcelas.Enabled = false;
            this.txtParcelas.Location = new System.Drawing.Point(280, 333);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(94, 20);
            this.txtParcelas.TabIndex = 11;
            this.txtParcelas.Text = "0,00";
            // 
            // txtAberto
            // 
            this.txtAberto.Enabled = false;
            this.txtAberto.Location = new System.Drawing.Point(470, 333);
            this.txtAberto.Name = "txtAberto";
            this.txtAberto.Size = new System.Drawing.Size(94, 20);
            this.txtAberto.TabIndex = 12;
            this.txtAberto.Text = "0,00";
            // 
            // txtRecebido
            // 
            this.txtRecebido.Enabled = false;
            this.txtRecebido.Location = new System.Drawing.Point(679, 333);
            this.txtRecebido.Name = "txtRecebido";
            this.txtRecebido.Size = new System.Drawing.Size(94, 20);
            this.txtRecebido.TabIndex = 13;
            this.txtRecebido.Text = "0,00";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(448, 379);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(114, 32);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmConsultaParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 426);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtRecebido);
            this.Controls.Add(this.txtAberto);
            this.Controls.Add(this.txtParcelas);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaParcelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Parcelas";
            this.Load += new System.EventHandler(this.frmConsultaParcelas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlanilha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.TextBox txtAberto;
        private System.Windows.Forms.TextBox txtRecebido;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.CheckBox chbdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}