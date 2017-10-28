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
    public partial class frmConsultaParcelas : Form
    {
        //String de conectar banco visomax
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

        String RelatorioTitulo = "Relação de Consulta de Parcelas - ";
        int paginaAtual = 1;
        static int li = 0;

        public frmConsultaParcelas()
        {
            InitializeComponent();
        }

        private void frmConsultaParcelas_Load(object sender, EventArgs e)
        {
            dtpData.Value = DateTime.Now.Date;

            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand ComboFilial = new SqlCommand("SELECT Codigo from Parametros_Filial ", conn);
                conn.Open();
                SqlDataReader leitor = ComboFilial.ExecuteReader();
                while (leitor.Read())
                {
                    cmbFilial.Items.Add(leitor.GetValue(0));
                }
                conn.Close();

                dtpData.DataBindings.Add("Enabled", chbdata, "Checked");
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
                " where Codigo = '" + cmbFilial.Text + "'", conn);
                conn.Open();
                SqlDataReader nome = NomeFilial.ExecuteReader();
                while (nome.Read())
                {
                    txtFilial.Text = Convert.ToString(nome.GetValue(1));
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Limpar grid
            dataGridView1.Rows.Clear();
            txtQuantidade.Text = "0";
            txtParcelas.Text = "0,00";
            txtAberto.Text = "0,00";
            txtRecebido.Text = "0,00";


            //busca somente por data
            if (txtFilial.Text == "" && txtCliente.Text == "" && txtPlanilha.Text == "" && chbdata.Checked)
            {
                //Convertendo data para o formato americano
                DateTime Data = Convert.ToDateTime(dtpData.Text);
                string DataFormato = Data.ToString("s");

                try
                {
                    //Query SQL de busca
                    SqlCommand busca = new SqlCommand("Select Contas_Receber.Filial, Contas_Receber.Sequencia, Contas_Receber.Parcela," +
                        "Contas_Receber.Cliente, Cli_For.Nome, Contas_Receber.Emissao, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento, Contas_Receber.Valor_Recebido, " +
                        "Contas_Receber.Tipo_Parcelamento " +
                        "FROM Contas_Receber, Cli_For " +
                        "where Contas_Receber.Emissao  = '" + DataFormato + "' and Cli_for.Codigo = Contas_Receber.Cliente " +
                        "and (Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c') and Cli_for.Codigo <> '1' and Contas_Receber.Sequencia <> '' ", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca.ExecuteReader();

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

                                    if (linhaDados[a] == "C")
                                    {
                                        linhaDados[a] = "Carteira";
                                    }
                                    else if (linhaDados[a] == "T")
                                    {
                                        linhaDados[a] = "Carnê";
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

                                    //Ao chegar na linha 7, da o total de parcelas
                                    if (a == 7)
                                    {
                                        txtParcelas.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtParcelas.Text));
                                    }

                                    //Ao chegar na linha 9, da o valor recebido e o que falta receber
                                    else if (a == 9)
                                    {
                                        if (linhaDados[a] == "0,00")
                                        {
                                            txtAberto.Text = Convert.ToString(Convert.ToDecimal(linhaDados[7]) + Convert.ToDecimal(txtAberto.Text));
                                        }
                                        else
                                        {
                                            txtRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[9]) + Convert.ToDecimal(txtRecebido.Text));
                                        }
                                    }
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
                        this.dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add(linhaDados);

                        });
                    }
                    conn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtQuantidade.Text = this.dataGridView1.Rows.Count.ToString();
            }

            //Busca por sequencia
            else if (txtPlanilha.Text != "" && txtCliente.Text == "" && txtFilial.Text == "" )
            {

                //Query SQL de busca
                SqlCommand busca = new SqlCommand("Select Contas_Receber.Filial, Contas_Receber.Sequencia, Contas_Receber.Parcela," +
                    "Contas_Receber.Cliente, Cli_For.Nome, Contas_Receber.Emissao, Contas_Receber.Vencimento, " +
                    "Contas_Receber.Valor, Contas_Receber.Data_Recebimento, Contas_Receber.Valor_Recebido, " +
                    "Contas_Receber.Tipo_Parcelamento " +
                    "FROM Contas_Receber, Cli_For " +
                    "where Contas_Receber.Sequencia  = '" + txtPlanilha.Text+ "' and Cli_for.Codigo = Contas_Receber.Cliente " +
                    "and (Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                    "Contas_Receber.tipo = 'c') and Cli_for.Codigo <> '1' and Contas_Receber.Sequencia <> '' ", conn);

                conn.Open();

                //define o tipo do comando 
                busca.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = busca.ExecuteReader();

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

                                linhaDados[a] = dr.GetString(a).ToString();

                                if (linhaDados[a] == "C")
                                {
                                    linhaDados[a] = "Carteira";
                                }
                                else if (linhaDados[a] == "T")
                                {
                                    linhaDados[a] = "Carnê";
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
                                linhaDados[a] = dr.GetDateTime(a).ToString();
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

                                //Ao chegar na linha 7, da o total de parcelas
                                if (a == 7)
                                {
                                    txtParcelas.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtParcelas.Text));
                                }

                                //Ao chegar na linha 9, da o valor recebido e o que falta receber
                                else if (a == 9)
                                {
                                    if (linhaDados[a] == "0,00")
                                    {
                                        txtAberto.Text = Convert.ToString(Convert.ToDecimal(linhaDados[7]) + Convert.ToDecimal(txtAberto.Text));
                                    }
                                    else
                                    {
                                        txtRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[9]) + Convert.ToDecimal(txtRecebido.Text));
                                    }
                                }
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
                    this.dataGridView1.Invoke((MethodInvoker)delegate
                    {
                        dataGridView1.Rows.Add(linhaDados);

                    });
                }
                conn.Close();

                txtQuantidade.Text = this.dataGridView1.Rows.Count.ToString();
            }

                //busca por sequencia e filial
            else if (txtPlanilha.Text != "" && txtCliente.Text == "" && txtFilial.Text != "")
            {
                try
                {
                    //Query SQL de busca
                    SqlCommand busca = new SqlCommand("Select Contas_Receber.Filial, Contas_Receber.Sequencia, Contas_Receber.Parcela," +
                        "Contas_Receber.Cliente, Cli_For.Nome, Contas_Receber.Emissao, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento, Contas_Receber.Valor_Recebido, " +
                        "Contas_Receber.Tipo_Parcelamento " +
                        "FROM Contas_Receber, Cli_For " +
                        "where Contas_Receber.Sequencia  = '" + txtPlanilha.Text + "' and Contas_Receber.Filial = '" + cmbFilial.Text + "' and Cli_for.Codigo = Contas_Receber.Cliente " +
                        "and (Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c') and Cli_for.Codigo <> '1' and Contas_Receber.Sequencia <> '' ", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca.ExecuteReader();

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

                                    if (linhaDados[a] == "C")
                                    {
                                        linhaDados[a] = "Carteira";
                                    }
                                    else if (linhaDados[a] == "T")
                                    {
                                        linhaDados[a] = "Carnê";
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
                                    linhaDados[a] = dr.GetDateTime(a).ToString();
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

                                    //Ao chegar na linha 7, da o total de parcelas
                                    if (a == 7)
                                    {
                                        txtParcelas.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtParcelas.Text));
                                    }

                                    //Ao chegar na linha 9, da o valor recebido e o que falta receber
                                    else if (a == 9)
                                    {
                                        if (linhaDados[a] == "0,00")
                                        {
                                            txtAberto.Text = Convert.ToString(Convert.ToDecimal(linhaDados[7]) + Convert.ToDecimal(txtAberto.Text));
                                        }
                                        else
                                        {
                                            txtRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[9]) + Convert.ToDecimal(txtRecebido.Text));
                                        }
                                    }
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
                        this.dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add(linhaDados);

                        });
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtQuantidade.Text = this.dataGridView1.Rows.Count.ToString();
            }

                //Busca filial e data
            else if (txtPlanilha.Text == "" && txtCliente.Text == "" && txtFilial.Text != "" && dtpData.Checked)
            {
                DateTime Data = Convert.ToDateTime(dtpData.Text);
                string DataFormato = Data.ToString("s");

                try
                {
                    //Query SQL de busca
                    SqlCommand busca = new SqlCommand("Select Contas_Receber.Filial, Contas_Receber.Sequencia, Contas_Receber.Parcela," +
                        "Contas_Receber.Cliente, Cli_For.Nome, Contas_Receber.Emissao, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento, Contas_Receber.Valor_Recebido, " +
                        "Contas_Receber.Tipo_Parcelamento " +
                        "FROM Contas_Receber, Cli_For " +
                        "where Contas_Receber.Data_Recebimento  = '" + DataFormato + "' and Contas_Receber.Filial = '" + cmbFilial.Text + "' and Cli_for.Codigo = Contas_Receber.Cliente " +
                        "and (Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c') and Cli_for.Codigo <> '1' and Contas_Receber.Sequencia <> '' ", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca.ExecuteReader();

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

                                    linhaDados[a] = dr.GetString(a).ToString();

                                    if (linhaDados[a] == "C")
                                    {
                                        linhaDados[a] = "Carteira";
                                    }
                                    else if (linhaDados[a] == "T")
                                    {
                                        linhaDados[a] = "Carnê";
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
                                    linhaDados[a] = dr.GetDateTime(a).ToString();
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

                                    //Ao chegar na linha 7, da o total de parcelas
                                    if (a == 7)
                                    {
                                        txtParcelas.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtParcelas.Text));
                                    }

                                    //Ao chegar na linha 9, da o valor recebido e o que falta receber
                                    else if (a == 9)
                                    {
                                        if (linhaDados[a] == "0,00")
                                        {
                                            txtAberto.Text = Convert.ToString(Convert.ToDecimal(linhaDados[7]) + Convert.ToDecimal(txtAberto.Text));
                                        }
                                        else
                                        {
                                            txtRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[9]) + Convert.ToDecimal(txtRecebido.Text));
                                        }
                                    }
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
                        this.dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add(linhaDados);

                        });
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtQuantidade.Text = this.dataGridView1.Rows.Count.ToString();
            }

            //Busca por cliente
            else if (txtPlanilha.Text == "" && txtCliente.Text != "" && txtFilial.Text == "" && dtpData.Checked)
            {

                try
                {
                    //Query SQL de busca
                    SqlCommand busca = new SqlCommand("Select Contas_Receber.Filial, Contas_Receber.Sequencia, Contas_Receber.Parcela," +
                        "Contas_Receber.Cliente, Cli_For.Nome, Contas_Receber.Emissao, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento, Contas_Receber.Valor_Recebido, " +
                        "Contas_Receber.Tipo_Parcelamento " +
                        "FROM Contas_Receber, Cli_For " +
                        "where Cli_For.Nome in (Select nome from Cli_For where nome  like '%" + txtCliente.Text + "%') and Cli_for.Codigo = Contas_Receber.Cliente " +
                        "and (Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c') and Cli_for.Codigo <> '1' and Contas_Receber.Sequencia <> '' ", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca.ExecuteReader();

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

                                    if (linhaDados[a] == "C")
                                    {
                                        linhaDados[a] = "Carteira";
                                    }
                                    else if (linhaDados[a] == "T")
                                    {
                                        linhaDados[a] = "Carnê";
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
                                    linhaDados[a] = dr.GetDateTime(a).ToString();
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

                                    //Ao chegar na linha 7, da o total de parcelas
                                    if (a == 7)
                                    {
                                        txtParcelas.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtParcelas.Text));
                                    }

                                    //Ao chegar na linha 9, da o valor recebido e o que falta receber
                                    else if (a == 9)
                                    {
                                        if (linhaDados[a] == "0,00")
                                        {
                                            txtAberto.Text = Convert.ToString(Convert.ToDecimal(linhaDados[7]) + Convert.ToDecimal(txtAberto.Text));
                                        }
                                        else
                                        {
                                            txtRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[9]) + Convert.ToDecimal(txtRecebido.Text));
                                        }
                                    }
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
                        this.dataGridView1.Invoke((MethodInvoker)delegate
                        {
                            dataGridView1.Rows.Add(linhaDados);

                        });
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtQuantidade.Text = this.dataGridView1.Rows.Count.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];
                frmConsultaDebito chamar = new frmConsultaDebito(SelectedRow);
                chamar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um registro!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string Filial = null;
            string Documento = null;
            string Parcela = null;
            string Codigo_cliente = null;
            string Emissao = null;
            string Valor_parcela = null;
            string Pagamento = null;
            string Valor_pagamento = null;

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
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 60, MargemDireita +90, 60);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 160, MargemDireita+90, 160);
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
            e.Graphics.DrawString("Filial ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
            e.Graphics.DrawString("Documento ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
            e.Graphics.DrawString("Parcela ", FonteNegrito, Brushes.Black, MargemEsq + 160, PosicaoDaLinha);
            e.Graphics.DrawString("Código cliente ", FonteNegrito, Brushes.Black, MargemEsq + 230, PosicaoDaLinha);
            e.Graphics.DrawString("Emissão ", FonteNegrito, Brushes.Black, MargemEsq + 340, PosicaoDaLinha);
            e.Graphics.DrawString("Valor da parcela ", FonteNegrito, Brushes.Black, MargemEsq + 430, PosicaoDaLinha);
            e.Graphics.DrawString("Pagamento ", FonteNegrito, Brushes.Black, MargemEsq + 560, PosicaoDaLinha);
            e.Graphics.DrawString("Valor pagamento ", FonteNegrito, Brushes.Black, MargemEsq + 670, PosicaoDaLinha);


            while ((LinhaAtual < LinhasPorPagina && registros > li))
            {
                //obtem os valores do datareader
                Filial = dataGridView1.Rows[li].Cells[0].Value.ToString();
                Documento = dataGridView1.Rows[li].Cells[1].Value.ToString();
                Parcela = dataGridView1.Rows[li].Cells[2].Value.ToString();
                Codigo_cliente = dataGridView1.Rows[li].Cells[3].Value.ToString();
                Emissao = dataGridView1.Rows[li].Cells[5].Value.ToString();
                Valor_parcela = dataGridView1.Rows[li].Cells[7].Value.ToString();
                Pagamento = dataGridView1.Rows[li].Cells[8].Value.ToString();
                Valor_pagamento = dataGridView1.Rows[li].Cells[9].Value.ToString(); 


                ////'impressão dos dados
                //PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString(Filial, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Documento, FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Parcela, FonteNormal, Brushes.Black, MargemEsq + 160, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Codigo_cliente, FonteNormal, Brushes.Black, MargemEsq + 230, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Emissao, FonteNormal, Brushes.Black, MargemEsq + 340, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Valor_parcela, FonteNormal, Brushes.Black, MargemEsq + 430, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Pagamento, FonteNormal, Brushes.Black, MargemEsq + 560, PosicaoDaLinha + 15);
                e.Graphics.DrawString(Valor_pagamento, FonteNormal, Brushes.Black, MargemEsq +670, PosicaoDaLinha + 15);

                PosicaoDaLinha = PosicaoDaLinha + 20;

                LinhaAtual += 1;
                li += 1;

            }

            //Rodape
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, MargemInferior, MargemDireita+90, MargemInferior);
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
                RelatorioTitulo = "Consulta de Parcelas - ";
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
    }
}
