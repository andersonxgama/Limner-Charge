namespace Visomax
{
    partial class frminadimplencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frminadimplencia));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtbase = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtFilialAnalitico = new System.Windows.Forms.TextBox();
            this.cmbFilialAnalitico = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDataAnalitico = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDataAnaliticof = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBuscarSintético = new System.Windows.Forms.Button();
            this.txtFilialSintetico = new System.Windows.Forms.TextBox();
            this.cmbFilialSintetico = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtVencimentoI = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtVencimentoF = new System.Windows.Forms.DateTimePicker();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 356);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFilial);
            this.tabPage1.Controls.Add(this.cmbFilial);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dtbase);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lojas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFilial
            // 
            this.txtFilial.Enabled = false;
            this.txtFilial.Location = new System.Drawing.Point(356, 12);
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.Size = new System.Drawing.Size(121, 20);
            this.txtFilial.TabIndex = 18;
            // 
            // cmbFilial
            // 
            this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(282, 12);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(68, 21);
            this.cmbFilial.TabIndex = 17;
            this.cmbFilial.SelectedIndexChanged += new System.EventHandler(this.cmbFilial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filial:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(502, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 30);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtbase
            // 
            this.dtbase.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbase.Location = new System.Drawing.Point(147, 12);
            this.dtbase.Name = "dtbase";
            this.dtbase.Size = new System.Drawing.Size(82, 20);
            this.dtbase.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data vencimento base:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
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
            this.Column10});
            this.dataGridView1.Location = new System.Drawing.Point(6, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(952, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Filial";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Período";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Vlr. Previsto";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qtd. Previsto";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Vlr. Realizado";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Qtde. Realizado";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Vlr. Saldo";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Qtde. Saldo";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "% Valor";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "% Quantidade";
            this.Column10.Name = "Column10";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnImprimir);
            this.tabPage2.Controls.Add(this.txtFilialAnalitico);
            this.tabPage2.Controls.Add(this.cmbFilialAnalitico);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dtDataAnalitico);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dtDataAnaliticof);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(980, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vendedor Analítico";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(17, 112);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(114, 32);
            this.btnImprimir.TabIndex = 25;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtFilialAnalitico
            // 
            this.txtFilialAnalitico.Enabled = false;
            this.txtFilialAnalitico.Location = new System.Drawing.Point(124, 58);
            this.txtFilialAnalitico.Name = "txtFilialAnalitico";
            this.txtFilialAnalitico.Size = new System.Drawing.Size(121, 20);
            this.txtFilialAnalitico.TabIndex = 24;
            // 
            // cmbFilialAnalitico
            // 
            this.cmbFilialAnalitico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilialAnalitico.FormattingEnabled = true;
            this.cmbFilialAnalitico.Location = new System.Drawing.Point(50, 58);
            this.cmbFilialAnalitico.Name = "cmbFilialAnalitico";
            this.cmbFilialAnalitico.Size = new System.Drawing.Size(68, 21);
            this.cmbFilialAnalitico.TabIndex = 23;
            this.cmbFilialAnalitico.SelectedIndexChanged += new System.EventHandler(this.cmbFilialAnalitico_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Filial:";
            // 
            // dtDataAnalitico
            // 
            this.dtDataAnalitico.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataAnalitico.Location = new System.Drawing.Point(112, 9);
            this.dtDataAnalitico.Name = "dtDataAnalitico";
            this.dtDataAnalitico.Size = new System.Drawing.Size(82, 20);
            this.dtDataAnalitico.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Data Vencimento:";
            // 
            // dtDataAnaliticof
            // 
            this.dtDataAnaliticof.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDataAnaliticof.Location = new System.Drawing.Point(200, 9);
            this.dtDataAnaliticof.Name = "dtDataAnaliticof";
            this.dtDataAnaliticof.Size = new System.Drawing.Size(85, 20);
            this.dtDataAnaliticof.TabIndex = 26;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBuscarSintético);
            this.tabPage3.Controls.Add(this.txtFilialSintetico);
            this.tabPage3.Controls.Add(this.cmbFilialSintetico);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dtVencimentoI);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.dtVencimentoF);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(980, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vendedor Sintético";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBuscarSintético
            // 
            this.btnBuscarSintético.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarSintético.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarSintético.Image")));
            this.btnBuscarSintético.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSintético.Location = new System.Drawing.Point(523, 9);
            this.btnBuscarSintético.Name = "btnBuscarSintético";
            this.btnBuscarSintético.Size = new System.Drawing.Size(122, 30);
            this.btnBuscarSintético.TabIndex = 33;
            this.btnBuscarSintético.Text = "&Buscar";
            this.btnBuscarSintético.UseVisualStyleBackColor = true;
            this.btnBuscarSintético.Click += new System.EventHandler(this.btnBuscarSintético_Click);
            // 
            // txtFilialSintetico
            // 
            this.txtFilialSintetico.Enabled = false;
            this.txtFilialSintetico.Location = new System.Drawing.Point(396, 15);
            this.txtFilialSintetico.Name = "txtFilialSintetico";
            this.txtFilialSintetico.Size = new System.Drawing.Size(121, 20);
            this.txtFilialSintetico.TabIndex = 32;
            // 
            // cmbFilialSintetico
            // 
            this.cmbFilialSintetico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilialSintetico.FormattingEnabled = true;
            this.cmbFilialSintetico.Location = new System.Drawing.Point(322, 15);
            this.cmbFilialSintetico.Name = "cmbFilialSintetico";
            this.cmbFilialSintetico.Size = new System.Drawing.Size(68, 21);
            this.cmbFilialSintetico.TabIndex = 31;
            this.cmbFilialSintetico.SelectedIndexChanged += new System.EventHandler(this.cmbFilialSintetico_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Filial:";
            // 
            // dtVencimentoI
            // 
            this.dtVencimentoI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVencimentoI.Location = new System.Drawing.Point(104, 15);
            this.dtVencimentoI.Name = "dtVencimentoI";
            this.dtVencimentoI.Size = new System.Drawing.Size(82, 20);
            this.dtVencimentoI.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Data Vencimento:";
            // 
            // dtVencimentoF
            // 
            this.dtVencimentoF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVencimentoF.Location = new System.Drawing.Point(192, 15);
            this.dtVencimentoF.Name = "dtVencimentoF";
            this.dtVencimentoF.Size = new System.Drawing.Size(85, 20);
            this.dtVencimentoF.TabIndex = 29;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17});
            this.dataGridView2.Location = new System.Drawing.Point(6, 46);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(814, 249);
            this.dataGridView2.TabIndex = 0;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Filial";
            this.Column11.Name = "Column11";
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Código";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Vendedor";
            this.Column13.Name = "Column13";
            this.Column13.Width = 200;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Valor Previsto";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Valor Realizado";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Saldo";
            this.Column16.Name = "Column16";
            // 
            // Column17
            // 
            this.Column17.HeaderText = "Inadiplência";
            this.Column17.Name = "Column17";
            // 
            // frminadimplencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 370);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frminadimplencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inadimplência";
            this.Load += new System.EventHandler(this.frminadimplencia_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtbase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox txtFilialAnalitico;
        private System.Windows.Forms.ComboBox cmbFilialAnalitico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDataAnalitico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DateTimePicker dtDataAnaliticof;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.TextBox txtFilialSintetico;
        private System.Windows.Forms.ComboBox cmbFilialSintetico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtVencimentoI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtVencimentoF;
        private System.Windows.Forms.Button btnBuscarSintético;
    }
}