namespace Visomax
{
    partial class frmCobranca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobranca));
            this.btnEfetuarCobranca = new System.Windows.Forms.Button();
            this.btnGerarCobranca = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCobradora = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEfetuarCobranca
            // 
            this.btnEfetuarCobranca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEfetuarCobranca.Image = ((System.Drawing.Image)(resources.GetObject("btnEfetuarCobranca.Image")));
            this.btnEfetuarCobranca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEfetuarCobranca.Location = new System.Drawing.Point(137, 117);
            this.btnEfetuarCobranca.Name = "btnEfetuarCobranca";
            this.btnEfetuarCobranca.Size = new System.Drawing.Size(150, 30);
            this.btnEfetuarCobranca.TabIndex = 1;
            this.btnEfetuarCobranca.Text = "&Efetuar Cobrança";
            this.btnEfetuarCobranca.UseVisualStyleBackColor = true;
            this.btnEfetuarCobranca.Click += new System.EventHandler(this.btnEfetuarCobranca_Click);
            // 
            // btnGerarCobranca
            // 
            this.btnGerarCobranca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarCobranca.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCobranca.Image")));
            this.btnGerarCobranca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCobranca.Location = new System.Drawing.Point(125, 53);
            this.btnGerarCobranca.Name = "btnGerarCobranca";
            this.btnGerarCobranca.Size = new System.Drawing.Size(150, 30);
            this.btnGerarCobranca.TabIndex = 2;
            this.btnGerarCobranca.Text = "&Gerar Cobrança";
            this.btnGerarCobranca.UseVisualStyleBackColor = true;
            this.btnGerarCobranca.Click += new System.EventHandler(this.btnGerarCobranca_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCobradora);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGerarCobranca);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros";
            // 
            // cmbCobradora
            // 
            this.cmbCobradora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCobradora.FormattingEnabled = true;
            this.cmbCobradora.Location = new System.Drawing.Point(245, 26);
            this.cmbCobradora.Name = "cmbCobradora";
            this.cmbCobradora.Size = new System.Drawing.Size(142, 21);
            this.cmbCobradora.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cobradora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dias em atraso:";
            // 
            // frmCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 161);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEfetuarCobranca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobranca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrança";
            this.Load += new System.EventHandler(this.frmCobranca_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEfetuarCobranca;
        private System.Windows.Forms.Button btnGerarCobranca;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCobradora;
        private System.Windows.Forms.TextBox textBox1;
    }
}