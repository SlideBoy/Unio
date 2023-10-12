const btnDados = document.querySelector("#meusDados");
const btnProfissoes = document.querySelector("#btnProfissoes");
const btnPortfolio = document.querySelector("#btnPortfolio");
const btnEmblemas = document.querySelector("#emblemas");
const btnAvaliacoes = document.querySelector("#avaliacoes");

const dados = document.querySelector(".dados");
const profissoes = document.querySelector(".profissoes");
const profissoesNovas = document.querySelector(".profissoesNovas");
const portfolio = document.querySelector(".portfolio");

const btnSalvarDados = document.querySelector("#btnSalvarDados");
const btnAdicionarNovaProfissão = document.querySelector("#adicionarNovaProfissao");
const btnAdd = document.querySelector("#btnAddProfissao");
const btnSalvarProfissao = document.querySelector("#btnSalvarProfissao");
const pnlSalvar = document.querySelector(".pnlSalvar");
const blur = document.querySelector(".blur");
const btnVoltar = document.querySelector("#btnVoltar");
const btnSalvarMesmo = document.querySelector("#btnSalvar");


btnDados.addEventListener('click', abrirDados);
btnAdicionarNovaProfissão.addEventListener('click', abrirPnlNovaProfissao);
btnProfissoes.addEventListener('click', abrirProfissoes);
btnAdd.addEventListener('click', salvar);
btnPortfolio.addEventListener('click', abrirPortfolio);
btnEmblemas.addEventListener('click', abrirEmblemas);
btnAvaliacoes.addEventListener('click', abrirAvaliacoes);
btnSalvarDados.addEventListener('click', salvar);
btnSalvarProfissao.addEventListener('click', salvar);
btnVoltar.addEventListener('click', voltar);
btnSalvarMesmo.addEventListener('click', voltar);


function abrirDados(){
    btnDados.classList.add("filtroSelecionado");
    btnProfissoes.classList.remove("filtroSelecionado");
    btnPortfolio.classList.remove("filtroSelecionado");
    btnEmblemas.classList.remove("filtroSelecionado");

    dados.classList.remove("escondido");
    profissoes.classList.add("escondido");
    profissoesNovas.classList.add("escondido");
    portfolio.classList.add("escondido");
}

function abrirPnlNovaProfissao(){
    profissoes.classList.add("escondido");
    profissoesNovas.classList.remove('escondido');
}

function abrirProfissoes(){
    btnProfissoes.classList.add("filtroSelecionado");
    btnDados.classList.remove("filtroSelecionado");
    btnPortfolio.classList.remove("filtroSelecionado");
    btnEmblemas.classList.remove("filtroSelecionado");

    profissoes.classList.remove("escondido");
    profissoesNovas.classList.add("escondido");
    dados.classList.add("escondido");
    portfolio.classList.add("escondido");
}

function abrirPortfolio(){
    btnPortfolio.classList.add("filtroSelecionado");
    btnProfissoes.classList.remove("filtroSelecionado");
    btnDados.classList.remove("filtroSelecionado");
    btnEmblemas.classList.remove("filtroSelecionado");

    portfolio.classList.remove("escondido");
    dados.classList.add("escondido");
    profissoes.classList.add("escondido");
    profissoesNovas.classList.add("escondido");
}

function abrirEmblemas(){
    btnEmblemas.classList.add("filtroSelecionado");
    btnProfissoes.classList.remove("filtroSelecionado");
    btnDados.classList.remove("filtroSelecionado");
    btnPortfolio.classList.remove("filtroSelecionado");
}

function abrirAvaliacoes(){
    btnAvaliacoes.classList.add("filtroSelecionado");
    btnProfissoes.classList.remove("filtroSelecionado");
    btnDados.classList.remove("filtroSelecionado");
    btnPortfolio.classList.remove("filtroSelecionado");
    btnEmblemas.classList.remove("filtroSelecionado");
}

function salvar(){

    pnlSalvar.classList.remove("escondido");
    blur.classList.remove("escondido");
}

function voltar(){

    pnlSalvar.classList.add("escondido");
    blur.classList.add("escondido");
}