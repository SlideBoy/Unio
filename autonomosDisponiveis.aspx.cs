using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class autonomosDisponiveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            if (Session != null)
            {
                if (!String.IsNullOrEmpty(Request["ca"]))
                {
                    string emailCliente = "";

                    if (Session["email"] != null)
                    {
                        emailCliente = Session["email"].ToString();
                    }

                    Cliente c = new Cliente();
                    (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

                    arquivoImagem = "";
                    foto = cliente.Foto;
                    base64String = Convert.ToBase64String(foto, 0, foto.Length);
                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                    litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

                    Literal litIdentificador = new Literal();
                    litIdentificador.Text = $@"<input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>";

                    litResultados.Text = "";
                    Propostas propostas = new Propostas();
                    List<Autonomo> candidatos = propostas.CarregarCandidatos(Request["ca"], Session["email"].ToString());

                    int i = 0;
                    foreach (Autonomo candidato in candidatos)
                    {
                        arquivoImagem = "";
                        foto = candidato.Foto; 
                        base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        litResultados.Text += $@"<div class='autonomosResultado'>
                                    <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                    <input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>
                                    <div class='autonomo'>
                                        <div class='infoAutonomo'>
                                            <input type='hidden' id='identificadorCandidato' value='{candidato.Email}'>
                                            <h3>{candidato.Nome}</h3>
                                            <p class='descricao'>{candidato.Comentario.Substring(0, 200)}...</p>
                                            <div class='avaliacaoEstrelas'>
                                                <div class='barra' valor='5'>
                                                    <div></div>
                                                </div>
                                                <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                            </div>
                                        </div>

                                        <div class='coracoesEButton'>
                                             <button id='btnContratar'>Contratar</button>
                                             <input type ='hidden' value='{candidato.Email}'>
                                            <figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                            <figure class='coracoesPreenchidos escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                        </div>
                                    </div>
                                </div>";

                        i++;
                    }
                }
            }
            else
            {
                Response.Redirect("erro.aspx");
            }
        }
    }
}