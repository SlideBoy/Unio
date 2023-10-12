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
    public partial class CarregarConversas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            if (Session != null)
            {
                if (!String.IsNullOrEmpty(Request["e"]) && String.IsNullOrEmpty(Request["count"]))
                {
                    Mensagens mensagens = new Mensagens();
                    List<Mensagem> conversa = new List<Mensagem>();

                    if (Session["type"].ToString() == "Cliente")
                    {
                        Proposta prop = new Proposta();
                        int cdProp = prop.VerificarAnuncioContratado(Request["e"], Session["email"].ToString());
                        conversa = mensagens.CarregarMensagens(Request["e"], Session["email"].ToString(), cdProp.ToString());
                    }

                    if (Session["type"].ToString() == "Autonomo")
                    {
                        Proposta prop = new Proposta();
                        int cdProp = prop.VerificarAnuncioContratado(Session["email"].ToString(), Request["e"]);
                        conversa = mensagens.CarregarMensagens(Session["email"].ToString(), Request["e"], cdProp.ToString());
                    }

                    string retorno = "{'situacao':'false'}";

                    if (conversa != null && conversa.Count > 0)
                    {
                        retorno = "[";
                        foreach (Mensagem item in conversa)
                        {
                            retorno += "{'Mensagem':'" + item.Descricao + "', 'Envio':";

                            if (item.Envio == 1)
                            {
                                retorno += "'AutonomoMsg',";
                            }
                            if (item.Envio == 0)
                            {
                                retorno += "'ClienteMsg',";
                            }

                            retorno += "'type':'" + Session["type"].ToString() + "'},";
                        }
                        retorno = retorno.TrimEnd(',');
                        retorno += "]";

                        Response.Write(retorno.Replace('\'', '\"'));
                    }
                    else if (conversa != null && conversa.Count == 0)
                    {
                        retorno = "{'situacao':'true', 'qtMsg':'0'}";
                        Response.Write(retorno.Replace('\'', '\"'));
                    }
                    else
                    {
                        Response.Write(retorno.Replace('\'', '\"'));
                    }
                }

                if (!String.IsNullOrEmpty(Request["e"]) && !String.IsNullOrEmpty(Request["count"]))
                {
                    Mensagens mensagens = new Mensagens();
                    List<Mensagem> conversa = new List<Mensagem>();

                    if (Session["type"].ToString() == "Cliente")
                    {
                        Proposta prop = new Proposta();
                        int cdProp = prop.VerificarAnuncioContratado(Request["e"], Session["email"].ToString());
                        conversa = mensagens.CarregarMensagens(Request["e"], Session["email"].ToString(), cdProp.ToString());
                    }

                    if (Session["type"].ToString() == "Autonomo")
                    {
                        Proposta prop = new Proposta();
                        int cdProp = prop.VerificarAnuncioContratado(Session["email"].ToString(), Request["e"]);
                        conversa = mensagens.CarregarMensagens(Session["email"].ToString(), Request["e"], cdProp.ToString());
                    }

                    string retorno = "{'situacao':'false'}";

                    if (conversa != null && conversa.Count > int.Parse(Request["count"]))
                    {
                        retorno = "{'situacao':'true'}";
                        Response.Write(retorno.Replace('\'', '\"'));
                    }
                    else
                    {
                        Response.Write(retorno.Replace('\'', '\"'));
                    }
                }
            }
        }
    }
}