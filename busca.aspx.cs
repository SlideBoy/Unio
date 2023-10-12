using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class busca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (!String.IsNullOrEmpty(Request["p"]))
                {
                    string busca = Request["p"].ToString();
                    iptBusca.Text = busca;

                    Profissoes profissoes = new Profissoes();
                    List<Profissao> listaProfissao = profissoes.carregarProfissoesNaBusca(busca);

                    if (listaProfissao.Count > 0)
                    {
                        litResultados.Text = "<section class='resultadosBusca'>";
                        litResultados.Text += $@"<p class='titulo'>Resultados por <strong>'{busca}'</strong></p>";
                        foreach (Profissao profissao in listaProfissao)
                        {
                            litResultados.Text += $@"
                        <a href='buscaAutonomo.aspx?p={profissao.Nome}' class='resultados'>
                            <div class='itemResultados'>
                                <p>{profissao.Nome}</p>
                                <img src='imagens/icones/front_icon_busca.png' alt=''>
                            </div>
                        </a>";
                        }
                        litResultados.Text += "</section>";
                    }
                    else
                    {
                        litResultados.Text = $@"<div class='SemAnuncios'>
                                            <figure>
                                                <img src = 'imagens/elementos/Elemento19.svg' alt = ''>
   
                                            </figure>
   
                                            <h2> Hmm... Não achamos um serviço com essas especificações:/</h2>
                                            <p> Tente pesquisar de uma maneira diferente.</p>
                                            </div> ";
                    }
                }
            }
        }

        protected void btnBusca_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;
            if (string.IsNullOrEmpty(busca))
            {
                iptBusca.Focus();
            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }
    }
}