using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class AdicionarCandidatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (!String.IsNullOrEmpty(Request["ec"]) && !String.IsNullOrEmpty(Request["ca"]))
            {
                string emailCadindato = Session["email"].ToString();

                string emailCliente = Request["ec"];
  
                string codigoAnuncio = Request["ca"];

                Proposta proposta = new Proposta();
                bool retorno = proposta.AdicionarCandidato(emailCadindato, emailCliente, codigoAnuncio);

                string r = "{'situacao':'erro'}";
                if (!retorno)
                {
                    Response.Write(r.Replace('\'', '\"'));
                }
                else
                {
                    r = "{'situacao':'ok'}";
                    Response.Redirect("painelAutonomo.aspx");
                    Response.Write(r.Replace('\'', '\"'));
                }
            }
        }
    }
}