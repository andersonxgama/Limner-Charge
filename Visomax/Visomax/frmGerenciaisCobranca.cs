using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Visomax
{
    public partial class frmGerenciaisCobranca : Form
    {
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        public frmGerenciaisCobranca()
        {
            InitializeComponent();
        }

        public frmGerenciaisCobranca(int filial, DateTime data, DateTime data2)
        {

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaGerencialCombranca chamar = new frmBuscaGerencialCombranca();
            chamar.ShowDialog();

            if (frmBuscaGerencialCombranca.filial != null && frmBuscaGerencialCombranca.data != null && frmBuscaGerencialCombranca.data2 != null)
            {
            

                DateTime datai = Convert.ToDateTime(frmBuscaGerencialCombranca.data);
                DateTime dataf = Convert.ToDateTime(frmBuscaGerencialCombranca.data2);
                string DataFormato = datai.ToString("s");
                string DataFormato2 = dataf.ToString("s");

                SqlCommand cliente = new SqlCommand("select " +
                    "a.filial, " +
                    "a.sequencia, " +
                    "a.parcela, " +
                    "a.cod_cliente, " +
                    "a.cliente,  " +
                    "(select   " +
                        "sum(x.valor)  " +
                        "from  " +
                        "S8_Real.dbo.contas_receber as x (nolock)  " +
                        "where  " +
                        "x.cliente   = a.cod_cliente and  " +
                        "x.filial    = a.filial      and  " +
                        "x.sequencia = a.sequencia   and   " +
                        "x.data_recebimento is null  and   " +
                        "x.vencimento < '" + DataFormato2 + "') as vlrvencido,  " +
                    "a.dt_geracao,  " +
                    "a.dt_execucao,  " +
                    "a.id_cob_acao,  " +
                    "a.descricao,   " +
                    "a.pendente " +
                    "from  " +
                    "cobranca_docto_evento as a (nolock)  " +
                    "where    " +
                    "1 = 1   " +
                    "and a.filial = '" + frmBuscaGerencialCombranca.filial + "'  " +
                    "and a.dt_geracao >= '" + DataFormato + "' " +
                    "and a.dt_geracao <= '" + DataFormato2 + "' ", conn);

                conn.Open();

                //define o tipo do comando 
                cliente.CommandType = CommandType.Text;
                //obtem um datareader
                IDataReader dr = cliente.ExecuteReader();

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

                                if (linhaDados[a] == "N")
                                {
                                    linhaDados[a] = "Não";
                                }
                                else if (linhaDados[a] == "S")
                                {
                                    linhaDados[a] = "Sim";
                                }

                            }
                        }
                        if (dr.GetFieldType(a).ToString() == "System.DateTime")
                        {
                            if (dr.IsDBNull(a))
                            {
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
                                linhaDados[a] = "0,00";
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

                    dataGridView1.Rows.Add(linhaDados);
                }
                conn.Close();
            }
        }
    }
}
