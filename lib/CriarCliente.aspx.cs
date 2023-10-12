using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class CriarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            try
            {

            Cliente cliente = new Cliente();
            string nome = Request["n"].ToString();
            string email = Request["e"].ToString();
            string cpf = Request["c"].ToString();
            string senha = Request["s"].ToString();
            string telefone = Request["t"].ToString();
            string cidade = Request["d"].ToString();

            string[] dadosCliente = { nome, email, cpf, senha, telefone, cidade, null };

            cliente.CadastrarCliente(dadosCliente);
                if (cliente.CadastrarCliente(dadosCliente))
                {
                    string retorno = "{'situacao':'true'}";
                    retorno = retorno.Replace('\'', '\"');
                    Response.Write(retorno);
                }
                else {
                    string retorno = "{'situacao':'false'}";
                    retorno = retorno.Replace('\'', '\"');
                    Response.Write(retorno);
                }
            }
            catch (Exception)
            {
                string retorno = "{'situacao':'false'}";
                retorno = retorno.Replace('\'', '\"');
                Response.Write(retorno);
            }
        }
    }
}