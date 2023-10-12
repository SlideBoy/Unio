using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class GerenciaFavs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (!String.IsNullOrEmpty(Request["type"]) && !String.IsNullOrEmpty(Request["filtro"]))
            {
                Favoritos favs = new Favoritos();
                List<String> emailsFavs = favs.CarregarFavoritosPorArea(Session["email"].ToString(), Request["filtro"]);

                List<Autonomo> favoritos = new List<Autonomo>();

                if (emailsFavs != null && emailsFavs.Count > 0)
                {
                    foreach (String line in emailsFavs)
                    {
                        string[] info = line.Split(',');

                        Autonomo favorito = new Autonomo();
                        favorito.Email = info[0];
                        favorito.PreencherDados();

                        favoritos.Add(favorito);
                    }

                    string retorno = "[";
                    foreach (Autonomo item in favoritos)
                    {
                        string check = "false";

                        foreach (Profissao p in item.Profissoes)
                        {
                            if (p.areaAtuacao.Codigo == int.Parse(Request["filtro"]))
                            {
                                check = "true"; break;
                            }
                        }

                        string arquivoImagem = "";

                        byte[] foto = item.Foto;
                        string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        retorno += "{'Email':'" + item.Email + "', 'Nome':'" + item.Nome + "',  'Comentario':'" + item.Comentario + "', 'Check':'" + check + "', 'Foto':'" + arquivoImagem + "'},";
                    }
                    retorno = retorno.TrimEnd(',');
                    retorno += "]";

                    Response.Write(retorno.Replace('\'', '\"'));

                }
                else
                {
                    string retorno = "{'situacao':'ok', 'qtFavs':'0'}";
                    Response.Write(retorno.Replace('\'', '\"'));
                }
            }
        }
    }
}