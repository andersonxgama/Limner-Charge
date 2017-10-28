using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Visomax
{
    public partial class frmAdmCartoes : Form
    {
        public frmAdmCartoes()
        {
            InitializeComponent();
        }

        //Faz as configurações iniciais ao abrir o form
        private void frmAdmCartoes_Load(object sender, EventArgs e)
        {
            //O botão está desabilitado, pois o cliente não resolveu as pendências referentes ao relatório Redecard.
            optRedecard.Enabled = false;
            
            btnBuscar.Enabled = false;
            btnGravar.Enabled = false;
            btnLimpar.Enabled = false;
            //btnImprimir.Enabled = false;
        }

        //Importa o arquivo com as informações e mostra o caminho na caixa de texto
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txtDocumento.Text = ofd.FileName;

            if (!Path.GetExtension(txtDocumento.Text).Equals(".csv") && optCielo.Checked == true)//Verifica se extensão do arquivo é ".csv"
            {
                txtDocumento.Clear();
                MessageBox.Show("O arquivo importado deve estar no formato \".csv\" ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!Path.GetExtension(txtDocumento.Text).Equals(".xls") && optRedecard.Checked == true)//Verifica se extensão do arquivo é ".xls"
                {
                    txtDocumento.Clear();
                    MessageBox.Show("O arquivo importado deve estar no formato \".xls\" ", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //Importa os dados do arquivo carregado na "txtDocumento" para a grid
        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Primeiramente é necessário importar o arquivo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                gridCielo.Rows.Clear();
                gridRedecard.Rows.Clear();

                if (optCielo.Checked == true)
                {
                    StreamReader sr = new StreamReader(@txtDocumento.Text,Encoding.Default);

                    while (!sr.EndOfStream)//Importa o arquivo ".csv" p/ a grid
                    {
                        var fields = sr.ReadLine().Replace("\"", "").Split(';');
                        gridCielo.Rows.Add(fields);
                    }

                    sr.Close();

                    //Remove as linhas excedentes (título e dados não necessários) da grid
                    gridCielo.Rows.RemoveAt(0);
                    gridCielo.Rows.RemoveAt(1);
                    gridCielo.Rows.RemoveAt(0);
                }
                else
                {
                    StreamReader sr = new StreamReader(@txtDocumento.Text,Encoding.Default);

                    while (!sr.EndOfStream)//Importa o arquivo ".xls" p/ a grid
                    {
                        var fields = sr.ReadLine().Split('\t');
                        gridRedecard.Rows.Add(fields);
                    }

                    sr.Close();

                    //Remove as linhas excedentes (título e dados não necessários) da grid
                    gridRedecard.Rows.RemoveAt(0);
                    gridRedecard.Rows.RemoveAt(gridRedecard.RowCount - 1);
                    gridRedecard.Rows.RemoveAt(gridRedecard.RowCount - 1);
                }
            }

            if ((gridCielo.Rows.Count != 0) || (gridRedecard.Rows.Count != 0))
            {
                btnGravar.Enabled = true;
                btnLimpar.Enabled = true;
            }
        }

        //Clique do botão de opção "Cielo"
        private void optCielo_Click(object sender, EventArgs e)
        {
            gridCielo.Visible = true;
            gridRedecard.Visible = false;
            btnBuscar.Enabled = true;
            txtDocumento.Text = "";
            gridRedecard.Rows.Clear();
        }

        //Clique do botão de opção "Redecard"
        private void optRedecard_Click(object sender, EventArgs e)
        {
            gridRedecard.Visible = true;
            gridCielo.Visible = false;
            btnBuscar.Enabled = true;
            txtDocumento.Text = "";
            gridCielo.Rows.Clear();
        }

        //Salva a grid p/ o banco de dados
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((optCielo.Checked == true) && (gridCielo.Rows.Count >= 0))
            {
                int codigo = retornaUltimoIdCielo();
                DateTime dataVenda;
                DateTime dataEfetiva;
                SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
                sc.Open();

                String query = "";

                try
                {
                    for (int i = 0; i < gridCielo.Rows.Count; i++)//Insere dados na grid da Cielo
                    {
                        dataVenda = DateTime.Parse(gridCielo.Rows[i].Cells[0].Value.ToString());
                        dataEfetiva = DateTime.Parse(gridCielo.Rows[i].Cells[1].Value.ToString());

                        query = "INSERT INTO Adm_Cartoes_Cielo (Codigo, DataVenda, DataEfetiva, Descricao, Resumo, NumCartaoTid, NsuDoc, CodigoAutorizacao, ValorBruto, Rejeitado, ValorSaque) VALUES (" +
                            " ' " + codigo++ + "', " +
                            " ' " + dataVenda.ToString("yyyy-MM-dd") + "', " +// DataVenda - date
                            " ' " + dataEfetiva.ToString("yyyy-MM-dd") + "', " +// DataEfetiva - date
                            " ' " + gridCielo.Rows[i].Cells[2].Value.ToString() + "', " +// Descricao - varchar(50)
                            " ' " + gridCielo.Rows[i].Cells[3].Value + "', " +// Resumo - int
                            " ' " + gridCielo.Rows[i].Cells[4].Value.ToString() + "', " +// NumCartaoTid - varchar(30)
                            " ' " + gridCielo.Rows[i].Cells[5].Value + "', " +// NsuDoc - int
                            " ' " + gridCielo.Rows[i].Cells[6].Value.ToString() + "', " +// CodigoAutorizacao - varchar(20)
                            " ' " + SqlDecimal.Parse(gridCielo.Rows[i].Cells[7].Value.ToString().Replace(".", "").Replace(",", ".")) + "', " +// ValorBruto - decimal(6,2)
                            " ' " + gridCielo.Rows[i].Cells[8].Value.ToString() + "', " +// Rejeitado - varchar(5)
                            " ' " + SqlDecimal.Parse(gridCielo.Rows[i].Cells[9].Value.ToString().Replace(".", "").Replace(",", ".")) + "')";// ValorSaque - decimal(6,2)

                        SqlCommand cmd = new SqlCommand(query, sc);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados gravados com sucesso!", "Administração de cartões", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados da Cielo", "Erro - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sc.Close();
                }
            }
            else
            {
                if ((optRedecard.Checked == true) && (gridRedecard.Rows.Count >= 0))//Insere dados na grid da Redecard (a gridRedecard está localizada atrás da gridCielo)
                {
                    int codigo = retornaUltimoIdRedecard();
                    DateTime DataVenda;
                    DateTime DataRecebimento;
                    SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
                    sc.Open();

                    String query = "";

                    try
                    {
                        for (int i = 0; i < gridRedecard.Rows.Count; i++)
                        {
                            DataVenda = DateTime.Parse(gridRedecard.Rows[i].Cells[1].Value.ToString());
                            DataRecebimento = DateTime.Parse(gridRedecard.Rows[i].Cells[2].Value.ToString());

                            query = "INSERT INTO Adm_Cartoes_Redecard (Codigo, Numero_estabelecimento, Data_Venda, Data_Recebimento, Prazo_Recebimento, Resumo_Vendas, Quantidade_Vendas, Bandeira, Valor_Bruto) VALUES (" +
                                " ' " + codigo++ + "', " +
                                " ' " + gridRedecard.Rows[i].Cells[0].Value + "', " +//Numero_estabelecimento
                                " ' " + DataVenda.ToString("yyyy-MM-dd") + "', " +//Data_Venda
                                " ' " + DataRecebimento.ToString("yyyy-MM-dd") + "', " +//Data_Recebimento
                                " ' " + gridRedecard.Rows[i].Cells[3].Value.ToString() + "', " +//Prazo_Recebimento
                                " ' " + gridRedecard.Rows[i].Cells[4].Value + "', " +//Resumo_Vendas
                                " ' " + gridRedecard.Rows[i].Cells[5].Value + "', " +//Quantidade_Vendas
                                " ' " + gridRedecard.Rows[i].Cells[6].Value.ToString() + "', " +//Bandeira
                                " ' " + SqlDecimal.Parse(gridRedecard.Rows[i].Cells[7].Value.ToString().Replace(".", "").Replace(",", ".")) + "')";//Valor_Bruto

                            SqlCommand cmd = new SqlCommand(query, sc);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Dados gravados com sucesso!", "Administração de cartões", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        //MessageBox.Show("Erro ao carregar os dados da Redecard", "Erro - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(ex.Message, "Erro - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        sc.Close();
                    }
                }
            }
        }

        //Limpa a(s) grid(s) e faz a configuração do form a seu estado inicial
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            optCielo.Checked = false;
            optRedecard.Checked = false;
            txtDocumento.Text = "";
            btnBuscar.Enabled = false;
            gridCielo.Rows.Clear();
            gridRedecard.Rows.Clear();
            btnGravar.Enabled = false;
            btnLimpar.Enabled = false;
        }

        //Método retorna último número da coluna "Codigo" da tabela Adm_Cartoes_Cielo
        private int retornaUltimoIdCielo()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            int codigo = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM Adm_Cartoes_Cielo", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    codigo = Convert.ToInt32(sdr[0]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar o código (ID - Cielo)", "Erro - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.Close();
            }

            return codigo;
        }

        //Método que retorna último número da coluna "Codigo" da tabela Adm_Cartoes_Redecard
        private int retornaUltimoIdRedecard()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            int codigo = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT (*) FROM Adm_Cartoes_Redecard", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    codigo = Convert.ToInt32(sdr[0]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar o código (ID - Redecard)", "Erro - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.Close();
            }

            return codigo;
        }

        //Remove acentos da palavra passada por parâmetro e retorna a mesma.
        public static string removeAcentos(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}