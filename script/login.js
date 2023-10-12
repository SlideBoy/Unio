let TelaLoginAberta = false;

let email = document.querySelector("#txtEmail");
let senha = document.querySelector("#txtSenha");

const mensagemErro = document.querySelector(".msgErro");
const btnLogin = document.querySelector("#btnLogin");
/*console.log(btnLogin);*/
const btnVoltar = document.querySelector(".backIcon");
/*console.log(btnVoltar);*/
const btnEntrar = document.querySelector("#btnEntrar");
/*console.log(btnEntrar);*/

const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

const telaLogin = document.querySelector(".pnlLogin");
const bluur = document.querySelector(".blur");

const btnSaibaComo = document.querySelector("#btnSaibaMais");
const btnBuscarJa = document.querySelector("#buscarJa");
const btnEscolherJa = document.querySelector("#escolherJa");
const btnNegociarJa = document.querySelector("#negociarJa");
const btnAnuncieServico = document.querySelector("#AnuncieServico");


if (btnLogin !=null) btnLogin.addEventListener('click', abrirTelaLogin);
if (btnVoltar != null) btnVoltar.addEventListener('click', fecharTelaLogin);
if (btnEntrar != null) btnEntrar.addEventListener('click', entrar);


if(btnBuscarJa !=null) btnBuscarJa.addEventListener('click', abrirTelaLogin);
if(btnEscolherJa !=null) btnEscolherJa.addEventListener('click', abrirTelaLogin);
if(btnNegociarJa !=null) btnNegociarJa.addEventListener('click', abrirTelaLogin);
if (btnAnuncieServico != null) btnAnuncieServico.addEventListener('click', abrirTelaLogin);



/*--------------------------------FUNÇÕES--------------------------------*/


/*------------------------Tela de Login------------------------*/

function abrirTelaLogin(e)
{
     //email.value ="";
     //senha.value ="";
     //msgErro.classList.add("escondido");

    e.preventDefault();

    if (TelaLoginAberta == false) {
        bluur.classList.remove("escondido");
        telaLogin.classList.remove("escondido");
    }

    TelaLoginAberta = !TelaLoginAberta;
}

function fecharTelaLogin()
{

    if (TelaLoginAberta == true) {
        bluur.classList.add("escondido");
        telaLogin.classList.add("escondido");
    }

    TelaLoginAberta = !TelaLoginAberta;
}

/*-------------------------Login-------------------------*/

function entrar(event) {
    event.preventDefault();
    mensagemErro.classList.add("escondido");  

    if (email.value == "" && senha.value == "") {
        mensagemErro.innerHTML = "Email e senha n&atilde;o digitados!";
        mensagemErro.classList.remove("escondido");
        return;
    }

    if (email.value == "") {
        mensagemErro.innerHTML = "Email n&atilde;o digitado!";
        mensagemErro.classList.remove("escondido");
        return;
    }

    if (senha.value == "") {
        mensagemErro.innerHTML = "Senha n&atilde;o digitada!";
        mensagemErro.classList.remove("escondido");
        return;
    }

    if (!emailRegex.test(email.value)) {
        mensagemErro.innerHTML = "Email inválido!";
        mensagemErro.classList.remove("escondido");
        return;
    }

    $.post("lib/EntrarSessao.aspx", { "e":email.value, "s":senha.value }, function (retorno) {

        console.log(retorno.situacao);
        if (retorno.situacao == "ok") {
            // Aqui vai redirecionar o cara para a outra página caso seja autonomo ou cliente

            if (retorno.tipo == "autonomo") {
                /*window.location.replace("");*/
                //mensagemErro.innerHTML = retorno.profissao;
                //mensagemErro.classList.remove("escondido");
                window.location = "painelAutonomo.aspx";
            }
            if (retorno.tipo == "cliente") {
                /*window.location.replace("");*/
                //mensagemErro.innerHTML = retorno.profissao;
                //mensagemErro.classList.remove("escondido");
                window.location = "painelCliente.aspx";
            }
        }
        else { 
            mensagemErro.innerHTML = "Email e/ou senha inválidos!";
            mensagemErro.classList.remove("escondido");
        }
    }, 'json');

}
