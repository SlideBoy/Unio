using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class EnviarMensagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (!String.IsNullOrEmpty(Request["ed"]) && !String.IsNullOrEmpty(Request["msg"]))
            {
                string r = "{'situacao':'true'}";

                Mensagem novaMsg = new Mensagem();
                novaMsg.Descricao = Request["msg"];
                
                if (Session["type"].ToString() == "Cliente")
                {
                    novaMsg.EmailCliente = Session["email"].ToString();
                    novaMsg.EmailAutonomo = Request["ed"];
                    novaMsg.Envio = 0;
                }

                if (Session["type"].ToString() == "Autonomo")
                {
                    novaMsg.EmailAutonomo = Session["email"].ToString();
                    novaMsg.EmailCliente = Request["ed"];
                    novaMsg.Envio = 1;
                }

                try
                {
                    novaMsg.EnviarMensagem();
                }
                catch
                {
                    r = "{'situacao':'false'}";
                }
                finally
                {
                    Response.Write(r.Replace('\'', '\"'));
                }
            }
        }
    }
}