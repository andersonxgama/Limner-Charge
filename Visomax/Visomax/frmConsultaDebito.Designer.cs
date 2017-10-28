namespace Visomax
{
    partial class frmConsultaDebito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaDebito));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnHistoricoCobranca = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmissao = new System.Windows.Forms.TextBox();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.txtValorReceber = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gridConsultaDebito = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAtrasoMedio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtNomeFilial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoFilial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDebitoDois = new System.Windows.Forms.TextBox();
            this.txtDebitoUm = new System.Windows.Forms.TextBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDadosCadastrais = new System.Windows.Forms.Button();
            this.txtTelComercial = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtTelResidencial = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultaDebito)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(770, 475);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(103, 30);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVenda
            // 
            this.btnVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnVenda.Image")));
            this.btnVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVenda.Location = new System.Drawing.Point(360, 475);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(103, 30);
            this.btnVenda.TabIndex = 4;
            this.btnVenda.Text = "&Venda";
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            // 
            // btnHistoricoCobranca
            // 
            this.btnHistoricoCobranca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoricoCobranca.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoricoCobranca.Image")));
            this.btnHistoricoCobranca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoricoCobranca.Location = new System.Drawing.Point(529, 475);
            this.btnHistoricoCobranca.Name = "btnHistoricoCobranca";
            this.btnHistoricoCobranca.Size = new System.Drawing.Size(174, 30);
            this.btnHistoricoCobranca.TabIndex = 3;
            this.btnHistoricoCobranca.Text = "&Histórico de cobrança";
            this.btnHistoricoCobranca.UseVisualStyleBackColor = true;
            this.btnHistoricoCobranca.Click += new System.EventHandler(this.btnHistoricoCobranca_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmissao);
            this.groupBox2.Controls.Add(this.txtValorRecebido);
            this.groupBox2.Controls.Add(this.txtValorReceber);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.gridConsultaDebito);
            this.groupBox2.Controls.Add(this.txtAtrasoMedio);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDocumento);
            this.groupBox2.Controls.Add(this.txtNomeFilial);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCodigoFilial);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtDebitoDois);
            this.groupBox2.Controls.Add(this.txtDebitoUm);
            this.groupBox2.Controls.Add(this.btnProximo);
            this.groupBox2.Controls.Add(this.btnAnterior);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(882, 318);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Débitos:";
            // 
            // txtEmissao
            // 
            this.txtEmissao.Location = new System.Drawing.Point(615, 23);
            this.txtEmissao.Name = "txtEmissao";
            this.txtEmissao.ReadOnly = true;
            this.txtEmissao.Size = new System.Drawing.Size(87, 20);
            this.txtEmissao.TabIndex = 20;
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Location = new System.Drawing.Point(769, 286);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.ReadOnly = true;
            this.txtValorRecebido.Size = new System.Drawing.Size(91, 20);
            this.txtValorRecebido.TabIndex = 19;
            this.txtValorRecebido.Text = "0";
            // 
            // txtValorReceber
            // 
            this.txtValorReceber.Location = new System.Drawing.Point(541, 286);
            this.txtValorReceber.Name = "txtValorReceber";
            this.txtValorReceber.ReadOnly = true;
            this.txtValorReceber.Size = new System.Drawing.Size(91, 20);
            this.txtValorReceber.TabIndex = 18;
            this.txtValorReceber.Text = "0,00";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(282, 286);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(91, 20);
            this.txtTotal.TabIndex = 17;
            this.txtTotal.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(684, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Valor recebido:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(456, 290);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Valor a receber:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Total:";
            // 
            // gridConsultaDebito
            // 
            this.gridConsultaDebito.AllowUserToAddRows = false;
            this.gridConsultaDebito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsultaDebito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.gridConsultaDebito.Location = new System.Drawing.Point(6, 57);
            this.gridConsultaDebito.Name = "gridConsultaDebito";
            this.gridConsultaDebito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConsultaDebito.Size = new System.Drawing.Size(870, 214);
            this.gridConsultaDebito.TabIndex = 13;       
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Parcelamento";
            this.Column1.Name = "Column1";
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Parcela";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Vencimento";
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Valor parcela";
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Pagamento";
            this.Column5.Name = "Column5";
            this.Column5.Width = 75;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Valor pago";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "A Receber";
            this.Column7.Name = "Column7";
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Atraso";
            this.Column8.Name = "Column8";
            this.Column8.Width = 75;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Observações";
            this.Column9.Name = "Column9";
            this.Column9.Width = 190;
            // 
            // txtAtrasoMedio
            // 
            this.txtAtrasoMedio.Location = new System.Drawing.Point(791, 23);
            this.txtAtrasoMedio.Name = "txtAtrasoMedio";
            this.txtAtrasoMedio.ReadOnly = true;
            this.txtAtrasoMedio.Size = new System.Drawing.Size(71, 20);
            this.txtAtrasoMedio.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(717, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Atraso médio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(564, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Emissão:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(436, 23);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(110, 20);
            this.txtDocumento.TabIndex = 8;
            // 
            // txtNomeFilial
            // 
            this.txtNomeFilial.Location = new System.Drawing.Point(245, 23);
            this.txtNomeFilial.Name = "txtNomeFilial";
            this.txtNomeFilial.ReadOnly = true;
            this.txtNomeFilial.Size = new System.Drawing.Size(108, 20);
            this.txtNomeFilial.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Documento:";
            // 
            // txtCodigoFilial
            // 
            this.txtCodigoFilial.Location = new System.Drawing.Point(220, 23);
            this.txtCodigoFilial.Name = "txtCodigoFilial";
            this.txtCodigoFilial.ReadOnly = true;
            this.txtCodigoFilial.Size = new System.Drawing.Size(21, 20);
            this.txtCodigoFilial.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Filial:";
            // 
            // txtDebitoDois
            // 
            this.txtDebitoDois.Location = new System.Drawing.Point(93, 23);
            this.txtDebitoDois.Name = "txtDebitoDois";
            this.txtDebitoDois.ReadOnly = true;
            this.txtDebitoDois.Size = new System.Drawing.Size(43, 20);
            this.txtDebitoDois.TabIndex = 3;
            // 
            // txtDebitoUm
            // 
            this.txtDebitoUm.Location = new System.Drawing.Point(46, 23);
            this.txtDebitoUm.Name = "txtDebitoUm";
            this.txtDebitoUm.ReadOnly = true;
            this.txtDebitoUm.Size = new System.Drawing.Size(43, 20);
            this.txtDebitoUm.TabIndex = 2;
            // 
            // btnProximo
            // 
            this.btnProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.Location = new System.Drawing.Point(140, 19);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(28, 28);
            this.btnProximo.TabIndex = 1;
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(14, 19);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(28, 28);
            this.btnAnterior.TabIndex = 0;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDadosCadastrais);
            this.groupBox1.Controls.Add(this.txtTelComercial);
            this.groupBox1.Controls.Add(this.txtCelular);
            this.groupBox1.Controls.Add(this.txtTelResidencial);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.txtCpf);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";

            // 
            // btnDadosCadastrais
            // 
            this.btnDadosCadastrais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDadosCadastrais.Image = ((System.Drawing.Image)(resources.GetObject("btnDadosCadastrais.Image")));
            this.btnDadosCadastrais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDadosCadastrais.Location = new System.Drawing.Point(359, 104);
            this.btnDadosCadastrais.Name = "btnDadosCadastrais";
            this.btnDadosCadastrais.Size = new System.Drawing.Size(161, 28);
            this.btnDadosCadastrais.TabIndex = 14;
            this.btnDadosCadastrais.Text = "&Dados Cadastrais";
            this.btnDadosCadastrais.UseVisualStyleBackColor = true;
            this.btnDadosCadastrais.Click += new System.EventHandler(this.btnDadosCadastrais_Click);
            // 
            // txtTelComercial
            // 
            this.txtTelComercial.Location = new System.Drawing.Point(724, 65);
            this.txtTelComercial.Name = "txtTelComercial";
            this.txtTelComercial.ReadOnly = true;
            this.txtTelComercial.Size = new System.Drawing.Size(108, 20);
            this.txtTelComercial.TabIndex = 13;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(500, 66);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.ReadOnly = true;
            this.txtCelular.Size = new System.Drawing.Size(108, 20);
            this.txtCelular.TabIndex = 12;
            // 
            // txtTelResidencial
            // 
            this.txtTelResidencial.Location = new System.Drawing.Point(318, 65);
            this.txtTelResidencial.Name = "txtTelResidencial";
            this.txtTelResidencial.ReadOnly = true;
            this.txtTelResidencial.Size = new System.Drawing.Size(108, 20);
            this.txtTelResidencial.TabIndex = 11;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(67, 65);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(134, 20);
            this.txtCidade.TabIndex = 10;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(680, 25);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.ReadOnly = true;
            this.txtCpf.Size = new System.Drawing.Size(152, 20);
            this.txtCpf.TabIndex = 9;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(251, 25);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(357, 20);
            this.txtNome.TabIndex = 8;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(65, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(81, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(645, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tel. Comercial:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(456, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Celular:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tel. Residencial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(168, 475);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 30);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmConsultaDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 516);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHistoricoCobranca);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaDebito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de débito de clientes";
            this.Load += new System.EventHandler(this.frmConsultaDebito_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultaDebito)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTelComercial;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtTelResidencial;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDebitoDois;
        private System.Windows.Forms.TextBox txtDebitoUm;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.TextBox txtCodigoFilial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeFilial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtAtrasoMedio;
        private System.Windows.Forms.DataGridView gridConsultaDebito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.TextBox txtValorReceber;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnHistoricoCobranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnDadosCadastrais;
        private System.Windows.Forms.TextBox txtEmissao;
        private System.Windows.Forms.Button btnBuscar;
    }
}