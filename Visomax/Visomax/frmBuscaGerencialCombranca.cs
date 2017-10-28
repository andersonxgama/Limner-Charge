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
    public partial class frmBuscaGerencialCombranca : Form
    {
        public static string filial, data, data2;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        SqlConnection conn2 = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        public frmBuscaGerencialCombranca()
        {
            InitializeComponent();
        }

        private void txtcliente_TextChanged(object sender, EventArgs e)
        {
            //Buscando dados pessoais no banco
            SqlCommand busca = new SqlCommand("SELECT Codigo, Nome FROM Cli_For where Codigo = '" + txtcliente.Text + "'", conn);

            conn.Open();

            //joga para o data reader aas informações
            SqlDataReader DR1 = busca.ExecuteReader();


            //Lança dados para os campos enquanto tiveer dados
            while (DR1.Read())
            {
                txtnomecliente.Text = (DR1["Nome"].ToString());

            }
            conn.Close();
        }

        private void frmBuscaGerencialCombranca_Load(object sender, EventArgs e)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ArrayList acao = new ArrayList(); 
            ArrayList descricao = new ArrayList();

            try
            {
                //Comando sql para buscar o código das filiais
                SqlCommand acoes = new SqlCommand("select "+
                    "id_cob_acao, " +           
                    "descricao "+              
                    "from "+
                    "cobranca_acao (nolock) " + 
                    "order by "+                 
                    "id_cob_acao ", conn2);
                conn2.Open();

                SqlDataReader leitor = acoes.ExecuteReader();
                while (leitor.Read())
                {
                    acao.Add(leitor["id_cob_acao"]);
                    descricao.Add(leitor["descricao"]);
                }
                conn2.Close();

                for (int i = 0; i < acao.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = acao[i].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = descricao[i].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {

                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    dataGridView1.Rows[x].Cells[0].Value = true;
                }
            }
            else
            {
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    dataGridView1.Rows[x].Cells[0].Value = false;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filial = cmbFilial.Text;
            data = dtgeracaoi.Text;
            data2 = dtgeracaof.Text;
            
            Close();
        }


    }
}
