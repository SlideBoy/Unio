using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class painelCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }

            Cliente c = new Cliente();
            (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            string arquivoImagem = "";
            byte[] foto = cliente.Foto; 
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            litInfosCliente.Text = $@"<div class='informacoes'>
                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                            <div class='info'>
                                                <h2>{cliente.Nome}</h2>
                                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {cliente.Cidade.Nome} </div>
                                            </div>                    
                                          </div>";
            litServicos.Text = "";

            Anuncios anuncios = new Anuncios();
            List<Anuncio> listAnuncios = anuncios.CarregarAnunciosCliente(emailCliente);
            int i = 0;

            if(listAnuncios.Count >= 1){
                litServicos.Text = $@" <section class='listaServicos'>";
                foreach (Anuncio anuncio in listAnuncios)
                {
                    //type = 'hidden'
                    litDenunciar.Text += $@"    <article class='pnlDenuncia escondido' qual='{i}'>
                                                <div class='cabecalhoDenuncia'>
                                                    <figure class='backIcon'>
                                                        <img src='imagens/icones/back_icon.png' alt=''>
                                                    </figure>
                                                    <h2>Denuncie</h2>
                                                    <figure class='alertIcon'>
                                                        <img src='imagens/icones/alert_icon.png' alt=''>
                                                    </figure>
                                                </div>
                                                <div class='areaVermelha'>Revise os dados da sua denúncia</div>

                                                <section class='infosCliente'>
                                                    <p class='clienteDenunciado'>Autônomo denunciado:</p>
                                                    <div class='SobreOAutonomo'>
                                                        <figure>
                                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                        </figure>
                                                        <div>
                                                            <h2>{cliente.Nome}</h2>
                                                            <p>{anuncio.Titulo}</p>
                                                            <p class='data'>{anuncio.DataPublicacao}</p>
                                                        </div>
                                                    </div>
                                                    <div class='SobreADenuncia'>
                                                        <label for=''>Selecione uma categoria:
                                                            <select name='' id='selectCategoriaDenuncia'></select>
                                                        </label>
                
                                                        <label for='' class='divTextarea'>Descreva o ocorrido:
                                                            <textarea name='' id='' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                        </label>
                                                        <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o autônomo não saberá que ela foi feita por você.</p>
                                                        <div class='divButton'>
                                                            <button id='btnDenunciar'>Denunciar</button>
                                                        </div>
                                                    </div>
                                                </section>
                                            </article>";

                    litConcluir.Text += $@"<article class='pnlConcluir escondido' qual='{i}'>
                                            <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                            <div class='cabecalhoConcluir'>
                                                <figure class='backIcon'>
                                                    <img src='imagens/icones/back_icon.png' alt=''>
                                                </figure>
                                                <h2>Concluir</h2>
                                            </div>
                                                <section class='infosCliente'>
                                                    <div class='SobreOAutonomo'>
                                                        <figure>
                                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                        </figure>
                                                        <div>
                                                            <h2>{anuncio.Titulo}</h2>
                                                            <p>{cliente.Nome}</p>
                                                        </div>
                                                    </div>

                                                    <section class='InicioPrazoConclusao'>
                                                        <div>
                                                            <h3 class='inicio'>Início</h3>
                                                            <p>{anuncio.DataPublicacao.ToString().Substring(0,10)}</p>
                                                        </div>
                                                        <div class='divMeio'>
                                                            <h3 class='prazo'>Prazo</h3>
                                                            <p>{anuncio.Prazo.Nome}</p>
                                                        </div>
                                                        <div>
                                                            <h3 class='conclusao'>Conclusão</h3>
                                                            <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                        </div>
                                                    </section>
                                                    <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao concluir tenha certeza de que o serviço já foi completamente finalizado.</p>
                                                    <div class='divButton'>
                                                        <button id='btnConcluir'>Concluir</button>
                                                    </div>
                                                </section>
                                        </article>";

                    litCancelar.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                           <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                            <div class='cabecalhoCancelar'>
                                                <figure class='backIcon'>
                                                    <img src='imagens/icones/back_icon.png' alt=''>
                                                </figure>
                                                <h2>Cancelar</h2>
                                            </div>

                                                <section class='infosCliente'>
                                                    <div class='SobreOAutonomo'>
                                                        <figure>
                                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                        </figure>
                                                        <div>
                                                            <h2>{anuncio.Cliente.Nome}</h2>
                                                            <p>Personalização da minha geladeira</p>
                                                        </div>
                                                    </div>
                                                    <section class='InicioPrazoCancelamento'>
                                                        <div>
                                                            <h3 class='inicio'>Início</h3>
                                                            <p>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                        </div>
                                                        <div class='divMeio'>
                                                            <h3 class='prazo'>Prazo</h3>
                                                            <p>{anuncio.Prazo.Nome}</p>
                                                        </div>
                                                        <div>
                                                            <h3 class='cancelamento'>Cancelamento</h3>
                                                            <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                        </div>
                                                    </section>
                                                    <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                    <div class='divButton'>
                                                        <button id='btnCancelar2'>Cancelar</button>
                                                    </div>
                                                </section>
                                        </article>";

                    string styleEstado = "";
                    if (anuncio.Estado.Codigo == 1)
                    {
                        styleEstado = "background-color: #4660d06b; color: #1736be;";
                    }
                    if (anuncio.Estado.Codigo == 2)
                    {
                        styleEstado = "background-color: #4660cf; color: #f2f5ff;";
                    }
                    if (anuncio.Estado.Codigo == 3)
                    {
                        styleEstado = "background-color: #6dc00088; color: #2C4F00;";
                    }
                    if (anuncio.Estado.Codigo == 4)
                    {
                        styleEstado = "background-color: #de0028a6; color: #fefefe;";
                    }


                    litServicos.Text += $@"<article class='anuncio'>
                                    <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                    <div class='titulo_Btn'>
                                        <h2>{anuncio.Titulo}</h2>
                                        <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                    </div>
        
                                    <div class='data_Prazo'>
                                        <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                    </div>
        
                                    <p class='descricao'>{anuncio.Descricao}</p>
        
                                    <div class='cliente_Opcoes'>
                                        <div>
                                            <a href='AutonomosDisponiveis.aspx?ca={anuncio.Codigo}'><p class='autonomosDisponiveis'>{anuncio.Destinatarios.Count}</p></a>
                                            <p>Autônomo(s) disponível(eis)</p>
                                        </div>
                                        
                                        <figure class='pontinhos' qual='{i}'>
                                            <img src='imagens/icones/opcoes.png' alt=''>
                                        </figure>
                                    </div>

                                    <div class='OpcoesMenu escondido' qual='{i}'>
                                        <p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Concluir'>Concluir</p>
                                        <hr>
                                        <p id='Editar'>Editar</p>
                                        <hr>
                                        <p id='Cancelar'>Cancelar Projeto</p>
                                    </div>
                                </article>";
                    i++;
                }
                litServicos.Text += $@"</section>";
            }

            else{
                litServicos.Text = "";
                litSemAnuncios.Text = $@"<section class='SemAnuncios'>
                                            <figure>
                                                <img src='imagens/elementos/Elemento20.svg' alt=''>
                                            </figure>
                                            <h2>Bem vindo(a) a Unio!</h2>
                                            <p>Este é o seu painel de anúncios, que tal começar criando um novo?</p>
                                            <a href='criacaoAnuncio.aspx'><button id='btnCriarAnuncio'>Criar anúncio</button></a>
                                        </section>";
            }
        }
    }
}