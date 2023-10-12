using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class ConcluirAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (!String.IsNullOrEmpty(Request["c"]))
            {
                int codigo = int.Parse(Request["c"]);

                string retorno = "";

                retorno = "{'situacao':'ok'}";

                Anuncio anuncio = new Anuncio();

                try
                {
                    anuncio.ConcluirAnuncio(codigo);
                }
                catch
                {
                    retorno = "{'situacao':'erro'}";
                }
                finally
                {
                    Response.Write(retorno.Replace('\'', '\"'));
                }

            }
        }
    }
}