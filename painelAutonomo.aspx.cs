using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class painelAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string emailAutonomo = "";

                if (Session["email"] != null)
                {
                    emailAutonomo = Session["email"].ToString();
                }

                Autonomo a = new Autonomo();
                (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(emailAutonomo, Session["senha"].ToString());

                string arquivoImagem = "";
                byte[] foto = autonomo.Foto;
                    string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

                litInfosAutonomo.Text = $@"<div class='informacoes'>
                                                <img id='imgAutonomo' src='{arquivoImagem}' alt=''>

                                                <div class='progressoAutonomo'>
                                                    <p class='progresso' valor='4'>4,0</p>
                                                    <div class='avaliacaoProgresso'>
                                                        <div class='barra'>
                                                            <div></div>
                                                        </div>
                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                    </div>
                                                </div>
                                                <div class='info'>
                                                    <h2>{autonomo.Nome}</h2>";

                foreach (Profissao profissao in autonomo.Profissoes)
                {
                    ddlProfissao.Items.Add(new ListItem(profissao.Nome, profissao.Codigo.ToString()));
                }

                ddlProfissao.SelectedIndex = 0;

                litInfosAutonomo2.Text = $@"<div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome}</div>
                                                </div>                    
                                          </div>";

                Propostas propostas = new Propostas();
                List<Proposta> listPropostas = propostas.CarregarPropostas(emailAutonomo, int.Parse(ddlProfissao.SelectedItem.Value));
                int i = 0;
                if (listPropostas.Count >= 1)
                {
                litServicos.Text = "<section class='listaServicos'>";
                    foreach (Proposta proposta in listPropostas)
                    {
                        arquivoImagem = "";
                        foto = null;
                        foto = proposta.Cliente.Foto;
                        base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        //type = 'hidden'
                        litDenunciar.Text += $@"      <article class='pnlDenuncia escondido' qual='{i}'>
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
                                                                <p class='clienteDenunciado'>Cliente denunciado:</p>
                                                                <div class='SobreOCliente'>
                                                                    <figure>
                                                                        <img src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{proposta.Cliente.Nome}</h2>
                                                                        <p>{proposta.Titulo}</p>
                                                                        <p class='data'>{proposta.DataPublicacao}</p>
                                                                    </div>
                                                                </div>
                                                                <div class='SobreADenuncia'>
                                                                    <label for=''>Selecione uma categoria:
                                                                        <select name='' id='selectCategoriaDenuncia'></select>
                                                                    </label>
                
                                                                    <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                        <textarea name='' id='' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                    </label>
                                                                    <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o cliente não saberá que ela foi feita por você.</p>
                                                                    <div class='divButton'>
                                                                        <button id='btnDenunciar'>Denunciar</button>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                        </article>";

                        litCancelar.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                                <div class='cabecalhoCancelar'>
                                                    <figure class='backIcon'>
                                                        <img src='imagens/icones/back_icon.png' alt=''>
                                                    </figure>
                                                    <h2>Cancelar</h2>
                                                </div>
                                                    <section class='infosCliente'>
                                                        <div class='SobreOCliente'>
                                                            <figure>
                                                                <img src='{arquivoImagem}' alt=''>
                                                            </figure>
                                                            <div>
                                                                <h2>{proposta.Cliente.Nome}</h2>
                                                                <p>{proposta.Titulo}</p>
                                                            </div>
                                                        </div>

                                                        <section class='InicioPrazoCancelamento'>
                                                            <div>
                                                                <h3 class='inicio'>Início</h3>
                                                                <p>{proposta.DataProposta}</p>
                                                            </div>
                                                            <div class='divMeio'>
                                                                <h3 class='prazo'>Prazo</h3>
                                                                <p>{proposta.Prazo.Nome}</p>
                                                            </div>
                                                            <div>
                                                                <h3 class='cancelamento'>Cancelamento</h3>
                                                                <p>{DateTime.Now}</p>
                                                            </div>
                                                        </section>
                                                        <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                        <div class='divButton'>
                                                            <button id='btnCancelar2'>Cancelar</button>
                                                        </div>
                                                    </section>
                                            </article>";

                        litServicos.Text += $@"<article class='anuncio'>
                                <div class='titulo_Btn'>
                                    <h2>{proposta.Titulo}</h2>
                                    <div class='status estadoAnuncio_0{proposta.Estado.Codigo}'>{proposta.Estado.Nome}</div>
                                </div>
    
                                <div class='data_Prazo'>
                                    <p class='data'>{proposta.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                    <p>Prazo: <strong>{proposta.Prazo.Nome}</strong></p>
                                </div>
    
                                <p class='descricao'>{proposta.Descricao}</p>
    
                                <div class='cliente_Opcoes'>
                                    <div>
                                        <figure>
                                            <img src='{arquivoImagem}' alt=''>
                                        </figure>
                                        <p>{proposta.Cliente.Nome}</p>
                                    </div>
                                    
                                    <figure class='pontinhos' qual='{i}'>
                                        <img src='imagens/icones/opcoes.png' alt=''>
                                    </figure>
                                </div>

                                <div class='OpcoesMenu escondido' qual='{i}'>
                                    <p id = 'Denunciar'> Denunciar </p>
                                    <hr>
                                    <p id='Cancelar'>Cancelar Projeto</p>
                                </div>
                            </article>";
                        i++;
                    }
                    litServicos.Text += "</section>";

                }

                else
                {
                    litSemServicos.Text = $@"<section class='SemAnuncios'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento20.svg' alt=''>
                                                </figure>
                                                <h2>Bem vindo(a) a Unio!</h2>
                                                <p>Este é o seu painel de serviços, que tal começar se candidatando para uma vaga nova?</p>
                                                <a href='buscaServicos.aspx'><button id='btnProcurarServicos'>Procurar serviços</button></a>
                                            </section>";
                }

            }

        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}