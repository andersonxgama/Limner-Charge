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
    public partial class frmBuscarBordero : Form
    {
        public frmBuscarBordero()
        {
            InitializeComponent();
        }

        private void frmBuscarBordero_Load(object sender, EventArgs e)
        {
            carregaComboCobradoras();
            lblCobradora.Enabled = false;
            cmbCobradoras.Enabled = false;
            lblBorderoDe.Enabled = false;
            lblBorderoAte.Enabled = false;
            txtBorderoDe.Enabled = false;
            txtBorderoAte.Enabled = false;
            lblDataDe.Enabled = false;
            lblDataAte.Enabled = false;
            dataDeBordero.Enabled = false;
            dataAteBordero.Enabled = false;
        }

        //Clique do botão buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grdBuscaBordero.Rows.Clear();

            if(verificaCampos())
            {
                //Se nenhuma das checkbox estirem preenchidas
                if((!chkCobradora.Checked) && (!chkBordero.Checked) && (!chkData.Checked) && (chkEnvioCobradora.Checked) && (chkRetornoCobradora.Checked))
                {
                    preencheGrid();

                    for(int i = 0; i < grdBuscaBordero.Rows.Count; i++)
                    {
                        preencheGridColunaCobradora(grdBuscaBordero.Rows[i].Cells[1].Value.ToString(), i);
                    }
                }
                else
                {
                    String cobradora;
                    String borderoDe, borderoAte;

                    if(chkCobradora.Checked)
                    {
                        cobradora = cmbCobradoras.SelectedItem.ToString();
                    }
                    else
                    {
                        cobradora = "";
                    }

                    if(chkBordero.Checked)
                    {
                        if (txtBorderoDe.Text.Equals(""))
                        {
                            borderoDe = "";
                        }
                        else
                        {
                            borderoDe = txtBorderoDe.Text;
                        }

                        if (txtBorderoAte.Text.Equals(""))
                        {
                            borderoAte = "";
                        }
                        else
                        {
                            borderoAte = txtBorderoAte.Text;
                        }
                    }
                    else
                    {
                        borderoDe = "";
                        borderoAte = "";
                    }

                    buscaBorderoFiltros.preencheGridFiltrada(cobradora, borderoDe, borderoAte, dataDeBordero, dataAteBordero, grdBuscaBordero, chkData, chkEnvioCobradora, chkRetornoCobradora);
                    buscaBorderoFiltros.preencheColunaCobradora(grdBuscaBordero);

                    if (grdBuscaBordero.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum dado encontrado", "Busca Borderô", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //Clique do botão "Limpar"
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            grdBuscaBordero.Rows.Clear();
        }

        //Método que preenche a coluna Cobradora (nome), de acordo com o ID (que vem da coluna Código) recebido por parâmetro
        private void preencheGridColunaCobradora(String idCobradora, int linha)
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                String query = "SELECT descricao FROM Cobradoras WHERE id_cob_portador = '" + Convert.ToInt32(idCobradora) + "' AND tipo_cob_portador = 'C';";

                SqlCommand cmd = new SqlCommand(query, sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    grdBuscaBordero.Rows[linha].Cells[2].Value = sdr["descricao"].ToString();
                }

                sdr.Close();
            }
            catch(SqlException se)
            {
                MessageBox.Show("Erro ao pesquisar o nome da cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Método que preenche a grid quando não há nenhuma checkbox selecionada
        private void preencheGrid()
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                String query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();
                DateTime data;

                while (sdr.Read())
                {
                    data = DateTime.Parse(sdr["dt_geracao"].ToString());
                    grdBuscaBordero.Rows.Add(sdr["desc_acao"], sdr["idPortador"].ToString(), "", sdr["numBordero"].ToString(), data.ToString("dd/MM/yyyy"), sdr["qtde"].ToString());
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show("Ocorreu um erro ao preencher a grid", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Método que faz o carregamento (evento load) das cobradoras
        private void carregaComboCobradoras()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT descricao FROM Cobradoras WHERE tipo_cob_portador = 'C'", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    cmbCobradoras.Items.Add(sdr.GetValue(0).ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar a lista de cobradoras", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Ao dar um duplo clique em uma das linhas da grid
        private void grdBuscaBordero_DoubleClick(object sender, EventArgs e)
        {
            int idCobradora = buscaBorderoFiltros.retornaIdCobradora(grdBuscaBordero.CurrentRow.Cells[2].Value.ToString());
            String nomeCobradora = grdBuscaBordero.CurrentRow.Cells[2].Value.ToString();
            String acaoCobranca = grdBuscaBordero.CurrentRow.Cells[0].Value.ToString();
            int numeroBordero = int.Parse(grdBuscaBordero.CurrentRow.Cells[3].Value.ToString());
            String data = grdBuscaBordero.CurrentRow.Cells[4].Value.ToString();
            String quantidade = grdBuscaBordero.CurrentRow.Cells[5].Value.ToString();

            this.Hide();

            frmBordero fb = new frmBordero(idCobradora, nomeCobradora, acaoCobranca, numeroBordero, data, quantidade);
            fb.ShowDialog();

            this.Close();
        }

        //O método faz as verificações de preenchimento da combo, txtborderô (de/até) e datas. O método é utilizado no clique de busca.
        private Boolean verificaCampos()
        {
            Boolean verificacao = false;

            if((!chkEnvioCobradora.Checked) && (!chkRetornoCobradora.Checked))
            {
                MessageBox.Show("As opções \"Envio a cobradora\" e \"Retorno a cobradora\" não foram selecionadas, é necessário selecionar uma delas (ou ambas)", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if((chkCobradora.Checked) && (cmbCobradoras.SelectedIndex == -1))
            {
                MessageBox.Show("É necessário selecionar uma das cobradoras", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(dataDeBordero.Value > dataAteBordero.Value)
            {
                MessageBox.Show("A data \"de\" não poder ser maior que a data \"até\"", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(chkBordero.Checked)
                {
                    if ((txtBorderoDe.Text.Equals("")) && (txtBorderoAte.Text.Equals("")))
                    {
                        MessageBox.Show("Nenhum parâmetro (de/até) foi atribuído ao borderô", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            if (int.Parse(txtBorderoDe.Text) > int.Parse(txtBorderoAte.Text))
                            {
                                MessageBox.Show("O número inicial do borderô não pode ser maior que o final", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch (FormatException)
                        {
                            verificacao = true;
                        }
                    }
                }

                verificacao = true;
            }

            return verificacao;
        }

        //Clique da checkbox "Cobradora"
        private void chkCobradora_Click(object sender, EventArgs e)
        {
            if (chkCobradora.Checked)
            {
                lblCobradora.Enabled = true;
                cmbCobradoras.Enabled = true;
            }
            else
            {
                lblCobradora.Enabled = false;
                cmbCobradoras.SelectedIndex = -1;
                cmbCobradoras.Enabled = false;
            }
        }

        //Clique da checkbox "Borderô"
        private void chkBordero_Click(object sender, EventArgs e)
        {
            if (chkBordero.Checked)
            {
                lblBorderoDe.Enabled = true;
                lblBorderoAte.Enabled = true;
                txtBorderoDe.Enabled = true;
                txtBorderoAte.Enabled = true;
            }
            else
            {
                lblBorderoDe.Enabled = false;
                lblBorderoAte.Enabled = false;
                txtBorderoDe.Clear();
                txtBorderoAte.Clear();
                txtBorderoDe.Enabled = false;
                txtBorderoAte.Enabled = false;
            }
        }

        //Clique da checkbox "Data"
        private void chkData_Click(object sender, EventArgs e)
        {
            if (chkData.Checked)
            {
                lblDataDe.Enabled = true;
                lblDataAte.Enabled = true;
                dataDeBordero.Enabled = true;
                dataAteBordero.Enabled = true;
            }
            else
            {
                lblDataDe.Enabled = false;
                lblDataAte.Enabled = false;
                dataDeBordero.Value = DateTime.Today;
                dataAteBordero.Value = DateTime.Today;
                dataDeBordero.Enabled = false;
                dataAteBordero.Enabled = false;
            }
        }
    }
}