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
    public partial class frmHistoricoCobranca : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);

        public frmHistoricoCobranca()
        {
            InitializeComponent();
        }

        //Faz a abertura da tela dos dados cadastrais
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCobranca.Text != "")
            {
                DataGridViewRow SelectedRow = gridHistoricoCobranca.SelectedRows[0];
                string codcli = txtCodigoCliente.Text;
                string cli = txtNomeCliente.Text;

                frmAlterarHistoricoCobranca fahc = new frmAlterarHistoricoCobranca(SelectedRow, codcli, cli);
                fahc.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Erro ao abrir", "ERRO!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void frmHistoricoCobranca_Load(object sender, EventArgs e)
        {

        }

        public frmHistoricoCobranca (int cliente)
        {
            InitializeComponent();
            int cli = cliente;

            SqlCommand buscacliente = new SqlCommand("SELECT Codigo, Nome "+
                "FROM Cli_For "+
                "where Codigo = '"+cli+"'", conn);

            conn.Open();

            //datareader recebe busca
            SqlDataReader nome = buscacliente.ExecuteReader();

            //enquanto tiver oque ler
            while (nome.Read())
            {

                txtCodigoCliente.Text = nome["Codigo"].ToString();
                txtNomeCliente.Text = nome["Nome"].ToString();
            }

            conn.Close();

            SqlCommand grid = new SqlCommand("SELECT id_cob_doc_evento, filial,  sequencia,  parcela, descricao," +
                "dt_geracao " +
                "FROM cobranca_docto_evento where cliente = '" + txtNomeCliente.Text + "'", conn2);

            conn2.Open();

            //define o tipo do comando 
            grid.CommandType = CommandType.Text;
            //obtem um datareader
            IDataReader dr = grid.ExecuteReader();

            //Obtem o número de colunas
            int nColunas = dr.FieldCount;
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

                    gridHistoricoCobranca.Rows.Add(linhaDados);

            }
            conn2.Close();


        }

        private void gridHistoricoCobranca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridHistoricoCobranca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow SelectedRow = gridHistoricoCobranca.SelectedRows[0];
            string gridcob = SelectedRow.Cells[0].Value.ToString();

            SqlCommand Cobranca = new SqlCommand("SELECT id_cob_doc_evento, tipo_cob_portador, pendente, automatico, "+
                "num_bordero, usuario, dt_criacao, dt_execucao "+
                 "FROM cobranca_docto_evento where id_cob_doc_evento = '" + gridcob + "'", conn2);

            conn2.Open();

            //datareader recebe busca
            SqlDataReader cob = Cobranca.ExecuteReader();

            //enquanto tiver oque ler
            while (cob.Read())
            {

                txtCodigoCobranca.Text = cob["id_cob_doc_evento"].ToString();
                txtPortador.Text = cob["tipo_cob_portador"].ToString();
                txtPendente.Text = cob["pendente"].ToString();
                txtAutomatico.Text = cob["automatico"].ToString();
                txtBordero.Text = cob["num_bordero"].ToString();
                txtUsuario.Text = cob["Usuario"].ToString();
                txtDataCriacao.Text = cob["dt_criacao"].ToString();
                txtDataExecucao.Text = cob["dt_execucao"].ToString();
            }

            conn2.Close();

            SqlCommand resposta = new SqlCommand("SELECT sequencial, id_cob_resposta, dt_resposta, dt_criacao, observacao, usuario "+
                "FROM cobranca_docto_resposta "+
                "where id_cob_doc_evento = '"+txtCodigoCobranca.Text+"'", conn2);

            conn2.Open();

            //datareader recebe busca
            SqlDataReader res = resposta.ExecuteReader();

            //enquanto tiver oque ler
            while (res.Read())
            {
                txtRespostaUm.Text = res["sequencial"].ToString();
                txtResposta.Text = res["id_cob_resposta"].ToString();
                txtDataResposta.Text = res["dt_resposta"].ToString();
                txtObservacao.Text = res["observacao"].ToString();
                txtCriacao.Text = res["dt_criacao"].ToString();
                txtUsuario2.Text = res["usuario"].ToString();
 
            }

            conn2.Close();

            SqlCommand portador = new SqlCommand("SELECT cobranca_docto_evento.tipo_cob_portador, "+
                "cobranca_docto_evento.id_cob_portador, cobranca_portador.descricao "+
                "FROM cobranca_docto_evento, cobranca_portador "+
                "where cod_cliente = '"+txtCodigoCliente.Text+"' and cobranca_docto_evento.tipo_cob_portador = cobranca_portador.tipo_cob_portador "+
                "and cobranca_docto_evento.id_cob_portador = cobranca_portador.id_cob_portador and "+ 
                "cobranca_docto_evento.id_cob_doc_evento = '"+txtCodigoCobranca.Text+"'", conn2);

            conn2.Open();

            //datareader recebe busca
            SqlDataReader por = portador.ExecuteReader();

            //enquanto tiver oque ler
            while (por.Read())
            {
                txtPortador.Text = por["descricao"].ToString();
            }

            conn2.Close();

            if (txtPendente.Text == "N")
            {
                txtPendente.Text = "Não";
            }
            else
            {
                txtPendente.Text = "Sim";
            }

        }

        private void btnRespostaPosterior_Click(object sender, EventArgs e)
        {

        }
    }
}
