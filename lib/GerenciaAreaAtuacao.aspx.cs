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
    public partial class GerenciaAreaAtuacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            try
            {
                AreasAtuacao areas = new AreasAtuacao();
                List<AreaAtuacao> listAreas = areas.CarregarAreasAtuacao();

                if (listAreas.Count == 0)
                {
                    string retorno = "{'situacao':'true', 'qtAreas': '0'}";
                    retorno = retorno.Replace('\'', '\"');
                    Response.Write(retorno);
                }
                else
                {
                    JavaScriptSerializer json = new JavaScriptSerializer();
                    string dadosJson = json.Serialize(listAreas);
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