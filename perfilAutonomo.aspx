<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfilAutonomo.aspx.cs" Inherits="Unio.perfilAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerSemLogar.css">
    <link rel="stylesheet" href="css/perfilAutonomoStyle.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx">
                    <img src="imagens/logos/logo_padrao.png" alt="">
                   </a>
            </div>
            <div class="divBusca">
                <input type="text" name="iptBusca" id="iptBusca" placeholder="Ex. eletricista">
                <a href="busca.html" id="btnBusca"><button id="btnBusca"><img src="imagens/icones/search_icon.png" alt=""></button></a>
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
            <img src="imagens/elementos/Elemento03.webp" alt="">
        </figure>
        <h2>Login</h2>
        <input type="text" id="txtEmail" placeholder="Digite seu e-mail" class="inputLogin">
        <input type="text" id="txtSenha" placeholder="Digite sua senha" class="inputLogin">
        <button id="btnEntrar">Entrar</button>
        <div>
            <p style="margin-right: 3px;">Não possui cadastro?<a href="cadastro.html"><strong> Cadastre-se</strong></a></p>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
        <span class="msgErro escondido">Login e/ou senha inválido(s)</span>
    </article>

    <section class="blur escondido"></section>

    <section class="sessaoBg">
        <main>
            <asp:Literal ID="litGeral" runat="server"></asp:Literal>
        </main>
    </section>
    
    <script src="script/login.js"></script>
    <script src="script/perfilAutonomo.js"></script>
    </form>
</body>
</html>
