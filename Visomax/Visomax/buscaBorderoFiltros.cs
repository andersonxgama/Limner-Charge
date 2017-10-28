using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Visomax
{
    class buscaBorderoFiltros
    {
        //Método que preenche a grid de acordo com as checkbox(es) selecionada(s)
        public static void preencheGridFiltrada(String cobradora, String borderoDe, String borderoAte, DateTimePicker dataDe, DateTimePicker dataAte, DataGridView grid, CheckBox chkData, CheckBox chkEnvio, CheckBox chkRetorno)
        {
            String query = "";
            int id = retornaIdCobradora(cobradora);

            // 1 - Cobradora (Envio e Retorno)
            if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 2 - Cobradora (somente Envio)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 3 - Cobradora (somente Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 4 - Cobradora + Borderô (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 5 - Cobradora + Borderô (somente Envio)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 6 - Cobradora + Borderô (somente Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) (somente Envio)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) (somente Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) (somente Envio)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) (somente Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 7 - Cobradora + Data (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 8 - Cobradora + Data (somente Envio)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 9 - Cobradora + Data (somente Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 10 - Cobradora + Borderô + Data (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 11 - Cobradora + Borderô + Data (somente envio)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 12 - Cobradora + Borderô + Data (somente retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) + Data (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) + Data (somente envio)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoDe) + Data (somente retorno)
            else if ((!cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) + Data (Envio e Retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) + Data (somente envio)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Cobradora + Borderô (somente borderoAte) + Data (somente retorno)
            else if ((!cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.id_cob_portador = '" + id + "' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 13 - Borderô (Envio e Retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 14 - Borderô (somente envio)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 15 - Borderô (somente retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoDe) (Envio e Retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoDe) (somente envio)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoDe) (somente retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) (Envio e Retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) (somente envio)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) (somente retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 16 - Borderô + Data (Envio e Retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 17 - Borderô + Data (somente envio)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 18 - Borderô + Data (somente retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Borderô (somente borderoDe) + Data (Envio e Retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoDe) + Data (somente envio)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoDe) + Data (somente retorno)
            else if ((cobradora.Equals("")) && (!borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN '" + borderoDe + "' AND (SELECT MAX(num_bordero) FROM cobranca_docto_evento) AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) + Data (Envio e Retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) + Data (somente envio)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // Borderô (somente borderoAte) + Data (somente retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (!borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.num_bordero BETWEEN (SELECT MIN(num_bordero) FROM cobranca_docto_evento) AND '" + borderoAte + "' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // 19 - Data (Envio e Retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 20 - Data (somente envio)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 21 - Data (somente retorno)
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.dt_geracao BETWEEN '" + dataDe.Value.ToString("yyyy-MM-dd") + "' AND '" + dataAte.Value.ToString("yyyy-MM-dd") + "' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 22 - Envio
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (chkEnvio.Checked) && (!chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.descricao = 'Envio a Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }
            // 23 - Retorno
            else if ((cobradora.Equals("")) && (borderoDe.Equals("")) && (borderoAte.Equals("")) && (!chkData.Checked) && (!chkEnvio.Checked) && (chkRetorno.Checked))
            {
                query = "SELECT cde.descricao AS desc_acao, cde.id_cob_portador AS idPortador, cde.num_bordero AS numBordero, cde.dt_geracao AS dataGeracao, cp.descricao, cde.tipo_cob_portador AS TipoPortador, COUNT(1) AS qtde FROM cobranca_docto_evento cde INNER JOIN cobranca_portador cp ON cp.tipo_cob_portador = cde.tipo_cob_portador AND cp.id_cob_portador = cde.id_cob_portador WHERE cde.tipo_cob_portador = 'C' AND cde.descricao = 'Retorno da Cobradora' AND cde.num_bordero IS NOT NULL AND cp.tipo_cob_portador = 'C' AND cob_acao_tipo IN ('M','N') GROUP BY cde.cob_acao_tipo, cde.descricao, cde.tipo_cob_portador, cde.id_cob_portador, cde.dt_geracao, cde.num_bordero, cp.descricao ";
            }

            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            conexao.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conexao);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    grid.Rows.Add(sdr["desc_acao"], sdr["idPortador"].ToString(), cobradora, sdr["numBordero"].ToString(), Convert.ToDateTime(sdr["dataGeracao"].ToString()).ToString("dd/MM/yyyy"), sdr["qtde"].ToString());
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Erro na busca por filtros", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        //Preenche a coluna cobradora, caso a mesma esteja vazia
        public static void preencheColunaCobradora(DataGridView grid)
        {
            String query;

            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            try
            {
                if(grid.Rows.Count != 0)
                {
                    if(grid.Rows[0].Cells[2].Value.ToString().Equals(""))
                    {
                        for(int i = 0; i < grid.Rows.Count; i++)
                        {
                            query = "SELECT descricao FROM Cobradoras WHERE tipo_cob_portador = 'C' AND id_cob_portador = '" + grid.Rows[i].Cells[1].Value + "'";

                            SqlCommand cmd = new SqlCommand(query, sc);
                            SqlDataReader sdr = cmd.ExecuteReader();

                            while (sdr.Read())
                            {
                                grid.Rows[i].Cells[2].Value = sdr["descricao"];
                            }

                            sdr.Close();
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Não foi possível retornar a descrição da cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }
        }

        //Retorna o id da cobradora passado por parâmetro
        public static int retornaIdCobradora(String nomeCobradora)
        {
            SqlConnection sc = new SqlConnection(Properties.Settings.Default.VisomaxConnectionString);
            sc.Open();

            int id = 0;

            try
            {
                String query = "SELECT id_cob_portador FROM Cobradoras WHERE descricao = '" + nomeCobradora + "';";
                SqlCommand cmd = new SqlCommand(query, sc);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    id = sdr.GetByte(0);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível retornar o ID da cobradora", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                sc.Close();
            }

            return id;
        }
    }
}