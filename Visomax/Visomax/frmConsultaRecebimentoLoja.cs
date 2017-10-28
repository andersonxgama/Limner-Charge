using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Visomax
{
    public partial class frmConsultaRecebimentoLoja : Form
    {
        public frmConsultaRecebimentoLoja()
        {
            InitializeComponent();
        }

        //Faz o carregamento do form com os dados vindos do clique da grid do formRecebimentoCaixas
        public frmConsultaRecebimentoLoja(String loja, String caixa, String id)
        {
            InitializeComponent();
            txtLoja.Text = loja;
            txtCaixa.Text = caixa;
            txtId.Text = id;
            preencheTextBox(txtLoja.Text, txtCaixa.Text, txtId.Text);
            preencheGridParcelas(txtLoja.Text, txtCaixa.Text, txtId.Text);
            preencheGridNumerariosBanco(preencheGridNumerariosRecebimentoNumerario(txtLoja.Text, txtCaixa.Text, txtId.Text));
            Decimal recebido = 0;

            if(gridNumerarios.Rows.Count > 0)
            {
                for(int linha = 0; linha < gridNumerarios.Rows.Count; linha++)
                {
                    recebido += Decimal.Parse(gridNumerarios.Rows[linha].Cells[2].Value.ToString());
                }
            }

            txtRecebido.Text = "R$" + recebido.ToString();
        }

        //Faz o carregamento das textboxes com os dados vindos do banco
        private void preencheTextBox(String filial, String caixa, String id)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                String query = "SELECT dt_pagto, vlr_total_parcela, vlr_total_juros, vlr_total_descontos, vlr_total_pagto, vlr_troco, qtde_pc, qtde_numerario, dt_ins, cancelado, motivo_cancelamento FROM recebimento WHERE filial = '" + Convert.ToInt32(filial) + "' AND caixa = '" + Convert.ToInt32(caixa) + "' AND id_recebimento = '" + Convert.ToInt32(id) + "';";

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    DateTime dataPgto = Convert.ToDateTime(sdr["dt_pagto"]);
                    txtDataPgto.Text = dataPgto.ToString("dd/MM/yyyy");

                    DateTime dataCriacao = Convert.ToDateTime(sdr["dt_ins"]);
                    txtCriadoEm.Text = dataCriacao.ToString("dd/MM/yyyy");

                    txtCancelado.Text = sdr["cancelado"].ToString();

                    if((txtCancelado.Text.Equals("N")) || (txtCancelado.Text.Equals("n")))
                    {
                        txtCancelado.Text = "Não";
                    }
                    else
                    {
                        txtCancelado.Text = "Sim";
                    }

                    txtCanceladoMotivo.Text = sdr["motivo_cancelamento"].ToString();
                    txtParcelas.Text = sdr["qtde_pc"].ToString();

                    Decimal juros = (Decimal)sdr["vlr_total_juros"];
                    txtJuros.Text = "R$" + juros.ToString("0.00");

                    Decimal desconto = (Decimal)sdr["vlr_total_descontos"];
                    txtDesconto.Text = "R$" + desconto.ToString("0.00").Replace(".", ",");

                    Decimal totalPagamento = (Decimal)sdr["vlr_total_pagto"];
                    txtPagamento.Text = "R$" + totalPagamento.ToString("0.00").Replace(".", ",");

                    Decimal troco = (Decimal)sdr["vlr_troco"];
                    txtTroco.Text = "R$" + troco.ToString("0.00").Replace(".", ",");
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show("Falha ao carregar os dados das caixas de texto", "Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Preenche a gridParcelas com os dados vindos do banco
        private void preencheGridParcelas(String filial, String caixa, String id)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                String query = "SELECT sequencial, cod_cliente, filial_pc, documento, parcela, cliente, dt_vencto, vlr_parcela, vlr_juros, vlr_descontos, vlr_pagto FROM recebimento_parcela WHERE filial = '" + Convert.ToInt32(filial) + "' AND caixa = '" + Convert.ToInt32(caixa) + "' AND id_recebimento = '" + Convert.ToInt32(id) + "';";

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                DateTime dataPgto;
                String data;

                Decimal vlr_parcela = 0;
                Decimal vlr_juros = 0;
                Decimal vlr_descontos = 0;
                Decimal vlr_pagto = 0;

                while(sdr.Read())
                {
                    dataPgto = Convert.ToDateTime(sdr["dt_vencto"]);
                    data = dataPgto.ToString("dd/MM/yyyy");

                    vlr_parcela = (Decimal)sdr["vlr_parcela"];
                    vlr_juros = (Decimal)sdr["vlr_juros"];
                    vlr_descontos = (Decimal)sdr["vlr_descontos"];
                    vlr_pagto = (Decimal)sdr["vlr_pagto"];

                    gridParcelas.Rows.Add(sdr["sequencial"].ToString(), sdr["cod_cliente"].ToString(), sdr["filial_pc"].ToString(), sdr["documento"].ToString(), sdr["parcela"].ToString(), sdr["cliente"], data, vlr_parcela.ToString("0.00").Replace(".", ","), vlr_juros.ToString("0.00").Replace(".", ","), vlr_descontos.ToString("0.00").Replace(".", ","), vlr_pagto.ToString("0.00").Replace(".", ","));
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show("Falha ao carregar os dados das grid parcelas", "Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Preenche a gridNumerarios com os dados referentes a tabela "recebimento_numerario" vindos do banco
        private String preencheGridNumerariosRecebimentoNumerario(String filial, String caixa, String id)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();
            int linha = 0;
            String idBanco = "";

            try
            {
                String query = "SELECT "
                                 + "sequencial, "
                                 + "id_numerario, "
                                 + "vlr_numerario, "
                                 + "id_adm_cartao, "
                                 + "agencia, "
                                 + "conta, "
                                 + "cheque, "
                                 + "cpf_cnpj, "
                                 + "dt_numerario, "
                                 + "id_banco "  //Este campo deve ser mandado para uma lista, p/ pegar a descricao do banco em outro método que deve ser criado.
                               + "FROM "
                                 + "recebimento_numerario "
                               + "WHERE "
                                 + "filial = '" + Convert.ToInt32(filial) + "' AND caixa = '" + Convert.ToInt32(caixa) + "' AND id_recebimento = '" + Convert.ToInt32(id) + "';";

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                Decimal vlr_numerario;

                while (sdr.Read())
                {
                    gridNumerarios.Rows.Add();
                    gridNumerarios.Rows[linha].Cells[0].Value = sdr["sequencial"];

                    if (sdr["id_numerario"].ToString().Equals("1"))
                    {
                        gridNumerarios.Rows[linha].Cells[1].Value = "Dinheiro";
                    }
                    else if(sdr["id_numerario"].ToString().Equals("2"))
                    {
                        gridNumerarios.Rows[linha].Cells[1].Value = "Cheque";
                    }
                    else if (sdr["id_numerario"].ToString().Equals("3"))
                    {
                        gridNumerarios.Rows[linha].Cells[1].Value = "Cartão débito";
                    }

                    vlr_numerario = (Decimal)sdr["vlr_numerario"];
                    gridNumerarios.Rows[linha].Cells[2].Value = vlr_numerario.ToString("0.00").Replace(".", ",");

                    if (sdr["id_adm_cartao"].ToString().Equals("1"))
                    {
                        gridNumerarios.Rows[linha].Cells[3].Value = "Visa Electron";
                    }
                    else if (sdr["id_adm_cartao"].ToString().Equals("2"))
                    {
                        gridNumerarios.Rows[linha].Cells[3].Value = "Redeshop";
                    }

                    gridNumerarios.Rows[linha].Cells[5].Value = sdr["agencia"].ToString();
                    gridNumerarios.Rows[linha].Cells[6].Value = sdr["conta"].ToString();
                    gridNumerarios.Rows[linha].Cells[7].Value = sdr["cheque"].ToString();
                    gridNumerarios.Rows[linha].Cells[8].Value = sdr["cpf_cnpj"].ToString();

                    if (sdr["dt_numerario"] != DBNull.Value)
                    {
                        gridNumerarios.Rows[linha].Cells[9].Value = Convert.ToDateTime(sdr["dt_numerario"].ToString()).ToString("dd/MM/yyyy");
                    }

                    if (sdr["id_banco"] != DBNull.Value)
                    {
                        idBanco = sdr["id_banco"].ToString();
                    }

                    linha++;
                }

                sdr.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return idBanco;
        }

        //Preenche a gridNumerarios com o nome do banco da tabela banco, referente ao codigo passado por parâmetro
        private void preencheGridNumerariosBanco(String idBanco)
        {
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                String query = "SELECT descricao FROM banco WHERE cod_banco = '" + idBanco + "'";

                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    if (sdr["descricao"] != DBNull.Value)
                    {
                        gridNumerarios.Rows[0].Cells[4].Value = sdr["descricao"].ToString();
                    }
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show(se.Message, "Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void frmConsultaRecebimentoLoja_Load(object sender, EventArgs e)
        {

        }
    }
}