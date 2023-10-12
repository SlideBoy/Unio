<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuPerfilCliente.aspx.cs" Inherits="Unio.meuPerfilCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/meuPerfilCliente.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/> 
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="painelCliente.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_branca.png" alt="">
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                </a>
            </div>

            <div class="divBusca" id="divBusca">
                <input type="text" name="iptBusca" id="iptBusca" placeholder="Ex. eletricista">
                <a href="busca.aspx" id="btnBusca"><button id="btnBusca"><img src="imagens/icones/search_icon.png" alt=""></button></a>
            </div>

            <div class="divMenu">
                <ul>
                    <li class="liDoPopup"><img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><a href="chatCliente.aspx"><img src="imagens/icones/Mensagens_icon.png" alt="Ícone de mensagens"></a></li>
                    <li class="liDoPopup">
                      <div class="popupNotificacao escondido">
                          <div>
                              <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                              <p>
                                  <strong>Você foi selecionado!</strong><br>
                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                              </p>
                          </div>
                          <div>
                              <figure><img src="imagens/icon_notificacoes/icon_concluido.png" alt=""></figure>
                              <p>
                                  <strong>Serviço concluído</strong><br>
                                  Cliente concluiu o serviço. Confirme você também para finalizá-lo.
                              </p>
                          </div>
                          <div>
                              <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                              <p>
                                  <strong>Você foi selecionado!</strong><br>
                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                              </p>
                          </div>
                          <div>
                              <figure>
                                  <img src="imagens/icon_notificacoes/icon_mensagem.png" alt="">
                              </figure>
                              <p>
                                  <strong>Você tem uma nova mensagem</strong><br>
                                  Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                              </p>
                          </div>
                          <div>
                              <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                              <p>
                                  <strong>Você foi selecionado!</strong><br>
                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                              </p>
                          </div>
                          <div>
                              <figure>
                                  <img src="imagens/icon_notificacoes/icon_mensagem.png" alt="">
                              </figure>
                              <p>
                                  <strong>Você tem uma nova mensagem</strong><br>
                                  Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                              </p>
                          </div>
                      </div>
                      <img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><img id="sininho" src="imagens/icones/Notificacoes_icon.png" alt="Ícone de notificações">
                    </li>
                  <li id="perfilCliente">
                      <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                      <%--<img src="imagens/clientes/cliente_1.png" id="imgCliente" alt="ícone do perfil">--%>
                  </li>
                </ul>
              
                <article class="prflCliente escondido"> 
                    <a href="painelCliente.aspx" class="opcao">Painel de Serviços</a>
                    <a href="meuPerfilCliente.aspx" class="opcao">Meu perfil</a>
                    <a href="criacaoAnuncio.aspx" class="opcao">Criar anúncios</a>
                    <a href="AutonomosFavoritos.aspx" class="opcao">Favoritos</a>
                    <a href="ComoFunciona.aspx" class="opcao"><img src="imagens/icones/comoFunciona_Icon.png" alt="">Como funciona</a>
                    <button class="opcaoBtn">Sair</button>
                </article>
            </div>
        </main>  
    </header>
    <section class="areaMenu escondido"></section>

    <section class="sessaoBg">
        <main>
            <section class="geral">

                <section class="buscaMobile" id="buscaMobile">
                    <div class="divBusca">
                        <input type="text" name="iptBusca" id="iptBusca" placeholder="Ex. eletricista">
                        <a href="busca.aspx" id="btnBusca"><button id="btnBusca"><img src="imagens/icones/search_icon.png" alt=""></button></a>
                    </div>
                </section>

                <section class="perfilCliente">
                    <section class="bgPerfil" >
                            <asp:Literal ID="litInfosCliente" runat="server"></asp:Literal>
                        <%--<div class="informacoes">
                            <img id="imgCliente" src="imagens/clientes/cliente_1.png" alt="">
                            <div class="info">
                                <h2>Carolina de Almeida dos Santos</h2>
                                <div class="cidade"> <img src="imagens/icones/localizacao.png" alt=""> Santos - SP </div>
                            </div>                    
                        </div>--%>
                    </section>
                </section>

                <section class="dadosClientes">

                    <article class="pnlSalvar escondido">
                        <p> Foram realizadas alterações em seu perfil. Deseja salvá-las?</p>
                        <div>
                            <button id="btnVoltar">Voltar</button>
                            <button id="btnSalvar">Salvar</button>
                        </div>
                    </article>
                    <section class="blur escondido"></section>


                    <article class="dadosForm1">
                        <div class="coluna1">
                            <label for="">Nome Completo:
                                <div class="divInput">
                                    <input type="text" placeholder="Digite aqui..." class="inputs">
                                </div>
                            </label>
                            <label for="">E-mail:
                                <div class="divInput">
                                    <input type="text" placeholder="Digite aqui..." class="inputs">
                                </div>
                            </label>
                            <label for="" class="senha">Senha:
                                <div class="divInput">
                                    <input type="text" placeholder="Digite aqui..." class="inputs">
                                    <div class="avisoInput">
                                        <img id="aviso-icon" src="imagens/icones/aviso_icon.png" alt="">
                                        <div class="popupAviso">A senha deve conter no mínimo 8 caracteres</div>
                                    </div>
                                </div>
                                <span></span>
                            </label>
    
                            <label for="">Confirme sua senha:
                                <div class="divInput">
                                    <input type="text" placeholder="Digite aqui..." class="inputs">
                                </div>
                            </label>
                        </div>
    
                        <div class="coluna2">
                            <label for="">Celular:
                                <div class="divInput">
                                    <input type="tel" placeholder="(__) _____-____" class="inputs">
                                </div>
                            </label>
                            <label for="">Onde você reside?
                                <div class="divInput">
                                    <select name="" id="" class="inputs estado">
                                    <option value="">Selecione</option>
                                    </select>
    
                                    <select name="" id="" class="inputs">
                                    <option value="">Selecione</option>
                                    </select>
                                </div>
                            </label>
                            <label for="">CPF:
                                <div class="divInput">
                                    <input type="text" placeholder="___.___.____-__" class="inputs">
                                </div>
                            </label>
                            
                            <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
                            <button id="btnSalvarAlteracoes">Salvar</button>
                        </div>
                    </article>
                </section>
                
            </section>
        </main>
    </section>

    <script src="script/menuHeaderCliente.js"></script>
    <script src="script/meuPerfilCliente.js"></script>
    <script src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
