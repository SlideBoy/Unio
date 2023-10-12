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
    public partial class GerenciaEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            try
            {
                Estados estados = new Estados();
                List<Estado> listEstados = estados.CarregarEstados();

                if (listEstados.Count == 0)
                {
                    string retorno = "{'situacao':'true', 'qtProfissoes': '0'}";
                    retorno = retorno.Replace('\'', '\"');
                    Response.Write(retorno);
                }
                else
                {
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    string dadosJson = json.Serialize(listEstados);
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