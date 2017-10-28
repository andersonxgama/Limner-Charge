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
using System.Collections;

namespace Visomax
{
    public partial class frmCobranca : Form
    {
        //String de conectar banco visomax
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
        SqlConnection connR = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

        public frmCobranca()
        {
            InitializeComponent();
        }

        private void frmCobranca_Load(object sender, EventArgs e)
        {

        }

        private void btnGerarCobranca_Click(object sender, EventArgs e)
        {

            //Gerando primeiro telefonema
            DateTime inicio = DateTime.Now;
            inicio = inicio.AddDays(-8);
            DateTime fim = DateTime.Now;
            fim = fim.AddDays(-11);


            SqlCommand primeirotelefonema = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, "+
                "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                "where vencimento between '"+fim.ToString("s")+"' and '"+inicio.ToString("s")+"' "+
                "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 "+
                "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

            connR.Open();
            SqlDataReader sdr = primeirotelefonema.ExecuteReader();

            ArrayList listaSequencia = new ArrayList();
            ArrayList listaFilial = new ArrayList();
            ArrayList listaVencimento = new ArrayList();
            ArrayList listaParcela = new ArrayList();
            ArrayList listaCliente = new ArrayList();
            ArrayList listaTipoParcelamento = new ArrayList();
            ArrayList ListaNomeCliente = new ArrayList();

            while (sdr.Read())
            {
                listaSequencia.Add(sdr["Sequencia"]);
                listaFilial.Add(sdr["filial"]);
                listaVencimento.Add(sdr["Vencimento"]);
                listaParcela.Add(sdr["parcela"]);
                listaCliente.Add(sdr["Cliente"]);
                listaTipoParcelamento.Add(sdr["Tipo_Parcelamento"]);
                ListaNomeCliente.Add(sdr["Nome"]);
            }
            connR.Close();

           
                foreach(Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);
                    
                    SqlCommand verificaprimeirotelefonema = new SqlCommand("if not exists (select sequencia "+
	                "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" +numeroSequencia.ToString()+ "' "+
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') "+
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', "+
                    "'', '"+listaCliente[i]+"', '"+ListaNomeCliente[i]+"', "+
                    "'1', 'Primeiro Telefonema', 'T', 'E', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificaprimeirotelefonema.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                   
                }

                //Gerando primeira Carta
                DateTime inicio1 = DateTime.Now;
                inicio1 = inicio1.AddDays(-12);
                DateTime fim1 = DateTime.Now;
                fim1 = fim1.AddDays(-19);


                SqlCommand primeiracarta = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, " +
                    "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                    "where vencimento between '" + fim1.ToString("s") + "' and '" + inicio1.ToString("s") + "' " +
                    "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 " +
                    "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                    "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

                connR.Open();
                SqlDataReader sdr1 = primeiracarta.ExecuteReader();

                listaSequencia.Clear();
                listaFilial.Clear();
                listaVencimento.Clear();
                listaParcela.Clear();
                listaCliente.Clear();
                listaTipoParcelamento.Clear();
                ListaNomeCliente.Clear();

                while (sdr1.Read())
                {
                    listaSequencia.Add(sdr1["Sequencia"]);
                    listaFilial.Add(sdr1["filial"]);
                    listaVencimento.Add(sdr1["Vencimento"]);
                    listaParcela.Add(sdr1["parcela"]);
                    listaCliente.Add(sdr1["Cliente"]);
                    listaTipoParcelamento.Add(sdr1["Tipo_Parcelamento"]);
                    ListaNomeCliente.Add(sdr1["Nome"]);
                }
                connR.Close();


                foreach (Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);

                    SqlCommand verificaprimeiracarta = new SqlCommand("if not exists (select sequencia " +
                    "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" + numeroSequencia.ToString() + "' " +
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') " +
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', " +
                    "'', '" + listaCliente[i] + "', '" + ListaNomeCliente[i] + "', " +
                    "'2', 'Primeira Carta', 'C', 'E', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificaprimeiracarta.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }

                //Gerando segundo telefonema
                DateTime inicio2 = DateTime.Now;
                inicio2 = inicio2.AddDays(-20);
                DateTime fim2 = DateTime.Now;
                fim2 = fim2.AddDays(-23);


                SqlCommand segundotelefonema = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, " +
                    "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                    "where vencimento between '" + fim2.ToString("s") + "' and '" + inicio2.ToString("s") + "' " +
                    "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 " +
                    "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                    "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

                connR.Open();
                SqlDataReader sdr2 = segundotelefonema.ExecuteReader();

                listaSequencia.Clear();
                listaFilial.Clear();
                listaVencimento.Clear();
                listaParcela.Clear();
                listaCliente.Clear();
                listaTipoParcelamento.Clear();
                ListaNomeCliente.Clear();

                while (sdr2.Read())
                {
                    listaSequencia.Add(sdr2["Sequencia"]);
                    listaFilial.Add(sdr2["filial"]);
                    listaVencimento.Add(sdr2["Vencimento"]);
                    listaParcela.Add(sdr2["parcela"]);
                    listaCliente.Add(sdr2["Cliente"]);
                    listaTipoParcelamento.Add(sdr2["Tipo_Parcelamento"]);
                    ListaNomeCliente.Add(sdr2["Nome"]);
                }
                connR.Close();


                foreach (Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);

                    SqlCommand verificasegundotelefonema = new SqlCommand("if not exists (select sequencia " +
                    "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" + numeroSequencia.ToString() + "' " +
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') " +
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', " +
                    "'', '" + listaCliente[i] + "', '" + ListaNomeCliente[i] + "', " +
                    "'3', 'Segundo Telefonema', 'T', 'E', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificasegundotelefonema.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                //Gerando segundo carta
                DateTime inicio3 = DateTime.Now;
                inicio3 = inicio3.AddDays(-24);
                DateTime fim3 = DateTime.Now;
                fim3 = fim3.AddDays(-29);


                SqlCommand segundacarta = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, " +
                    "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                    "where vencimento between '" + fim3.ToString("s") + "' and '" + inicio3.ToString("s") + "' " +
                    "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 " +
                    "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                    "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

                connR.Open();
                SqlDataReader sdr3 = segundacarta.ExecuteReader();

                listaSequencia.Clear();
                listaFilial.Clear();
                listaVencimento.Clear();
                listaParcela.Clear();
                listaCliente.Clear();
                listaTipoParcelamento.Clear();
                ListaNomeCliente.Clear();

                while (sdr3.Read())
                {
                    listaSequencia.Add(sdr3["Sequencia"]);
                    listaFilial.Add(sdr3["filial"]);
                    listaVencimento.Add(sdr3["Vencimento"]);
                    listaParcela.Add(sdr3["parcela"]);
                    listaCliente.Add(sdr3["Cliente"]);
                    listaTipoParcelamento.Add(sdr3["Tipo_Parcelamento"]);
                    ListaNomeCliente.Add(sdr3["Nome"]);
                }
                connR.Close();


                foreach (Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);

                    SqlCommand verificasegundacarta = new SqlCommand("if not exists (select sequencia " +
                    "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" + numeroSequencia.ToString() + "' " +
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') " +
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', " +
                    "'', '" + listaCliente[i] + "', '" + ListaNomeCliente[i] + "', " +
                    "'4', 'Segunda Carta', 'C', 'E', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificasegundacarta.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }

                //Gerando Envio SPC
                DateTime inicio4 = DateTime.Now;
                inicio4 = inicio4.AddDays(30);
                DateTime fim4 = DateTime.Now;
                fim4 = fim4.AddDays(39);


                SqlCommand SPC = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, " +
                    "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                    "where vencimento between '" + fim4.ToString("s") + "' and '" + inicio4.ToString("s") + "' " +
                    "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 " +
                    "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                    "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

                connR.Open();
                SqlDataReader sdr4 = SPC.ExecuteReader();

                listaSequencia.Clear();
                listaFilial.Clear();
                listaVencimento.Clear();
                listaParcela.Clear();
                listaCliente.Clear();
                listaTipoParcelamento.Clear();
                ListaNomeCliente.Clear();

                while (sdr4.Read())
                {
                    listaSequencia.Add(sdr4["Sequencia"]);
                    listaFilial.Add(sdr4["filial"]);
                    listaVencimento.Add(sdr4["Vencimento"]);
                    listaParcela.Add(sdr4["parcela"]);
                    listaCliente.Add(sdr4["Cliente"]);
                    listaTipoParcelamento.Add(sdr4["Tipo_Parcelamento"]);
                    ListaNomeCliente.Add(sdr4["Nome"]);
                }
                connR.Close();


                foreach (Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);

                    SqlCommand verificaspc = new SqlCommand("if not exists (select sequencia " +
                    "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" + numeroSequencia.ToString() + "' " +
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') " +
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', " +
                    "'', '" + listaCliente[i] + "', '" + ListaNomeCliente[i] + "', " +
                    "'5', 'Envio ao SPC', 'E', 'S', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificaspc.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
                //Gerando Envio Cobradora

                DateTime inicio5 = DateTime.Now;
                inicio5 = inicio5.AddDays(30);
                DateTime fim5 = DateTime.Now;
                fim5 = fim4.AddDays(39);


                SqlCommand cobradora = new SqlCommand("SELECT Sequencia, filial, Vencimento, MIN(parcela) as parcela, " +
                    "Cliente, Tipo_Parcelamento, Cli_For.Nome FROM Contas_Receber, Cli_For " +
                    "where vencimento between '" + fim5.ToString("s") + "' and '" + inicio5.ToString("s") + "' " +
                    "and Data_Recebimento is NULL and Usado_Pagar_Venda = 1 and Renegociado = 0 " +
                    "and Conta_Cancelada = 0 and Devolvido = 0 and Tipo_Parcelamento = 'T' and Cliente = Cli_For.Codigo " +
                    "Group by Sequencia, Filial, Parcela, Vencimento, Cliente, Tipo_Parcelamento, Cli_For.Nome", connR);

                connR.Open();
                SqlDataReader sdr5 = cobradora.ExecuteReader();

                listaSequencia.Clear();
                listaFilial.Clear();
                listaVencimento.Clear();
                listaParcela.Clear();
                listaCliente.Clear();
                listaTipoParcelamento.Clear();
                ListaNomeCliente.Clear();

                while (sdr5.Read())
                {
                    listaSequencia.Add(sdr5["Sequencia"]);
                    listaFilial.Add(sdr5["filial"]);
                    listaVencimento.Add(sdr5["Vencimento"]);
                    listaParcela.Add(sdr5["parcela"]);
                    listaCliente.Add(sdr5["Cliente"]);
                    listaTipoParcelamento.Add(sdr5["Tipo_Parcelamento"]);
                    ListaNomeCliente.Add(sdr5["Nome"]);
                }
                connR.Close();


                foreach (Int64 numeroSequencia in listaSequencia)
                {
                    int i = listaSequencia.IndexOf(numeroSequencia);

                    SqlCommand verificacobradora = new SqlCommand("if not exists (select sequencia " +
                    "from cobranca_docto_evento	where cobranca_docto_evento.sequencia = '" + numeroSequencia.ToString() + "' " +
                    "and cobranca_docto_evento.filial = '" + listaFilial[i] + "') " +
                    "INSERT INTO cobranca_docto_evento VALUES ((Select MAX (id_cob_doc_evento)+1 from cobranca_docto_evento),'R','" + listaFilial[i] + "', " +
                    "'" + numeroSequencia.ToString() + "', '" + listaParcela[i] + "', " +
                    "'', '" + listaCliente[i] + "', '" + ListaNomeCliente[i] + "', " +
                    "'8', 'Envio a Cobradora', 'M', 'C', '1', '" + DateTime.Now.ToString("s") + "', '" + DateTime.Now.ToString("s") + "', 'S', 'NULL', 'A', '" + System.Environment.UserName + "', " +
                    "'NULL','N')", conn);
                    try
                    {
                        conn.Open();
                        verificacobradora.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }

           
        }

        private void btnEfetuarCobranca_Click(object sender, EventArgs e)
        {
            frmExecucaoCobranca chamar = new frmExecucaoCobranca();
            chamar.ShowDialog();
        }

    }
}
