using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class CriarAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (!String.IsNullOrEmpty(Request["type"]) && !String.IsNullOrEmpty(Request["t"]) && !String.IsNullOrEmpty(Request["d"]) && !String.IsNullOrEmpty(Request["p"]) && !String.IsNullOrEmpty(Request["a"]))
            {
                string tipoAnuncio = Request["type"];
                string titulo = Request["t"];
                string descricao = Request["d"];
                string prazo = Request["p"];
                string area = Request["a"];

                Cliente cliente = new Cliente();
                cliente.Email = Session["email"].ToString();

                AreaAtuacao areaSelecionada = new AreaAtuacao();
                areaSelecionada.Codigo = int.Parse(area);

                Prazo prazoSelecionado = new Prazo();
                prazoSelecionado.Codigo = int.Parse(prazo);

                Anuncio anuncio = new Anuncio();
                anuncio.Cliente = cliente;
                anuncio.Titulo = titulo;
                anuncio.Descricao = descricao;
                anuncio.Prazo = prazoSelecionado;
                anuncio.AreaAtuacao = areaSelecionada;

                string retorno = "";

                if (tipoAnuncio == "public")
                {
                    anuncio.Destinatarios = null;
                }

                if (tipoAnuncio == "private")
                {
                    string[] destinatarios = { };

                    if (Request["dest"] == "")
                    {
                        retorno = "{'situacao':'erro', 'qtDestinatarios':'0'}";
                        Response.Write(retorno.Replace('\'', '\"'));
                        return;
                    }

                    destinatarios = Request["dest"].Split(',');

                    List<Autonomo> listDestinatarios = new List<Autonomo>();
                    foreach (string dest in destinatarios)
                    {
                        Autonomo autonomo = new Autonomo();
                        autonomo.Email = dest;

                        listDestinatarios.Add(autonomo);
                    }

                    anuncio.Destinatarios = listDestinatarios;
                }

                retorno = "{'situacao':'ok'}";

                try
                {
                    anuncio.CriarNovoAnuncio();
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