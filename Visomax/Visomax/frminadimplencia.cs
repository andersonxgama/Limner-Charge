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
    public partial class frminadimplencia : Form
    {
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        String RelatorioTitulo = "Vendedor Analítico - ";
        int paginaAtual = 1;
        static int li = 0;
        public frminadimplencia()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string mes;
            decimal calculo;
            DateTime data = dtbase.Value;

            if (txtFilial.Text != "")
            {
               
                dataGridView1.Rows.Clear();

                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows.Add();
                    data = data.AddMonths(-i);
                    mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(data.Month) + "/" + data.Year;
                    dataGridView1.Rows[i].Cells[1].Value = mes;
                    dataGridView1.Rows[i].Cells[0].Value = cmbFilial.Text;

                    if (data.Month == DateTime.Now.Month)
                    {
                        SqlCommand cliente = new SqlCommand("select " +
                            "sum(a.Valor) as VlrPrevisto " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','''')  and " +
                            "a.filial in (" + cmbFilial.Text + ") and " +
                            "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                            "and DAY(a.vencimento) BETWEEN '1' AND '" + data.Day + "'", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        cliente.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr = cliente.ExecuteReader();
                        while (dr.Read())
                        {
                            dataGridView1.Rows[i].Cells[2].Value = dr["VlrPrevisto"];
                        }
                        conn2.Close();


                        //Qtde previsto

                        SqlCommand qtde = new SqlCommand("select " +
                            "count(1) as QtdPrevista " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                           "and DAY(a.vencimento) BETWEEN '1' AND '" + data.Day + "'", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtde.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr1 = qtde.ExecuteReader();
                        while (dr1.Read())
                        {
                            dataGridView1.Rows[i].Cells[3].Value = dr1["QtdPrevista"];
                        }
                        conn2.Close();


                        //Valor realizado

                        SqlCommand realizado = new SqlCommand("select " +
                            "sum(a.Valor) as VlrRealizado " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                           "and DAY(a.vencimento) BETWEEN '1' AND '" + data.Day + "'  and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        realizado.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr2 = realizado.ExecuteReader();
                        while (dr2.Read())
                        {
                            dataGridView1.Rows[i].Cells[4].Value = dr2["VlrRealizado"];
                        }
                        conn2.Close();


                        //Qtde realizados

                        SqlCommand qtderealizado = new SqlCommand("select " +
                            "count(1) as QtdRealizada " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                           "and DAY(a.vencimento) BETWEEN '1' AND '" + data.Day + "'  and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtderealizado.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr3 = qtderealizado.ExecuteReader();
                        while (dr3.Read())
                        {
                            dataGridView1.Rows[i].Cells[5].Value = dr3["QtdRealizada"];
                        }
                        conn2.Close();


                    }
                    else
                    {
                        SqlCommand cliente = new SqlCommand("select " +
                            "sum(a.Valor) as VlrPrevisto " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','''')  and " +
                            "a.filial in (" + cmbFilial.Text + ") and " +
                            "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "'", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        cliente.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr = cliente.ExecuteReader();
                        while (dr.Read())
                        {
                            dataGridView1.Rows[i].Cells[2].Value = dr["VlrPrevisto"];
                        }
                        conn2.Close();


                        //Qtde previsto

                        SqlCommand qtde = new SqlCommand("select " +
                            "count(1) as QtdPrevista " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtde.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr1 = qtde.ExecuteReader();
                        while (dr1.Read())
                        {
                            dataGridView1.Rows[i].Cells[3].Value = dr1["QtdPrevista"];
                        }
                        conn2.Close();


                        //Valor realizado

                        SqlCommand realizado = new SqlCommand("select " +
                            "sum(a.Valor) as VlrRealizado " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                           "and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        realizado.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr2 = realizado.ExecuteReader();
                        while (dr2.Read())
                        {
                            dataGridView1.Rows[i].Cells[4].Value = dr2["VlrRealizado"];
                        }
                        conn2.Close();


                        //Qtde realizados

                        SqlCommand qtderealizado = new SqlCommand("select " +
                            "count(1) as QtdRealizada " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                           "MONTH(a.vencimento) BETWEEN '" + data.Month + "' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '" + data.Year + "' AND '" + data.Year + "' " +
                           "and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtderealizado.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader dr3 = qtderealizado.ExecuteReader();
                        while (dr3.Read())
                        {
                            dataGridView1.Rows[i].Cells[5].Value = dr3["QtdRealizada"];
                        }
                        conn2.Close();

                    }
                
                    data = dtbase.Value;
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value) - Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);


                    calculo = (Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    dataGridView1.Rows[i].Cells[8].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                    dataGridView1.Rows[i].Cells[8].Value = dataGridView1.Rows[i].Cells[8].Value  + "%";

                    calculo = (Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    dataGridView1.Rows[i].Cells[9].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                    dataGridView1.Rows[i].Cells[9].Value = dataGridView1.Rows[i].Cells[9].Value  + "%";
                }

                //ACUMULADO
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "Acumulado";
                data = data.AddMonths(-6);

                 SqlCommand cliente1 = new SqlCommand("select " +
                            "sum(a.Valor) as VlrPrevisto " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                            "a.filial in (" + cmbFilial.Text + ") and " +
                            "MONTH(a.vencimento) BETWEEN '01' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '1900' AND '" + data.Year + "'", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        cliente1.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader drr = cliente1.ExecuteReader();
                        while (drr.Read())
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = drr["VlrPrevisto"];
                        }
                        conn2.Close();


                        //Qtde previsto

                        SqlCommand qtde1 = new SqlCommand("select " +
                            "count(1) as QtdPrevista " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                            "MONTH(a.vencimento) BETWEEN '01' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '1900' AND '" + data.Year + "'", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtde1.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader drr1 = qtde1.ExecuteReader();
                        while (drr1.Read())
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = drr1["QtdPrevista"];
                        }
                        conn2.Close();


                        //Valor realizado

                        SqlCommand realizado1 = new SqlCommand("select " +
                            "sum(a.Valor) as VlrRealizado " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                         "MONTH(a.vencimento) BETWEEN '01' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '1900' AND '" + data.Year + "' " +
                           "and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        realizado1.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader drr2 = realizado1.ExecuteReader();
                        while (drr2.Read())
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = drr2["VlrRealizado"];
                        }
                        conn2.Close();


                        //Qtde realizados

                        SqlCommand qtderealizado1 = new SqlCommand("select " +
                            "count(1) as QtdRealizada " +
                            "from " +
                            "contas_receber as a (nolock) " +
                            "inner join cli_for as b (nolock) " +
                            "on b.codigo = a.cliente " +
                            "where " +
                            "a.sequencia is not null and " +
                            "a.sequencia > 0 and " +
                            "a.conta_cancelada = 0 and " +
                            "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                           "a.filial in (" + cmbFilial.Text + ") and " +
                            "MONTH(a.vencimento) BETWEEN '01' AND '" + data.Month + "' AND YEAR(a.vencimento) BETWEEN '1900' AND '" + data.Year + "' " +
                           "and a.data_recebimento is not null ", conn2);
                        conn2.Open();

                        //define o tipo do comando 
                        qtderealizado1.CommandType = CommandType.Text;
                        //obtem um datareader
                        IDataReader drr3 = qtderealizado1.ExecuteReader();
                        while (drr3.Read())
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = drr3["QtdRealizada"];
                        }
                        conn2.Close();                  
                
               
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value) - Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value) - Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value);


                    calculo = (Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value + "%";

                    calculo = (Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value  + "%";

                //TOTAL

                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "TOTAL";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Tomato;
                
                for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = Convert.ToDecimal(dataGridView1.Rows[a].Cells[2].Value) + Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value) + Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[a].Cells[4].Value) + Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[a].Cells[5].Value) + Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value = Convert.ToDecimal(dataGridView1.Rows[a].Cells[6].Value) + Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value = Convert.ToInt32(dataGridView1.Rows[a].Cells[7].Value) + Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value);
                }

                calculo = (Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value + "%";

                calculo = (Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value) * 100) / Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value = 100 - Convert.ToDecimal(calculo.ToString("0.00"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[9].Value + "%";

               
            }
            else
            {
                MessageBox.Show("Obrigatório selecionar filial.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frminadimplencia_Load(object sender, EventArgs e)
        {
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

            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand ComboFilial = new SqlCommand("SELECT Codigo from Parametros_Filial ", conn2);
                conn2.Open();
                SqlDataReader leitor = ComboFilial.ExecuteReader();
                while (leitor.Read())
                {
                   cmbFilialAnalitico.Items.Add(leitor.GetValue(0));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand ComboFilial = new SqlCommand("SELECT Codigo from Parametros_Filial ", conn2);
                conn2.Open();
                SqlDataReader leitor = ComboFilial.ExecuteReader();
                while (leitor.Read())
                {
                    cmbFilialSintetico.Items.Add(leitor.GetValue(0));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilialAnalitico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + cmbFilialAnalitico.Text + "'", conn2);
                conn2.Open();
                SqlDataReader nome = NomeFilial.ExecuteReader();
                while (nome.Read())
                {
                    txtFilialAnalitico.Text = Convert.ToString(nome.GetValue(1));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string vendedor = null;
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
            DateTime Data = Convert.ToDateTime(dtDataAnalitico.Text);
            string DataFormato = Data.ToString("s");
            DateTime Dataf = Convert.ToDateTime(dtDataAnaliticof.Text);
            string DataFormatof = Dataf.ToString("s");

            //Comando sql para buscar o código das filiais
            SqlCommand buscavendedor = new SqlCommand("select distinct "+                                                      
                "c.nome as vendedor, "+                                                           
                "isnull((select top 1 "+                                               
                "aux.filial "+                                               
                "from "+                                                       
                "funcionarios_filiais as aux (nolock) "+                     
                "where  "+                                                     
                "aux.funcionario = a.vendedor "+                             
                "order by "+                                                   
                "aux.funcionario desc), 1) as loja "+                        
                "from  "+                                                                
                "contas_receber as a (nolock)  "+                                      
                "inner join cli_for as b (nolock)  "+                                  
                "on b.codigo = a.cliente  "+                                         
                "inner join funcionarios as c (nolock)  "+                             
                "on c.codigo = a.vendedor  "+                                        
                "where "+                                                                
                "a.sequencia is not null and "+                                       
                "a.sequencia > 0 and "+                                               
                "a.conta_cancelada = 0 and "+                                         
                "a.vendedor is not null and "+                                        
                "a.vendedor > 0 and "+                                                
                "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and "+                                       
                "isnull((select top 1 "+                                               
                    "aux.filial "+                                               
                    "from "+                                                       
                    "funcionarios_filiais as aux (nolock) "+                     
                    "where "+                                                      
                    "aux.funcionario = a.vendedor "+                             
                    "order by "+
                    "aux.funcionario desc), 1) in (" + cmbFilialAnalitico.Text + ") " + 
                "and  c.nome in (select distinct "+ 
                    "c.Nome "+                                                                                       
                    "from "+                                            
                    "contas_receber as a (nolock) "+                   
                    "inner join cli_for as b (nolock) "+               
                    "on b.codigo = a.cliente "+                     
                    "inner join funcionarios as c (nolock) "+         
                    "on c.codigo = a.vendedor "+                    
                    "where "+                                           
                    "a.sequencia is not null and "+                    
                    "a.sequencia > 0 and "+                            
                    "a.conta_cancelada = 0 and "+                     
                    "a.vendedor is not null and "+                    
                    "a.vendedor > 0 and "+                            
                    "a.data_recebimento is null and "+                
                    "a.vencimento < GetDate() and "+
                    "a.vencimento between '" + DataFormato + "' and '" + DataFormatof + "' and " +        
                    "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  ) "+
                "order by 2, 1", conn2);
            conn2.Open();

            //define o tipo do comando 
            buscavendedor.CommandType = CommandType.Text;
            //obtem um datareader
            IDataReader drrvendedor = buscavendedor.ExecuteReader();
            ArrayList lstvendedores = new ArrayList();
            ArrayList loja = new ArrayList();
            ArrayList lstclientevendas = new ArrayList();
            ArrayList lstlojas = new ArrayList();
            ArrayList lstsequenci = new ArrayList();
            ArrayList lstpc = new ArrayList();
            ArrayList lstvencimento = new ArrayList();
            ArrayList lstvalortotal = new ArrayList();
            ArrayList lstvaloraberto = new ArrayList();
            ArrayList lstvalorvencido = new ArrayList();

            while (drrvendedor.Read())
            {
                lstvendedores.Add(drrvendedor["vendedor"]);
                loja.Add(drrvendedor["loja"]);
            }
            conn2.Close();

            registros = lstvendedores.Count;

            //inicia a impressao
            PosicaoDaLinha = MargemSuperior + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
          

            int linhas = 0;

            while ((LinhaAtual < LinhasPorPagina && registros > li))
            {


                //obtem os valores do datareader
                e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha - 20, 820, PosicaoDaLinha - 20);
                e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha + 20, 820, PosicaoDaLinha + 20);

                e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha - 21, 60, PosicaoDaLinha+20);
                e.Graphics.DrawLine(CanetaDaImpressora, 300,PosicaoDaLinha - 21, 300,PosicaoDaLinha +20);
                e.Graphics.DrawString("Loja: ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha);
                filial = Convert.ToString(loja[li]);
                e.Graphics.DrawString(filial, FonteNegrito, Brushes.Black, MargemEsq + 100, PosicaoDaLinha);
                e.Graphics.DrawLine(CanetaDaImpressora, 820, PosicaoDaLinha -20, 820, PosicaoDaLinha +20);
                e.Graphics.DrawString("Vendedor: ", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha);
                vendedor = Convert.ToString(lstvendedores[li]);
                e.Graphics.DrawString(vendedor, FonteNegrito, Brushes.Black, MargemEsq + 380, PosicaoDaLinha);

                e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha +60, 820, PosicaoDaLinha+60);

                e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha + 20, 60, PosicaoDaLinha +60);
                e.Graphics.DrawLine(CanetaDaImpressora, 300, PosicaoDaLinha + 20, 300, PosicaoDaLinha +60);
                e.Graphics.DrawString("Cliente: ", FonteNegrito, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 40);
                e.Graphics.DrawLine(CanetaDaImpressora, 350, PosicaoDaLinha + 20, 350, PosicaoDaLinha +60);
                e.Graphics.DrawString("Lj: ", FonteNegrito, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 40);
                e.Graphics.DrawLine(CanetaDaImpressora, 420, PosicaoDaLinha + 20, 420, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Docto: ", FonteNegrito, Brushes.Black, MargemEsq + 350, PosicaoDaLinha + 40);
                e.Graphics.DrawLine(CanetaDaImpressora, 480, PosicaoDaLinha + 20, 480, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Parcs: ", FonteNegrito, Brushes.Black, MargemEsq + 420, PosicaoDaLinha + 40 );
                e.Graphics.DrawLine(CanetaDaImpressora, 550, PosicaoDaLinha + 20, 550, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Vencto: ", FonteNegrito, Brushes.Black, MargemEsq + 480, PosicaoDaLinha + 40 );
                e.Graphics.DrawLine(CanetaDaImpressora, 640, PosicaoDaLinha + 20, 640, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Vlr.Total: ", FonteNegrito, Brushes.Black, MargemEsq + 550, PosicaoDaLinha + 40);
                e.Graphics.DrawLine(CanetaDaImpressora, 730, PosicaoDaLinha + 20, 730, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Vlr.Aberto: ", FonteNegrito, Brushes.Black, MargemEsq + 640, PosicaoDaLinha + 40 );
                e.Graphics.DrawLine(CanetaDaImpressora, 820, PosicaoDaLinha + 20, 820, PosicaoDaLinha + 60);
                e.Graphics.DrawString("Vlr.Vencido: ", FonteNegrito, Brushes.Black, MargemEsq + 730, PosicaoDaLinha + 40 );


                SqlCommand buscavendas = new SqlCommand("select distinct " +
                "a.cliente, " +
                "b.nome, " +
                "a.filial, " +
                "a.sequencia, " +
                "(select " +
                    "isnull(min(cr.parcela), 0) " +
                    "from " +
                    "contas_receber as cr (nolock) " +
                    "where " +
                    "cr.cliente   = a.cliente   and " +
                    "cr.filial    = a.filial    and " +
                    "cr.sequencia = a.sequencia and " +
                "cr.data_recebimento is null) as PrimParc, " +
                "(select " +
                    "isnull(max(cr.parcela), 0) " +
                    "from " +
                    "contas_receber as cr (nolock) " +
                    "where " +
                    "cr.cliente   = a.cliente   and " +
                    "cr.filial    = a.filial    and " +
                "cr.sequencia = a.sequencia) as TotParc, " +
                "(select " +
                "min(cr.vencimento) " +
                "from " +
                "contas_receber as cr (nolock) " +
                "where " +
                "cr.cliente   = a.cliente   and " +
                "cr.filial    = a.filial    and " +
                "cr.sequencia = a.sequencia and " +
                "cr.data_recebimento is null) as PrimVcto, " +
                "(select " +
                    "isnull(sum(cr.valor), 0) " +
                    "from " +
                    "contas_receber as cr (nolock) " +
                    "where " +
                    "cr.cliente   = a.cliente   and " +
                    "cr.filial    = a.filial    and " +
                "cr.sequencia = a.sequencia) as VlrTotal, " +
                "(select " +
                    "isnull(sum(cr.valor), 0) " +
                    "from " +
                    "contas_receber as cr (nolock) " +
                    "where " +
                    "cr.cliente   = a.cliente   and " +
                    "cr.filial    = a.filial    and " +
                    "cr.sequencia = a.sequencia and " +
                "cr.data_recebimento is null) as VlrAberto, " +
                "(select " +
                    " isnull(sum(cr.valor), 0) " +
                    "from " +
                    "contas_receber as cr (nolock) " +
                    "where " +
                    "cr.cliente   = a.cliente   and " +
                    "cr.filial    = a.filial    and " +
                    "cr.sequencia = a.sequencia and " +
                    "cr.data_recebimento is null and " +
                    "cr.vencimento < GetDate()) as VlrVencido " +
                "from " +
                "contas_receber as a (nolock) " +
                "inner join cli_for as b (nolock) " +
                "on b.codigo = a.cliente " +
                "inner join funcionarios as c (nolock) " +
                "on c.codigo = a.vendedor " +
                "where " +
                "a.sequencia is not null and " +
                "a.sequencia > 0 and " +
                "a.conta_cancelada = 0 and " +
                "a.vendedor is not null and " +
                "a.vendedor > 0 and " +
                "a.data_recebimento is null and " +
                "a.vencimento < GetDate() and " +
                "a.vencimento between '" + DataFormato + "' and '" + DataFormatof + "' and " +
                "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                "c.nome = '" + lstvendedores[li] + "'", conn2);
                conn2.Open();

                //define o tipo do comando 
                buscavendas.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader ddrvendas = buscavendas.ExecuteReader();
                lstclientevendas.Clear();
                lstlojas.Clear();
                lstsequenci.Clear();
                lstpc.Clear();
                lstvencimento.Clear();
                lstvalortotal.Clear();
                lstvaloraberto.Clear();
                lstvalorvencido.Clear(); 

                while (ddrvendas.Read())
                {
                    
                    lstclientevendas.Add(ddrvendas["nome"]);
                    
                    lstlojas.Add(ddrvendas["filial"]);
                    
                    lstsequenci.Add(ddrvendas["sequencia"]);
                    
                    lstpc.Add(ddrvendas["PrimParc"]);
                    
                    lstvencimento.Add(DateTime.Parse(Convert.ToString(ddrvendas["PrimVcto"])).ToString("dd/MM/yyyy"));
                    
                    lstvalortotal.Add(ddrvendas["VlrTotal"]);
                    
                    lstvaloraberto.Add(ddrvendas["VlrAberto"]);
                    
                    lstvalorvencido.Add(ddrvendas["VlrVencido"]);


                    
                   
                }

                for (int i = 0; i < lstclientevendas.Count; i++)
                {
                    e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha + 100 + linhas, 820, PosicaoDaLinha + 100 + linhas);

                    e.Graphics.DrawLine(CanetaDaImpressora, 60, PosicaoDaLinha + 60 + linhas, 60, PosicaoDaLinha + 100 + linhas);
                    e.Graphics.DrawLine(CanetaDaImpressora, 820, PosicaoDaLinha + 60 + linhas, 820, PosicaoDaLinha + 100 + linhas);
                    
                    e.Graphics.DrawString(Convert.ToString(lstclientevendas[i]), FonteNormal, Brushes.Black, MargemEsq + 60, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstlojas[i]), FonteNormal, Brushes.Black, MargemEsq + 300, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstsequenci[i]), FonteNormal, Brushes.Black, MargemEsq + 350, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstpc[i]), FonteNormal, Brushes.Black, MargemEsq + 420, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstvencimento[i]), FonteNormal, Brushes.Black, MargemEsq + 470, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstvalortotal[i]), FonteNormal, Brushes.Black, MargemEsq + 550, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstvaloraberto[i]), FonteNormal, Brushes.Black, MargemEsq + 640, PosicaoDaLinha + 70 + linhas);
                    e.Graphics.DrawString(Convert.ToString(lstvalorvencido[i]), FonteNormal, Brushes.Black, MargemEsq + 730, PosicaoDaLinha + 70 + linhas);

                    linhas = linhas + 30;


                }

                conn2.Close();

                PosicaoDaLinha = PosicaoDaLinha + 100 + linhas;
                LinhaAtual += 8;
                li += 1;
                linhas = 0;
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
            if (cmbFilialAnalitico.Text == "")
            {

            }
            else
            {
                RelatorioTitulo = "Relatório de Inadimplentes por Vendedor - ";
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

        private void cmbFilialSintetico_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Comando SQL, ao selecionar envia o nome da filial para o txtfilial
            try
            {
                SqlCommand NomeFilial = new SqlCommand("SELECT Codigo, Nome from Parametros_Filial" +
                " where Codigo = '" + cmbFilialSintetico.Text + "'", conn2);
                conn2.Open();
                SqlDataReader nome = NomeFilial.ExecuteReader();
                while (nome.Read())
                {
                    txtFilialSintetico.Text = Convert.ToString(nome.GetValue(1));
                }
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarSintético_Click(object sender, EventArgs e)
        {
            if (cmbFilialSintetico.Text == "")
            {
            }
            else
            {
                dataGridView2.Rows.Clear();

                DateTime Data = Convert.ToDateTime(dtVencimentoI.Text);
                string DataFormato = Data.ToString("s");
                DateTime Dataf = Convert.ToDateTime(dtVencimentoF.Text);
                string DataFormatof = Dataf.ToString("s");

                SqlCommand vendedor = new SqlCommand("select distinct " +
                    "a.filial, " +
                    "a.vendedor, " +
                    "c.nome " +
                    "from " +
                    "contas_receber as a (nolock) " +
                    "inner join cli_for as b (nolock) " +
                    "on b.codigo = a.cliente " +
                    "inner join funcionarios as c (nolock) " +
                    "on c.codigo = a.vendedor " +
                    "where " +
                    "a.sequencia is not null and " +
                    "a.sequencia > 0 and " +
                    "a.conta_cancelada = 0 and  " +
                    "a.vendedor is not null and " +
                    "a.vendedor > 0 and " +
                    "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and  " +
                    "a.filial in (" + cmbFilialSintetico.Text + ")  " +
                    "order by " +
                    "a.filial, " +
                    "a.vendedor, " +
                    "c.nome", conn2);
                conn2.Open();

                //define o tipo do comando 
                vendedor.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = vendedor.ExecuteReader();
                //Obtem o número de colunas
                int nColunas = dr.FieldCount;

                //define um array de strings com nCOlunas
                string[] linhaDados = new string[nColunas];
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

                    dataGridView2.Rows.Add(linhaDados);

                }

                conn2.Close();

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {

                    SqlCommand VlrPrevisto = new SqlCommand("select " +
                        "sum(a.Valor) as VlrPrevisto " +
                        "from " +
                        "contas_receber as a (nolock) " +
                        "inner join cli_for as b (nolock) " +
                        "on b.codigo = a.cliente " +
                        "where " +
                        "a.sequencia is not null and " +
                        "a.sequencia > 0 and " +
                        "a.conta_cancelada = 0 and " +
                        "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and " +
                        "a.filial = " + cmbFilialSintetico.Text + " and " +
                        "a.vendedor = " + dataGridView2.Rows[i].Cells[1].Value + " and  " +
                        "a.vencimento between '" + DataFormato + "' and '" + DataFormatof + "'   ", conn2);
                    conn2.Open();

                    //define o tipo do comando 
                    VlrPrevisto.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader drVlrPrevisto = VlrPrevisto.ExecuteReader();
                    while (drVlrPrevisto.Read())
                    {
                        dataGridView2.Rows[i].Cells[3].Value = drVlrPrevisto["VlrPrevisto"];
                    }
                    conn2.Close();
                    if (dataGridView2.Rows[i].Cells[3].Value.ToString() == "")
                    {
                        dataGridView2.Rows[i].Cells[3].Value = "0,00";
                    }

                    SqlCommand VlrRealizado = new SqlCommand("select " +
                        "sum(a.Valor) as VlrRealizado " +
                        "from   " +
                        "contas_receber as a (nolock)   " +
                        "inner join cli_for as b (nolock)  " +
                        "on b.codigo = a.cliente " +
                        "where   " +
                        "a.sequencia is not null and  " +
                        "a.sequencia > 0 and    " +
                        "a.conta_cancelada = 0 and    " +
                        "a.tipo in ('R','C')  and a.tipo_parcelamento in ('C','B','T','')  and   " +
                        "a.filial = " + cmbFilialSintetico.Text + " and   " +
                        "a.vendedor = " + dataGridView2.Rows[i].Cells[1].Value + "  and   " +
                        "a.vencimento between '" + DataFormato + "' and '" + DataFormatof + "' and   " +
                        "a.data_recebimento is not null", conn2);
                    conn2.Open();

                    //define o tipo do comando 
                    VlrPrevisto.CommandType = CommandType.Text;
                    //obtem um datareader
                    IDataReader drVlrRealizado = VlrRealizado.ExecuteReader();
                    while (drVlrRealizado.Read())
                    {
                        dataGridView2.Rows[i].Cells[4].Value = drVlrRealizado["VlrRealizado"];
                    }
                    conn2.Close();
                    if (dataGridView2.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        dataGridView2.Rows[i].Cells[4].Value = "0,00";
                    }

                    dataGridView2.Rows[i].Cells[6].Value = "0.00%";


                    dataGridView2.Rows[i].Cells[5].Value = Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value) - Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);

                    if (dataGridView2.Rows[i].Cells[3].Value.ToString() == "0,00" || dataGridView2.Rows[i].Cells[4].Value.ToString() == "0,00")
                    {
                    }
                    else
                    {
                        decimal calculo2 = Convert.ToDecimal(dataGridView2.Rows[i].Cells[5].Value) / Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value) * 100;
                        dataGridView2.Rows[i].Cells[6].Value = Convert.ToDecimal(calculo2.ToString("0.00"));
                        dataGridView2.Rows[i].Cells[6].Value = dataGridView2.Rows[i].Cells[6].Value + "%";
                    }
                    
                   
                
                    
                }
            }
        }

    }
}
