using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Visomax
{
    public partial class frmInformacoesCartao : Form
    {
        public frmInformacoesCartao()
        {
            InitializeComponent();
        }

        //Faz o carregamento do form com os dados vindos do clique da grid do frmBuscaCartoes
        public frmInformacoesCartao(String filial, String sequencia, String autorizacao, String dataVenda, String dataEfetiva, String valorBruto, String descricao)
        {
            InitializeComponent();
            btnReceberCartao.Enabled = false;
            txtFilial.Text = filial;
            txtSequencia.Text = sequencia;
            txtAutorizacao.Text = autorizacao;
            txtDataVenda.Text = dataVenda;
            txtDataEfetiva.Text = dataEfetiva;
            txtValorBruto.Text = "R$" + valorBruto;
            txtDescricao.Text = descricao;

            preencherGrid();

            if(gridInformacoesCartoes.Rows.Count != 0)
            {
                btnReceberCartao.Enabled = true;
            }
        }

        //Clique do botão "Receber cartão"
        private void btnReceberCartao_Click(object sender, EventArgs e)
        {
            if(gridInformacoesCartoes.SelectedCells.Count == 1)
            {
                int selectedrowindex = gridInformacoesCartoes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = gridInformacoesCartoes.Rows[selectedrowindex];

                //A variável valorRecebido receberá o valor da coluna "Valor"
                String valorRecebido = Convert.ToString(selectedRow.Cells[4].Value).Replace(",",".");
                String cartaoRecebido = Convert.ToString(selectedRow.Cells[7].Value);

                if ((cartaoRecebido.Equals("Sim")) || (cartaoRecebido.Equals("sim")))
                {
                    MessageBox.Show("Este cartão já foi recebido", "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    updateDadosCartao(valorRecebido, txtSequencia.Text, Convert.ToString(selectedRow.Cells[8].Value));
                    gridInformacoesCartoes.Rows.Clear();
                    preencherGrid();
                }
            }
            else
            {
                if (gridInformacoesCartoes.SelectedCells.Count > 1)
                {
                    MessageBox.Show("Não é possível selecionar mais de uma linha", "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (gridInformacoesCartoes.SelectedCells.Count == 0)
                {
                    MessageBox.Show("É necessário selecionar uma das linhas", "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //Carrega os dados da grid. O método é usado no construtor de deste form
        private void preencherGrid()
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

            try
            {
                String query = "SELECT Cliente, Data_Criacao, Emissao, Vencimento, Valor, Valor_Recebido, Data_Recebimento, Cartao_Recebido, Descricao FROM Contas_Receber WHERE Num_Cartao = '" + txtAutorizacao.Text.Replace(" ", "") + "' AND Sequencia = '" + txtSequencia.Text + "' AND (Tipo = 'O' OR Tipo = 'R')";

                conexao.Open();

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();
                String dataRecebimento = "";

                while (sdr.Read())
                {
                    String cliente = sdr["Cliente"].ToString();
                    String dataCriacao = Convert.ToDateTime(sdr["Data_Criacao"].ToString()).ToString("dd/MM/yyyy");
                    String emissao = Convert.ToDateTime(sdr["Emissao"].ToString()).ToString("dd/MM/yyyy");
                    String vencimento = Convert.ToDateTime(sdr["Vencimento"].ToString()).ToString("dd/MM/yyyy");
                    String valor = sdr["Valor"].ToString();
                    String valorRecebido = sdr["Valor_Recebido"].ToString();

                    if (sdr["Data_Recebimento"] != DBNull.Value)
                    {
                        dataRecebimento = Convert.ToDateTime(sdr["Data_Recebimento"].ToString()).ToString("dd/MM/yyyy");
                    }

                    int cartaoRecebido = Convert.ToInt32(sdr["Cartao_Recebido"]);
                    String cartao = "";

                    if (cartaoRecebido == 0)
                    {
                        cartao = "Não";
                    }
                    else
                    {
                        cartao = "Sim";
                    }

                    String descricaoQuery = sdr["Descricao"].ToString();

                    gridInformacoesCartoes.Rows.Add(cliente, dataCriacao, emissao, vencimento, valor, valorRecebido, dataRecebimento, cartao, descricaoQuery);
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Falha ao retornar as informações do cartão", "Informações cartão - Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Faz o update dos dados do cartão na tabela Contas_Receber. O método está sendo usado no clique do botão "Receber cartão"
        private void updateDadosCartao(String valor, String sequencia, String descricao)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
            conexao.Open();

            try
            {
                String query = "UPDATE Contas_Receber SET Valor_Recebido = '" + valor + "', Data_Recebimento = '" + DateTime.Now.ToString("s") + "', Cartao_Recebido = '1' WHERE Sequencia = '" + sequencia + "' AND descricao = '" + descricao + "'";

                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados atualizados com sucesso", "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(SqlException se)
            {
                //MessageBox.Show("Não foi possível atualizar as informações do recebimento", "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(se.Message, "Informações cartão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmInformacoesCartao_Load(object sender, EventArgs e)
        {

        }
    }
}