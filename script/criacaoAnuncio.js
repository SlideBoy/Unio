const btnAutoFavorito = document.querySelector("#btnAutoFavorito");
const dadosForm1 = document.querySelector(".dadosForm1");
const dadosForm2 = document.querySelector(".dadosForm2");
let VoltarIcon = document.querySelector(".voltarIcon");
let titulo = document.querySelector(".atualizarDados h2");

const btnSalvarEdicao = document.querySelector("#btnSalvarEdicao");

if (btnAutoFavorito != null) btnAutoFavorito.addEventListener('click', mostrarFavoritos)
if (VoltarIcon != null) VoltarIcon.addEventListener('click', mostrarForm)

function mostrarFavoritos() {
    dadosForm1.classList.add("escondido");
    dadosForm2.classList.remove("escondido");

    VoltarIcon.innerHTML = `<a><img src="imagens/icones/back_forms_icon.png" alt=""></a>`;
    titulo.innerHTML = "Selecione seus autônomos preferidos";
}

function mostrarForm() {
    dadosForm1.classList.remove("escondido");
    dadosForm2.classList.add("escondido");

    VoltarIcon.innerHTML = `<a href="painelCliente.html"><img src="imagens/icones/back_forms_icon.png" alt=""></a>`;
    titulo.innerHTML = "Criação Anúncio";
}


/* -  - - - - - - -  - */

const painelResultados = document.querySelector("#pnlResultados");

const btnPublico = document.querySelector("#btnPublicar");
const btnFavorito = document.querySelector("#btnAutoFavorito");
const btnEnvioFav = document.querySelector("#btnEnviar");

if (btnPublico != null) { btnPublico.addEventListener('click', AndamentoAnuncio) }
if (btnAutoFavorito != null) { btnAutoFavorito.addEventListener('click', AndamentoAnuncio) }
if (btnEnvioFav != null) { btnEnvioFav.addEventListener('click', CriarAnuncioPrivado) }
if (btnSalvarEdicao != null) { btnSalvarEdicao.addEventListener('click', EditarAnuncio) }

const ddlAreas = document.querySelector("#ddlAreaAtuacao");
const ddlPrazos = document.querySelector("#selectPrazo");

CarregarAreasAtuacao();
CarregarPrazos();

function CriarAnuncioPrivado(e) {
    e.preventDefault();

    const retorno = document.querySelector("#lblMsg");

    const txtTitulo = document.querySelector("#txtTitulo");
    const txtDescricao = document.querySelector("#txtDescricao");

    var Prazo = ddlPrazos.value;
    var Area = ddlAreas.value;

    if (txtTitulo.value == "") {
        retorno.textContent = "Preencha a(s) área(s) em branco!";
        return;
    }

    if (txtDescricao.value == "") {
        retorno.textContent = "Preencha a(s) área(s) em branco!";
        return;
    }

    if (Prazo.value == "0") {
        retorno.textContent = "Selecione um Prazo";
        return;
    }

    if (Area.value == "0") {
        retorno.textContent = "Selecione uma Area de Atuação";
        return;
    }

    var Chks = document.querySelectorAll(".identificaChk");
    var emailsDest = [];

    for (var i = 0; i < Chks.length; i++) {
        if (!Chks[i].disabled) {
            if (Chks[i].checked) {
                emailsDest.push(Chks[i].getAttribute('value'));
            }
        }
    }

    if (emailsDest.length < 1) {
        retorno.textContent = "Selecione pelo menos 1 Autonomo";
        return;
    }

    var destinatarios = "";
    for (var i = 0; i < emailsDest.length; i++) {
        destinatarios += emailsDest[i] + ",";
    }
    destinatarios = destinatarios.substring(0, destinatarios.length - 1);

    console.log(destinatarios);

    fetch('../lib/CriarAnuncio.aspx?type=private&t=' + txtTitulo.value + '&d=' + txtDescricao.value + '&p=' + Prazo + '&a=' + Area + '&dest=' + destinatarios).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                window.location = "painelCliente.aspx";
            }
            else {
                retorno.textContent = "Falha ao criar Anuncio!";
            }
        }
    })

}

function AndamentoAnuncio(e) {
    e.preventDefault();

    const retorno = document.querySelector("#lblMsg");

    const txtTitulo = document.querySelector("#txtTitulo");
    const txtDescricao = document.querySelector("#txtDescricao");

    var Prazo = ddlPrazos.value;
    var Area = ddlAreas.value;

    if (txtTitulo.value == "") {
        retorno.textContent = "Preencha a(s) área(s) em branco!";
        return;
    }

    if (txtDescricao.value == "") {
        retorno.textContent = "Preencha a(s) área(s) em branco!";
        return;
    }

    if (Prazo.value == "0") {
        retorno.textContent = "Selecione um Prazo";
        return;
    }

    if (Area.value == "0") {
        retorno.textContent = "Selecione uma Area de Atuação";
        return;
    }

    if (this.id == "btnPublicar") {
        console.log("public", txtTitulo.value, txtDescricao.value, Prazo, Area);
        fetch('../lib/CriarAnuncio.aspx?type=public&t=' + txtTitulo.value + '&d=' + txtDescricao.value + '&p=' + Prazo + '&a=' + Area).then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados != null) {
                if (dados.situacao == "ok") {
                    window.location = "painelCliente.aspx";
                }
                else {
                    retorno.textContent = "Falha ao criar Anuncio!";
                }
            }
        })

    }
    if (this.id == "btnAutoFavorito") {
        /*console.log("private", txtTitulo.value, txtDescricao.value, Prazo, Area);*/
        fetch('../lib/GerenciaFavs.aspx?type=area&filtro=' + Area).then(function (resposta) {
            return resposta.json()
        }).then(function (dados) {
            for (var i = 0; i < dados.length; i++) {
                var divAutonomosResultado = document.createElement('div');
                divAutonomosResultado.classList.add("autonomosResultado");

                var divImgAutonomo = document.createElement('img');
                divImgAutonomo.classList.add("imgAutonomo");
                divImgAutonomo.src = dados[i].Foto;

                var divAutonomo = document.createElement('div');
                divAutonomo.classList.add("autonomo");
                divAutonomo.id = "divAutonomo";

                var divInfoAutonomo = document.createElement('div');
                divInfoAutonomo.classList.add("infoAutonomo");

                var h3 = document.createElement('h3');
                h3.textContent = dados[i].Nome;

                var p = document.createElement('p');
                p.textContent = dados[i].Comentario;
                p.classList.add("descricao");

                var divAvaliacao = document.createElement('div');
                divAvaliacao.classList.add("avaliacao");

                var divBarra = document.createElement('div');
                divBarra.classList.add("barra");
                divBarra.setAttribute("valor", "4.5");

                var div = document.createElement('div');

                var imgFigure = document.createElement('img');
                imgFigure.src = "imagens/icones/estrelas_vazadas.png";
                var figure = document.createElement('figure');

                var checkBox = document.createElement('input');
                checkBox.type = "checkbox";
                checkBox.disabled = true;
                checkBox.classList.add("identificaChk");
                checkBox.setAttribute('value', dados[i].Email);

                if (dados[i].Check == "true") {
                    checkBox.disabled = false;
                }

                divInfoAutonomo.appendChild(h3);
                divInfoAutonomo.appendChild(p);

                divAutonomo.appendChild(divInfoAutonomo);
                divAutonomo.appendChild(checkBox);

                divAutonomosResultado.appendChild(divImgAutonomo);
                divAutonomosResultado.appendChild(divAutonomo);

                painelResultados.appendChild(divAutonomosResultado);
            }
        });
    }
}

function CarregarPrazos() {
    fetch('../lib/GerenciaPrazo.aspx').then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "false") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "erro ao carregar itens!";
                erro.selected = true;

                ddlPrazos.appendChild(erro);
                return;
            }
            if (dados.situacao == "true" && dados.qtPrazos == "0") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "nenhum item encontrado!";
                erro.selected = true;

                ddlPrazos.appendChild(erro);
                return;
            }
            if (dados.length != 0) {

                var selecione = document.createElement('option');
                selecione.value = "0";
                selecione.text = "-- Selecione --";
                selecione.selected = true;
                selecione.disabled = true;

                ddlPrazos.appendChild(selecione);

                var url = new URL(window.location.href);
                if (url.searchParams.get("p") != null) { 
                var p = url.searchParams.get("p");
                }

                for (var i = 0; i < dados.length; i++) {
                    var option = document.createElement('option');
                    option.value = dados[i]["Codigo"];
                    option.text = dados[i]["Nome"];
                    ddlPrazos.appendChild(option);
                    if (option.value == p) {
                        option.setAttribute('selected', 'true');
                    }
                }
                
            }
        }
    })
}

function CarregarAreasAtuacao() {
    fetch('../lib/GerenciaAreaAtuacao.aspx').then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "false") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "erro ao carregar itens!";
                erro.selected = true;

                ddlAreas.appendChild(erro);
                return;
            }
            if (dados.situacao == "true" && dados.qtAreas == "0") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "nenhum item encontrado!";
                erro.selected = true;

                ddlAreas.appendChild(erro);
                return;
            }
            if (dados.length != 0) {

                var selecione = document.createElement('option');
                selecione.value = "0";
                selecione.text = "-- Selecione --";
                selecione.selected = true;
                selecione.disabled = true;

                ddlAreas.appendChild(selecione);

                var url = new URL(window.location.href);
                if (url.searchParams.get("a") != null) {
                    var a = url.searchParams.get("a");
                }

                for (var i = 0; i < dados.length; i++) {
                    var option = document.createElement('option');
                    option.value = dados[i]["Codigo"];
                    option.text = dados[i]["Nome"];
                    ddlAreas.appendChild(option);
                    if (option.value == a) {
                        option.setAttribute('selected', 'true');
                    }
                }
            }
        }
    })
}

function EditarAnuncio(e) {
    e.preventDefault();

    var Codigo = 0;
    var url = new URL(window.location.href);
    if (url.searchParams.get("c") != null) {
      Codigo = url.searchParams.get("c");
    }

    const txtTitulo = document.querySelector("#iptTitulo");
    const txtDescricao = document.querySelector("#iptDescricao");

    var Prazo = ddlPrazos.value;
    var Area = ddlAreas.value;

    console.log(Codigo);
    console.log(txtTitulo.value);
    console.log(txtDescricao.value);
    console.log(Prazo);
    console.log(Area);

    fetch('../lib/EditarAnuncio.aspx?c=' + Codigo +'&t=' + txtTitulo.value + '&d=' + txtDescricao.value + '&p=' + Prazo + '&a=' + Area).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                window.location = "painelCliente.aspx";
            }
            else {
                retorno.textContent = "Falha ao editar anúncio!";
            }
        }
    })
}

