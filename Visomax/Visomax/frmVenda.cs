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
    public partial class frmVenda : Form
    {
        SqlConnection conn= new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

        public frmVenda()
        {
            InitializeComponent();
        }

        private void frmVenda_Load(object sender, EventArgs e)
        {

        }
        public frmVenda(string doc, string filial)
        {

            InitializeComponent();
            SqlCommand Vendedor = new SqlCommand("SELECT Saidas.vendedor1, funcionarios.Nome "+ 
                "FROM Saidas, Funcionarios "+
                "where Saidas.vendedor1 = funcionarios.codigo and Saidas.Sequencia = '"+doc+"' "+
                "and Saidas.Filial ='"+filial+"'", conn);
           
            conn.Open();

            //define o tipo do comando 
            Vendedor.CommandType = CommandType.Text;
            //joga para o data reader aas informações
            IDataReader DR1 = Vendedor.ExecuteReader();


            //Lança dados para os campos enquanto tiveer dados
            while (DR1.Read())
            {
               txtCodigoVendedor.Text = DR1["vendedor1"].ToString();
               txtNomeVendedor.Text = DR1["Nome"].ToString();
            }
            conn.Close();


            //Query SQL de busca
            SqlCommand busca = new SqlCommand("SELECT Saidas_Produtos.Codigo, Produtos.Nome, Saidas_Produtos.Preco_Unit, "+
                "Saidas_Produtos.Qtde, Saidas_Produtos.Desconto_Perc, Saidas_Produtos.Preco_com_Desc "+
                "FROM Saidas_Produtos, Produtos "+
                "where produtos.Codigo = Saidas_Produtos.Codigo and Saidas_Produtos.Sequencia ='" + doc + "' and Saidas_Produtos.Filial = '" + filial + "'", conn);

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

                gridVenda.Rows.Add(linhaDados);

            }
            conn.Close();
        }
    }
}
