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
using System.Security.Principal;

namespace Visomax
{
    public partial class frmAlterarHistoricoCobranca : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        string evento;
        public frmAlterarHistoricoCobranca()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtObservacaoAlteracao.Text == "")
            {
                MessageBox.Show("A observação deve ser preenchida","Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {

                WindowsIdentity usuario = WindowsIdentity.GetCurrent();
                string name = usuario.Name;

                //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
                SqlCommand Nome = new SqlCommand("UPDATE cobranca_docto_resposta SET id_cob_resposta = '" + cmbResposta.Text + "', " +
                    "observacao = '" + txtObservacaoAlteracao.Text + "', usuario = '"+name+"' " +
                    "where id_cob_doc_evento = '" + evento + "'", conn);
                try
                {
                    conn.Open();
                    Nome.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Dado gravado!", "Gravado!", MessageBoxButtons.OKCancel);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel gravar!", "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbResposta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            SqlCommand Nome = new SqlCommand("SELECT descricao  FROM cobranca_resposta "+
                "where id_cob_resposta = '"+cmbResposta.Text+"'", conn);
            conn.Open();
            SqlDataReader nome = Nome.ExecuteReader();
            while (nome.Read())
            {
                txtresposta.Text = Convert.ToString(nome.GetValue(0));
            }
            conn.Close();
        }

        private void frmAlterarHistoricoCobranca_Load(object sender, EventArgs e)
        {
            //Comando sql para buscar o código das filiais
            SqlCommand Combo = new SqlCommand("SELECT id_cob_resposta  FROM cobranca_resposta ", conn);
            conn.Open();
            SqlDataReader leitor = Combo.ExecuteReader();
            while (leitor.Read())
            {
                cmbResposta.Items.Add(leitor.GetValue(0));
            }
            conn.Close();
        }
        public frmAlterarHistoricoCobranca(DataGridViewRow row, string codcli, string cli)
        {
            InitializeComponent();
            string filial = row.Cells[1].Value.ToString();
            string sequencia = row.Cells[2].Value.ToString();
            string parcela = row.Cells[3].Value.ToString();
            evento = row.Cells[0].Value.ToString();

            txtFilial.Text = filial;
            txtDocumento.Text = sequencia;
            txtParcela.Text = parcela;
            txtCodCli.Text = codcli;
            txtNomeCli.Text = cli;

            SqlCommand evt = new SqlCommand("SELECT id_cob_resposta, observacao "+
                "from cobranca_docto_resposta where id_cob_doc_evento = '"+evento+"'", conn);

            conn.Open();

            //datareader recebe busca
            SqlDataReader descricao = evt.ExecuteReader();

            //enquanto tiver oque ler
            while (descricao.Read())
            {

                txtObservacaoAlteracao.Text = descricao["observacao"].ToString();
                cmbResposta.Text = descricao["id_cob_resposta"].ToString();
            }

            conn.Close();
            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            SqlCommand Nome = new SqlCommand("SELECT descricao  FROM cobranca_resposta " +
                "where id_cob_resposta = '" + cmbResposta.Text + "'", conn);
            conn.Open();
            SqlDataReader nome = Nome.ExecuteReader();
            while (nome.Read())
            {
                txtresposta.Text = Convert.ToString(nome.GetValue(0));
            }
            conn.Close();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtObservacaoAlteracao.Text = "";
            cmbResposta.Text = "";
            txtresposta.Text = "";
        }
    }
}
