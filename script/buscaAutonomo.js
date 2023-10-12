const coracoesVazados = document.querySelectorAll(".coracoesVazados");
const coracoesPreenchidos = document.querySelectorAll(".coracoesPreenchidos")

const autonomo = document.querySelectorAll(".autonomo");
//let barra = document.querySelectorAll(".infoAutonomo .barra");
//let barraProgresso = document.querySelectorAll(".infoAutonomo .barra div");

//let progressoEstrelas = document.querySelector(".progressoAutonomo .progresso");
//let barraProgressoEstrelas = document.querySelector(".avaliacaoProgresso .barra div");

const avaliacao = document.querySelectorAll(".avaliacao .barra");
const progresso = document.querySelectorAll(".avaliacao .barra div");

for (let indice = 0; indice < coracoesVazados.length; indice++) {

    if (coracoesVazados[indice] != null) {
        coracoesVazados[indice].addEventListener('click', favoritar);
    }
}

for (let indice = 0; indice < coracoesPreenchidos.length; indice++) {

    if (coracoesPreenchidos[indice] != null) {
        coracoesPreenchidos[indice].addEventListener('click', desfavoritar);
    }
}

function favoritar() {
    let valor = this.getAttribute('qual');

    if (coracoesPreenchidos[valor].classList.contains('escondido')) {
        coracoesPreenchidos[valor].classList.remove('escondido');
    }

    var emailAutonomo = this.parentNode.querySelector("#identificadorAutonomo").getAttribute('value');
    var emailCliente = document.querySelector("#identificadorCliente").getAttribute('value');

    fetch('../lib/AdicionarFavorito.aspx?ia=' + emailAutonomo + '&ic=' + emailCliente);
}

function desfavoritar() {
    let valor = this.getAttribute('qual');

    if (!coracoesPreenchidos[valor].classList.contains('escondido')) {
        coracoesPreenchidos[valor].classList.add('escondido');
        coracoesVazados[valor].classList.remove('escondido');
    }

    var emailAutonomo = this.parentNode.querySelector("#identificadorAutonomo").getAttribute('value');
    var emailCliente = document.querySelector("#identificadorCliente").getAttribute('value');

    fetch('../lib/DeletarFavorito.aspx?ia=' + emailAutonomo + '&ic=' + emailCliente);
}

window.onload = function progressoAutonomo() {
    let porcentagem = 0;
    let porcentagemEstrelas = 0;

    for (indice = 0; indice < avaliacao.length; indice++) {
        let valorMedia = avaliacao[indice].getAttribute('valor');
        porcentagem = ((valorMedia / 5) * 100);
        progresso[indice].setAttribute("style", "width: " + porcentagem + "%");
    }
    //let valorEstrelas = progressoEstrelas.getAttribute('valor');
    //porcentagemEstrelas = ((valorEstrelas / 5) * 100);
    //barraProgressoEstrelas.setAttribute("style", "width: " + porcentagemEstrelas + "%");
}




