using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class EntrarSessao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string retorno = "{'situacao':'erro'}";

            if (String.IsNullOrEmpty(Request["e"]) || String.IsNullOrEmpty(Request["s"]))
            {
                Response.Write(retorno.Replace("'", "\""));
                return;
            }

            //Precisamos descobrir qual a melhor forma de avisar q eh um autonomo q ta vindo no usuario
            Usuario user = new Usuario();

            try
            {

                (Autonomo autonomo, Cliente cliente) = user.CarregarUsuario(Request["e"], Request["s"]);

                if (autonomo != null)
                {
                    Session["login"] = autonomo.Nome;
                    Session["email"] = autonomo.Email;
                    Session["senha"] = Request["s"]; /*Somente para fins de teste, posteriormente vamos retirar*/
                    Session["autonomo"] = autonomo;
                    Session["type"] = "Autonomo";
                    retorno = "{'situacao':'ok','nome':'" + autonomo.Nome + "', 'tipo': 'autonomo', 'profissao': '" + autonomo.Profissoes[0].Nome + "'}";
                    Response.Write(retorno.Replace("'", "\""));

                }
                else if (cliente != null)
                {
                    Session["login"] = cliente.Nome;
                    Session["email"] = cliente.Email;
                    Session["senha"] = Request["s"]; /*Somente para fins de teste, posteriormente vamos retirar*/
                    Session["cliente"] = cliente;
                    Session["type"] = "Cliente";
                    retorno = "{'situacao':'ok','nome':'" + cliente.Nome + "', 'tipo': 'cliente'}";
                    Response.Write(retorno.Replace("'", "\""));
                }
                else
                {
                    Response.Write(retorno.Replace("'", "\""));
                }
            }
            catch (Exception) {
                Response.Write(retorno.Replace("'", "\""));
            }
        }
    }
}