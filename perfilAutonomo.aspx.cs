using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class perfilAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["a"]) || String.IsNullOrEmpty(Request["p"]))
            {
                Response.Redirect("index.aspx");
            }

            Autonomo autonomo = new Autonomo();
            autonomo.Email = Request["a"];
            autonomo.PreencherDados();

            string arquivoImagem = "";
            byte[] foto = autonomo.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            #region FormaDePagamento
            string FormasDePagamento = "<div>";
            string NomeFormaDePagamento = "<p>";
            foreach (FormaPagamento formaPagamento in autonomo.FormasPagamento)
            {
                FormasDePagamento += $@"<img src='imagens/icones/forma_pag_{formaPagamento.Codigo}.png' alt=''>";
                //VIR AS FOTOS DO BANCO
                NomeFormaDePagamento += $@"{formaPagamento.Nome},";
            }

            NomeFormaDePagamento = NomeFormaDePagamento.Substring(0, (NomeFormaDePagamento.Length - 1));
            FormasDePagamento += "</div>";
            NomeFormaDePagamento += "</p>";
            #endregion

            #region Portfolio
            //            <section class='portfolioAutonomo'>
            //    <h2>Algumas imagens do meu trabalho:</h2>
            //    <div>
            //        <img src='imagens/autonomos/portfolio_1.png' alt=''>
            //        <img src='imagens/autonomos/portfolio_2.png' alt=''>
            //        <img src='imagens/autonomos/portfolio_3.png' alt=''>
            //    </div>
            //</section>
            #endregion

            #region Avaliações
            Avaliacoes avs = new Avaliacoes();
            List<Avaliacao> avaliacoes = avs.CarregarAvaliacoes(autonomo.Email);
            string txtAvaliacoes = "";
            foreach (Avaliacao avaliacao in avaliacoes)
            {
                string arquivoImagemAv = "";
                byte[] fotoAv = avaliacao.Cliente.Foto;
                string base64StringAv = Convert.ToBase64String(fotoAv, 0, fotoAv.Length);
                arquivoImagemAv = Convert.ToString("data:image/jpeg;base64,") + base64StringAv;

                txtAvaliacoes = $@"<div class='avaliacao'>
                        <img src='{arquivoImagemAv}' alt=''>
                        <div class='infoGeral'>
                            <div class='infoCima'>
                                <div class='nomeEavalicao'>
                                    <h2>{avaliacao.Cliente.Nome}</h2>
                                    <div class='avaliacaoEstrelas'>
                                        <div class='barra' valor='{avaliacao.Media.ToString().Replace(",", ".")}'>
                                            <div></div>
                                        </div>
                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                    </div>
                                </div>
                                <p>{avaliacao.DataPostagem}</p>
                            </div>
                            <p>{avaliacao.Descricao}!</p>
                        </div>
                    </div>";
            }
            #endregion

            litGeral.Text = $@"<section class='geral'>
                <section class='perfilAutonomo'>
                    <section class='bgPerfil' >
                        <div class='informacoes'>
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
                                <h2>{autonomo.Nome}</h2>
                                <p>{Request["p"]}</p>
                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome} - {autonomo.Estado.Nome} </div>
                            </div>                    
                        </div>
                        <figure class='coracoesVazados'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                        <figure class='coracoesPreenchidos escondido'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                    </section>
                </section>

                <section class='emblemaAutonomo'>
                    <p>Esse profissional é um usuário <strong>{autonomo.Emblema.Nome.ToLower()}!</strong></p> 
                    <img src='imagens/emblemas/{autonomo.Emblema.Nome.ToLower()}.png' alt=''>
                </section>

                <section class='sobreAutonomo'>
                    <h2>Um pouco sobre mim:</h2>
                    <p>{autonomo.Comentario}</p>
                </section>





                <section class='pagamentoAutonomo'>
                    <h2>Forma de pagamento:</h2>
                    {FormasDePagamento}
                    {NomeFormaDePagamento}
                </section>

                <section class='avaliacaoAutonomo'>
                    <div class='filtroEtitulo'>
                        <h2>Avaliações:</h2>
                        <section class='filtros'>
                            <div>
                                <div><p>Avaliação</p></div>
                                <select id='selectAvaliacao'>
                                    <option value=''>Maior</option>
                                </select>
                            </div>
                            <div>
                                <div><p>Data</p></div>
                                <select id='selectData'>
                                    <option value=''>Mais recente</option>
                                </select>
                            </div>
                        </section>
                    </div>

                    {txtAvaliacoes}
                    
                </section>

            </section>";
        }
        //        <div class='avaliacao'>
        //    <img src='imagens/clientes/cliente_1.png' alt=''>

        //    <div class='infoGeral'>

        //        <div class='infoCima'>
        //            <div class='nomeEavalicao'>
        //                <h2>Carolina de Almeida dos Santos</h2>
        //                <div class='avaliacaoEstrelas'>
        //                    <div class='barra' valor='5'>
        //                        <div></div>
        //                    </div>
        //                    <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
        //                </div>
        //            </div>
        //            <p>24/03/2022</p>
        //        </div>

        //        <p>O seu Joaquim foi um ótimo profissional, entregou tudo no prazo, sem gambiarras e ainda deixou tudo limpinho antes de ir embora. Super educado, e sincero, recomendo!</p>
        //    </div>
        //</div>
    }
}