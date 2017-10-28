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
using System.Collections;

namespace Visomax
{
    public partial class frmBuscaCartões : Form
    {
        String RelatorioTitulo = "Recebimento de caixas - ";
        int paginaAtual = 1;
        static int li = 0;
        
        public frmBuscaCartões()
        {
            InitializeComponent();
        }

        //Método que faz o carregamento inicial do form
        private void frmBuscaCartões_Load(object sender, EventArgs e)
        {
            lblAguarde.Visible = false;
        }

        //Clique do botão buscar que Importa dos dados para a grid
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblAguarde.Visible = true;
            lblAguarde.Refresh();
            ArrayList listaNumerosAutorizacao = retornaListaNumerosAutorizacao();
            int linha = 0;
            gridBuscaCartoes.Rows.Add();

            foreach (String numeroAutorizacao in listaNumerosAutorizacao)
            {
                gridBuscaCartoes.Rows[linha].Cells[2].Value = numeroAutorizacao;
                linha++;
                gridBuscaCartoes.Rows.Add();
            }

            ArrayList listaValores = preencheGridDadosCielo(listaNumerosAutorizacao);
            preencheGridDadosShop(listaNumerosAutorizacao);

            for (int i = 0; i < gridBuscaCartoes.Rows.Count; i++)
            {
                if ((gridBuscaCartoes.Rows[i].Cells[0].Value == null) || (gridBuscaCartoes.Rows[i].Cells[1].Value == null))
                {
                    gridBuscaCartoes.Rows[i].Cells[0].Value = "Não informado";
                    gridBuscaCartoes.Rows[i].Cells[1].Value = "Não informado";
                }
            }

            double soma = 0;

            foreach (String valor in listaValores)
            {
                soma += Double.Parse(valor);
            }

            txtTotal.Text = soma.ToString();

            gridBuscaCartoes.Rows.RemoveAt(gridBuscaCartoes.RowCount - 1);
            lblAguarde.Visible = false;
        }

        //Duplo clique na linha da grid
        private void gridBuscaCartoes_DoubleClick(object sender, EventArgs e)
        {
            String filial = gridBuscaCartoes.CurrentRow.Cells[0].Value.ToString();
            String sequencia = gridBuscaCartoes.CurrentRow.Cells[1].Value.ToString();
            String autorizacao = gridBuscaCartoes.CurrentRow.Cells[2].Value.ToString();
            String dataVenda = gridBuscaCartoes.CurrentRow.Cells[3].Value.ToString();
            String dataEfetiva = gridBuscaCartoes.CurrentRow.Cells[4].Value.ToString();
            String descricao = gridBuscaCartoes.CurrentRow.Cells[5].Value.ToString();
            String valorBruto = gridBuscaCartoes.CurrentRow.Cells[6].Value.ToString();

            if((filial.Equals("Não informado")) || (sequencia.Equals("Não informado")))
            {
                MessageBox.Show("Não é possível fazer a busca. Filial e/ou sequência não foram informados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //this.Hide();

                frmInformacoesCartao fic = new frmInformacoesCartao(filial, sequencia, autorizacao, dataVenda, dataEfetiva, valorBruto, descricao);
                fic.ShowDialog();

            }
        }

        //Retorna uma lista do(s) número(s) da(s) autorização(ções) que foram inseridos entre as datas especificadas na busca
        private ArrayList retornaListaNumerosAutorizacao()
        {
            SqlConnection conexaoCielo = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            ArrayList listaNumerosAutorizacao = new ArrayList();

            try
            {
                conexaoCielo.Open();

                String query = "SELECT CodigoAutorizacao FROM Adm_Cartoes_Cielo where DataEfetiva between '" + dtDataInicial.Value.ToString("yyyy-MM-dd") + "' and '" + dtDataFinal.Value.ToString("yyyy-MM-dd") + "'";

                SqlCommand cmd = new SqlCommand(query, conexaoCielo);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    listaNumerosAutorizacao.Add(sdr["CodigoAutorizacao"]);
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Falha ao retornar o número da autorização", "Autorização - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoCielo.Close();
            }

            return listaNumerosAutorizacao;
        }

        /*O método preenche a grid com os dados da Cielo de acordo com a lista de números de autorização passado por parâmetro.
        O mesmo é utilizado no clique do botão busca.*/
        private ArrayList preencheGridDadosCielo(ArrayList listaNumerosAutorizacao)
        {
            SqlConnection conexaoCielo = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            ArrayList listaValores = new ArrayList();

            try
            {
                conexaoCielo.Open();
                int linha = 0;

                foreach (String numero in listaNumerosAutorizacao)
                {
                    String query = "SELECT DataVenda, Descricao, DataEfetiva, ValorBruto, Rejeitado FROM Adm_Cartoes_Cielo WHERE CodigoAutorizacao = '" + gridBuscaCartoes.Rows[linha].Cells[2].Value + "'";

                    SqlCommand cmd = new SqlCommand(query, conexaoCielo);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        gridBuscaCartoes.Rows[linha].Cells[3].Value = Convert.ToDateTime(sdr["DataVenda"].ToString()).ToString("dd/MM/yyyy");
                        gridBuscaCartoes.Rows[linha].Cells[4].Value = Convert.ToDateTime(sdr["DataEfetiva"].ToString()).ToString("dd/MM/yyyy");
                        gridBuscaCartoes.Rows[linha].Cells[5].Value = sdr["Descricao"];
                        listaValores.Add(sdr["ValorBruto"].ToString());
                        gridBuscaCartoes.Rows[linha].Cells[6].Value = sdr["ValorBruto"].ToString().Replace(".", ",");
                        gridBuscaCartoes.Rows[linha].Cells[7].Value = sdr["Rejeitado"];
                        linha++;
                    }

                    sdr.Close();
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Falha ao preencher grid com dados da Cielo", "Cielo - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoCielo.Close();
            }

            return listaValores;
        }

        /*O método preenche a grid com os dados do Shop (Tabela Saidas_Recebimento) de acordo com a lista de números de autorização passado por parâmetro.
        O mesmo é utilizado no clique do botão busca.*/
        private void preencheGridDadosShop(ArrayList listaNumerosAutorizacao)
        {
            SqlConnection conexaoShop = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

            try
            {
                conexaoShop.Open();
                int linha = 0;

                foreach (String numero in listaNumerosAutorizacao)
                {
                    var autorizacao = gridBuscaCartoes.Rows[linha].Cells[2].Value.ToString();


                    String query = "SELECT Filial, Sequencia FROM Saidas_Recebimento WHERE Num_Cartao = '" + autorizacao.Replace(" ","") + "'";
                    

                    SqlCommand cmd = new SqlCommand(query, conexaoShop);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        gridBuscaCartoes.Rows[linha].Cells[0].Value = sdr["Filial"].ToString();
                        gridBuscaCartoes.Rows[linha].Cells[1].Value = sdr["Sequencia"].ToString();
                    }

                    linha++;
                    sdr.Close();
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Falha ao preencher grid com dados do Shop 8\n" + se.Message, "Shop 8 - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoShop.Close();
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

            int registros = gridBuscaCartoes.Rows.Count - 1;

          
                //inicia a impressao
                PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString("Filial ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
                e.Graphics.DrawString("Sequencia ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
                e.Graphics.DrawString("Autorização ", FonteNegrito, Brushes.Black, MargemEsq + 140, PosicaoDaLinha);
                e.Graphics.DrawString("Dt Venda ", FonteNegrito, Brushes.Black, MargemEsq + 240, PosicaoDaLinha);
                e.Graphics.DrawString("Dt Efetiva", FonteNegrito, Brushes.Black, MargemEsq + 340, PosicaoDaLinha);
                e.Graphics.DrawString("Descrição ", FonteNegrito, Brushes.Black, MargemEsq + 430, PosicaoDaLinha);
                e.Graphics.DrawString("Valor Bruto ", FonteNegrito, Brushes.Black, MargemEsq + 600, PosicaoDaLinha);
                e.Graphics.DrawString("Rejeitado ", FonteNegrito, Brushes.Black, MargemEsq + 690, PosicaoDaLinha);


                while ((LinhaAtual < LinhasPorPagina && registros > li))
                {
                    if (gridBuscaCartoes.Rows[li].Cells[0].Value.ToString() == "Não informado")
                    {
                        e.Graphics.DrawString("", FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                    }
                    else
                    {
                        e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[0].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                    }
                    if (gridBuscaCartoes.Rows[li].Cells[1].Value.ToString() == "Não informado")
                    {
                        e.Graphics.DrawString("", FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                    }
                    else
                    {
                        e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[1].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                    }
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[2].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 140, PosicaoDaLinha + 15);
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[3].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 240, PosicaoDaLinha + 15);
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[4].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 340, PosicaoDaLinha + 15);
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[5].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 430, PosicaoDaLinha + 15);
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[6].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 600, PosicaoDaLinha + 15);
                    e.Graphics.DrawString(gridBuscaCartoes.Rows[li].Cells[7].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 690, PosicaoDaLinha + 15);


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
            if (gridBuscaCartoes.Rows.Count == 0)
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
    }
}