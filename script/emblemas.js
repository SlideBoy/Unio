let btnMeuProgresso = document.querySelector("#btnMeuProgresso");
let btnNovato = document.querySelector("#btnNovato");
let btnBronze = document.querySelector("#btnBronze");
let btnPrata = document.querySelector("#btnPrata");
let btnOuro = document.querySelector("#btnOuro");


const sobreMeuProgresso = document.querySelector(".infoEmblemas");
const sobreNovato = document.querySelector(".sobreNovato");
const sobreBronze = document.querySelector(".sobreBronze");
const sobrePrata = document.querySelector(".sobrePrata");
const sobreOuro = document.querySelector(".sobreOuro");

let quantoFaltaBronze = document.querySelector(".quantoFaltaBronze")
let barraBronze = document.querySelector(".barraBronze div");

let quantoFaltaPrata = document.querySelector(".quantoFaltaPrata")
let barraPrata = document.querySelector(".barraPrata div");

let quantoFaltaOuro = document.querySelector(".quantoFaltaOuro")
let barraOuro = document.querySelector(".barraOuro div");

let valorTotalBronze = 100;
let valorTotalPrata = 200;
let valorTotalOuro = 300;


/*-------------------------------------Eventos---------------------------------*/
btnMeuProgresso.addEventListener('click', abrirProgresso);
btnNovato.addEventListener('click', abrirNovato);
btnBronze.addEventListener('click', abrirBronze);
btnPrata.addEventListener('click', abrirPrata);
btnOuro.addEventListener('click', abrirOuro);

function abrirProgresso(){
    btnMeuProgresso.classList.add("filtroSelecionado");
    btnNovato.classList.remove("filtroSelecionado");
    btnBronze.classList.remove("filtroSelecionado");
    btnPrata.classList.remove("filtroSelecionado");
    btnOuro.classList.remove("filtroSelecionado");

    sobreMeuProgresso.classList.remove("escondido");
    sobreNovato.classList.add("escondido");
    sobreBronze.classList.add("escondido");
    sobrePrata.classList.add("escondido");
    sobreOuro.classList.add("escondido");
}

function abrirNovato(){
    btnMeuProgresso.classList.remove("filtroSelecionado");
    btnNovato.classList.add("filtroSelecionado");
    btnBronze.classList.remove("filtroSelecionado");
    btnPrata.classList.remove("filtroSelecionado");
    btnOuro.classList.remove("filtroSelecionado");

    sobreMeuProgresso.classList.add("escondido");
    sobreNovato.classList.remove("escondido");
    sobreBronze.classList.add("escondido");
    sobrePrata.classList.add("escondido");
    sobreOuro.classList.add("escondido");
}

function abrirBronze(){
    let valor = quantoFaltaBronze.getAttribute('valorBronze');
    let porcentagem = ((valor/valorTotalBronze)*100);
    barraBronze.setAttribute("style", "width: " + porcentagem + "%");


    btnMeuProgresso.classList.remove("filtroSelecionado");
    btnNovato.classList.remove("filtroSelecionado");
    btnBronze.classList.add("filtroSelecionado");
    btnPrata.classList.remove("filtroSelecionado");
    btnOuro.classList.remove("filtroSelecionado");

    sobreMeuProgresso.classList.add("escondido");
    sobreNovato.classList.add("escondido");
    sobreBronze.classList.remove("escondido");
    sobrePrata.classList.add("escondido");
    sobreOuro.classList.add("escondido");

}

function abrirPrata(){
    let valor = quantoFaltaPrata.getAttribute('valorPrata');
    let porcentagem = ((valor/valorTotalPrata)*100);
    barraPrata.setAttribute("style", "width: " + porcentagem + "%");

    btnMeuProgresso.classList.remove("filtroSelecionado");
    btnNovato.classList.remove("filtroSelecionado");
    btnBronze.classList.remove("filtroSelecionado");
    btnPrata.classList.add("filtroSelecionado");
    btnOuro.classList.remove("filtroSelecionado");

    sobreMeuProgresso.classList.add("escondido");
    sobreNovato.classList.add("escondido");
    sobreBronze.classList.add("escondido");
    sobrePrata.classList.remove("escondido");
    sobreOuro.classList.add("escondido");
}

function abrirOuro(){
    let valor = quantoFaltaOuro.getAttribute('valorOuro');
    let porcentagem = ((valor/valorTotalOuro)*100);
    barraOuro.setAttribute("style", "width: " + porcentagem + "%");

    btnMeuProgresso.classList.remove("filtroSelecionado");
    btnNovato.classList.remove("filtroSelecionado");
    btnBronze.classList.remove("filtroSelecionado");
    btnPrata.classList.remove("filtroSelecionado");
    btnOuro.classList.add("filtroSelecionado");

    sobreMeuProgresso.classList.add("escondido");
    sobreNovato.classList.add("escondido");
    sobreBronze.classList.add("escondido");
    sobrePrata.classList.add("escondido");
    sobreOuro.classList.remove("escondido");
}