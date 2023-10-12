using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class ContratarAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (!String.IsNullOrEmpty(Request["ec"]) && !String.IsNullOrEmpty(Request["cd"]))
            {
                string emailCadindato = Request["ec"];
                string cdAnuncio = Request["cd"];

                Proposta proposta = new Proposta();

                string retorno = "";


                if(proposta.ContratarAutonomo(emailCadindato, cdAnuncio))
                retorno = "{'situacao':'ok'}";

                else
                retorno = "{'situacao':'erro'}";

                Response.Write(retorno.Replace('\'', '\"'));
            }
        }
    }
}