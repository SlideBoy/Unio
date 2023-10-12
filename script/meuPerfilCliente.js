const btnSalvarDados = document.querySelector("#btnSalvarAlteracoes");

const pnlSalvar = document.querySelector(".pnlSalvar");
const blur = document.querySelector(".blur");
const btnVoltar = document.querySelector("#btnVoltar");
const btnSalvarMesmo = document.querySelector("#btnSalvar");

btnSalvarDados.addEventListener('click', salvar);
btnVoltar.addEventListener('click', voltar);
btnSalvarMesmo.addEventListener('click', voltar);

function salvar(){

    pnlSalvar.classList.remove("escondido");
    blur.classList.remove("escondido");
}

function voltar(){

    pnlSalvar.classList.add("escondido");
    blur.classList.add("escondido");
}