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

    public partial class frmBuscaDebito : Form
    {
        public static string cliente = "";

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
        public frmBuscaDebito()
        {
            InitializeComponent();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            //Buscando dados pessoais no banco
            SqlCommand busca = new SqlCommand("SELECT Codigo, Nome FROM Cli_For where Codigo = '"+txtCliente.Text+"'", conn);

            conn.Open();

            //joga para o data reader aas informações
            SqlDataReader DR1 = busca.ExecuteReader();


            //Lança dados para os campos enquanto tiveer dados
            while (DR1.Read())
            {
                txtClienteNome.Text = (DR1["Nome"].ToString());
 
            }
            conn.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cliente = txtCliente.Text;
       
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtClienteNome.Text = "";
        }
    }
}
