using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Visomax
{
    public partial class frmRecebimentoCaixas : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

        String RelatorioTitulo = "Recebimento de caixas - ";
        int paginaAtual = 1;
        static int li = 0;

        public frmRecebimentoCaixas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (txtFilial.Text == "")
            {
                //Convertendo data para o formato americano
                DateTime Data = Convert.ToDateTime(dtpData.Text);
                string DataFormato = Data.ToString("s");
                DateTime Data2 = Convert.ToDateTime(dtpData2.Text);
                string DataFormato2 = Data2.ToString("s");

                try
                {


                    SqlCommand caixa = new SqlCommand("SELECT recebimento_parcela.filial, recebimento_parcela.caixa, " +
                        "recebimento_parcela.id_recebimento, recebimento_parcela.filial_pc, recebimento_parcela.documento, " +
                        "recebimento_parcela.parcela, recebimento_parcela.dt_vencto, recebimento_parcela.vlr_parcela, " +
                        "recebimento.dt_pagto, recebimento_parcela.vlr_juros, recebimento_parcela.vlr_descontos, " +
                        "recebimento_parcela.vlr_pagto, recebimento.cancelado, recebimento_parcela.parcial, " +
                        "recebimento_parcela.cod_cliente, recebimento_parcela.cliente, recebimento_parcela.exportado, " +
                        "recebimento_parcela.sequencial FROM recebimento_parcela, recebimento " +
                        "where (recebimento.dt_pagto BETWEEN  '" + DataFormato + "' and '" + DataFormato2 + "') and " +
                        "recebimento_parcela.id_recebimento = recebimento.id_recebimento and recebimento_parcela.filial = recebimento.filial", conn);
                    conn.Open();

                    //define o tipo do comando 
                    caixa.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = caixa.ExecuteReader();

                    //Obtem o número de colunas
                    int nColunas = dr.FieldCount;
                    //percorre as colunas obtendo o seu nome e incluindo no DataGridView


                    //for (int i = 0; i < nColunas; i++)
                    //{
                    // dataGridView1.Columns.Add(dr.GetName(i).ToString(), dr.GetName(i).ToString());
                    //}


                    //define um array de strings com nCOlunas
                    string[] linhaDados = new string[nColunas];

                    //percorre o DataRead
                    while (dr.Read())
                    {

                        //percorre cada uma das colunas
                        for (int a = 0; a < nColunas; a++)
                        {
                            //verifica o tipo de dados da coluna
                            if (dr.GetFieldType(a).ToString() == "System.Int32")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt32(a).ToString();
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Int16")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt16(a).ToString();
                                }
                            }
                            if (dr.GetFieldType(a).ToString() == "System.Int64")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt64(a).ToString();
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.String")
                            {

                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {

                                    linhaDados[a] = dr.GetString(a).ToString();


                                }
                            }
                            if (dr.GetFieldType(a).ToString() == "System.DateTime")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetDateTime(a).ToString("d");
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Decimal")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetDecimal(a).ToString("N");


                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Byte")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetByte(a).ToString();
                                }
                            }


                        }

                        dataGridView1.Rows.Add(linhaDados);


                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            { 
                //Convertendo data para o formato americano
                DateTime Data = Convert.ToDateTime(dtpData.Text);
                string DataFormato = Data.ToString("s");
                DateTime Data2 = Convert.ToDateTime(dtpData2.Text);
                string DataFormato2 = Data2.ToString("s");

                try
                {


                    SqlCommand caixa = new SqlCommand("SELECT recebimento_parcela.filial, recebimento_parcela.caixa, " +
                        "recebimento_parcela.id_recebimento, recebimento_parcela.filial_pc, recebimento_parcela.documento, " +
                        "recebimento_parcela.parcela, recebimento_parcela.dt_vencto, recebimento_parcela.vlr_parcela, " +
                        "recebimento.dt_pagto, recebimento_parcela.vlr_juros, recebimento_parcela.vlr_descontos, " +
                        "recebimento_parcela.vlr_pagto, recebimento.cancelado, recebimento_parcela.parcial, " +
                        "recebimento_parcela.cod_cliente, recebimento_parcela.cliente, recebimento_parcela.exportado, " +
                        "recebimento_parcela.sequencial FROM recebimento_parcela, recebimento " +
                        "where (recebimento.dt_pagto BETWEEN  '" + DataFormato + "' and '" + DataFormato2 + "') and "+
                        "recebimento_parcela.id_recebimento = recebimento.id_recebimento and recebimento_parcela.filial = recebimento.filial and recebimento.filial = '" + cmbFilial.Text + "' and recebimento_parcela.caixa = '" + cmbcaixa.Text + "' ", conn);
                    conn.Open();

                    //define o tipo do comando 
                    caixa.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = caixa.ExecuteReader();

                    //Obtem o número de colunas
                    int nColunas = dr.FieldCount;
                    //percorre as colunas obtendo o seu nome e incluindo no DataGridView


                    //for (int i = 0; i < nColunas; i++)
                    //{
                    // dataGridView1.Columns.Add(dr.GetName(i).ToString(), dr.GetName(i).ToString());
                    //}


                    //define um array de strings com nCOlunas
                    string[] linhaDados = new string[nColunas];

                    //percorre o DataRead
                    while (dr.Read())
                    {

                        //percorre cada uma das colunas
                        for (int a = 0; a < nColunas; a++)
                        {
                            //verifica o tipo de dados da coluna
                            if (dr.GetFieldType(a).ToString() == "System.Int32")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt32(a).ToString();
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Int16")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt16(a).ToString();
                                }
                            }
                            if (dr.GetFieldType(a).ToString() == "System.Int64")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetInt64(a).ToString();
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.String")
                            {

                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {

                                    linhaDados[a] = dr.GetString(a).ToString();


                                }
                            }
                            if (dr.GetFieldType(a).ToString() == "System.DateTime")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetDateTime(a).ToString("d");
                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Decimal")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetDecimal(a).ToString("N");


                                }
                            }

                            if (dr.GetFieldType(a).ToString() == "System.Byte")
                            {
                                if (dr.IsDBNull(a))
                                {

                                }
                                else
                                {
                                    linhaDados[a] = dr.GetByte(a).ToString();
                                }
                            }


                        }

                        dataGridView1.Rows.Add(linhaDados);


                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Begin_Print(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            paginaAtual = 1;
        }

        private void End_Print(object sender, System.Drawing.Printing.PrintEventArgs byvale)
        {
        }

        private void pdRelatorios_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Variaveis das linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;


            //Variaveis das margens
            float MargemEsq = e.MarginBounds.Left - 90;
            float MargemSuperior = e.MarginBounds.Top + 100;
            float MargemDireita = e.MarginBounds.Right;
            float MargemInferior = e.MarginBounds.Bottom;

            Pen CanetaDaImpressora = new Pen(Color.Black, 1);

            //Variaveis das fontes
            Font FonteNegrito = default(Font);
            Font FonteTitulo = default(Font);
            Font FonteSubTitulo = default(Font);
            Font FonteRodape = default(Font);
            Font FonteNormal = default(Font);

            //define efeitos em fontes
            FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            FonteRodape = new Font("Arial", 8);
            FonteNormal = new Font("Arial", 10);

            //define valores para linha atual e para linha da impressao
            LinhaAtual = 0;

            //Cabecalho
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 60, MargemDireita + 90, 60);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 160, MargemDireita + 90, 160);
            //nome da empresa
            e.Graphics.DrawString("Visomax", FonteTitulo, Brushes.Blue, MargemEsq + 250, 80, new StringFormat());
            //Imagem
            e.Graphics.DrawString(RelatorioTitulo + System.DateTime.Now.ToString("dd/MM/yyyy"), FonteSubTitulo, Brushes.Black, MargemEsq + 250, 110, new StringFormat());

            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 20);

            int registros = dataGridView1.Rows.Count - 1;



            //List<DataRow> clientes = new List<DataRow>();
            //foreach (DataRow dr in dtClientes.Rows)
            //{
            //    clientes.Add(dr);
            //}

            //inicia a impressao
            PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
            e.Graphics.DrawString("Loja ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
            e.Graphics.DrawString("Caixa ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
            e.Graphics.DrawString("Documento ", FonteNegrito, Brushes.Black, MargemEsq + 120, PosicaoDaLinha);
            e.Graphics.DrawString("Parcela ", FonteNegrito, Brushes.Black, MargemEsq + 220, PosicaoDaLinha);
            e.Graphics.DrawString("Vencimento", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha);
            e.Graphics.DrawString("Valor ", FonteNegrito, Brushes.Black, MargemEsq + 430, PosicaoDaLinha);
            e.Graphics.DrawString("Pagamento ", FonteNegrito, Brushes.Black, MargemEsq + 560, PosicaoDaLinha);


            while ((LinhaAtual < LinhasPorPagina && registros > li))
            {
           


                ////'impressão dos dados
                //PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[0].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[1].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[4].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 120, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[5].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 220, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[6].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[11].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 430, PosicaoDaLinha + 15);
                e.Graphics.DrawString(dataGridView1.Rows[li].Cells[8].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 560, PosicaoDaLinha + 15);
              

                PosicaoDaLinha = PosicaoDaLinha + 20;

                LinhaAtual += 1;
                li += 1;

            }

            //Rodape
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, MargemInferior, MargemDireita + 90, MargemInferior);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, MargemEsq, MargemInferior, new StringFormat());
            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Pagina : " + paginaAtual, FonteRodape, Brushes.Black, MargemDireita - 50, MargemInferior, new StringFormat());

            //Incrementa o numero da pagina
            paginaAtual += 1;

            //verifica se continua imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                li = 0;
                e.HasMorePages = false;
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Obrigatorio fazer à busca!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RelatorioTitulo = "Consulta de Caixa - ";
                //define os objetos printdocument e os eventos associados
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                //IMPORTANTE - definimos 3 eventos para tratar a impressão : PringPage, BeginPrint e EndPrint.
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdRelatorios_PrintPage);
                pd.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.Begin_Print);
                pd.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.End_Print);

                //define o objeto para visualizar a impressao
                PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
             
                    //define o formulário como maximizado e com Zoom
                    {
                        objPrintPreview.Document = pd;
                        objPrintPreview.WindowState = FormWindowState.Maximized;
                        objPrintPreview.PrintPreviewControl.Zoom = 1;
                        objPrintPreview.Text = "Movimento";
                        objPrintPreview.ShowDialog();
                    }
                }
              
            }

        private void frmRecebimentoCaixas_Load(object sender, EventArgs e)
        {
            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand ComboFilial = new SqlCommand("SELECT Codigo from Parametros_Filial ", conn2);
                conn2.Open();
                SqlDataReader leitor = ComboFilial.ExecuteReader();
                while (leitor.Read())
                {
                    cmbFilial.Items.Add(leitor.GetValue(0));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbFilial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + cmbFilial.Text + "'", conn2);
                conn2.Open();
                SqlDataReader nome = NomeFilial.ExecuteReader();
                while (nome.Read())
                {
                    txtFilial.Text = Convert.ToString(nome.GetValue(1));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand ComboFilial = new SqlCommand("SELECT Codigo "+
                    "FROM Caixas "+
                    "where Filial = "+cmbFilial.Text+" ", conn2);
                conn2.Open();
                SqlDataReader leitor = ComboFilial.ExecuteReader();
                while (leitor.Read())
                {
                    cmbcaixa.Items.Add(leitor.GetValue(0));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Duplo clique na linha da grid
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            String loja = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String caixa = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String id = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //this.Hide();

            frmConsultaRecebimentoLoja fcbl = new frmConsultaRecebimentoLoja(loja, caixa, id);
            fcbl.ShowDialog();

            this.Close();
        }
    }
}