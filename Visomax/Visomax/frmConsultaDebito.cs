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
    public partial class frmConsultaDebito : Form
    {
        //String de conectar banco visomax
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        String RelatorioTitulo = "Relação de Consulta de Parcelas - ";
        int paginaAtual = 1;
        DataTable dataGridView = null;
        static int li = 0;

        public frmConsultaDebito()
        {
            InitializeComponent();
        }

        //Faz a abertura da tela dos dados cadastrais
        private void btnDadosCadastrais_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Obrigatório fazer primeiro a busca", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                frmDadosCadastrais fdc = new frmDadosCadastrais(codigo);
                fdc.ShowDialog();
            }
        }

        //Faz a abertura da tela da tela de vendas
        private void btnVenda_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            string filial = txtCodigoFilial.Text;
            frmVenda fv = new frmVenda(documento, filial);
            fv.ShowDialog();
        }

        //Faz a abertura da tela da tela de consulta de débito
        private void btnHistoricoCobranca_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(txtCodigo.Text);
            frmHistoricoCobranca fhc = new frmHistoricoCobranca(cliente);
            fhc.ShowDialog();
        }

        private void frmConsultaDebito_Load(object sender, EventArgs e)
        {

        }
        public frmConsultaDebito(DataGridViewRow row, string date)
        {
            InitializeComponent();
            //Pega informações da tela frmconsultaparcela
            txtCodigo.Text = row.Cells[4].Value.ToString();
            txtDocumento.Text = row.Cells[2].Value.ToString();
            txtCodigoFilial.Text = row.Cells[1].Value.ToString();
            txtEmissao.Text = date;

            string pagamento = null;
            string vencimento = null;
            string atraso = null;
            //variavel para calcular atraso
            TimeSpan data;
            string mediatraso = null;


            //Buscando dados pessoais no banco
            try
            {
                SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, Cli_For.Nome, Cli_For.CNPJ,  Cli_For.Cidade, " +
                    "Cli_For.Fone_1, Cli_For.Fone_2, Cli_For_Credito.Telefone FROM Cli_For, " +
                    "Cli_For_Credito where Cli_For.Codigo = Cli_For_Credito.Codigo and Cli_For.Codigo = '" + txtCodigo.Text + "'", conn);

                conn.Open();

                //joga para o data reader aas informações
                SqlDataReader DR1 = busca.ExecuteReader();


                //Lança dados para os campos enquanto tiveer dados
                while (DR1.Read())
                {
                    txtNome.Text = (DR1["Nome"].ToString());
                    txtCpf.Text = (DR1["CNPJ"].ToString());
                    txtCidade.Text = (DR1["Cidade"].ToString());
                    txtTelResidencial.Text = (DR1["Fone_1"].ToString());
                    txtCelular.Text = (DR1["Fone_2"].ToString());
                    txtTelComercial.Text = (DR1["Telefone"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                conn.Open();

                //datareader recebe busca
                SqlDataReader nome = NomeFilial.ExecuteReader();

                //enquanto tiver oque ler
                while (nome.Read())
                {
                    //pega o nome da filial
                    txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Query SQL de busca para grid
            try
            {
                SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                    "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                    "FROM Contas_Receber, Cli_For " +
                    "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                    "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                    "Contas_Receber.tipo = 'c')", conn);

                conn.Open();

                //define o tipo do comando 
                busca2.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = busca2.ExecuteReader();

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

                                //Substitui para o tipo de pagamento por nome
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
                                //se a data do pagamento for null coloca 00/00/0000
                                linhaDados[a] = "00/00/0000";
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

                                //Calcula total das parcelas
                                if (a == 3)
                                {
                                    txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                }
                                //Calcula valor recebido
                                else if (a == 5)
                                {
                                    txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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

                    //adiciona linha na grid
                    gridConsultaDebito.Rows.Add(linhaDados);

                    txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                    //pecorre a grid
                    for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                    {

                        //joga valores da grid em variveis 
                        vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                        pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                        atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();

                        // se o valor pago e = 0 joga valor da parcela para a receber
                        if (atraso == "0,00")
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                        }
                        //se não joga 0
                        else
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                        }

                        //verifica a quantidade de dias em atraso
                        if (pagamento == "00/00/0000")
                        {
                            data = DateTime.Now - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                        }
                        else
                        {
                            data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                        }
                    }


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //calcula a media de atraso
            txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / gridConsultaDebito.Rows.Count);

            //conta a quantidade de vendas
            try
            {
                SqlCommand busca3 = new SqlCommand("SELECT COUNT(*) as contador " +
                    "FROM [S8_Real].[dbo].[Saidas] where Cliente = '" + txtCodigo.Text + "'" +
                    "and exists (Select Sequencia from Contas_Receber " +
                    "where Saidas.Sequencia = Contas_Receber.Sequencia and " +
    "               Saidas.Filial = Contas_Receber.Filial)", conn);

                conn.Open();
                SqlDataReader DR2 = busca3.ExecuteReader();


                //coloca a quantidade de venda
                while (DR2.Read())
                {
                    txtDebitoDois.Text = (DR2["contador"].ToString());

                }
                conn.Close();


                //Buscando o numero da venda
                SqlCommand busca4 = new SqlCommand("WITH ClientesComPosicao AS( " +
                         "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia " +
                         "FROM Saidas " +
                         "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500) " +
                         "SELECT POS AS POS2 FROM ClientesComPosicao WHERE Sequencia = '" + txtDocumento.Text + "'", conn);

                conn.Open();
                //joga o numero da venda
                txtDebitoUm.Text = busca4.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Referencia de informaçoes frmConsultaParcelas
        public frmConsultaDebito(DataGridViewRow row)
        {
            InitializeComponent();
            //Pega informações da tela frmconsultaparcela
            txtCodigo.Text = row.Cells[3].Value.ToString();
            txtDocumento.Text = row.Cells[1].Value.ToString();
            txtCodigoFilial.Text = row.Cells[0].Value.ToString();
            txtEmissao.Text = row.Cells[5].Value.ToString();

            string pagamento = null;
            string vencimento = null;
            string atraso = null;
            //variavel para calcular atraso
            TimeSpan data;
            string mediatraso = null;


            //Buscando dados pessoais no banco
            try
            {
                SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, Cli_For.Nome, Cli_For.CNPJ,  Cli_For.Cidade, " +
                    "Cli_For.Fone_1, Cli_For.Fone_2, Cli_For_Credito.Telefone FROM Cli_For, " +
                    "Cli_For_Credito where Cli_For.Codigo = Cli_For_Credito.Codigo and Cli_For.Codigo = '" + txtCodigo.Text + "'", conn);

                conn.Open();

                //joga para o data reader aas informações
                SqlDataReader DR1 = busca.ExecuteReader();


                //Lança dados para os campos enquanto tiveer dados
                while (DR1.Read())
                {
                    txtNome.Text = (DR1["Nome"].ToString());
                    txtCpf.Text = (DR1["CNPJ"].ToString());
                    txtCidade.Text = (DR1["Cidade"].ToString());
                    txtTelResidencial.Text = (DR1["Fone_1"].ToString());
                    txtCelular.Text = (DR1["Fone_2"].ToString());
                    txtTelComercial.Text = (DR1["Telefone"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                conn.Open();

                //datareader recebe busca
                SqlDataReader nome = NomeFilial.ExecuteReader();

                //enquanto tiver oque ler
                while (nome.Read())
                {
                    //pega o nome da filial
                    txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Query SQL de busca para grid
            try
            {
                SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                    "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                    "FROM Contas_Receber, Cli_For " +
                    "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                    "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                    "Contas_Receber.tipo = 'c')", conn);

                conn.Open();

                //define o tipo do comando 
                busca2.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = busca2.ExecuteReader();

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

                                //Substitui para o tipo de pagamento por nome
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
                                //se a data do pagamento for null coloca 00/00/0000
                                linhaDados[a] = "00/00/0000";
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

                                //Calcula total das parcelas
                                if (a == 3)
                                {
                                    txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                }
                                //Calcula valor recebido
                                else if (a == 5)
                                {
                                    txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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

                    //adiciona linha na grid
                    gridConsultaDebito.Rows.Add(linhaDados);

                    txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                    //pecorre a grid
                    for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                    {

                        //joga valores da grid em variveis 
                        vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                        pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                        atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();

                        // se o valor pago e = 0 joga valor da parcela para a receber
                        if (atraso == "0,00")
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                        }
                        //se não joga 0
                        else
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                        }

                        //verifica a quantidade de dias em atraso
                        if (pagamento == "00/00/0000")
                        {
                            data = DateTime.Now - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                        }
                        else
                        {
                            data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                        }
                    }


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //calcula a media de atraso
            txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / gridConsultaDebito.Rows.Count); 

            //conta a quantidade de vendas
            try
            {
                SqlCommand busca3 = new SqlCommand("SELECT COUNT(*) as contador " +
                    "FROM [S8_Real].[dbo].[Saidas] where Cliente = '" + txtCodigo.Text + "'" +
                    "and exists (Select Sequencia from Contas_Receber " +
                    "where Saidas.Sequencia = Contas_Receber.Sequencia and " +
    "               Saidas.Filial = Contas_Receber.Filial)", conn);

                conn.Open();
                SqlDataReader DR2 = busca3.ExecuteReader();


                //coloca a quantidade de venda
                while (DR2.Read())
                {
                    txtDebitoDois.Text = (DR2["contador"].ToString());

                }
                conn.Close();


                //Buscando o numero da venda
                SqlCommand busca4 = new SqlCommand("WITH ClientesComPosicao AS( " +
                         "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia " +
                         "FROM Saidas " +
                         "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500) " +
                         "SELECT POS AS POS2 FROM ClientesComPosicao WHERE Sequencia = '" + txtDocumento.Text + "'", conn);

                conn.Open();
                //joga o numero da venda
                txtDebitoUm.Text = busca4.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        //Banguelas
        public frmConsultaDebito(string cod, string doc, string fil, string emis)
        {
            InitializeComponent();
            //Pega informações da tela frmconsultaparcela
            txtCodigo.Text = cod;
            txtDocumento.Text = doc;
            txtCodigoFilial.Text = fil;
            txtEmissao.Text = emis;

            string pagamento = null;
            string vencimento = null;
            string atraso = null;
            //variavel para calcular atraso
            TimeSpan data;
            string mediatraso = null;


            //Buscando dados pessoais no banco
            try
            {
                SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, Cli_For.Nome, Cli_For.CNPJ,  Cli_For.Cidade, " +
                    "Cli_For.Fone_1, Cli_For.Fone_2, Cli_For_Credito.Telefone FROM Cli_For, " +
                    "Cli_For_Credito where Cli_For.Codigo = Cli_For_Credito.Codigo and Cli_For.Codigo = '" + txtCodigo.Text + "'", conn);

                conn.Open();

                //joga para o data reader aas informações
                SqlDataReader DR1 = busca.ExecuteReader();


                //Lança dados para os campos enquanto tiveer dados
                while (DR1.Read())
                {
                    txtNome.Text = (DR1["Nome"].ToString());
                    txtCpf.Text = (DR1["CNPJ"].ToString());
                    txtCidade.Text = (DR1["Cidade"].ToString());
                    txtTelResidencial.Text = (DR1["Fone_1"].ToString());
                    txtCelular.Text = (DR1["Fone_2"].ToString());
                    txtTelComercial.Text = (DR1["Telefone"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                conn.Open();

                //datareader recebe busca
                SqlDataReader nome = NomeFilial.ExecuteReader();

                //enquanto tiver oque ler
                while (nome.Read())
                {
                    //pega o nome da filial
                    txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Query SQL de busca para grid
            try
            {
                SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                    "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                    "FROM Contas_Receber, Cli_For " +
                    "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                    "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                    "Contas_Receber.tipo = 'c')", conn);

                conn.Open();

                //define o tipo do comando 
                busca2.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = busca2.ExecuteReader();

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

                                //Substitui para o tipo de pagamento por nome
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
                                //se a data do pagamento for null coloca 00/00/0000
                                linhaDados[a] = "00/00/0000";
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

                                //Calcula total das parcelas
                                if (a == 3)
                                {
                                    txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                }
                                //Calcula valor recebido
                                else if (a == 5)
                                {
                                    txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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

                    //adiciona linha na grid
                    gridConsultaDebito.Rows.Add(linhaDados);

                    txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                    //pecorre a grid
                    for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                    {

                        //joga valores da grid em variveis 
                        vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                        pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                        atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();

                        // se o valor pago e = 0 joga valor da parcela para a receber
                        if (atraso == "0,00")
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                        }
                        //se não joga 0
                        else
                        {
                            gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                        }

                        //verifica a quantidade de dias em atraso
                        if (pagamento == "00/00/0000")
                        {
                            data = DateTime.Now - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                        }
                        else
                        {
                            data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                            gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                            mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                        }
                    }


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //calcula a media de atraso
            txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / gridConsultaDebito.Rows.Count);

            //conta a quantidade de vendas
            try
            {
                SqlCommand busca3 = new SqlCommand("SELECT COUNT(*) as contador " +
                    "FROM [S8_Real].[dbo].[Saidas] where Cliente = '" + txtCodigo.Text + "'" +
                    "and exists (Select Sequencia from Contas_Receber " +
                    "where Saidas.Sequencia = Contas_Receber.Sequencia and " +
                    "Saidas.Filial = Contas_Receber.Filial)", conn);

                conn.Open();
                SqlDataReader DR2 = busca3.ExecuteReader();


                //coloca a quantidade de venda
                while (DR2.Read())
                {
                    txtDebitoDois.Text = (DR2["contador"].ToString());

                }
                conn.Close();


                //Buscando o numero da venda
                SqlCommand busca4 = new SqlCommand("WITH ClientesComPosicao AS( " +
                         "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia " +
                         "FROM Saidas " +
                         "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500) " +
                         "SELECT POS AS POS2 FROM ClientesComPosicao WHERE Sequencia = '" + txtDocumento.Text + "'", conn);

                conn.Open();
                //joga o numero da venda
                txtDebitoUm.Text = busca4.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            
            //indica o fim de vendas
            if (txtDebitoUm.Text == "1")
            {
                MessageBox.Show("Fim dos registros!", "Fim dos registros!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                gridConsultaDebito.Rows.Clear();
                txtTotal.Text = "0";
                txtValorRecebido.Text = "0";
                //se nao desce para o proximo numero
                txtDebitoUm.Text = Convert.ToString(Convert.ToInt16(txtDebitoUm.Text) - 1);

                //Buscando o numero da venda
                try
                {
                    SqlCommand busca5 = new SqlCommand("WITH ClientesComPosicao AS( " +
                             "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia, Filial " +
                             "FROM Saidas " +
                             "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500 " +
                             "and exists (Select Sequencia from Contas_Receber where " +
                             "Saidas.Sequencia = Contas_Receber.Sequencia and Saidas.Filial = Contas_Receber.Filial ))" +
                             "SELECT Sequencia,Filial FROM ClientesComPosicao WHERE POS = '" + txtDebitoUm.Text + "'", conn);

                    conn.Open();


                    SqlDataReader DR3 = busca5.ExecuteReader();
                    while (DR3.Read())
                    {
                        //muda o codigo do documento, filial....
                        txtDocumento.Text = Convert.ToString(DR3.GetValue(0));
                        txtCodigoFilial.Text = Convert.ToString(DR3.GetValue(1));
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
                try
                {
                    SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                    " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                    conn.Open();
                    SqlDataReader nome = NomeFilial.ExecuteReader();
                    while (nome.Read())
                    {
                        txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                 //Query SQL de busca para grid
                try
                {
                    SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                        "FROM Contas_Receber, Cli_For " +
                        "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                        "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c')", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca2.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca2.ExecuteReader();

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

                                    //Substitui para o tipo de pagamento por nome
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
                                    //se a data do pagamento for null coloca 00/00/0000
                                    linhaDados[a] = "00/00/0000";
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

                                    //Calcula total das parcelas
                                    if (a == 3)
                                    {
                                        txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                    }
                                    //Calcula valor recebido
                                    else if (a == 5)
                                    {
                                        txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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

                        //adiciona linha na grid
                        gridConsultaDebito.Rows.Add(linhaDados);

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                string vencimento;
                string pagamento;
                string atraso;
                //variavel para calcular atraso
                TimeSpan data;
                string mediatraso = null;

                //pecorre a grid
                for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                {

                    //joga valores da grid em variveis 
                    vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                    pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                    atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();

                    // se o valor pago e = 0 joga valor da parcela para a receber
                    if (atraso == "0,00")
                    {
                        gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                    }
                    //se não joga 0
                    else
                    {
                        gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                    }

                    //verifica a quantidade de dias em atraso
                    if (pagamento == "00/00/0000")
                    {
                        data = DateTime.Now - Convert.ToDateTime(vencimento);
                        gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                        mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                    }
                    else
                    {
                        data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                        gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                        mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                    }
                }

                //calcula a media de atraso
                txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / gridConsultaDebito.Rows.Count); 

            }
            
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            //mostra o fim do registro
            if (txtDebitoUm.Text == txtDebitoDois.Text)
            {
                MessageBox.Show("Fim dos registros!", "Fim dos registros!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtTotal.Text = "0";
                txtValorRecebido.Text = "0";
                gridConsultaDebito.Rows.Clear();
                //sobe o registro
                txtDebitoUm.Text = Convert.ToString(Convert.ToInt16(txtDebitoUm.Text) + 1);

                //Buscando o numero da venda
                try
                {
                    SqlCommand busca5 = new SqlCommand("WITH ClientesComPosicao AS( " +
                             "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia, Filial " +
                             "FROM Saidas " +
                             "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500 " +
                             "and exists (Select Sequencia from Contas_Receber where " +
                             "Saidas.Sequencia = Contas_Receber.Sequencia and Saidas.Filial = Contas_Receber.Filial ))" +
                             "SELECT Sequencia,Filial FROM ClientesComPosicao WHERE POS = '" + txtDebitoUm.Text + "'", conn);
                    conn.Open();

                    SqlDataReader DR3 = busca5.ExecuteReader();
                    while (DR3.Read())
                    {
                        txtDocumento.Text = Convert.ToString(DR3.GetValue(0));
                        txtCodigoFilial.Text = Convert.ToString(DR3.GetValue(1));
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Comando SQL, ao selecionar envia o nome da filial para o txtfilial

                try
                {
                    SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                    " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                    conn.Open();
                    SqlDataReader nome = NomeFilial.ExecuteReader();
                    while (nome.Read())
                    {
                        txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Query SQL de busca para grid
                try
                {
                    SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                        "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                        "FROM Contas_Receber, Cli_For " +
                        "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                        "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                        "Contas_Receber.tipo = 'c')", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca2.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader dr = busca2.ExecuteReader();

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

                                    //Substitui para o tipo de pagamento por nome
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
                                    //se a data do pagamento for null coloca 00/00/0000
                                    linhaDados[a] = "00/00/0000";
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

                                    //Calcula total das parcelas
                                    if (a == 3)
                                    {
                                        txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                    }
                                    //Calcula valor recebido
                                    else if (a == 5)
                                    {
                                        txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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

                        //adiciona linha na grid
                        gridConsultaDebito.Rows.Add(linhaDados);

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                string vencimento;
                string pagamento;
                string atraso;
                //variavel para calcular atraso
                TimeSpan data;
                string mediatraso = null;

                //pecorre a grid
                for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                {

                    //joga valores da grid em variveis 
                    vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                    pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                    atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();

                    // se o valor pago e = 0 joga valor da parcela para a receber
                    if (atraso == "0,00")
                    {
                        gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                    }
                    //se não joga 0
                    else
                    {
                        gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                    }

                    //verifica a quantidade de dias em atraso
                    if (pagamento == "00/00/0000")
                    {
                        data = DateTime.Now - Convert.ToDateTime(vencimento);
                        gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                        mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                    }
                    else
                    {
                        data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                        gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                        mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                    }
                }

                //calcula a media de atraso
                txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / (gridConsultaDebito.Rows.Count +1)); 

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                
            frmBuscaDebito chamar = new frmBuscaDebito();
            chamar.ShowDialog();

            if (frmBuscaDebito.cliente != null && frmBuscaDebito.cliente != "")
            {
                txtCodigo.Text = frmBuscaDebito.cliente;

                try
                {
                    //Buscando dados pessoais no banco
                    SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, Cli_For.Nome, Cli_For.CNPJ,  Cli_For.Cidade, " +
                            "Cli_For.Fone_1, Cli_For.Fone_2, Cli_For_Credito.Telefone FROM Cli_For, " +
                            "Cli_For_Credito where Cli_For.Codigo = Cli_For_Credito.Codigo and Cli_For.Codigo = '" + txtCodigo.Text + "'", conn);

                    conn.Open();

                    //joga para o data reader aas informações
                    SqlDataReader DR1 = busca.ExecuteReader();

                    //Lança dados para os campos enquanto tiveer dados
                    while (DR1.Read())
                    {
                        txtNome.Text = (DR1["Nome"].ToString());
                        txtCpf.Text = (DR1["CNPJ"].ToString());
                        txtCidade.Text = (DR1["Cidade"].ToString());
                        txtTelResidencial.Text = (DR1["Fone_1"].ToString());
                        txtCelular.Text = (DR1["Fone_2"].ToString());
                        txtTelComercial.Text = (DR1["Telefone"].ToString());
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //conta a quantidade de vendas

                try
                {
                    SqlCommand busca3 = new SqlCommand("SELECT COUNT(*) as contador " +
                            "FROM [S8_Real].[dbo].[Saidas] where Cliente = '" + txtCodigo.Text + "' " +
                            "and Cod_Operacao =500 and exists (Select Sequencia from Contas_Receber " +
                            "where Saidas.Sequencia = Contas_Receber.Sequencia and " +
                            "Saidas.Filial = Contas_Receber.Filial )", conn);

                    conn.Open();
                    SqlDataReader DR2 = busca3.ExecuteReader();


                    //coloca a quantidade de venda
                    while (DR2.Read())
                    {
                        txtDebitoDois.Text = (DR2["contador"].ToString());
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtDebitoUm.Text = "1";

                //conta a quantidade de vendas
                try
                {
                    SqlCommand busca4 = new SqlCommand("WITH ClientesComPosicao AS( " +
                            "SELECT ROW_NUMBER() OVER(ORDER BY data) AS POS, Sequencia, Filial, Data  " +
                            "FROM Saidas " +
                            "where Cliente = '" + txtCodigo.Text + "' and Cod_Operacao = 500) " +
                            "SELECT Sequencia, Filial, Data  FROM ClientesComPosicao WHERE POS = 1", conn);

                    conn.Open();

                    SqlDataReader DR3 = busca4.ExecuteReader();


                    //coloca a quantidade de venda
                    while (DR3.Read())
                    {
                        txtDocumento.Text = (DR3["Sequencia"].ToString());
                        txtCodigoFilial.Text = (DR3["Filial"].ToString());
                        txtEmissao.Text = DR3["Data"].ToString();

                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Query SQL de busca para grid
                try
                {
                    SqlCommand busca2 = new SqlCommand("Select Contas_Receber.Tipo_Parcelamento, Contas_Receber.Parcela, Contas_Receber.Vencimento, " +
                            "Contas_Receber.Valor, Contas_Receber.Data_Recebimento,  Contas_Receber.Valor_Recebido " +
                            "FROM Contas_Receber, Cli_For " +
                            "where  Cli_for.Codigo = Contas_Receber.Cliente and Sequencia = '" + txtDocumento.Text + "' and Filial = '" + txtCodigoFilial.Text + "' and " +
                            "(Contas_Receber.Tipo_Parcelamento  = 't' or  Contas_Receber.Tipo_Parcelamento = 'c' or " +
                            "Contas_Receber.tipo = 'c')", conn);

                    conn.Open();

                    //define o tipo do comando 
                    busca2.CommandType = CommandType.Text;

                    //obtem um datareader
                    IDataReader dr = busca2.ExecuteReader();

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

                                    //Substitui para o tipo de pagamento por nome
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
                                    //se a data do pagamento for null coloca 00/00/0000
                                    linhaDados[a] = "00/00/0000";
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

                                    //Calcula total das parcelas
                                    if (a == 3)
                                    {
                                        txtTotal.Text = Convert.ToString(Convert.ToDecimal(linhaDados[a]) + Convert.ToDecimal(txtTotal.Text));
                                    }
                                    //Calcula valor recebido
                                    else if (a == 5)
                                    {
                                        txtValorRecebido.Text = Convert.ToString(Convert.ToDecimal(linhaDados[5]) + Convert.ToDecimal(txtValorRecebido.Text));
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
                    }
                    //adiciona linha na grid
                    gridConsultaDebito.Rows.Add(linhaDados);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                    //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
                try
                {
                    SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                    " where Codigo = '" + txtCodigoFilial.Text + "'", conn);
                    conn.Open();

                    //datareader recebe busca
                    SqlDataReader nome = NomeFilial.ExecuteReader();

                    //enquanto tiver oque ler
                    while (nome.Read())
                    {
                        //pega o nome da filial
                        txtNomeFilial.Text = Convert.ToString(nome.GetValue(1));
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (gridConsultaDebito.Rows.Count != 0)
                {

                    txtValorReceber.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtValorRecebido.Text));

                    string vencimento;
                    string pagamento;
                    string atraso;
                    //variavel para calcular atraso
                    TimeSpan data;
                    string mediatraso = null;

                    //pecorre a grid

                    try
                    {
                        for (int j = 0; j < gridConsultaDebito.Rows.Count; j++)
                        {

                            vencimento = gridConsultaDebito.Rows[j].Cells[2].Value.ToString();
                            pagamento = gridConsultaDebito.Rows[j].Cells[4].Value.ToString();
                            atraso = gridConsultaDebito.Rows[j].Cells[5].Value.ToString();



                            // se o valor pago e = 0 joga valor da parcela para a receber
                            if (atraso == "0,00")
                            {
                                gridConsultaDebito.Rows[j].Cells[6].Value = gridConsultaDebito.Rows[j].Cells[3].Value.ToString();

                            }
                            //se não joga 0
                            else
                            {
                                gridConsultaDebito.Rows[j].Cells[6].Value = "0,00";

                            }

                            //verifica a quantidade de dias em atraso
                            if (pagamento == "00/00/0000")
                            {
                                data = DateTime.Now - Convert.ToDateTime(vencimento);
                                gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                                mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));

                            }
                            else
                            {
                                data = Convert.ToDateTime(pagamento) - Convert.ToDateTime(vencimento);
                                gridConsultaDebito.Rows[j].Cells[7].Value = data.Days;
                                mediatraso = Convert.ToString(Convert.ToInt32(gridConsultaDebito.Rows[j].Cells[7].Value.ToString()) + Convert.ToInt32(mediatraso));
                            }
                        }
                    }
                    catch (NullReferenceException ex)
                    {

                    }

                    //calcula a media de atraso
                    txtAtrasoMedio.Text = Convert.ToString(Convert.ToInt32(mediatraso) / gridConsultaDebito.Rows.Count);


                }
                else
                {
                    MessageBox.Show("Nenhuma venda encontrada!", "Não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


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
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 60, MargemDireita +90, 60);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, 160, MargemDireita +90, 160);
            //nome da empresa
            e.Graphics.DrawString("Visomax", FonteTitulo, Brushes.Blue, MargemEsq + 250, 80, new StringFormat());
            //Imagem
            e.Graphics.DrawString(RelatorioTitulo + DateTime.Now.ToString("dd/MM/yyyy"), FonteSubTitulo, Brushes.Black, MargemEsq + 250, 110, new StringFormat());

            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 20);

            int registros = gridConsultaDebito.Rows.Count;



            SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, "+
            "Cli_For.Tipo, "+
            "Cli_For.Fisica_Juridica, "+
            "Cli_For.Inativo, Cli_For.Bloqueado, "+
            "Cli_For.Data_Cadastro, "+
            "Cli_For.Data_Alteracao, "+ 
            "Cli_For.Nome, "+
            "Cli_For.CNPJ, "+ 
            "Cli_For.Inscricao, "+
            "Cli_For.Fone_1, "+ 
            "Cli_For.Fone_2, "+ 
            "Cli_For.Fax, "+
            "Cli_For.Endereco, "+ 
            "Cli_For.Complemento, "+ 
            "Cli_For.Bairro, "+ 
            "Cli_For.Cidade, "+ 
            "Cli_For.Estado, "+ 
            "Cli_For.CEP, "+
            "Cli_For_Credito.Sexo, "+ 
            "Cli_For_Credito.Nascimento, "+ 
            "Cli_For_Credito.Estado_Civil, "+ 
            "Cli_For_Credito.Naturalidade, "+
            "Cli_For_Credito.Nome_Mae, "+ 
            "Cli_For_Credito.Nome_Pai, "+ 
            "Cli_For_Credito.Tipo_Residencia, "+ 
            "Cli_For_Credito.Tempo_Residencia, "+
            "Cli_For_Credito.RG_Expedido_Em, "+ 
            "Cli_For_Credito.Empresa, "+ 
            "Cli_For_Credito.Telefone, "+ 
            "Cli_For_Credito.Contratacao, "+
            "Cli_For_Credito.Cargo, "+ 
            "Cli_For_Credito.Salario, "+
            "Cli_For.Comentarios, "+ 
            "Cli_For_Credito.OBS "+
            "FROM Cli_For, Cli_For_Credito " +
            "where Cli_For.codigo = Cli_For_Credito.Codigo and Cli_For.Codigo = '"+txtCodigo.Text+"'", conn);

            conn.Open();

            //joga para o data reader aas informações
            SqlDataReader DR1 = busca.ExecuteReader();
            string Codigo = "";
            string Tipo = "";
            string Fisica_Juridica = "";
            string Inativo = "";
            string Bloqueado = "";
            string Data_Cadastro = "";
            string Data_Alteracao = "";
            string Nome = "";
            string CNPJ = "";
            string Inscricao = "";
            string Fone_1 = "";
            string Fone_2 = "";
            string Fax = "";
            string Endereco = "";
            string Complemento = "";
            string Bairro = "";
            string Cidade = "";
            string Estado = "";
            string CEP = "";
            string Sexo = "";
            string Nascimento = "";
            string Estado_Civil = "";
            string Naturalidade = "";
            string Nome_Mae = "";
            string Nome_Pai = "";
            string Tipo_Residencia = "";
            string Tempo_Residencia = "";
            string RG_Expedido_Em = "";
            string Empresa = "";
            string Telefone = "";
            string Contratacao = "";
            string Cargo = "";
            string Salario = "";
            string Comentarios = "";
            string OBS = "";
            int caracteres;
            int linhas;

            //Lança dados para os campos enquanto tiveer dados
            while (DR1.Read())
            {
                Codigo = (DR1["Codigo"].ToString());
                Tipo = (DR1["Tipo"].ToString());
                Fisica_Juridica = (DR1["Fisica_Juridica"].ToString());
                Inativo = (DR1["Inativo"].ToString());
                Bloqueado = (DR1["Bloqueado"].ToString());
                Data_Cadastro = (DR1["Data_Cadastro"].ToString());
                Data_Alteracao = (DR1["Data_Alteracao"].ToString());
                Nome = (DR1["Nome"].ToString());
                CNPJ = (DR1["CNPJ"].ToString());
                Inscricao = (DR1["Inscricao"].ToString());
                Fone_1 = (DR1["Fone_1"].ToString());
                Fone_2 = (DR1["Fone_2"].ToString());
                Fax = (DR1["Fax"].ToString());
                Endereco = (DR1["Endereco"].ToString());
                Complemento = (DR1["Complemento"].ToString());
                Bairro = (DR1["Bairro"].ToString());
                Cidade = (DR1["Cidade"].ToString());
                Estado = (DR1["Estado"].ToString());
                CEP = (DR1["CEP"].ToString());
                Sexo = (DR1["Sexo"].ToString());
                Nascimento = (DR1["Nascimento"].ToString());
                Estado_Civil = (DR1["Estado_Civil"].ToString());
                Naturalidade = (DR1["Naturalidade"].ToString());
                Nome_Mae = (DR1["Nome_Mae"].ToString());
                Nome_Pai = (DR1["Nome_Pai"].ToString());
                Tipo_Residencia = (DR1["Tipo_Residencia"].ToString());
                Tempo_Residencia = (DR1["Tempo_Residencia"].ToString());
                RG_Expedido_Em = (DR1["RG_Expedido_Em"].ToString());
                Empresa = (DR1["Empresa"].ToString());
                Telefone = (DR1["Telefone"].ToString());
                Contratacao = (DR1["Contratacao"].ToString());
                Cargo = (DR1["Cargo"].ToString());
                Salario = (DR1["Salario"].ToString());
                Comentarios = (DR1["Comentarios"].ToString());
                OBS = (DR1["OBS"].ToString());
            }
            conn.Close();
            if (Tipo == "C")
            {
                Tipo = "Cliente";
            }
            else
            {
                Tipo = "Fornecedor";
            }
            if (Fisica_Juridica == "F")
            {
                Fisica_Juridica = "Física";
            }
            else 
            {
                Fisica_Juridica = "Jurídica";
            }
            if (Inativo == "0")
            {
                Inativo = "Não";
            }
            else
            {
                Inativo = "Sim";
            }
            if (Bloqueado == "0")
            {
                Bloqueado = "Não";
            }
            else
            {
                Bloqueado = "Sim";
            }
            if (Sexo == "M")
            {
                Sexo = "Masculino";
            }
            else if (Sexo == "F")
            {
                Sexo = "Feminino";
            }
            if (Tipo_Residencia == "P")
            {
                Tempo_Residencia = "Própria";
            }
           
            //inicia a impressao
            PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
            e.Graphics.DrawString("Código: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha);
            e.Graphics.DrawString(Codigo, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 20);
            e.Graphics.DrawString("Tipo: ", FonteNegrito, Brushes.Black, MargemEsq + 100, PosicaoDaLinha);
            e.Graphics.DrawString(Tipo, FonteNormal, Brushes.Black, MargemEsq + 100 , PosicaoDaLinha + 20);
            e.Graphics.DrawString("Pessoa: ", FonteNegrito, Brushes.Black, MargemEsq + 200, PosicaoDaLinha);
            e.Graphics.DrawString(Fisica_Juridica, FonteNormal, Brushes.Black, MargemEsq + 200, PosicaoDaLinha+ 20);
            e.Graphics.DrawString("Inativo: ", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha);
            e.Graphics.DrawString(Inativo, FonteNormal, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 20);
            e.Graphics.DrawString("Bloqueado: ", FonteNegrito, Brushes.Black, MargemEsq + 400, PosicaoDaLinha);
            e.Graphics.DrawString(Bloqueado, FonteNormal, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 20);
            e.Graphics.DrawString("Cadastro: ", FonteNegrito, Brushes.Black, MargemEsq + 500, PosicaoDaLinha);
            e.Graphics.DrawString(Convert.ToString(Convert.ToDateTime(Data_Cadastro).ToString("dd/MM/yyyy")), FonteNormal, Brushes.Black, MargemEsq + 500, PosicaoDaLinha + 20);
            e.Graphics.DrawString("Atualização: ", FonteNegrito, Brushes.Black, MargemEsq + 600, PosicaoDaLinha );
            e.Graphics.DrawString(Convert.ToString(Convert.ToDateTime(Data_Alteracao).ToString("dd/MM/yyyy")), FonteNormal, Brushes.Black, MargemEsq + 600, PosicaoDaLinha + 20);
            e.Graphics.DrawString("Nome: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 40);
            e.Graphics.DrawString(Nome, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 60);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, PosicaoDaLinha + 80, MargemDireita + 90, PosicaoDaLinha + 80);
            
            e.Graphics.DrawString("CPF: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 100);
            e.Graphics.DrawString(CNPJ, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 120);
            e.Graphics.DrawString("RG: ", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 100);
            e.Graphics.DrawString(Inscricao, FonteNormal, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 120);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, PosicaoDaLinha + 140, MargemDireita + 90, PosicaoDaLinha + 140);

            e.Graphics.DrawString("Endereço: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 160);
            e.Graphics.DrawString(Endereco, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 180);
            e.Graphics.DrawString("Complemento: ", FonteNegrito, Brushes.Black, MargemEsq+500, PosicaoDaLinha + 160);
            e.Graphics.DrawString(Complemento, FonteNormal, Brushes.Black, MargemEsq + 500, PosicaoDaLinha + 180);
            e.Graphics.DrawString("Bairro: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 200);
            e.Graphics.DrawString(Bairro, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 220);
            e.Graphics.DrawString("Cidade: ", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 200);
            e.Graphics.DrawString(Cidade, FonteNormal, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 220);
            e.Graphics.DrawString("UF: ", FonteNegrito, Brushes.Black, MargemEsq + 600, PosicaoDaLinha + 200);
            e.Graphics.DrawString(Estado, FonteNormal, Brushes.Black, MargemEsq + 600, PosicaoDaLinha + 220);
            e.Graphics.DrawString("CEP: ", FonteNegrito, Brushes.Black, MargemEsq + 700, PosicaoDaLinha + 200);
            e.Graphics.DrawString(CEP, FonteNormal, Brushes.Black, MargemEsq + 700, PosicaoDaLinha + 220);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, PosicaoDaLinha + 240, MargemDireita + 90, PosicaoDaLinha + 240);

            e.Graphics.DrawString("Sexo: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 260);
            e.Graphics.DrawString(Sexo, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 280);
            e.Graphics.DrawString("Nascimento: ", FonteNegrito, Brushes.Black, MargemEsq+100, PosicaoDaLinha + 260);
            e.Graphics.DrawString(Nascimento, FonteNormal, Brushes.Black, MargemEsq+100, PosicaoDaLinha + 280);
            e.Graphics.DrawString("Estado Civil: ", FonteNegrito, Brushes.Black, MargemEsq+300, PosicaoDaLinha + 260);
            e.Graphics.DrawString(Estado_Civil, FonteNormal, Brushes.Black, MargemEsq +300, PosicaoDaLinha + 280);
            e.Graphics.DrawString("Naturalidade: ", FonteNegrito, Brushes.Black, MargemEsq+600, PosicaoDaLinha + 260);
            e.Graphics.DrawString(Naturalidade, FonteNormal, Brushes.Black, MargemEsq+600, PosicaoDaLinha + 280);
            e.Graphics.DrawString("Nome Mãe: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 300);
            e.Graphics.DrawString(Nome_Mae, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 320);
            e.Graphics.DrawString("Nome Pai: ", FonteNegrito, Brushes.Black, MargemEsq + 500, PosicaoDaLinha + 300);
            e.Graphics.DrawString(Nome_Pai, FonteNormal, Brushes.Black, MargemEsq + 500, PosicaoDaLinha + 320);
            e.Graphics.DrawString("Residência: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 340);
            e.Graphics.DrawString(Tipo_Residencia, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 360);
            e.Graphics.DrawString("Tempo Residência: ", FonteNegrito, Brushes.Black, MargemEsq + 200, PosicaoDaLinha + 340);
            e.Graphics.DrawString(Tempo_Residencia, FonteNormal, Brushes.Black, MargemEsq + 200, PosicaoDaLinha + 360);
            e.Graphics.DrawString("RG: ", FonteNegrito, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 340);
            e.Graphics.DrawString(RG_Expedido_Em, FonteNormal, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 360);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, PosicaoDaLinha + 380, MargemDireita + 90, PosicaoDaLinha + 380);

            e.Graphics.DrawString("Empresa: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 400);
            e.Graphics.DrawString(Empresa, FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 420);
            e.Graphics.DrawString("Telefone: ", FonteNegrito, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 400);
            e.Graphics.DrawString(Telefone, FonteNormal, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 420);
            e.Graphics.DrawString("Contratação: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 440);
            if (Contratacao != "")
            {
                e.Graphics.DrawString(Convert.ToString(Convert.ToDateTime(Contratacao).ToString("dd/MM/yyyy")), FonteNormal, Brushes.Black, MargemEsq, PosicaoDaLinha + 460);
            }
            e.Graphics.DrawString("Cargo: ", FonteNegrito, Brushes.Black, MargemEsq + 200, PosicaoDaLinha + 440);
            e.Graphics.DrawString(Cargo, FonteNormal, Brushes.Black, MargemEsq + 200, PosicaoDaLinha + 460);
            e.Graphics.DrawString("Salário: ", FonteNegrito, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 440);
            e.Graphics.DrawString(Cargo, FonteNormal, Brushes.Black, MargemEsq + 400, PosicaoDaLinha + 460);
            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, PosicaoDaLinha + 480, MargemDireita + 90, PosicaoDaLinha + 480);

      

            e.Graphics.DrawString("Comentários: ", FonteNegrito, Brushes.Black, MargemEsq, PosicaoDaLinha + 500);
            int cara;
            int l;
            float y = PosicaoDaLinha + 520;
            float x = PosicaoDaLinha + 580;
            SizeF linhadeimpressao = new SizeF(800, FonteNormal.Height);
            OBS = OBS.Replace("\n", " ");
            Comentarios = Comentarios.Replace("\n", " ");

            while (Comentarios.Length > 0)
            {

                e.Graphics.MeasureString(Comentarios, FonteNormal, linhadeimpressao, StringFormat.GenericDefault, out cara, out l);
                e.Graphics.DrawString(Comentarios.Substring(0, cara), FonteNormal, Brushes.Black, MargemEsq, y);
                y = y + 20;

                if (y == e.MarginBounds.Height)
                {
                    break;
                }
                Comentarios = Comentarios.Substring(cara);
            }
            
            e.Graphics.DrawString("Observações: ", FonteNegrito, Brushes.Black, MargemEsq, y + 20);
            x = y + 40;

            while ( OBS.Length > 0)
            {
           
            e.Graphics.MeasureString(OBS, FonteNormal, linhadeimpressao, StringFormat.GenericDefault, out cara, out l);
            e.Graphics.DrawString(OBS.Substring(0, cara), FonteNormal, Brushes.Black, MargemEsq, x);
            x = x + 20;

                if (x ==  e.MarginBounds.Height)
                {
                    break;
                }
                OBS = OBS.Substring(cara);
            }

            e.Graphics.DrawLine(CanetaDaImpressora, MargemEsq, x, MargemDireita + 90, x);
            e.Graphics.DrawString("Parcelamento", FonteNegrito, Brushes.Black, MargemEsq, x);
            e.Graphics.DrawString("Parcela", FonteNegrito, Brushes.Black, MargemEsq+100, x);
            e.Graphics.DrawString("Vencimento", FonteNegrito, Brushes.Black, MargemEsq + 200, x);
            e.Graphics.DrawString("Pagamento", FonteNegrito, Brushes.Black, MargemEsq + 300, x);
            e.Graphics.DrawString("Valor Pago", FonteNegrito, Brushes.Black, MargemEsq + 400, x);
            e.Graphics.DrawString("Receber", FonteNegrito, Brushes.Black, MargemEsq + 500, x);
            e.Graphics.DrawString("Atraso", FonteNegrito, Brushes.Black, MargemEsq + 600,  x);


            try
            {
                while ((LinhaAtual < LinhasPorPagina && registros > li))
                {


                    ////'impressão dos dados
                    PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[0].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[1].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 100, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[2].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 200, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[3].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 300, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[5].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 400, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[6].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 500, x + 20);
                    e.Graphics.DrawString(gridConsultaDebito.Rows[li].Cells[7].Value.ToString(), FonteNormal, Brushes.Black, MargemEsq + 600, x + 20);


                    x = x + 20;

                    LinhaAtual += 1;
                    li += 1;

                }
            }
            catch (NullReferenceException ex)
            {

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

            if (txtCodigo.Text != "")
            {

                RelatorioTitulo = "Consulta Débito de Cliente - ";
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
            else
            {
                MessageBox.Show("Obrigatório fazer a busca","Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
