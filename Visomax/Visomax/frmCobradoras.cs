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
using System.Collections;
using System.Web;

namespace Visomax
{
    public partial class frmCobradoras : Form
    {
        public frmCobradoras()
        {
            InitializeComponent();
        }

        //Carrega as configurações iniciais do form
        private void frmCobradoras_Load(object sender, EventArgs e)
        {
            lblAguarde.Visible = false;
            carregaListaCobradoras();
        }

        //Clique do botão buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grdCobradoras.Rows.Clear();
            lblAguarde.Visible = true;
            lblAguarde.Refresh();
            carregarGridfrmCobradoras();
            lblAguarde.Visible = false;

            if(grdCobradoras.Rows.Count == 0)
            {
                lblAguarde.Visible = true;
                lblAguarde.Refresh();
                lblAguarde.Text = "Nenhum dado encontrado...";
                lblAguarde.Refresh();
                System.Threading.Thread.Sleep(5000);
                lblAguarde.Refresh();
                lblAguarde.Hide();
                lblAguarde.Refresh();
            }
        }

        //Clique do botão salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtCobradora.Text.Equals(""))
            {
                MessageBox.Show("Digite o nome da cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (lstCobradoras.Items.Contains(txtCobradora.Text))
                {
                    MessageBox.Show("Cobradora já cadastrada", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    inserirCobradora();
                    lstCobradoras.Items.Clear();
                    lstCobradoras.Refresh();
                    carregaListaCobradoras();
                    lstCobradoras.Refresh();
                    txtCobradora.Clear();
                }
            }
        }

        //Método que insere uma cobradora no BD
        private void inserirCobradora()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Cobradoras VALUES ('C','" + retornaProximoId() + "', '" + txtCobradora.Text + "')", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    lstCobradoras.Items.Add(sdr.GetValue(0).ToString());
                }

                MessageBox.Show("Cobradora cadastrada com sucesso", "Cobradoras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Método que faz o carregamento (evento load) das cobradoras
        private void carregaListaCobradoras()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT descricao FROM Cobradoras WHERE tipo_cob_portador = 'C'", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    lstCobradoras.Items.Add(sdr.GetValue(0).ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Carrega a grid com as informações da cobradora especificada na lista, e entre as datas selecionadas
        private void carregarGridfrmCobradoras()
        {
            if(lstCobradoras.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int idCobradora = retornaIdCobradora(lstCobradoras.SelectedItem.ToString());
                ArrayList listaClientes = retornaIdsClientesCobradora(idCobradora);

                foreach(int codigoCliente in listaClientes)
                {
                    carregarGridClientes(codigoCliente);
                }

                carregarGridSaldoDevedor();
                carregarGridSaldoVencer();
            }
        }

        //Método para preencher a grid com informações relativas ao saldo a vencer
        private void carregarGridSaldoVencer()
        {
            String query;

            SqlConnection sc = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
            sc.Open();

            try
            {
                for (int i = 0; i < grdCobradoras.Rows.Count; i++)
                {
                    query = "SELECT SUM(valor) AS 'saldoVencer' FROM Contas_Receber WHERE Cliente = '" + grdCobradoras.Rows[i].Cells[0].Value + "' AND Data_Recebimento IS NULL AND Vencimento > '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Tipo = 'R'";

                    SqlCommand cmd = new SqlCommand(query, sc);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        grdCobradoras.Rows[i].Cells[6].Value = sdr["saldoVencer"].ToString();
                    }

                    sdr.Close();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Método para preencher a grid com informações relativas ao saldo devedor
        private void carregarGridSaldoDevedor()
        {
            String query;

            SqlConnection sc = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);
            sc.Open();

            try
            {
                for (int i = 0; i < grdCobradoras.Rows.Count; i++)
                {
                    query = "SELECT SUM (valor) AS 'saldoDevedor' FROM Contas_Receber WHERE Cliente = '" + grdCobradoras.Rows[i].Cells[0].Value + "' AND Data_Recebimento IS  NULL;";

                    SqlCommand cmd = new SqlCommand(query, sc);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        grdCobradoras.Rows[i].Cells[5].Value = sdr["saldoDevedor"].ToString();
                    }

                    sdr.Close();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        /*Método para preencher a grid com as informações da tabela cobranca_docto_portador (informações referentes ao cliente). O método recebe por parâmetro
        os números vindo da lista que contêm os IDs dos clientes*/
        private void carregarGridClientes(int i)
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                String query = "SELECT cod_cliente, cliente, filial, sequencia, dt_inclusao FROM cobranca_docto_portador WHERE cod_cliente = '" + i + "' AND dt_inclusao >= '" + dataDeEnvio.Value.ToString("yyyy-MM-dd") + "' AND dt_inclusao <= '" + dataAteEnvio.Value.ToString("yyyy-MM-dd") + "' and tipo_cob_portador = 'C';";
                SqlCommand cmd = new SqlCommand(query, sc);
                SqlDataReader sdr = cmd.ExecuteReader();
                DateTime data;

                while (sdr.Read())
                {
                    data = DateTime.Parse(sdr["dt_inclusao"].ToString());
                    grdCobradoras.Rows.Add(sdr["cod_cliente"].ToString(), sdr["cliente"], sdr["filial"].ToString(), sdr["sequencia"].ToString(), data.ToString("dd/MM/yyyy"));
                }

                sdr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Método que retorna a lista de IDs dos Clientes cadastrados na cobradora passada por parâmetro
        private ArrayList retornaIdsClientesCobradora(int idCobradora)
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            ArrayList idListaCliente = new ArrayList();

            try
            {
                String query = "SELECT cod_cliente FROM cobranca_docto_portador WHERE id_cob_portador = '" + idCobradora + "';";
                SqlCommand cmd = new SqlCommand(query, sc);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    idListaCliente.Add(Convert.ToInt32(sdr["cod_cliente"]));
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }

            return idListaCliente;
        }

        //Método que retorna o ID da cobradora passado por parâmentro
        private int retornaIdCobradora(String cobradora)
        {
            int id = 0;

            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                String query = "SELECT id_cob_portador FROM Cobradoras WHERE descricao = '" + cobradora + "';";
                SqlCommand cmd = new SqlCommand(query, sc);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    id = sdr.GetByte(0);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }

            return id;
        }

        //Método que consulta o último ID cadastrado e retorna o próximo disponível
        private int retornaProximoId()
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            int id = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(id_cob_portador) FROM Cobradoras WHERE tipo_cob_portador = 'C'", sc);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    id = sdr.GetByte(0);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar o ID da última cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }

            return id + 1;
        }
    }
}