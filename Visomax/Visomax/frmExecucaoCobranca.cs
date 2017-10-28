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
   
    public partial class frmExecucaoCobranca : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        public frmExecucaoCobranca()
        {
            InitializeComponent();
        }
  

        private void frmExecucaoCobranca_Load(object sender, EventArgs e)
        {
            SqlCommand busca = new SqlCommand("select dt_geracao, descricao, count(1) as Qtde "+            
            "from cobranca_docto_evento "+
            "where cob_acao_tipo <> 'T' and pendente = 'S' "+          
            "group by dt_geracao, descricao, cob_acao_tipo "+               
            "order by dt_geracao", conn);

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
                this.dataGridView1.Invoke((MethodInvoker)delegate
                {
                    dataGridView1.Rows.Add(linhaDados);

                });
            }
            conn.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];
                frmEventosCobranca chamar = new frmEventosCobranca(SelectedRow);
                chamar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um registro!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
