namespace Visomax
{
    partial class frmCobradoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobradoras));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataAteEnvio = new System.Windows.Forms.DateTimePicker();
            this.dataDeEnvio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCobradoras = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtCobradora = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grdCobradoras = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoDevedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoVencer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCobradoras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de cobradoras:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data de inclusão:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dataAteEnvio);
            this.groupBox1.Controls.Add(this.dataDeEnvio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lstCobradoras);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar cobradora";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(282, 136);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 32);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataAteEnvio
            // 
            this.dataAteEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataAteEnvio.Location = new System.Drawing.Point(306, 82);
            this.dataAteEnvio.Name = "dataAteEnvio";
            this.dataAteEnvio.Size = new System.Drawing.Size(102, 20);
            this.dataAteEnvio.TabIndex = 6;
            // 
            // dataDeEnvio
            // 
            this.dataDeEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDeEnvio.Location = new System.Drawing.Point(306, 52);
            this.dataDeEnvio.Name = "dataDeEnvio";
            this.dataDeEnvio.Size = new System.Drawing.Size(102, 20);
            this.dataDeEnvio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Até:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "De:";
            // 
            // lstCobradoras
            // 
            this.lstCobradoras.FormattingEnabled = true;
            this.lstCobradoras.Location = new System.Drawing.Point(21, 56);
            this.lstCobradoras.Name = "lstCobradoras";
            this.lstCobradoras.Size = new System.Drawing.Size(189, 134);
            this.lstCobradoras.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.txtCobradora);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(477, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 203);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastrar cobradora";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(57, 136);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(122, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtCobradora
            // 
            this.txtCobradora.Location = new System.Drawing.Point(80, 48);
            this.txtCobradora.Name = "txtCobradora";
            this.txtCobradora.Size = new System.Drawing.Size(137, 20);
            this.txtCobradora.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cobradora:";
            // 
            // grdCobradoras
            // 
            this.grdCobradoras.AllowUserToAddRows = false;
            this.grdCobradoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCobradoras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.cliente,
            this.filial,
            this.documento,
            this.inclusao,
            this.saldoDevedor,
            this.saldoVencer});
            this.grdCobradoras.Location = new System.Drawing.Point(12, 270);
            this.grdCobradoras.Name = "grdCobradoras";
            this.grdCobradoras.Size = new System.Drawing.Size(709, 205);
            this.grdCobradoras.TabIndex = 5;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 65;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 250;
            // 
            // filial
            // 
            this.filial.HeaderText = "Filial";
            this.filial.Name = "filial";
            this.filial.ReadOnly = true;
            this.filial.Width = 35;
            // 
            // documento
            // 
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            this.documento.Width = 70;
            // 
            // inclusao
            // 
            this.inclusao.HeaderText = "Inclusão";
            this.inclusao.Name = "inclusao";
            this.inclusao.ReadOnly = true;
            this.inclusao.Width = 70;
            // 
            // saldoDevedor
            // 
            this.saldoDevedor.HeaderText = "Saldo devedor";
            this.saldoDevedor.Name = "saldoDevedor";
            this.saldoDevedor.ReadOnly = true;
            this.saldoDevedor.Width = 75;
            // 
            // saldoVencer
            // 
            this.saldoVencer.HeaderText = "Saldo a vencer";
            this.saldoVencer.Name = "saldoVencer";
            this.saldoVencer.ReadOnly = true;
            this.saldoVencer.Width = 75;
            // 
            // lblAguarde
            // 
            this.lblAguarde.AutoSize = true;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.ForeColor = System.Drawing.Color.Red;
            this.lblAguarde.Location = new System.Drawing.Point(245, 233);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(243, 17);
            this.lblAguarde.TabIndex = 6;
            this.lblAguarde.Text = "Carregando os dados...aguarde!";
            // 
            // frmCobradoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 487);
            this.Controls.Add(this.lblAguarde);
            this.Controls.Add(this.grdCobradoras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobradoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobradoras";
            this.Load += new System.EventHandler(this.frmCobradoras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCobradoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dataAteEnvio;
        private System.Windows.Forms.DateTimePicker dataDeEnvio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtCobradora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdCobradoras;
        private System.Windows.Forms.ListBox lstCobradoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn filial;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn inclusao;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoDevedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoVencer;
        private System.Windows.Forms.Label lblAguarde;
    }
}