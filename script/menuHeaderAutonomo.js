let MenuAberto = false;

const areaMenu = document.querySelector(".areaMenu");
const divFoto = document.querySelector("#perfilAutonomo");
const fotoAutonomo = document.querySelector("#perfilAutonomo img")
const menuPerfil = document.querySelector(".prflAutonomo");

const btnSair = document.querySelector(".opcaoBtn");

const avaliacao = document.querySelectorAll(".avaliacao");
let barra = document.querySelectorAll(".avaliacaoEstrelas .barra");
let barraProgresso = document.querySelectorAll(".avaliacaoEstrelas .barra div");

let progressoEstrelas = document.querySelector(".progressoAutonomo .progresso");
let barraProgressoEstrelas = document.querySelector(".avaliacaoProgresso .barra div");

fotoAutonomo.addEventListener('click', abrirMenu);
areaMenu.addEventListener('click', fecharMenu);
btnSair.addEventListener('click', SairSessao);

function abrirMenu() {
    if (!MenuAberto) {
        menuPerfil.classList.remove("escondido");
        fotoAutonomo.setAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.remove("escondido");
    } else {
        menuPerfil.classList.add("escondido");
        fotoAutonomo.removeAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.add("escondido");
    }

    MenuAberto = !MenuAberto;
}

function fecharMenu()
{
    if(MenuAberto)
    {
        menuPerfil.classList.add("escondido");
        fotoAutonomo.removeAttribute("style", "border: 5px var(--Azul-marinho) solid;");
        areaMenu.classList.add("escondido");
    }

    MenuAberto = !MenuAberto;
}

window.onload = function progressoAutonomo(){
    let porcentagem = 0;
    let porcentagemEstrelas = 0;

    for(indice = 0; indice < avaliacao.length; indice++)
    {
        let valorMedia = barra[indice].getAttribute('valor');
        porcentagem = ((valorMedia/5)*100);
        barraProgresso[indice].setAttribute("style", "width: " + porcentagem + "%");
    }
    
    let valorEstrelas = progressoEstrelas.getAttribute('valor');
    porcentagemEstrelas = ((valorEstrelas/5)*100);
    barraProgressoEstrelas.setAttribute("style", "width: " + porcentagemEstrelas + "%");
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