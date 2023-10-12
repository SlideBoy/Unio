
const btnSeCandidatar = document.querySelectorAll(".btnCandidatar");
const popup = document.querySelectorAll(".popupDetalhes");
const areabluur = document.querySelector(".blur");

const btnCancelar = document.querySelectorAll("#btnCancelar");
const btnCandidatarMesmo = document.querySelectorAll("#btnCandidatarMesmo");
const btnCancelarCandidatura = document.querySelectorAll("#btnCancelarCandidaturaMesmo");

const pontinhos = document.querySelectorAll(".pontinhos");
const caixinhaMenuTresPontos = document.querySelectorAll(".OpcoesMenu");

const Denunciar = document.querySelectorAll("#Denunciar");
const Concluir = document.querySelectorAll("#Concluir");
const Cancelar = document.querySelectorAll("#Cancelar");

const pnlDenunciar = document.querySelectorAll(".pnlDenuncia");
const pnlConcluir = document.querySelectorAll(".pnlConcluir");
const pnlCancelar = document.querySelectorAll(".pnlCancelar");

const backIconDenunciar = document.querySelectorAll(".pnlDenuncia .cabecalhoDenuncia .backIcon");
const backIconConcluir = document.querySelectorAll(".pnlConcluir .cabecalhoConcluir .backIcon");
const backIconCancelar = document.querySelectorAll(".pnlCancelar .cabecalhoCancelar .backIcon");

const btnCancelar2 = document.querySelectorAll("#btnDenunciar");
const btnConcluir = document.querySelectorAll("#btnConcluir");
const btnCancelar2 = document.querySelectorAll("#btnCancelar2");


/*Array dos botoes de se candidatar na pagina de encontar serviços*/
for (let indice = 0; indice < btnSeCandidatar.length; indice++) {
    if (btnSeCandidatar[indice] != null) {
        btnSeCandidatar[indice].addEventListener('click', abrirDetalhes);
    }
}

/*Array do icone de tres pontos para ver o mini menu*/
for (let indice = 0; indice < pontinhos.length; indice++) {
    if (pontinhos[indice] != null) {
        pontinhos[indice].addEventListener('click', abrirMenuTresPontos);
    }

}

for (let indice = 0; indice < caixinhaMenuTresPontos.length; indice++) {
    if (caixinhaMenuTresPontos[indice].addEventListener('mouseleave', fecharMenuTresPontos));
}

/*Array da opção de denuncia no menu*/
for (let indice = 0; indice < Denunciar.length; indice++) {
    if (Denunciar[indice] != null) {
        Denunciar[indice].addEventListener('click', abrirPnlDenuncia);
    }
}

for (let indice = 0; indice < backIconDenunciar.length; indice++) {
    if (backIconDenunciar[indice] != null) {
        backIconDenunciar[indice].addEventListener('click', fecharPnlDenuncia);
    }
}

/*Array da opção de conclusão no menu*/
for (let indice = 0; indice < Concluir.length; indice++) {
    if (Concluir[indice] != null) {
        Concluir[indice].addEventListener('click', abrirPnlConclusao);
    }
}
for (let indice = 0; indice < backIconConcluir.length; indice++) {
    if (backIconConcluir[indice] != null) {
        backIconConcluir[indice].addEventListener('click', abrirPnlConclusao);
    }
}

/*Array da opção de cancelamento no menu*/
for (let indice = 0; indice < Cancelar.length; indice++) {
    Cancelar[indice].addEventListener('click', abrirPnlCancelamento);
}
for (let indice = 0; indice < backIconCancelar.length; indice++) {
    backIconCancelar[indice].addEventListener('click', fecharPnlCancelamento);
}

/*Abrir e fechar det5alhes do anuncio*/
for (let indice = 0; indice < btnCancelar.length; indice++) {
    btnCancelar[indice].addEventListener('click', fecharDetalhes);
}

for (let indice = 0; indice < btnCandidatarMesmo.length; indice++) {
    btnCandidatarMesmo[indice].addEventListener('click', seCandidatar);
}

for (let indice = 0; indice < btnCancelarCandidaturaMesmo.length; indice++) {
    btnCancelarCandidaturaMesmo[indice].addEventListener('click', retirarCandidatura);
}


/*Array do botão de denunciar mesmo*/
for (let indice = 0; indice < btnDenunciar.length; indice++) {
    if (btnDenunciar[indice] != null)
        btnDenunciar[indice].addEventListener('click', fecharPnlDenuncia);
}

/*Array do botão de concluir mesmo*/
for (let indice = 0; indice < btnConcluir.length; indice++) {
    if (btnConcluir[indice] != null)
        btnConcluir[indice].addEventListener('click', fecharPnlConclusao);

}

/*Array do botão de cancelar mesmo*/
for (let indice = 0; indice < btnCancelar2.length; indice++) {
    if (btnCancelar2[indice] != null)
        btnCancelar2[indice].addEventListener('click', fecharPnlCancelamento);
}

function abrirDetalhes(e) {
    e.preventDefault();

    let valor = this.getAttribute('qual');

    if (popup != null)
        popup[valor].classList.remove("escondido");


    areabluur.classList.remove("escondido");
}

function seCandidatar(e) {
    e.preventDefault();
    //console.log(emailAutonomo);
    var emailAutonomo = document.querySelector('#identificadorAutonomo').getAttribute('value');
    var emailCliente = this.parentNode.parentNode.querySelector('#identificadorCliente').getAttribute('value');
    var codigoAnuncio = this.parentNode.parentNode.getAttribute('id').substring(6, 8);
    console.log(emailAutonomo, emailCliente, codigoAnuncio);

    fetch("../lib/AdicionarCandidatura.aspx?ea=" + emailAutonomo + "&ec=" + emailCliente + "&ca=" + codigoAnuncio).then(function (resposta) {
        resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                window.location = "painelAutonomo.aspx";
                return;
            }
            if (dados.situacao == "erro") {
                // retorno visual indicando a falha na candidatura
                return;
            }
        }
    })
}

function retirarCandidatura(e) {
    e.preventDefault();

    var emailAutonomo = document.querySelector('#identificadorAutonomo').getAttribute('value');
    var emailCliente = document.querySelector('#identificadorCliente').getAttribute('value');
    var codigoAnuncio = this.parentNode.parentNode.getAttribute('id').substring(6, 8);

    fetch("../lib/RemoverCandidatura.aspx?ea=" + emailAutonomo + "&ec=" + emailCliente + "&ca=" + codigoAnuncio).then(function (resposta) {
        resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                return;
            }
            if (dados.situacao == "erro") {
                // retorno visual indicando a falha na retirada da candidatura
                return;
            }
        }
    })
}

function fecharDetalhes(e) {
    e.preventDefault();
    for (let indice = 0; indice < popup.length; indice++) {
        popup[indice].classList.add("escondido");
    }
    areabluur.classList.add("escondido");
}


function abrirMenuTresPontos(e) {
    e.preventDefault();
    let valor = this.getAttribute('qual');
    if (caixinhaMenuTresPontos[valor].classList.contains('escondido')) {
        caixinhaMenuTresPontos[valor].classList.remove('escondido');
    }
    else {
        caixinhaMenuTresPontos[valor].classList.add('escondido');
    }
}

function abrirPnlDenuncia(e) {
    e.preventDefault();

    let valor = this.parentNode.getAttribute('qual');

    if (pnlDenunciar != null)
        pnlDenunciar[valor].classList.remove("escondido");

    areabluur.classList.remove("escondido");
}

function fecharPnlDenuncia(e) {
    e.preventDefault();
    let valor = this.parentNode.parentNode.getAttribute('qual');
    pnlDenunciar[valor].classList.add("escondido");
    areabluur.classList.add("escondido");
    caixinhaMenuTresPontos[valor].classList.add('escondido');
}

function abrirPnlConclusao(e) {
    e.preventDefault();
    let valor = this.parentNode.getAttribute('qual');
    pnlConcluir[valor].classList.remove("escondido");
    areabluur.classList.remove("escondido");
}

function fecharPnlConclusao(e) {
    e.preventDefault();
    let valor = this.parentNode.getAttribute('qual');
    pnlConcluir[valor].classList.add("escondido");
    areabluur.classList.add("escondido");
    caixinhaMenuTresPontos[valor].classList.add('escondido');
}

function abrirPnlCancelamento(e) {
    e.preventDefault();
    let valor = this.parentNode.getAttribute('qual');
    pnlCancelar[valor].classList.remove("escondido");
    areabluur.classList.remove("escondido");
}

function fecharPnlCancelamento(e) {
    e.preventDefault();
    let valor = this.parentNode.parentNode.getAttribute('qual');
    pnlCancelar[valor].classList.add("escondido");
    caixinhaMenuTresPontos[valor].classList.add('escondido');
    areabluur.classList.add("escondido");
}

function fecharMenuTresPontos() {
    for (let indice = 0; indice < caixinhaMenuTresPontos.length; indice++) {
        caixinhaMenuTresPontos[indice].classList.add("escondido");
    }
}