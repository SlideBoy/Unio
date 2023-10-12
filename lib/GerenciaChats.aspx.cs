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
    public partial class GerenciaChats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string retorno = "{'situacao':'false'}";

            if(Session == null)
            {
                Response.Write(retorno.Replace('\'', '\"'));
                return;
            }

            if (Session["type"].ToString() == "Cliente")
            {
                Autonomos carregamento = new Autonomos();
                List<Autonomo> listChats = carregamento.CarregarContratados(Session["email"].ToString());

                if(listChats.Count > 0 && listChats != null)
                {
                    retorno = "[";
                    foreach (Autonomo item in listChats)
                    { 
                        string arquivoImagem = "";
                        string profissoes = "";

                        foreach (Profissao p in item.Profissoes)
                        {
                            profissoes += p.Nome + ",";
                        }
                        profissoes.TrimEnd(',');

                        byte[] foto = item.Foto;
                        string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        retorno += "{'Email':'" + item.Email + "', 'Nome':'" + item.Nome + "', 'Profissoes':'" + profissoes + "', 'Foto':'" + arquivoImagem + "'},";
                    }
                    retorno = retorno.TrimEnd(',');
                    retorno += "]";

                    Response.Write(retorno.Replace('\'', '\"'));
                }
                else
                {
                    retorno = "{'situacao':'true', 'qtChats':'0'}";
                    Response.Write(retorno);
                }
                
            }

            if (Session["type"].ToString() == "Autonomo")
            {
                Clientes carregamento = new Clientes();
                List<Cliente> listChats = carregamento.CarregarChats(Session["email"].ToString());

                if (listChats.Count > 0 && listChats != null)
                {
                    retorno = "[";
                    foreach (Cliente item in listChats)
                    {
                        string arquivoImagem = "";
                        byte[] foto = item.Foto;
                        string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        retorno += "{'Email':'" + item.Email + "', 'Nome':'" + item.Nome + "', 'Foto':'" + arquivoImagem + "'},";
                    }
                    retorno = retorno.TrimEnd(',');
                    retorno += "]";

                    Response.Write(retorno.Replace('\'', '\"'));
                }
                else
                {
                    retorno = "{'situacao':'true', 'qtChats':'0'}";
                    Response.Write(retorno);
                }
            }
        }
    }
}