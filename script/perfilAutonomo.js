const coracoesVazados = document.querySelector(".coracoesVazados");
const coracoesPreenchidos = document.querySelector(".coracoesPreenchidos")

const avaliacao = document.querySelectorAll(".avaliacao");
let barra = document.querySelectorAll(".avaliacaoEstrelas .barra");
let barraProgresso = document.querySelectorAll(".avaliacaoEstrelas .barra div");

let progressoEstrelas = document.querySelector(".progressoAutonomo .progresso");
let barraProgressoEstrelas = document.querySelector(".avaliacaoProgresso .barra div");

coracoesVazados.addEventListener('click', favoritar);
coracoesPreenchidos.addEventListener('click', desfavoritar);    

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

function favoritar(){
    coracoesPreenchidos.classList.remove('escondido');
    coracoesVazados.classList.add("escondido");
}

function desfavoritar(){
    coracoesVazados.classList.remove("escondido");
    coracoesPreenchidos.classList.add('escondido');
}