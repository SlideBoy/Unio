using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class buscaAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string loginCliente = "";

                if (Session["login"] != null)
                {
                    loginCliente = Session["login"].ToString();
                    Literal litIdentificador = new Literal();
                    litIdentificador.Text = $"<input type='hidden' id='identificadorCliente' value='{loginCliente}'>";
                    Form.Controls.Add(litIdentificador);
                }

                string filtro = Request["p"];

                #region Estados

                 Estados estados = new Estados();
                List<Estado> listEstados = new List<Estado>();
                listEstados = estados.CarregarEstados();

                ddlEstado.Items.Add(new ListItem("-- Selecione --", "-1"));

                for (int indice = 0; indice < listEstados.Count; indice++)
                {
                    string sigla = listEstados[indice].Sigla.ToString();
                    string nome = listEstados[indice].Nome;
                    ddlEstado.Items.Add(new ListItem(nome, sigla));
                }

                #endregion

                #region Cidades
                ddlCidade.Items.Add(new ListItem("-- Selecione o estado --", "-1"));
                #endregion

                Autonomos autonomos = new Autonomos();
                List<Autonomo> listaAutonomos = autonomos.CarregarAutonomos(filtro);

                int i = 0;
                if (listaAutonomos.Count > 0)
                {
                    foreach (Autonomo autonomo in listaAutonomos)
                    {
                        if (autonomo.Congelado == false)
                        {
                            string arquivoImagem = "";
                            byte[] foto = autonomo.Foto;
                            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;
                            string comentario = "";
                            string avaliacao = "";

                            if (autonomo.Comentario.Length > 100)
                            {
                                comentario = autonomo.Comentario.Substring(0, 100);
                            }
                            else 
                            {
                                comentario = autonomo.Comentario;
                            }

                            if (autonomo.Avaliacao != 0)
                            {
                                avaliacao = autonomo.Avaliacao.ToString().Replace(".", ",");
                            }
                            else {
                                avaliacao = "0,0";
                            }

                            litResultados.Text += $@"<div class='autonomosResultado'>
                                                            <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                                <div class='autonomo' qual='{i}'>
                                                                <a href = 'perfilAutonomo.aspx?a={autonomo.Email}&p={Request["p"]}' class='infoAutonomo'>
                                                                    <h3>{autonomo.Nome}</h3>
                                                                    <p>{comentario}...</p>
                                                                    <div class='avaliacao'>
                                                                        <div class='barra' valor='{avaliacao}'>
                                                                            <div></div>
                                                                        </div>
                                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                                    </div>
                                                                </a>";


                            if (Session["login"] != null)
                            {
                                Favoritos favoritos = new Favoritos();
                                List<Autonomo> listaFavoritos = new List<Autonomo>();
                                listaFavoritos = favoritos.CarregarFavoritos(loginCliente);

                                if (favoritos.VerificaFavorito(loginCliente, autonomo.Email))
                                {
                                    litResultados.Text += $@"<figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                        <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                }
                                else
                                {
                                    litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                        <figure class='coracoesPreenchidos  escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                }


                                litResultados.Text += $@"<input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>";

                                i++;
                            }

                            litResultados.Text += $@"</div> 
                                                    </div>";
                        }
                    }
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

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEstado.Items.RemoveAt(0);

            while (ddlCidade.Items.Count > 0)
                ddlCidade.Items.RemoveAt(0);

            #region Cidades

            Cidades cidades = new Cidades();
            List<Cidade> listCidades = new List<Cidade>();
            string sigla = ddlEstado.SelectedItem.Value;
            listCidades = cidades.FiltrarCidades(sigla);
            ddlCidade.Items.Add(new ListItem("-- Selecione --", "-1"));

            for (int i = 0; i < listCidades.Count; i++)
            {
                string codigo = listCidades[i].Codigo.ToString();
                string nome = listCidades[i].Nome;
                ddlCidade.Items.Add(new ListItem(nome, codigo));
            }

            #endregion
        }

        protected void ddlCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCidade.Items.RemoveAt(0);
        }
    }
}