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
    public partial class frmConsultaGerencial : Form
    {
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        String RelatorioTitulo = "Relação de Consulta Gerencial - ";
        int paginaAtual = 1;
        static int li = 0;
        public frmConsultaGerencial()
        {
            InitializeComponent();
        }

        private void frmConsultaGerencial_Load(object sender, EventArgs e)
        {
            dtpData.Text = DateTime.Now.ToString();
            dtpDataF.Text = DateTime.Now.ToString();
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (txtFilial.Text != "")
            {
                DateTime Data = Convert.ToDateTime(dtpData.Text);
                string DataFormato = Data.ToString("s");
                DateTime Data2 = Convert.ToDateTime(dtpDataF.Text);
                string DataFormato2 = Data2.ToString("s");

                SqlCommand cliente = new SqlCommand("select distinct "+                                                  
                    "contas_receber.filial    as cod_filial, "+                           
                    "filial.nome              as filial, "+                               
                    "contas_receber.sequencia as documento, "+                            
                    "contas_receber.cliente   as cod_cliente, "+                          
                    "cli_for.nome             as nome_cliente, "+                         
                    "(select top 1 "+                                                     
                        "aux.emissao "+                                                    
                        "from "+                                                             
                        "contas_receber as aux (nolock) "+                                 
                        "where "+                                                            
                        "aux.tipo in ('R', 'C') and "+                                 
                        "aux.sequencia is not null and "+                                  
                        "aux.sequencia > 0 and "+                                          
                        "aux.conta_cancelada = 0 and "+                                    
                        "aux.filial = contas_receber.filial and "+                         
                        "aux.sequencia = contas_receber.sequencia and "+                   
                        "aux.cliente = contas_receber.cliente) as emissao, "+              
                        "isnull((select "+                                                    
                            "count(1) "+                                                       
                            "from "+                                                             
                            "contas_receber as aux (nolock) "+                                 
                            "where "+                                                            
                            "aux.tipo in ('R') and "+                                        
                            "aux.sequencia is not null and "+                                  
                            "aux.sequencia > 0 and "+                                          
                            "aux.conta_cancelada = 0 and "+                                    
                            "aux.filial = contas_receber.filial and "+                         
                            "aux.sequencia = contas_receber.sequencia and "+                   
                            "aux.cliente = contas_receber.cliente),0) + "+                     
                            "isnull((select "+                                                    
                                "count(1) "+                                                       
                                "from "+                                                             
                                "contas_receber as aux (nolock) "+                                 
                                "where "+                                                            
                                "aux.tipo in ('C') and "+                                        
                                "aux.sequencia is not null and "+                                  
                                "aux.sequencia > 0 and "+                                          
                                "aux.conta_cancelada = 0 and "+                                    
                                "aux.filial = contas_receber.filial and "+                         
                                "aux.sequencia = contas_receber.sequencia and "+                   
                                "aux.cliente = contas_receber.cliente),0) + "+                                                                                    
                                "isnull((select "+                                                    
                                    "count(1) "+                                                       
                                    "from "+                                                             
                                    "contas_receber as aux (nolock) "+                                 
                                    "where "+                                                            
                                    "aux.tipo in ('O') and "+                                        
                                    "aux.sequencia is not null and "+                                  
                                    "aux.sequencia > 0 and "+                                          
                                    "aux.conta_cancelada = 0 and "+                                    
                                    "aux.filial = contas_receber.filial and "+                         
                                    "aux.sequencia = contas_receber.sequencia and "+                   
                                    "aux.cliente = contas_receber.cliente),0) as qtde_parcs, "+                                                                        
                                        "isnull((select "+                                                              
                                            "sum(aux.valor) "+                                                    
                                            "from "+                                                                 
                                            "contas_receber as aux (nolock) "+                                     
                                            "where "+                                                                
                                            "aux.sequencia is not null and "+                                      
                                            "aux.sequencia > 0 and "+                                              
                                            "aux.conta_cancelada = 0 and "+                                       
                                            "aux.filial = contas_receber.filial and "+                            
                                            "aux.sequencia = contas_receber.sequencia and "+                      
                                            "aux.cliente = contas_receber.cliente and "+                          
                                            "aux.data_recebimento is not null and "+                              
                                            "((aux.tipo in ('R', 'C') and (aux.vencimento between contas_receber.emissao and dateadd(day, +1, contas_receber.emissao))) or "+   
                                            "(aux.Tipo = 'O'))), 0.00) as vlr_entrada, "+             
                                            "isnull((select top 1 "+                                             
                                                "aux.valor "+                                              
                                                "from "+                                                     
                                                "contas_receber as aux (nolock) "+                         
                                                "where "+                                                    
                                                "aux.tipo in ('R', 'C') and "+                         
                                                "aux.sequencia is not null and "+                          
                                                "aux.sequencia > 0 and  "+                                 
                                                "aux.conta_cancelada = 0 and "+                            
                                                "aux.filial = contas_receber.filial and "+                 
                                                "aux.sequencia = contas_receber.sequencia and "+            
                                                "aux.cliente = contas_receber.cliente "+                   
                                                "order by "+                                                 
                                                "aux.vencimento desc), 0.00) as vlr_parcela, "+            
                                                "isnull((select top 1 "+                                             
                                                    "func.nome "+                                              
                                                    "from "+                                                     
                                                    "contas_receber as aux (nolock) "+                         
                                                    "inner join funcionarios as func (nolock) "+               
                                                    "on func.codigo = aux.vendedor  "+                       
                                                    "where  "+                                                   
                                                    "aux.tipo in ('R', 'C') and  "+                        
                                                    "aux.sequencia is not null and  "+                         
                                                    "aux.sequencia > 0 and   "+                                
                                                    "aux.conta_cancelada = 0 and   "+                          
                                                    "aux.filial = contas_receber.filial and "+                 
                                                    "aux.sequencia = contas_receber.sequencia and "+           
                                                    "aux.cliente = contas_receber.cliente and "+               
                                                    "aux.vendedor is not null and "+                           
                                                    "aux.vendedor <> 0), '''') as vendedor, "+                  
                                                    "isnull((select top 1 "+                                                      
                                                        "cli_for_credito.cargo  "+                                          
                                                        "from  "+                                                             
                                                        "cli_for_credito (nolock)  "+                                       
                                                        "where   "+                                                           
                                                        "cli_for_credito.codigo = cli_for.codigo), '''') as profissao, "+                                                                  
                                                        "isnull((select  "+                                                  
                                                            "count(1)  "+                                                     
                                                            "from    "+                                                         
                                                            "contas_receber as aux (nolock) "+                                
                                                            "where   "+                                                         
                                                            "aux.tipo in ('R', 'C') and    "+                             
                                                            "aux.sequencia is not null and   "+                               
                                                            "aux.sequencia > 0 and    "+                                      
                                                            "aux.conta_cancelada = 0 and "+                                   
                                                            "aux.filial = contas_receber.filial and  "+                       
                                                            "aux.sequencia = contas_receber.sequencia and   "+                
                                                            "aux.cliente = contas_receber.cliente and  "+                     
                                                            "aux.data_recebimento is null),0) as qtde_parcs_ab  "+                                         
                            "from   "+                                                             
                            "contas_receber (nolock)  "+                                         
                            "inner join parametros_filial as filial (nolock)  "+                 
                            "on filial.codigo = contas_receber.filial  "+                    
                            "inner join cli_for (nolock) "+                                      
                            "on cli_for.codigo = contas_receber.cliente  "+                    
                            "where  "+                                                             
                            "contas_receber.tipo in ('R', 'C') and  "+                       
                            "contas_receber.sequencia is not null and  "+                        
                            "contas_receber.sequencia > 0 and   "+                               
                            "contas_receber.conta_cancelada = 0 and     "+                       
                            "contas_receber.cliente <> 1 and  "+                                 
                            "contas_receber.filial = '"+cmbFilial.Text+"' and   "+
                            "contas_receber.emissao between '" + DataFormato + "' and '" + DataFormato2 + "' " +   
                            "order by  "+
                            "contas_receber.filial,   " +                                         
                            "contas_receber.sequencia", conn2);
                conn2.Open();

                //define o tipo do comando 
                cliente.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = cliente.ExecuteReader();

                //Obtem o número de colunas
                int nColunas = dr.FieldCount;

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
                conn2.Close();
            }
            else
            {
                MessageBox.Show("Obrigatório selecionar filial.","Erro!", MessageBoxButtons.OK,  MessageBoxIcon.Error);
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

            string filial = null;
            string descricao = null;
            string documento = null;
            string cliente = null;
            string nome = null;
            string emissao = null;
            string pcs = null;
            string entrada = null;
            string pago = null;


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

            int registros = dataGridView1.Rows.Count;



            //List<DataRow> clientes = new List<DataRow>();
            //foreach (DataRow dr in dtClientes.Rows)
            //{
            //    clientes.Add(dr);
            //}

            //inicia a impressao
            PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
            e.Graphics.DrawString("Filial: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
            e.Graphics.DrawString("Descrição: ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
            e.Graphics.DrawString("Documento: ", FonteNegrito, Brushes.Black, MargemEsq + 140, PosicaoDaLinha);
            e.Graphics.DrawString("Cliente: ", FonteNegrito, Brushes.Black, MargemEsq + 240, PosicaoDaLinha);
            e.Graphics.DrawString("Nome: ", FonteNegrito, Brushes.Black, MargemEsq + 320, PosicaoDaLinha);
            e.Graphics.DrawString("Emissão: ", FonteNegrito, Brushes.Black, MargemEsq + 470, PosicaoDaLinha);
            e.Graphics.DrawString("Pcs: ", FonteNegrito, Brushes.Black, MargemEsq + 550, PosicaoDaLinha);
            e.Graphics.DrawString("Vlr. Entrada: ", FonteNegrito, Brushes.Black, MargemEsq + 590, PosicaoDaLinha);
            e.Graphics.DrawString("Vlr. Pago: ", FonteNegrito, Brushes.Black, MargemEsq + 690, PosicaoDaLinha);


            while ((LinhaAtual < LinhasPorPagina && registros > li))
            {
                //obtem os valores do datareader
                filial = dataGridView1.Rows[li].Cells[0].Value.ToString();
                descricao = dataGridView1.Rows[li].Cells[1].Value.ToString();
                documento = dataGridView1.Rows[li].Cells[2].Value.ToString();
                cliente = dataGridView1.Rows[li].Cells[3].Value.ToString();
                nome = dataGridView1.Rows[li].Cells[4].Value.ToString();
                emissao = dataGridView1.Rows[li].Cells[5].Value.ToString();
                pcs = dataGridView1.Rows[li].Cells[6].Value.ToString();
                entrada = dataGridView1.Rows[li].Cells[7].Value.ToString();
                pago = dataGridView1.Rows[li].Cells[8].Value.ToString();
       

       

                e.Graphics.DrawString(filial, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                e.Graphics.DrawString(descricao, FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                e.Graphics.DrawString(documento, FonteNormal, Brushes.Black, MargemEsq + 140, PosicaoDaLinha + 15);
                e.Graphics.DrawString(cliente, FonteNormal, Brushes.Black, MargemEsq + 240, PosicaoDaLinha + 15);
                int cara;
                int l;
                float y = PosicaoDaLinha + 15;
                SizeF linhadeimpressao = new SizeF(150, FonteNormal.Height);

                while (cliente.Length > 0)
                {

                    e.Graphics.MeasureString(nome, FonteNormal, linhadeimpressao, StringFormat.GenericDefault, out cara, out l);
                    e.Graphics.DrawString(nome.Substring(0, cara), FonteNormal, Brushes.Black, MargemEsq + 320, y);
                    y = y + 20;
                    break;

                }
                e.Graphics.DrawString(emissao, FonteNormal, Brushes.Black, MargemEsq + 470, PosicaoDaLinha + 15);
                e.Graphics.DrawString(pcs, FonteNormal, Brushes.Black, MargemEsq + 550, PosicaoDaLinha + 15);
                e.Graphics.DrawString(entrada, FonteNormal, Brushes.Black, MargemEsq + 590, PosicaoDaLinha + 15);
                e.Graphics.DrawString(pago, FonteNormal, Brushes.Black, MargemEsq + 690, PosicaoDaLinha + 15);

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
                RelatorioTitulo = "Consulta Gerencial - ";
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
    }
}
