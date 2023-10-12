﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComoFunciona.aspx.cs" Inherits="Unio.ComoFunciona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerSemLogar.css">
    <link rel="stylesheet" type="text/css" href="css/comoFuncionaStyle.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_padrao.png" alt="">
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                </a>
            </div>
            <div class="divBusca">
                <input type="text" name="iptBusca" id="iptBusca" placeholder="Ex. eletricista">
                <a href="busca.aspx" id="btnBusca"><button id="btnBusca"><img src="imagens/icones/search_icon.png" alt=""></button></a>
            </div>
            <div class="divMenu" id="btnLogin">
                <ul>
                    <li>
                        <button name="btnLogin">Login / Cadastre-se</button><label for="btnLogin"><img src="imagens/icones/login_icon.png" alt=""></label>
                    </li>
                </ul>
            </div>
        </main>  
    </header>

    <article class="pnlLogin escondido">
        <figure class="backIcon">
            <img src="imagens/icones/back_icon.png" alt="">
        </figure>
        <figure class="logoLogin">
            <img src="imagens/elementos/Elemento03.png" alt="">
        </figure>
        <h2>Login</h2>
        <input type="text" id="txtEmail" placeholder="Digite seu e-mail" class="inputLogin">
        <input type="text" id="txtSenha" placeholder="Digite sua senha" class="inputLogin">
        <button id="btnEntrar">Entrar</button>
        <div>
            <p style="margin-right: 3px;">Não possui cadastro?<a href="cadastro.aspx"><strong> Cadastre-se</strong></a></p>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
        <span class="msgErro escondido">Login e/ou senha inválido(s)</span>
    </article>

    <section class="blur escondido"></section>

    <section>
        <div class="sessaoVideo">
            <div class="divChamada">
            <h1>Como <i><b>funciona</b></i> o</h1>
            <img src="imagens/logos/logo_branca_texto.svg" alt="">
            <div class="opcoes">
                <a href="#cliente"><div class="opcao ativa"><p>Para contratar</p></div></a>
                <a href="#autonomo"><div class="opcao"><p>Para ser contratado</p></div></a>
            </div>
        </div>
        <div class="filtroVideo"></div>
            <video loop autoplay muted>
                <source src="video/vComoFunciona.mp4" type="video/mp4">
                <source src="video/vComoFunciona.mp4" type="video/ogg">
                Your browser does not support the video tag.
            </video>
        </div>
    </section>

    <section style="margin-top: 60px;">
        <div class="textoIntroducao">
            <img src="imagens/elementos/Elemento06.svg" alt="">
            <p>
               <b>E aí, tudo bem?</b> Se você está aqui é porque possivelmente tem dúvidas de
               como utilizar a plataforma. Mas, fique tranquilo! Vamos te explicar de forma
               exata como tudo funciona!
            </p>
        </div>
        <div class="sessaoExplicacao">
            <div class="linha">
                <img src="imagens/como_funciona/linhaDoTempo.svg" alt="">
            </div>
            <div class="divConteudo">
                <div class="texto">
                    <div>
                        <h2>Página inicial e cadastro</h2>
                        <p>
                            Caso seja o seu primeiro contato com a Unio, para que você tenha acesso
                            livre em todas as páginas do site é necessário que realize um cadastro,
                            escolhendo uma das duas opções de perfil que disponibilizamos,
                            que são: Cliente ou Autônomo.
                            <br><br>
                            Na aba de cadastro, você fornecerá alguns dados para a plataforma, que
                            servirão para a estruturação e criação do seu perfil.
                            <br><br>
                            Desde já adiantamos que suas informações sigilosas como número de CPF
                            e senhas estarão protegidas conosco!
                            <br><br>
                            <i>
                                <b style="color: var(--Roxo);">OBS:</b> O número de CPF é solicitado para garantir um ambiente confiável
                                e seguro para todos! Não compartilhamos com terceiros.
                            </i>
                            <br><br>
                            Após completar seu cadastro, você será direcionado a página principal da plataforma,
                            nomeada por nós como <b><i>“Painel"</i></b>.
                        </p>
                    </div>
                    <div><img src="imagens/como_funciona/doodle1.svg" alt=""></div>
                </div>
                <a name="cliente"></a>
                <div class="texto">
                    <div>
                        <h2>Para contratar</h2>
                        <p>
                            Na Unio, se você é cliente, seu painel exibe os anúncios que você publicou,
                            com status como <b>“Em aberto”</b>,  <b>"Em andamento"</b>, <b>Concluído"</b>" ou <b>"Cancelado"</b>.
                            Anúncios são a forma de comunicar necessidades aos profissionais cadastrados.
                            Escolha a área desejada, e os prestadores relacionados podem confirmar disponibilidade. 
                            <br><br>
                            Após, avalie candidatos e escolha quem contatar. 
                            <br><br>
                            O painel inclui um chat para suas conversas. 
                            <br><br>
                            <b style="color: var(--Magenta);">A plataforma não lida com pagamentos</b>, ficando a responsabilidade de acordo entre
                            você e o autônomo. Você pode favoritar autônomos e criar anúncios privativos para
                            direcionar a pessoas específicas.
                            <br><br>
                            Além disso, é possível denunciar autônomos para a Unio investigar e tomar medidas
                            apropriadas.
                        </p>
                    </div>
                    <div><img src="imagens/como_funciona/doodle2.svg" alt=""></div>
                </div>
                <a name="autonomo"></a>
                <div class="texto">
                    <div>
                        <h2>Para ser contratado</h2>
                        <p>
                            O painel do autônomo na Unio exibe os anúncios aceitos para execução de serviços,
                            indicando seus status (“Em aberto”, "Em andamento", "Concluído", "Cancelado").
                            <br><br>
                            Os anúncios podem ser <b>públicos</b> (enviados para todos os profissionais da área
                            selecionada) e <b>privados</b> (enviados diretamente para profissionais favoritados).
                            <br><br>
                            Na aba "Procura de serviços", é possível candidatar-se a anúncios públicos e,
                            se selecionado, discutir detalhes através do chat.
                            <b style="color: var(--Magenta);">A plataforma não lida com pagamentos</b>, ficando a cargo do autônomo e cliente
                            decidirem a melhor forma de acerto.
                            <br><br>
                            A barra de progresso exibe emblemas que melhoram a reputação do perfil,
                            obtidos ao atingir metas e ter boa performance avaliada pelos clientes.
                            <br><br>
                            É possível denunciar clientes com experiências negativas para a Unio tomar
                            as medidas necessárias.
                        </p>
                    </div>
                    <div><img src="imagens/como_funciona/doodle3.svg" alt=""></div>
                </div>                    
            </div>
        </div>
        <div class="textoConclusao">
            <p>
                Caso surjam dúvidas, o suporte pode ser contatado pelo email <i><b>suport.unio@gmail.com.</b></i>
                <br><br>
                Atenciosamente, Equipe Unio :)
            </p>
        </div>
    </section>

    <footer>
        <div class="f_laterais f_esquerda">
            <div>

            </div>
        </div>
        <div class="f_meio">
            <div>
                <img src="imagens/logos/logo_vermelho.png" alt="">
            </div>

            <p>
                © 2023 UnioTeam | Powered by <b id="f_medium">ours</b> <br>
                Ainda tem dúvidas? <b id="f_semiB">Veja como funciona</b>
            </p>
            
            <div class="f_icons">
                <figure><img src="imagens/icones/facebook_icon.png" alt=""></figure>
                <figure><img src="imagens/icones/whatsapp_icon.png" alt=""></figure>
                <figure><img src="imagens/icones/linkedin_icon.png" alt=""></figure>
                <figure><img src="imagens/icones/ig_icon.png" alt=""></figure>
            </div>
        </div>
        <div class="f_laterais f_direita">
            <div>

            </div>
        </div>
    </footer>

    <script type="text/javascript" src="script/login.js"></script>
</body>
</body>
</html>
