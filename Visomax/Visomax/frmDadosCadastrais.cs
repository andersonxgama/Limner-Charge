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
    public partial class frmDadosCadastrais : Form
    {
        //String de conectar banco visomax
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.S8_RealConnectionString);

        public frmDadosCadastrais()
        {
            InitializeComponent();
        }

        private void frmDadosCadastrais_Load(object sender, EventArgs e)
        {

        }
        public  frmDadosCadastrais(int cod)
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString(cod);

            //Query SQL de busca
            SqlCommand busca = new SqlCommand("SELECT Cli_For.Codigo, Cli_For.tipo, Cli_For.Fisica_Juridica, "+
            "Cli_For.Data_Cadastro, Cli_For.Data_Alteracao, Cli_For.Nome, Cli_For.CNPJ, Cli_For.Inscricao, Cli_For.Inativo, "+ 
            "Cli_For.Bloqueado, Cli_For_Credito.Empresa, Cli_For_Credito.Contratacao, Cli_For_Credito.Cargo, "+
            "Cli_For_Credito.Salario, Cli_For.Fone_1, Cli_For.Fone_2, Cli_For_Credito.Telefone, Cli_For.Fax, "+
            "Cli_For.email, Cli_For.Endereco, Cli_For.Complemento, Cli_For.Bairro, Cli_For.Cidade, "+ 
            "Cli_For.Estado, Cli_For.CEP, Cli_For_Credito.Sexo, Cli_For_Credito.Nascimento, "+
            "Cli_For_Credito.Estado_Civil, Cli_For_Credito.Naturalidade, Cli_For_Credito.Nome_Mae, "+
            "Cli_For_Credito.Nome_Pai, Cli_For_Credito.Extra1, Cli_For_Credito.Tipo_Residencia, "+ 
            "Cli_For_Credito.Tempo_Residencia, Cli_For_Credito.Conjuge, Cli_For_Credito.C_Nascimento, "+
            "Cli_For_Credito.C_CPF, Cli_For_Credito.C_Empresa, Cli_For_Credito.C_Telefone, "+
            "Cli_For_Credito.C_Contratacao, Cli_For_Credito.C_Cargo, Cli_For_Credito.C_Salario, Cli_For.Comentarios, Cli_For_Credito.OBS " +
            "FROM Cli_For, Cli_For_Credito where Cli_For.Codigo = Cli_For_Credito.Codigo and Cli_For.Codigo ='"+txtCodigo.Text+"'", conn);
          
            conn.Open();

            //define o tipo do comando 
            busca.CommandType = CommandType.Text;
            //obtem um datareader
            IDataReader dr = busca.ExecuteReader();

            while (dr.Read())
            {
                txtTipo.Text = dr["tipo"].ToString();
                txtPessoa.Text = dr["Fisica_Juridica"].ToString();
                txtDataCadastro.Text = dr["Data_Cadastro"].ToString();
                txtDataAlteracao.Text = dr["Data_Alteracao"].ToString();
                txtNome.Text = dr["Nome"].ToString();
                txtCpf.Text = dr["CNPJ"].ToString();
                txtRg.Text = dr["Inscricao"].ToString();
                txtEmpresa.Text = dr["Empresa"].ToString();
                txtDataContratacao.Text = dr["Contratacao"].ToString();
                txtCargo.Text = dr["Cargo"].ToString();
                txtSalario.Text = dr["Salario"].ToString();
                txtTelResidencial.Text = dr["Fone_1"].ToString();
                txtCelular.Text = dr["Fone_2"].ToString();
                txtTelComercial.Text = dr["Telefone"].ToString();
                txtFax.Text = dr["Fax"].ToString();
                txtEmail.Text = dr["email"].ToString();
                txtEndereco.Text = dr["Endereco"].ToString();
                txtComplemento.Text = dr["Complemento"].ToString();
                txtBairro.Text = dr["Bairro"].ToString();
                txtCidade.Text = dr["Cidade"].ToString();
                txtEstado.Text = dr["Estado"].ToString();
                txtCep.Text = dr["CEP"].ToString();
                txtSexo.Text = dr["Sexo"].ToString();
                txtDataNascimento.Text = dr["Nascimento"].ToString();
                txtEstadoCivil.Text = dr["Estado_Civil"].ToString();
                txtNaturalidade.Text = dr["Naturalidade"].ToString();
                txtMae.Text = dr["Nome_Mae"].ToString();
                txtPai.Text = dr["Nome_Pai"].ToString();
                txtRgMae.Text = dr["Extra1"].ToString();
                txtResidencia.Text = dr["Tipo_Residencia"].ToString();
                txtTempoResidencia.Text = dr["Tempo_Residencia"].ToString();
                txtNomeConjuge.Text = dr["Conjuge"].ToString();
                txtDataNascimentoConjuge.Text = dr["C_Nascimento"].ToString();
                txtCpfConjuge.Text = dr["C_CPF"].ToString();
                txtEmpresaConjuge.Text = dr["C_Empresa"].ToString();
                txtTelefoneConjuge.Text = dr["C_Telefone"].ToString();
                txtDataContratacaoConjuge.Text = dr["C_Contratacao"].ToString();
                txtCargoConjuge.Text = dr["C_Cargo"].ToString();
                txtSalarioConjuge.Text = dr["C_Salario"].ToString();
                txtcomentario.Text = dr["Comentarios"].ToString();
                txtobs.Text = dr["OBS"].ToString();
                string inativo  = dr["inativo"].ToString();
                string bloqueado = dr["Bloqueado"].ToString();

                if (txtTipo.Text == "C")
                {
                    txtTipo.Text = "Cliente";
                }
                else
                {
                    txtTipo.Text = "Fornecedor";
                }

                if (txtPessoa.Text == "F")
                {
                    txtPessoa.Text = "Fisica";
                }
                else
                {
                    txtPessoa.Text = "Juridica";
                }

                if (inativo == "1")
                {
                    chkInativo.Checked = true;
                }
                if (bloqueado == "1")
                {
                    chkBloqueado.Checked = true;
                }
            }
        }
    }
}
