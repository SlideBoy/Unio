<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busca.aspx.cs" Inherits="Unio.busca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
 <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerSemLogar.css">
    <link rel="stylesheet" href="css/buscaStyle.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_padrao.png" alt="">
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                   </a>
            </div>
            <div class="divBusca">
                <asp:TextBox ID="iptBusca" runat="server"></asp:TextBox>
                <asp:ImageButton id="btnBusca" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBusca_Click"/>
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
            <img src="imagens/icones/back_icon.png" alt=""/>
        </figure>
        <figure class="logoLogin">
            <img src="imagens/elementos/Elemento03.png" alt=""/>
        </figure>
        <h2>Login</h2>
        <asp:TextBox runat="server" id="txtEmail" placeholder="Digite seu e-mail" CssClass="inputLogin"></asp:TextBox>
        <asp:TextBox runat="server" id="txtSenha" placeholder="Digite sua senha" CssClass="inputLogin" type="password"></asp:TextBox>
        <span class="msgErro escondido"></span>

        <button id="btnEntrar">Entrar</button>
               <div>
            <p style="margin-right: 3px;">Não possui cadastro?<a href="cadastro.aspx"><strong> Cadastre-se</strong></a></p>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
    </article>

    <section class="blur escondido"></section>

    <section class="sessaoBg">
        <main>

            <section class="geral">

                <section class="areaAtuacao">
    
                    <div class="filtro">
                        <div class="filtroTitulo">
                            <p>Áreas de atuação</p>
                        </div>
    
                        <div class="filtroAreas">
                            <p>Tecnologia e Informática</p>
                            <p>Marketing e Negócios</p>
                            <p>Saúde e Bem-estar</p>
                            <p>Arte e Design</p>
                            <p>Serviços domésticos</p>
                        </div>
                    </div>
                </section>
                <asp:Literal ID="litResultados" runat="server"></asp:Literal>
                <%--<section class="resultadosBusca">
                    <p class="titulo">Resultados por <strong>"Técnico"</strong></p>

                    <div class="resultados">
                        <div class="itemResultados">
                            <p>Técnico(a) em Informática Residencial</p>
                            <img src="imagens/icones/front_icon_busca.png" alt="">
                        </div>
                    </div>

                    <div class="resultados">
                        <div class="itemResultados">
                            <p>Técnico(a) em Edificações</p>
                            <img src="imagens/icones/front_icon_busca.png" alt="">
                        </div>
                    </div>

                    <div class="resultados">
                        <div class="itemResultados">
                            <p>Técnico(a) em Construção Civil</p>
                            <img src="imagens/icones/front_icon_busca.png" alt="">
                        </div>
                    </div>

                    <a href="buscaAutonomo.aspx" class="resultados">
                        <div class="itemResultados">
                        <p>Técnico(a) em Manutenção de Eletrodomésticos</p>
                        <img src="imagens/icones/front_icon_busca.png" alt="">
                        </div>
                    </a>

                    <div class="resultados">
                        <div class="itemResultados">
                            <p>Técnico(a) em Televisão e Home Theater</p>
                            <img src="imagens/icones/front_icon_busca.png" alt="">
                        </div>
                    </div>

                </section>--%>
            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/login.js"></script>
    <script type="text/javascript" src="script/IndexBuscarAutonomo.js"></script>
    </form>
</body>
</html>
