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
    public partial class frmEventosCobranca : Form
    {
        SqlConnection conn = new SqlConnection (Properties.Settings.Default.VisomaxConnectionString);
        public frmEventosCobranca()
        {
            InitializeComponent();
        }
        public frmEventosCobranca(DataGridViewRow row)
        {
            InitializeComponent();
            txtdata.Text = row.Cells[0].Value.ToString();
            txtacao.Text = row.Cells[1].Value.ToString();
            txtquantidade.Text = row.Cells[2].Value.ToString();
            DateTime Data = Convert.ToDateTime(txtdata.Text);
            string DataFormato = Data.ToString("s");

            SqlCommand cliente = new SqlCommand("select cde.id_cob_doc_evento as id_cob_doc_evento, "+                        
            "cde.filial            as filial, "+                          
            "cde.sequencia         as sequencia, "+                       
            "cde.parcela           as parcela, "+                                             
            "cde.cod_cliente       as codCliente, "+                      
            "cde.cliente           as nomeCliente, "+                     
            "cde.id_cob_acao       as id_cob_acao, "+                     
            "cde.tipo_cob_portador as tipoPortador, "+                      
            "cde.id_cob_portador   as codPortador "+                                         
            "from "+                                                        
            "cobranca_docto_evento as cde (nolock) "+                     
            "left outer join cobranca_portador cp (nolock) "+           
            "on cp.tipo_cob_portador = cde.tipo_cob_portador and "+   
            "cp.id_cob_portador   = cde.id_cob_portador "+         
            "where "+                                                       
            "tipo_cr      in ('R','C') and "+         
            "dt_geracao   = '"+DataFormato+"' and "+                           
            "cde.descricao  = '"+txtacao.Text+"' "+                               
            "and pendente = 'S' "+
            "order by "+                                                    
            "cde.filial, "+                                               
            "cde.sequencia, "+                                           
            "cde.parcela, "+                                              
            "cde.cheque ",conn);
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
              
                    dataGridView1.Rows.Add(linhaDados);

            }
            conn.Close();
        }
        private void frmEventosCobranca_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];
                frmConsultaDebito chamar = new frmConsultaDebito(SelectedRow, txtdata.Text);
                chamar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um registro!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
