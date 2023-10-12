const areabluur = document.querySelector(".blur");

const anuncios = document.querySelectorAll(".anuncio");
const pontinhos = document.querySelectorAll(".pontinhos");
const caixinhaMenuTresPontos = document.querySelectorAll(".OpcoesMenu");

const Denunciar = document.querySelectorAll("#Denunciar");
const Concluir = document.querySelectorAll("#Concluir");
const Cancelar = document.querySelectorAll("#Cancelar");
const Editar = document.querySelectorAll("#Editar");
const btnCriarAnuncio = document.querySelector("#btnCriarAnuncio");

const pnlDenunciar = document.querySelectorAll(".pnlDenuncia");
const pnlConcluir = document.querySelectorAll(".pnlConcluir");
const pnlAvaliar = document.querySelectorAll(".pnlAvaliar");
const pnlCancelar = document.querySelectorAll(".pnlCancelar");

const backIconDenunciar = document.querySelectorAll(".pnlDenuncia .cabecalhoDenuncia .backIcon");
const backIconConcluir = document.querySelectorAll(".pnlConcluir .cabecalhoConcluir .backIcon");
const backIconAvaliar = document.querySelectorAll(".pnlAvaliar .cabecalhoAvaliar .backIcon");
const backIconCancelar = document.querySelectorAll(".pnlCancelar .cabecalhoCancelar .backIcon");

const btnDenunciar = document.querySelectorAll("#btnDenunciar");
const btnConcluir = document.querySelectorAll("#btnConcluir");
const btnAvaliar = document.querySelectorAll("#btnAvaliar");
const btnCancelar2 = document.querySelectorAll("#btnCancelar2");

const estrelasCumprimento = document.querySelectorAll(".estrelasCumprimento figure img");
const estrelasExecucao = document.querySelectorAll(".estrelasExecucao figure img");
const estrelasComunicacao =document.querySelectorAll(".estrelasComunicacao figure img");
let marcacao = -1;

/*array que define indice para as estrelas*/
for (var i = 0; i < estrelasCumprimento.length; i++) {
   estrelasCumprimento[i].setAttribute("indice", i+1);
   estrelasCumprimento[i].addEventListener('click', pegarIndiceCumprimento);
   estrelasCumprimento[i].addEventListener("mouseover", PintarEstrelasAteAPosicaoDoCursorCum);
   estrelasCumprimento[i].addEventListener("mouseout", LimparERemarcarAteOObjetoClicadoCum);
}

for (var i = 0; i < estrelasExecucao.length; i++) {
   estrelasExecucao[i].setAttribute("indice", i+1);
   estrelasExecucao[i].addEventListener('click', pegarIndiceExecucao);
   estrelasExecucao[i].addEventListener("mouseover", PintarEstrelasAteAPosicaoDoCursorEx);
   estrelasExecucao[i].addEventListener("mouseout", LimparERemarcarAteOObjetoClicadoEx);
}

for (var i = 0; i < estrelasComunicacao.length; i++) {
   estrelasComunicacao[i].setAttribute("indice", i+1);
   estrelasComunicacao[i].addEventListener('click', pegarIndiceComunicacao);
   estrelasComunicacao[i].addEventListener("mouseover", PintarEstrelasAteAPosicaoDoCursorCom);
   estrelasComunicacao[i].addEventListener("mouseout", LimparERemarcarAteOObjetoClicadoCom);
}

/*Array do icone de tres pontos para ver o mini menu*/
for(let indice = 0; indice<pontinhos.length; indice++)
{
   if(pontinhos[indice]!=null)
   {
      pontinhos[indice].addEventListener('click', abrirMenuTresPontos);
   }
   
}

for(let indice=0; indice<caixinhaMenuTresPontos.length; indice++)
{
   if(caixinhaMenuTresPontos[indice].addEventListener('mouseleave', fecharMenuTresPontos));
}


/*Array da opção de denuncia no menu*/
for(let indice = 0; indice < Denunciar.length; indice++)
{
   if(Denunciar[indice]!=null)
   {
      Denunciar[indice].addEventListener('click', abrirPnlDenuncia);
   }
}
for (let indice = 0; indice < backIconDenunciar.length; indice++) {
    if (backIconDenunciar[indice] != null) {
        backIconDenunciar[indice].addEventListener('click', fecharPnlDenuncia);
    }
}

/*Array da opção de conclusão no menu*/
for(let indice = 0; indice<Concluir.length; indice++)
{
   if(Concluir[indice]!=null)
   {
      Concluir[indice].addEventListener('click', abrirPnlConclusao);
   }
}
for (let indice = 0; indice < backIconConcluir.length; indice++) {
    if (backIconConcluir[indice] != null) {
        backIconConcluir[indice].addEventListener('click', fecharPnlConclusao);
    }
} for (let indice = 0; indice < backIconAvaliar.length; indice++) {
    if (backIconAvaliar[indice] != null) {
        backIconAvaliar[indice].addEventListener('click', pnlAvaliar);
    }
}

/*Array da opção de cancelamento no menu*/
for(let indice = 0; indice<Cancelar.length; indice++)
{
   Cancelar[indice].addEventListener('click', abrirPnlCancelamento);
}
for (let indice = 0; indice < backIconCancelar.length; indice++) {
    backIconCancelar[indice].addEventListener('click', fecharPnlCancelamento);
}

/*------------------Eventos--------------------------------------------------------*/
if (btnCriarAnuncio != null) btnCriarAnuncio.addEventListener('click', criarAnuncio);

for (let indice = 0; indice < btnAvaliar.length; indice++) {
    if (btnAvaliar[indice] != null)
        btnAvaliar[indice].addEventListener('click', fecharPnlAvaliacao);
}

/*Array do botão de denunciar mesmo*/
for (let indice = 0; indice < btnDenunciar.length; indice++) {
    if (btnDenunciar[indice] != null)
        btnDenunciar[indice].addEventListener('click', Denunciar);
}

/*Array do botão de concluir mesmo*/
for (let indice = 0; indice < btnConcluir.length; indice++) {
    if (btnConcluir[indice] != null)
        btnConcluir[indice].addEventListener('click', ConcluirAnuncio);

}

/*Array do botão de cancelar mesmo*/
for (let indice = 0; indice < btnCancelar2.length; indice++) {
    if (btnCancelar2[indice] != null)
        btnCancelar2[indice].addEventListener('click', CancelarAnuncio);
}

/*Array do botão de editar anuncio*/
for (let indice = 0; indice < Editar.length; indice++) {
    if (Editar[indice] != null) {
        Editar[indice].addEventListener('click', abrirEdicaoAnuncio);
    }
}


function abrirMenuTresPontos()
{
    let valor = this.getAttribute('qual');
    
   if(caixinhaMenuTresPontos[valor].classList.contains('escondido'))
   {
      caixinhaMenuTresPontos[valor].classList.remove('escondido');
   }
   else{
      caixinhaMenuTresPontos[valor].classList.add('escondido');
   }
}

function fecharMenuTresPontos()
{
   for(let indice =0; indice<caixinhaMenuTresPontos.length; indice++)
   {
      caixinhaMenuTresPontos[indice].classList.add("escondido");
   }
}

function abrirPnlAvaliacao(){
   pnlConcluir.classList.add("escondido");
   pnlAvaliar.classList.remove("escondido");
   areabluur.classList.remove("escondido");
}

function fecharPnlAvaliacao(){
   pnlAvaliar.classList.add("escondido");
   areabluur.classList.add("escondido");
}

/*funções das estrelas*/
function pegarIndiceCumprimento(){
   marcacao = this.getAttribute("indice");

   // aqui seria um bom lugar
   // para uma requisição assíncrona para gravar a classificação indicada
}

function pegarIndiceExecucao(){
   marcacao = this.getAttribute("indice");

   // aqui seria um bom lugar
   // para uma requisição assíncrona para gravar a classificação indicada
} 

function pegarIndiceComunicacao(){
   marcacao = this.getAttribute("indice");

   // aqui seria um bom lugar
   // para uma requisição assíncrona para gravar a classificação indicada
}

function PintarEstrelasAteAPosicaoDoCursorCum() {
   
      let indice = this.getAttribute("indice");

      for (var j = 0; j < estrelasCumprimento.length; j++) {
         estrelasCumprimento[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
      }

      for (var j = 0; j < indice; j++) {
         estrelasCumprimento[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
      }
      
}

function PintarEstrelasAteAPosicaoDoCursorEx() {
   
   let indice = this.getAttribute("indice");

   for (var j = 0; j < estrelasExecucao.length; j++) {
      estrelasExecucao[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
   }

   for (var j = 0; j < indice; j++) {
      estrelasExecucao[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
   }
   
}

function PintarEstrelasAteAPosicaoDoCursorCom() {
   
   let indice = this.getAttribute("indice");

   for (var j = 0; j < estrelasComunicacao.length; j++) {
      estrelasComunicacao[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
   }

   for (var j = 0; j < indice; j++) {
      estrelasComunicacao[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
   }
   
}


function LimparERemarcarAteOObjetoClicadoCum() {

      for (var j = 0; j < estrelasCumprimento.length; j++) {
            estrelasCumprimento[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
      }

      if (marcacao - 1 >= 0) {
         for (var j = 0; j < marcacao; j++) {
            estrelasCumprimento[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
         }
      }

}

function LimparERemarcarAteOObjetoClicadoEx() {

   for (var j = 0; j < estrelasExecucao.length; j++) {
      estrelasExecucao[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
   }

   if (marcacao - 1 >= 0) {
      for (var j = 0; j < marcacao; j++) {
         estrelasExecucao[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
      }
   }
}

function LimparERemarcarAteOObjetoClicadoCom() {

   for (var j = 0; j < estrelasComunicacao.length; j++) {
      estrelasComunicacao[j].setAttribute("src", "imagens/icones/estrela_vazada_sozinha.png");
   }

   if (marcacao - 1 >= 0) {
      for (var j = 0; j < marcacao; j++) {
         estrelasComunicacao[j].setAttribute("src", "imagens/icones/estrela_pintada_sozinha.png");
      }
   }
}

function criarAnuncio(e) {
    e.preventDefault();
    window.location = "criacaoAnuncio.aspx";
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
    let valor = this.parentNode.parentNode.getAttribute('qual');
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

function abrirEdicaoAnuncio() {
    let codigo = this.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('codigo');
    let titulo = this.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('titulo');
    let descricao = this.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('descricao');
    let prazo = this.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('cdPrazo');
    let area = this.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('cdArea');

    console.log(codigo, titulo, descricao, prazo, area)

    window.location = "EdicaoAnuncio.aspx?c=" + codigo + "&t=" + titulo + "&d=" + descricao + "&p=" + prazo + "&a=" + area;
}

function ConcluirAnuncio(e) {
    e.preventDefault();
    let codigo = this.parentNode.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('codigo');
    let qual = this.parentNode.parentNode.parentNode.getAttribute('qual');

    fetch("../lib/ConcluirAnuncio.aspx?c=" + codigo).then(function (resposta) {
        resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                console.log('');
            }
            if (dados.situacao == "erro") {
                console.log('');
            }
        }
    })

    pnlConcluir[qual].classList.add("escondido");
    areabluur.classList.add("escondido");
    caixinhaMenuTresPontos[qual].classList.add('escondido');

    console.log(anuncios[qual].querySelector('.titulo_Btn').querySelector('.status'));
    anuncios[qual].querySelector('.titulo_Btn').querySelector('.status').setAttribute('style', 'background-color: #6dc00088; color: #2C4F00;');
    anuncios[qual].querySelector('.titulo_Btn').querySelector('.status').innerHTML = "Concluído";
}

function CancelarAnuncio(e) {
    e.preventDefault();
    let codigo = this.parentNode.parentNode.parentNode.querySelector('#infosAnuncio').getAttribute('codigo');
    let qual = this.parentNode.parentNode.parentNode.getAttribute('qual');

    fetch("../lib/CancelarAnuncio.aspx?c=" + codigo).then(function (resposta) {
        resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                console.log('Cancelado');
            }
            if (dados.situacao == "erro") {
                console.log('');
            }
        }
    })

    pnlCancelar[qual].classList.add("escondido");
    areabluur.classList.add("escondido");
    caixinhaMenuTresPontos[qual].classList.add('escondido');

    console.log(anuncios[qual].querySelector('.titulo_Btn').querySelector('.status'));
    anuncios[qual].querySelector('.titulo_Btn').querySelector('.status').setAttribute('style', 'background-color: #de0028a6; color: #ffe3ea;');
    anuncios[qual].querySelector('.titulo_Btn').querySelector('.status').innerHTML = "Cancelado";
}

function Denunciar(e) {
    e.preventDefault();
    console.log('Denunciado teste git hub');
}