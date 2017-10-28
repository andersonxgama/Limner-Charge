using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Visomax
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();

            t.Abort();
        }

        public void SplashStart()
        {
            Application.Run(new frmSplash());
        }

        //Faz a abertura da tela de Administração de Cartões
        private void btnAdmCartoes_Click(object sender, EventArgs e)
        {
            frmAdmCartoes fac = new frmAdmCartoes();
            fac.ShowDialog();
        }

        //Faz a abertura da tela de Busca de cartões
        private void btnBuscaCartoes_Click(object sender, EventArgs e)
        {
            frmBuscaCartões fbc = new frmBuscaCartões();
            fbc.ShowDialog();
        }

        //Faz a abertura da tela de Consulta de Débito
        private void btnConsultaDebito_Click(object sender, EventArgs e)
        {
            frmConsultaDebito fcd = new frmConsultaDebito();
            fcd.ShowDialog();
        }

        //Faz a abertura da tela de Cobrança
        private void btnCobranca_Click(object sender, EventArgs e)
        {
            frmCobranca fc = new frmCobranca();
            fc.ShowDialog();
        }

        //Faz a abertura da tela de Consulta de Parcelas
        private void btnConsultaParcelas_Click(object sender, EventArgs e)
        {
            frmConsultaParcelas fcp = new frmConsultaParcelas();
            fcp.ShowDialog();
        }

        //Faz a abertura da tela de Recebimento de Caixas
        private void btnRecebimentoCaixas_Click(object sender, EventArgs e)
        {
            frmRecebimentoCaixas frc = new frmRecebimentoCaixas();
            frc.ShowDialog();
        }

        //Faz a abertura da tela de Borderô
        private void btnBordero_Click(object sender, EventArgs e)
        {
            frmBordero fb = new frmBordero();
            fb.ShowDialog();
        }

        //Faz a abertura da tela de Cobradoras
        private void btnCobradoras_Click(object sender, EventArgs e)
        {
            frmCobradoras fc = new frmCobradoras();
            fc.ShowDialog();
        }

        //Faz a abertura da tela Sobre
        private void btnSobre_Click(object sender, EventArgs e)
        {
            frmSobre fs = new frmSobre();
            fs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBanguelas entrar = new frmBanguelas();
            entrar.ShowDialog();
        }

        private void btnCarteiraPendente_Click(object sender, EventArgs e)
        {
            frmCarteirasPendentes entrar = new frmCarteirasPendentes();
            entrar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmConsultaGerencial entrar = new frmConsultaGerencial();
            entrar.ShowDialog();
        }

        private void btnGerenciaisCobranca_Click(object sender, EventArgs e)
        {
            frmGerenciaisCobranca entrar = new frmGerenciaisCobranca();
            entrar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frminadimplencia entrar = new frminadimplencia();
            entrar.ShowDialog();
        }
    }
}
