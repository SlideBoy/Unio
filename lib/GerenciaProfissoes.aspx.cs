using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class GerenciaProfissoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            
            try
            {
                Profissoes profissoes = new Profissoes();
                List<Profissao> listProfissoes = profissoes.carregarProfissoes();

                if (listProfissoes.Count == 0)
                {
                    string retorno = "{'situacao':'true', 'qtProfissoes': '0'}";
                    retorno = retorno.Replace('\'', '\"');
                    Response.Write(retorno);
                }
                else
                {
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    string dadosJson = json.Serialize(listProfissoes);
                    Response.Write(dadosJson);
                }
            }
            catch
            {
                string retorno = "{'situacao':'false'}";
                retorno = retorno.Replace('\'', '\"');
                Response.Write(retorno);
            }
        }  
    }
}