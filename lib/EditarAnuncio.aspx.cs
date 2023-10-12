using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class EditarAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (!String.IsNullOrEmpty(Request["c"]) && !String.IsNullOrEmpty(Request["t"]) && !String.IsNullOrEmpty(Request["d"]) && !String.IsNullOrEmpty(Request["p"]) && !String.IsNullOrEmpty(Request["a"]))
            {
                string codigo = Request["c"];
                string titulo = Request["t"];
                string descricao = Request["d"];
                string prazo = Request["p"];
                string area = Request["a"];

                Cliente cliente = new Cliente();
                cliente.Email = Session["email"].ToString();

                Prazo prazoSelecionado = new Prazo();
                prazoSelecionado.Codigo = int.Parse(prazo);

                AreaAtuacao areaSelecionada = new AreaAtuacao();
                areaSelecionada.Codigo = int.Parse(area);

                Anuncio anuncio = new Anuncio();
                anuncio.Cliente = cliente;
                anuncio.Titulo = titulo;
                anuncio.Descricao = descricao;
                anuncio.Prazo = prazoSelecionado;
                anuncio.AreaAtuacao = areaSelecionada;

                string retorno = "";

                retorno = "{'situacao':'ok'}";

                try
                {
                    anuncio.EditarAnuncio(int.Parse(codigo), titulo, descricao, int.Parse(prazo), int.Parse(area));
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