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

namespace Visomax
{
    public partial class frmBordero : Form
    {
        public frmBordero()
        {
            InitializeComponent();
        }

        /*Este construtor é utilizado no duplo clique da grid do frmBuscaBordero. Os dados recebidos por parâmetros (vindos da linha clicada na grid)
          são passados para este form para serem utilizados na pesquisa (SELECT). */
        public frmBordero(int idCobradora, String nomeCobradora, String acaoCobranca, int numeroBordero, String data, String quantidadeDocumentos)
        {
            InitializeComponent();
            txtNumeroCobradora.Text = idCobradora.ToString();
            txtNomeCobradora.Text = nomeCobradora;
            txtAcaoCobranca.Text = acaoCobranca;
            txtBordero.Text = numeroBordero.ToString();
            txtData.Text = data;
            txtQtdeDocumentos.Text = quantidadeDocumentos;

            preencheGridBordero(txtAcaoCobranca.Text, int.Parse(txtNumeroCobradora.Text), int.Parse(txtBordero.Text));
        }

        /* Faz a abertura da tela de busca do borderô e fecha este form, para que o mesmo não seja aberto repetidamento quando receber dados
           tela de busca. */
        private void btnBuscarBordero_Click(object sender, EventArgs e)
        {
            frmBuscarBordero fbb = new frmBuscarBordero();
            this.Hide();
            fbb.ShowDialog();
            this.Close();
        }

        private void preencheGridBordero(String descricaoCobranca, int idCobradora, int numeroBordero)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                String query = "SELECT filial, sequencia, id_cob_portador, cliente FROM cobranca_docto_evento WHERE descricao = '" + descricaoCobranca + "' AND tipo_cob_portador = 'C' AND id_cob_portador = '" + idCobradora + "' AND num_bordero = '" + numeroBordero + "'";

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    gridBordero.Rows.Add(sdr["filial"].ToString(), sdr["sequencia"].ToString(), sdr["id_cob_portador"].ToString(), sdr["cliente"]);
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show("Erro no preenchimento dos dados do borderô", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}