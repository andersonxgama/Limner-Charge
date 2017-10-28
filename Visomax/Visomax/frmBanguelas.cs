using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Visomax
{
    public partial class frmBanguelas : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        String RelatorioTitulo = "Relação de Banguelas - ";
        int paginaAtual = 1;
        static int li = 0;
        public frmBanguelas()
        {
            InitializeComponent();
        }

        private void frmBanguelas_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand caixa = new SqlCommand("select " +
                   "contas_receber.tipo_parcelamento as tp_parcelamento, " +
                   "contas_receber.filial            as filial, " +
                   "contas_receber.sequencia         as documento, " +
                   "contas_receber.parcela           as parcela,     " +
                   "contas_receber.cliente           as cod_cliente,    " +
                   "cli_for.nome                     as cliente," +
                   "contas_receber.emissao           as dt_emissao, " +
                   "contas_receber.vencimento        as dt_vencimento,   " +
                   "contas_receber.valor             as valor   " +
                   "from          " +
                   "contas_receber  (nolock)     " +
                   "inner join cli_for (nolock)         " +
                   "on cli_for.codigo = contas_receber.cliente    " +
                   "where               " +
                   "contas_receber.tipo in ('R') and    " +
                   "contas_receber.sequencia is not null and   " +
                   "contas_receber.sequencia > 0 and         " +
                   "contas_receber.conta_cancelada = 0 and     " +
                   "Contas_Receber.data_recebimento is null " +
                   "and contas_receber.parcela < any (select    " +
                   "aux.parcela     " +
                   "from          " +
                   "contas_receber as aux (nolock)     " +
                   "where             " +
                   "aux.cliente   = contas_receber.cliente   and  " +
                   "aux.filial    = contas_receber.filial    and  " +
                   "aux.sequencia = contas_receber.sequencia and  " +
                   "aux.data_recebimento is not null)     " +
                   "order by             " +
                   "contas_receber.filial,    " +
                   "contas_receber.sequencia,    " +
                   "contas_receber.cliente,    " +
                   "contas_receber.parcela,     " +
                   "contas_receber.vencimento  ", conn);
                conn.Open();

                //define o tipo do comando 
                caixa.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = caixa.ExecuteReader();

                //Obtem o número de colunas
                int nColunas = dr.FieldCount;
                //percorre as colunas obtendo o seu nome e incluindo no DataGridView

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
                                if (dr.GetString(a).ToString() == "T")
                                {
                                    linhaDados[a] = "Carnê";
                                }
                                else if (dr.GetString(a).ToString() == "B")
                                {
                                    linhaDados[a] = "Boleto";
                                }
                                else
                                {
                                    linhaDados[a] = dr.GetString(a).ToString();
                                }

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

                SqlCommand caixaCartao = new SqlCommand("select " +
                   "contas_receber.tipo_parcelamento as tp_parcelamento, " +
                   "contas_receber.filial            as filial, " +
                   "contas_receber.sequencia         as documento, " +
                   "contas_receber.Cheque_Numero           as parcela,     " +
                   "contas_receber.cliente           as cod_cliente,    " +
                   "cli_for.nome                     as cliente," +
                   "contas_receber.emissao           as dt_emissao, " +
                   "contas_receber.vencimento        as dt_vencimento,   " +
                   "contas_receber.valor             as valor   " +
                   "from          " +
                   "contas_receber  (nolock)     " +
                   "inner join cli_for (nolock)         " +
                   "on cli_for.codigo = contas_receber.cliente    " +
                   "where               " +
                   "contas_receber.tipo in ('C') and    " +
                   "contas_receber.sequencia is not null and   " +
                   "contas_receber.sequencia > 0 and         " +
                   "contas_receber.conta_cancelada = 0 and     " +
                   "Contas_Receber.data_recebimento is null " +
                   "and contas_receber.Cheque_Numero < any (select    " +
                   "aux.Cheque_Numero     " +
                   "from          " +
                   "contas_receber as aux (nolock)     " +
                   "where             " +
                   "aux.cliente   = contas_receber.cliente   and  " +
                   "aux.filial    = contas_receber.filial    and  " +
                   "aux.sequencia = contas_receber.sequencia and  " +
                   "aux.data_recebimento is not null)     " +
                   "order by             " +
                   "contas_receber.filial,    " +
                   "contas_receber.sequencia,    " +
                   "contas_receber.cliente,    " +
                   "contas_receber.parcela,     " +
                   "contas_receber.vencimento  ", conn);
                conn.Open();

                //define o tipo do comando 
                caixa.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr1 = caixaCartao.ExecuteReader();

                //percorre o DataRead
                while (dr1.Read())
                {

                    //percorre cada uma das colunas
                    for (int a = 0; a < nColunas; a++)
                    {
                        //verifica o tipo de dados da coluna
                        if (dr1.GetFieldType(a).ToString() == "System.Int32")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetInt32(a).ToString();
                            }
                        }

                        if (dr1.GetFieldType(a).ToString() == "System.Int16")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetInt16(a).ToString();
                            }
                        }
                        if (dr1.GetFieldType(a).ToString() == "System.Int64")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetInt64(a).ToString();
                            }
                        }

                        if (dr1.GetFieldType(a).ToString() == "System.String")
                        {

                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {

                                if (dr1.GetString(a).ToString() == " ")
                                {
                                    linhaDados[a] = "Cheque";
                                }
                                else
                                {
                                    linhaDados[a] = dr1.GetString(a).ToString();
                                }

                            }
                        }
                        if (dr1.GetFieldType(a).ToString() == "System.DateTime")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetDateTime(a).ToString("d");
                            }
                        }

                        if (dr1.GetFieldType(a).ToString() == "System.Decimal")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetDecimal(a).ToString("N");


                            }
                        }

                        if (dr1.GetFieldType(a).ToString() == "System.Byte")
                        {
                            if (dr1.IsDBNull(a))
                            {

                            }
                            else
                            {
                                linhaDados[a] = dr1.GetByte(a).ToString();
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

            string tipo = null;
            string filial = null;
            string documento = null;
            string pc = null;
            string codigo = null;
            string cliente = null;
            string emissao = null;
            string vencimento = null;
            string valor = null;

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
            e.Graphics.DrawString("Tipo: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
            e.Graphics.DrawString("Filial: ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
            e.Graphics.DrawString("Documento: ", FonteNegrito, Brushes.Black, MargemEsq + 120, PosicaoDaLinha);
            e.Graphics.DrawString("PC: ", FonteNegrito, Brushes.Black, MargemEsq + 200, PosicaoDaLinha);
            e.Graphics.DrawString("Código: ", FonteNegrito, Brushes.Black, MargemEsq + 270, PosicaoDaLinha);
            e.Graphics.DrawString("Cliente: ", FonteNegrito, Brushes.Black, MargemEsq + 340, PosicaoDaLinha);
            e.Graphics.DrawString("Emissão ", FonteNegrito, Brushes.Black, MargemEsq + 500, PosicaoDaLinha);
            e.Graphics.DrawString("Vencimento: ", FonteNegrito, Brushes.Black, MargemEsq + 580, PosicaoDaLinha);
            e.Graphics.DrawString("Valor: ", FonteNegrito, Brushes.Black, MargemEsq + 680, PosicaoDaLinha);


            while ((LinhaAtual < LinhasPorPagina && registros > li))
            {
                //obtem os valores do datareader
                tipo = dataGridView1.Rows[li].Cells[0].Value.ToString();
                filial = dataGridView1.Rows[li].Cells[1].Value.ToString();
                documento = dataGridView1.Rows[li].Cells[2].Value.ToString();
                pc = dataGridView1.Rows[li].Cells[3].Value.ToString();
                codigo = dataGridView1.Rows[li].Cells[4].Value.ToString();
                cliente = dataGridView1.Rows[li].Cells[5].Value.ToString();
                emissao = dataGridView1.Rows[li].Cells[6].Value.ToString();
                vencimento = dataGridView1.Rows[li].Cells[7].Value.ToString();
                valor = dataGridView1.Rows[li].Cells[8].Value.ToString();


                ////'impressão dos dados
                //PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString(tipo, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                e.Graphics.DrawString(filial, FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                e.Graphics.DrawString(documento, FonteNormal, Brushes.Black, MargemEsq + 120, PosicaoDaLinha + 15);
                e.Graphics.DrawString(pc, FonteNormal, Brushes.Black, MargemEsq + 200, PosicaoDaLinha + 15);
                e.Graphics.DrawString(codigo, FonteNormal, Brushes.Black, MargemEsq + 270, PosicaoDaLinha + 15);
 
                int cara;
                int l;
                float y = PosicaoDaLinha + 15;
                SizeF linhadeimpressao = new SizeF(150, FonteNormal.Height);

                while (cliente.Length > 0)
                {

                    e.Graphics.MeasureString(cliente, FonteNormal, linhadeimpressao, StringFormat.GenericDefault, out cara, out l);
                    e.Graphics.DrawString(cliente.Substring(0,cara), FonteNormal, Brushes.Black, MargemEsq + 340, y);
                    y = y + 20;
                    break;
  
                }
               
                e.Graphics.DrawString(emissao, FonteNormal, Brushes.Black, MargemEsq + 500, PosicaoDaLinha + 15);
                e.Graphics.DrawString(vencimento, FonteNormal, Brushes.Black, MargemEsq + 580, PosicaoDaLinha + 15);
                e.Graphics.DrawString(valor, FonteNormal, Brushes.Black, MargemEsq + 680, PosicaoDaLinha + 15);

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
                RelatorioTitulo = "Consulta de Banguelas - ";
                //define os objetos printdocument e os eventos associados
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                //IMPORTANTE - definimos 3 eventos para tratar a impressão : PringPage, BeginPrint e EndPrint.
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdRelatorios_PrintPage);
                pd.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.Begin_Print);
                pd.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.End_Print);

                //define o objeto para visualizar a impressao
                PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
                try
                {
                    //define o formulário como maximizado e com Zoom
                    {
                        objPrintPreview.Document = pd;
                        objPrintPreview.WindowState = FormWindowState.Maximized;
                        objPrintPreview.PrintPreviewControl.Zoom = 1;
                        objPrintPreview.Text = "Movimento";
                        objPrintPreview.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo, documento, filial, emissao;
            DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];

            codigo = SelectedRow.Cells[4].Value.ToString();
            documento = SelectedRow.Cells[2].Value.ToString();
            filial = SelectedRow.Cells[1].Value.ToString();
            emissao = SelectedRow.Cells[6].Value.ToString();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                frmConsultaDebito chamar = new frmConsultaDebito(codigo,documento,filial,emissao);
                chamar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um registro!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
