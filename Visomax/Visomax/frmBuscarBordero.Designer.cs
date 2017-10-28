namespace Visomax
{
    partial class frmBuscarBordero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarBordero));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkData = new System.Windows.Forms.CheckBox();
            this.chkBordero = new System.Windows.Forms.CheckBox();
            this.chkCobradora = new System.Windows.Forms.CheckBox();
            this.chkRetornoCobradora = new System.Windows.Forms.CheckBox();
            this.dataDeBordero = new System.Windows.Forms.DateTimePicker();
            this.chkEnvioCobradora = new System.Windows.Forms.CheckBox();
            this.lblCobradora = new System.Windows.Forms.Label();
            this.lblDataAte = new System.Windows.Forms.Label();
            this.lblDataDe = new System.Windows.Forms.Label();
            this.cmbCobradoras = new System.Windows.Forms.ComboBox();
            this.dataAteBordero = new System.Windows.Forms.DateTimePicker();
            this.txtBorderoDe = new System.Windows.Forms.TextBox();
            this.lblBorderoDe = new System.Windows.Forms.Label();
            this.lblBorderoAte = new System.Windows.Forms.Label();
            this.txtBorderoAte = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grdBuscaBordero = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuscaBordero)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkData);
            this.groupBox1.Controls.Add(this.chkBordero);
            this.groupBox1.Controls.Add(this.chkCobradora);
            this.groupBox1.Controls.Add(this.chkRetornoCobradora);
            this.groupBox1.Controls.Add(this.dataDeBordero);
            this.groupBox1.Controls.Add(this.chkEnvioCobradora);
            this.groupBox1.Controls.Add(this.lblCobradora);
            this.groupBox1.Controls.Add(this.lblDataAte);
            this.groupBox1.Controls.Add(this.lblDataDe);
            this.groupBox1.Controls.Add(this.cmbCobradoras);
            this.groupBox1.Controls.Add(this.dataAteBordero);
            this.groupBox1.Controls.Add(this.txtBorderoDe);
            this.groupBox1.Controls.Add(this.lblBorderoDe);
            this.groupBox1.Controls.Add(this.lblBorderoAte);
            this.groupBox1.Controls.Add(this.txtBorderoAte);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos de Busca";
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.Location = new System.Drawing.Point(360, 35);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(15, 14);
            this.chkData.TabIndex = 14;
            this.chkData.UseVisualStyleBackColor = true;
            this.chkData.Click += new System.EventHandler(this.chkData_Click);
            // 
            // chkBordero
            // 
            this.chkBordero.AutoSize = true;
            this.chkBordero.Location = new System.Drawing.Point(17, 78);
            this.chkBordero.Name = "chkBordero";
            this.chkBordero.Size = new System.Drawing.Size(15, 14);
            this.chkBordero.TabIndex = 13;
            this.chkBordero.UseVisualStyleBackColor = true;
            this.chkBordero.Click += new System.EventHandler(this.chkBordero_Click);
            // 
            // chkCobradora
            // 
            this.chkCobradora.AutoSize = true;
            this.chkCobradora.Location = new System.Drawing.Point(17, 35);
            this.chkCobradora.Name = "chkCobradora";
            this.chkCobradora.Size = new System.Drawing.Size(15, 14);
            this.chkCobradora.TabIndex = 12;
            this.chkCobradora.UseVisualStyleBackColor = true;
            this.chkCobradora.Click += new System.EventHandler(this.chkCobradora_Click);
            // 
            // chkRetornoCobradora
            // 
            this.chkRetornoCobradora.AutoSize = true;
            this.chkRetornoCobradora.Location = new System.Drawing.Point(522, 77);
            this.chkRetornoCobradora.Name = "chkRetornoCobradora";
            this.chkRetornoCobradora.Size = new System.Drawing.Size(124, 17);
            this.chkRetornoCobradora.TabIndex = 11;
            this.chkRetornoCobradora.Text = "Retorno a cobradora";
            this.chkRetornoCobradora.UseVisualStyleBackColor = true;
            // 
            // dataDeBordero
            // 
            this.dataDeBordero.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDeBordero.Location = new System.Drawing.Point(441, 32);
            this.dataDeBordero.Name = "dataDeBordero";
            this.dataDeBordero.Size = new System.Drawing.Size(106, 20);
            this.dataDeBordero.TabIndex = 7;
            // 
            // chkEnvioCobradora
            // 
            this.chkEnvioCobradora.AutoSize = true;
            this.chkEnvioCobradora.Location = new System.Drawing.Point(391, 77);
            this.chkEnvioCobradora.Name = "chkEnvioCobradora";
            this.chkEnvioCobradora.Size = new System.Drawing.Size(113, 17);
            this.chkEnvioCobradora.TabIndex = 10;
            this.chkEnvioCobradora.Text = "Envio a cobradora";
            this.chkEnvioCobradora.UseVisualStyleBackColor = true;
            // 
            // lblCobradora
            // 
            this.lblCobradora.AutoSize = true;
            this.lblCobradora.Location = new System.Drawing.Point(42, 36);
            this.lblCobradora.Name = "lblCobradora";
            this.lblCobradora.Size = new System.Drawing.Size(59, 13);
            this.lblCobradora.TabIndex = 0;
            this.lblCobradora.Text = "Cobradora:";
            // 
            // lblDataAte
            // 
            this.lblDataAte.AutoSize = true;
            this.lblDataAte.Location = new System.Drawing.Point(550, 36);
            this.lblDataAte.Name = "lblDataAte";
            this.lblDataAte.Size = new System.Drawing.Size(22, 13);
            this.lblDataAte.TabIndex = 9;
            this.lblDataAte.Text = "até";
            // 
            // lblDataDe
            // 
            this.lblDataDe.AutoSize = true;
            this.lblDataDe.Location = new System.Drawing.Point(391, 36);
            this.lblDataDe.Name = "lblDataDe";
            this.lblDataDe.Size = new System.Drawing.Size(48, 13);
            this.lblDataDe.TabIndex = 6;
            this.lblDataDe.Text = "Data de:";
            // 
            // cmbCobradoras
            // 
            this.cmbCobradoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCobradoras.FormattingEnabled = true;
            this.cmbCobradoras.Location = new System.Drawing.Point(104, 32);
            this.cmbCobradoras.Name = "cmbCobradoras";
            this.cmbCobradoras.Size = new System.Drawing.Size(153, 21);
            this.cmbCobradoras.TabIndex = 1;
            // 
            // dataAteBordero
            // 
            this.dataAteBordero.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataAteBordero.Location = new System.Drawing.Point(575, 32);
            this.dataAteBordero.Name = "dataAteBordero";
            this.dataAteBordero.Size = new System.Drawing.Size(106, 20);
            this.dataAteBordero.TabIndex = 8;
            // 
            // txtBorderoDe
            // 
            this.txtBorderoDe.Location = new System.Drawing.Point(106, 75);
            this.txtBorderoDe.Name = "txtBorderoDe";
            this.txtBorderoDe.Size = new System.Drawing.Size(63, 20);
            this.txtBorderoDe.TabIndex = 4;
            // 
            // lblBorderoDe
            // 
            this.lblBorderoDe.AutoSize = true;
            this.lblBorderoDe.Location = new System.Drawing.Point(42, 79);
            this.lblBorderoDe.Name = "lblBorderoDe";
            this.lblBorderoDe.Size = new System.Drawing.Size(62, 13);
            this.lblBorderoDe.TabIndex = 2;
            this.lblBorderoDe.Text = "Borderô de:";
            // 
            // lblBorderoAte
            // 
            this.lblBorderoAte.AutoSize = true;
            this.lblBorderoAte.Location = new System.Drawing.Point(170, 79);
            this.lblBorderoAte.Name = "lblBorderoAte";
            this.lblBorderoAte.Size = new System.Drawing.Size(22, 13);
            this.lblBorderoAte.TabIndex = 3;
            this.lblBorderoAte.Text = "até";
            // 
            // txtBorderoAte
            // 
            this.txtBorderoAte.Location = new System.Drawing.Point(194, 75);
            this.txtBorderoAte.Name = "txtBorderoAte";
            this.txtBorderoAte.Size = new System.Drawing.Size(63, 20);
            this.txtBorderoAte.TabIndex = 5;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(445, 147);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(212, 147);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdBuscaBordero
            // 
            this.grdBuscaBordero.AllowUserToAddRows = false;
            this.grdBuscaBordero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBuscaBordero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grdBuscaBordero.Location = new System.Drawing.Point(12, 195);
            this.grdBuscaBordero.Name = "grdBuscaBordero";
            this.grdBuscaBordero.Size = new System.Drawing.Size(732, 206);
            this.grdBuscaBordero.TabIndex = 1;
            this.grdBuscaBordero.DoubleClick += new System.EventHandler(this.grdBuscaBordero_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Envio/Retorno";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Código";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cobradora";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 175;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Borderô";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Data";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Quantidade";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // frmBuscarBordero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 415);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grdBuscaBordero);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarBordero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Borderô";
            this.Load += new System.EventHandler(this.frmBuscarBordero_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuscaBordero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCobradora;
        private System.Windows.Forms.TextBox txtBorderoAte;
        private System.Windows.Forms.TextBox txtBorderoDe;
        private System.Windows.Forms.Label lblBorderoAte;
        private System.Windows.Forms.Label lblBorderoDe;
        private System.Windows.Forms.ComboBox cmbCobradoras;
        private System.Windows.Forms.Label lblDataAte;
        private System.Windows.Forms.DateTimePicker dataAteBordero;
        private System.Windows.Forms.DateTimePicker dataDeBordero;
        private System.Windows.Forms.Label lblDataDe;
        private System.Windows.Forms.CheckBox chkRetornoCobradora;
        private System.Windows.Forms.CheckBox chkEnvioCobradora;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView grdBuscaBordero;
        private System.Windows.Forms.CheckBox chkData;
        private System.Windows.Forms.CheckBox chkBordero;
        private System.Windows.Forms.CheckBox chkCobradora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}