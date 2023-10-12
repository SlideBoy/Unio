using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class buscaServicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginAutonomo = "alan.lima@outlook.com";
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            if (Session["login"] != null)
            {
                loginAutonomo = Session["email"].ToString();
            }

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(loginAutonomo, Session["senha"].ToString());

            foto = autonomo.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

            if (String.IsNullOrEmpty(Request["s"]))
            {
                Literal litIdentificador = new Literal();
                litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                Form.Controls.Add(litIdentificador);

                Anuncios anuncios = new Anuncios();
                List<Anuncio> listAnuncios = anuncios.CarregarAnuncios(loginAutonomo);
                if (listAnuncios.Count < 1)
                {
                    SemAnuncios.Text = $@"
                    <div class='SemAnuncios'>
                        <figure>
                            <img src='imagens/elementos/Elemento19.svg' alt=''>
                        </figure>
                        <h2>Hmm... Não achamos um serviço com essas especificações :/
                        </h2>
                        <p>Tente pesquisar de uma maneira diferente.</p>
                    </div>";
                }
                else
                {
                    int i = 0;
                    foreach (Anuncio anuncio in listAnuncios)
                    {
                        //foto = anuncio.Cliente.Foto;
                        //base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        //arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        litResultados.Text += $@"<article class='anuncio' id='{anuncio.Codigo}'>
                                         <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                            <div class='titulo_Btn'>
                                <h2>{anuncio.Titulo}</h2>";


                        Proposta prop = new Proposta();
                        prop.Codigo = anuncio.Codigo;
                        bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());


                        if (prop.VerificarCandidatura(Session["email"].ToString()))
                        {
                            litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                             <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                        }
                        else
                        {
                            litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                             <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                        }


                        litResultados.Text += $@"</div>

                            <div class='data_Prazo'>
                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                            </div>

                            <p class='descricao'>{anuncio.Descricao}</p>

                            <div class='cliente_Opcoes'>
                                <div>
                                    <figure>
                                        <img src = '{arquivoImagem}' alt=''>
                                    </figure>
                                    <p>{anuncio.Cliente.Nome}</p>
                                </div>
                            </div>
                        </article>";

                        litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";


                        if (estadoCandidatura)
                        {
                            litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                        }
                        else
                        {
                            litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                        }

                        litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                            '<input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                <figure>
                                                    <img src='{arquivoImagem}' alt=''>
                                                </figure>
                                                <div class='SobreOanuncio'>
                                                    <h2>{anuncio.Titulo}</h2>
                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                    <div>
                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                    </div>
                                                </div>
                                            </section>
                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                            <div class='buttons' qual='{i}'>
                                                <button id = 'btnCancelar'> Cancelar </button>";

                        if (estadoCandidatura)
                        {
                            litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                            <button id='btnCancelarCandidaturaMesmo'>Retirar-me</button>";
                        }
                        else
                        {
                            litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                            <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Retirar-me</button>";
                        }
                        litPopUpDetalhes.Text += $@"</div>
                                        </article>";
                        i++;
                    }
                }
            }
            else
            {
                string busca = Request["s"].ToString();

                Literal litIdentificador = new Literal();
                litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                Form.Controls.Add(litIdentificador);

                Anuncios anuncios = new Anuncios();
                List<Anuncio> listAnuncios = anuncios.CarregarAnunciosComFiltro(loginAutonomo, busca);

                if (listAnuncios.Count < 1)
                {
                    SemAnuncios.Text = $@"
                    <div class='SemAnuncios'>
                        <figure>
                            <img src='imagens/elementos/Elemento19.svg' alt=''>
                        </figure>
                        <h2>Hmm... Não achamos um serviço com essas especificações :/
                        </h2>
                        <p>Tente pesquisar de uma maneira diferente.</p>
                    </div>";
                }
                else
                {
                    int i = 0;
                    foreach (Anuncio anuncio in listAnuncios)
                    {
                        foto = anuncio.Cliente.Foto;
                        base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        litResultados.Text += $@"<article class='anuncio' id='{anuncio.Codigo}'>
                                         <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                            <div class='titulo_Btn'>
                                <h2>{anuncio.Titulo}</h2>";


                        Proposta prop = new Proposta();
                        prop.Codigo = anuncio.Codigo;
                        bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());


                        if (prop.VerificarCandidatura(Session["email"].ToString()))
                        {
                            litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                             <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                        }
                        else
                        {
                            litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                             <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                        }


                        litResultados.Text += $@"</div>

                            <div class='data_Prazo'>
                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                            </div>

                            <p class='descricao'>{anuncio.Descricao}</p>

                            <div class='cliente_Opcoes'>
                                <div>
                                    <figure>
                                        <img src = '{arquivoImagem}' alt=''>
                                    </figure>
                                    <p>{anuncio.Cliente.Nome}</p>
                                </div>
                            </div>
                        </article>";

                        litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";


                        if (estadoCandidatura)
                        {
                            litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                        }
                        else
                        {
                            litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                        }

                        litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                            '<input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                <figure>
                                                    <img src='{arquivoImagem}' alt=''>
                                                </figure>
                                                <div class='SobreOanuncio'>
                                                    <h2>{anuncio.Titulo}</h2>
                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                    <div>
                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                    </div>
                                                </div>
                                            </section>
                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                            <div class='buttons' qual='{i}'>
                                                <button id = 'btnCancelar'> Cancelar </button>";

                        if (estadoCandidatura)
                        {
                            litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                            <button id='btnCancelarCandidaturaMesmo'>Retirar-me</button>";
                        }
                        else
                        {
                            litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                            <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Retirar-me</button>";
                        }
                        litPopUpDetalhes.Text += $@"</div>
                                        </article>";
                        i++;
                    }
                }

            }


        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;
            if (string.IsNullOrEmpty(busca))
            {

            }
            else
            {
                Response.Redirect($@"buscaServicos.aspx?s={busca}");

            }
        }
    }
}