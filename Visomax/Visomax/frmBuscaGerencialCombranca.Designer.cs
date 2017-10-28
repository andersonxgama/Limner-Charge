namespace Visomax
{
    partial class frmBuscaGerencialCombranca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaGerencialCombranca));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtnomecliente = new System.Windows.Forms.TextBox();
            this.txtcliente = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txdocumento = new System.Windows.Forms.TextBox();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkpendentes = new System.Windows.Forms.CheckBox();
            this.dtrespostaf = new System.Windows.Forms.DateTimePicker();
            this.dtrespostai = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtexecucaof = new System.Windows.Forms.DateTimePicker();
            this.dtexecucaoi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgeracaof = new System.Windows.Forms.DateTimePicker();
            this.dtgeracaoi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtnomecliente);
            this.groupBox1.Controls.Add(this.txtcliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // txtnomecliente
            // 
            this.txtnomecliente.Location = new System.Drawing.Point(112, 19);
            this.txtnomecliente.Name = "txtnomecliente";
            this.txtnomecliente.ReadOnly = true;
            this.txtnomecliente.Size = new System.Drawing.Size(362, 20);
            this.txtnomecliente.TabIndex = 1;
            // 
            // txtcliente
            // 
            this.txtcliente.Location = new System.Drawing.Point(6, 19);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.Size = new System.Drawing.Size(100, 20);
            this.txtcliente.TabIndex = 0;
            this.txtcliente.TextChanged += new System.EventHandler(this.txtcliente_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txdocumento);
            this.groupBox2.Controls.Add(this.cmbFilial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento";
            // 
            // txdocumento
            // 
            this.txdocumento.Location = new System.Drawing.Point(95, 32);
            this.txdocumento.Name = "txdocumento";
            this.txdocumento.Size = new System.Drawing.Size(181, 20);
            this.txdocumento.TabIndex = 3;
            // 
            // cmbFilial
            // 
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(6, 32);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(75, 21);
            this.cmbFilial.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Documento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filial:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkpendentes);
            this.groupBox3.Controls.Add(this.dtrespostaf);
            this.groupBox3.Controls.Add(this.dtrespostai);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtexecucaof);
            this.groupBox3.Controls.Add(this.dtexecucaoi);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dtgeracaof);
            this.groupBox3.Controls.Add(this.dtgeracaoi);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cobranças";
            // 
            // chkpendentes
            // 
            this.chkpendentes.AutoSize = true;
            this.chkpendentes.Location = new System.Drawing.Point(254, 74);
            this.chkpendentes.Name = "chkpendentes";
            this.chkpendentes.Size = new System.Drawing.Size(122, 17);
            this.chkpendentes.TabIndex = 9;
            this.chkpendentes.Text = "Somente Pendentes";
            this.chkpendentes.UseVisualStyleBackColor = true;
            // 
            // dtrespostaf
            // 
            this.dtrespostaf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtrespostaf.Location = new System.Drawing.Point(112, 71);
            this.dtrespostaf.Name = "dtrespostaf";
            this.dtrespostaf.Size = new System.Drawing.Size(97, 20);
            this.dtrespostaf.TabIndex = 8;
            // 
            // dtrespostai
            // 
            this.dtrespostai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtrespostai.Location = new System.Drawing.Point(9, 71);
            this.dtrespostai.Name = "dtrespostai";
            this.dtrespostai.Size = new System.Drawing.Size(97, 20);
            this.dtrespostai.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data de resposta:";
            // 
            // dtexecucaof
            // 
            this.dtexecucaof.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtexecucaof.Location = new System.Drawing.Point(357, 32);
            this.dtexecucaof.Name = "dtexecucaof";
            this.dtexecucaof.Size = new System.Drawing.Size(97, 20);
            this.dtexecucaof.TabIndex = 5;
            // 
            // dtexecucaoi
            // 
            this.dtexecucaoi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtexecucaoi.Location = new System.Drawing.Point(254, 32);
            this.dtexecucaoi.Name = "dtexecucaoi";
            this.dtexecucaoi.Size = new System.Drawing.Size(97, 20);
            this.dtexecucaoi.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data execução:";
            // 
            // dtgeracaof
            // 
            this.dtgeracaof.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtgeracaof.Location = new System.Drawing.Point(112, 32);
            this.dtgeracaof.Name = "dtgeracaof";
            this.dtgeracaof.Size = new System.Drawing.Size(97, 20);
            this.dtgeracaof.TabIndex = 2;
            // 
            // dtgeracaoi
            // 
            this.dtgeracaoi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtgeracaoi.Location = new System.Drawing.Point(9, 32);
            this.dtgeracaoi.Name = "dtgeracaoi";
            this.dtgeracaoi.Size = new System.Drawing.Size(97, 20);
            this.dtgeracaoi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data geração:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 220);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ações";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(479, 172);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Código";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Descrição";
            this.Column3.Name = "Column3";
            this.Column3.Width = 320;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(210, 466);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(388, 197);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(100, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Selecionar tudo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // frmBuscaGerencialCombranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 508);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaGerencialCombranca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca Gerencial de Combrança";
            this.Load += new System.EventHandler(this.frmBuscaGerencialCombranca_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtnomecliente;
        private System.Windows.Forms.TextBox txtcliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txdocumento;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkpendentes;
        private System.Windows.Forms.DateTimePicker dtrespostaf;
        private System.Windows.Forms.DateTimePicker dtrespostai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtexecucaof;
        private System.Windows.Forms.DateTimePicker dtexecucaoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtgeracaof;
        private System.Windows.Forms.DateTimePicker dtgeracaoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}