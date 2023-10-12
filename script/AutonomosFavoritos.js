const coracoesVazados = document.querySelectorAll(".coracoesVazados");
const coracoesPreenchidos = document.querySelectorAll(".coracoesPreenchidos");

const avaliacao = document.querySelectorAll(".avaliacao");
let barra = document.querySelectorAll(".avaliacaoEstrelas .barra");
let barraProgresso = document.querySelectorAll(".avaliacaoEstrelas .barra div");


for(let indice =0; indice < coracoesVazados.length; indice++){

    if(coracoesVazados[indice] != null){
        coracoesVazados[indice].addEventListener('click', favoritar);       
    }
}

for(let indice =0; indice < coracoesPreenchidos.length; indice++){

    if(coracoesPreenchidos[indice] != null){
        coracoesPreenchidos[indice].addEventListener('click', desfavoritar);       
    }
}



window.onload = function progressoAutonomo(){
    let porcentagem = 0;
    let porcentagemEstrelas = 0;

    for(indice = 0; indice < barra.length; indice++)
    {
        let valorMedia = barra[indice].getAttribute('valor');
        porcentagem = ((valorMedia/5)*100);
        barraProgresso[indice].setAttribute("style", "width: " + porcentagem + "%");
    }

}

function favoritar(){
    let valor = this.getAttribute('qual');
    if(coracoesPreenchidos[valor].classList.contains('escondido'))
    {
        coracoesPreenchidos[valor].classList.remove('escondido');
    }
}

function desfavoritar(){
    this.classList.add("escondido");
   
}


