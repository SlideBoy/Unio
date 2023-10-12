let MenuAberto = false;

const areaMenu = document.querySelector(".areaMenu");
let divFoto = document.querySelector("#perfilCliente");
const btnSair = document.querySelector(".opcaoBtn");
let fotoCliente = document.querySelector("#perfilCliente img");
let menuPerfil = document.querySelector(".prflCliente");

/*--------------------------------------------Eventos------------------------------------------------------*/

fotoCliente.addEventListener('click', abrirMenu);
areaMenu.addEventListener('click', fecharMenu);
btnSair.addEventListener('click', SairSessao);

/*--------------------------------------------Funções------------------------------------------------------*/

function abrirMenu() {
    if (!MenuAberto) {
        menuPerfil.classList.remove("escondido");
        fotoCliente.setAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.remove("escondido");
    } else {
        menuPerfil.classList.add("escondido");
        fotoCliente.removeAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.add("escondido");
    }

    MenuAberto = !MenuAberto;
}

function fecharMenu()
{
    if(MenuAberto)
    {
        menuPerfil.classList.add("escondido");
        fotoCliente.removeAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.add("escondido");
    }

    MenuAberto = !MenuAberto;
}

function SairSessao(e) {
    e.preventDefault();

    fetch('../lib/SairSessao.aspx').then(function (resp) {
        return resp.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                window.location = "index.aspx";
            }
            else {
                return;
            }
        }
    });
}



