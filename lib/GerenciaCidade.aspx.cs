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
    public partial class GerenciaCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (Request["f"] != null)
            {
                try
                {
                    Cidades cidades = new Cidades();
                    List<Cidade> listCidades = cidades.FiltrarCidades(Request["f"]); 

                    if (listCidades.Count == 0)
                    {
                        string retorno = "{'situacao':'true', 'qtCidade': '0'}";
                        retorno = retorno.Replace('\'', '\"');
                        Response.Write(retorno);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        string dadosJson = json.Serialize(listCidades);
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
            else
            {
                try
                {
                    Cidades cidades = new Cidades();
                    List<Cidade> listCidades = cidades.CarregarCidades();

                    if (listCidades.Count == 0)
                    {
                        string retorno = "{'situacao':'true', 'qtCidade': '0'}";
                        retorno = retorno.Replace('\'', '\"');
                        Response.Write(retorno);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        string dadosJson = json.Serialize(listCidades);
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
}