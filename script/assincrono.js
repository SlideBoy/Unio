let txtNome = document.querySelector("#inputNome");
let txtEmail = document.querySelector("#inputEmail");
let txtSenha = document.querySelector("#inputSenha");
let txtSenhaConfirmacao = document.querySelector("#inputSenhaConfirmacao");
const txtTelefone = document.querySelector("#inputTelefone");
const ddlEstado = document.querySelector("#ddlEstado");
const ddlCidade = document.querySelector("#ddlCidade");
const txtCPF = document.querySelector("#inputCPF");
const ddlProfissao = document.querySelector("#ddlProfissao");

const erroMensagem = document.querySelector(".labelErro");
const btnCriar = document.querySelector("#btnCriarPerfil");

if (btnCriar != null) btnCriar.addEventListener('click', CriarPerfil);

function CriarPerfil(e)
{
    e.preventDefault();
    erroMensagem.innerHTML = "";

    if (txtNome.value == null || txtNome.value == "") {
        txtNome.focus();
        erroMensagem.innerHTML = "O campo \"Nome Completo\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtEmail.value == null || txtEmail.value == "") {
        txtEmail.focus();
        erroMensagem.innerHTML = "O campo \"E-mail\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    let regexPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (!regexPattern.test(txtEmail.value)) {
        txtEmail.focus();
        erroMensagem.innerHTML = "E-mail inválido.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtSenha.value == null || txtSenha.value == "") {
        txtSenha.focus();
        erroMensagem.innerHTML = "O campo \"Senha\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    regexPattern = /^(?=.*\d).{8,}$/

    if (!regexPattern.test(txtSenha.value)) {
        txtSenha.focus();
        erroMensagem.innerHTML = "O campo \"Senha\" deve conter no mínimo 8 caracteres com pelo menos uma número.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtSenhaConfirmacao.value == null || txtSenhaConfirmacao.value == "") {
        txtSenhaConfirmacao.focus();
        erroMensagem.innerHTML = "A confirmação da senha não pode ser vazia.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtSenha.value != txtSenhaConfirmacao.value) {
        txtSenhaConfirmacao.focus();
        erroMensagem.innerHTML = "As senhas devem ser idênticas.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtTelefone.value == null || txtTelefone.value == "") {
        txtTelefone.focus();
        erroMensagem.innerHTML = "o Campo \"Celular\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    regexPattern = /^\d{11}$/;

    if (!regexPattern.test(txtTelefone.value)) {
        txtTelefone.focus();
        erroMensagem.innerHTML = "Telefone inválido.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (ddlEstado.selectedIndex == 0) {
        ddlEstado.focus();
        erroMensagem.innerHTML = "O Campo \"Estado\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (ddlCidade.selectedIndex == 0) {
        ddlCidade.focus();
        erroMensagem.innerHTML = "O Campo \"Cidade\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    if (txtCPF.value == null || txtCPF.value == "")
    {
        txtCPF.focus();
        erroMensagem.innerHTML = "o campo \"CPF\" não pode ser vazio.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    regexPattern = /^\d{11}$/;

    if (!regexPattern.test(txtCPF.value))
    {
        txtCPF.focus();
        erroMensagem.innerHTML = "CPF inválido.";
        erroMensagem.classList.remove("escondido");
        return;
    }

    fetch('../lib/CriarCliente.aspx?n=' + txtNome.value +
        '&e=' + txtEmail.value +
        '&c=' + txtCPF.value +
        '&s=' + txtSenha.value +
        '&t=' + txtTelefone.value +
        '&d=' + ddlCidade.selectedIndex
    ).then(function (resposta) {
        return resposta.json();
        }).then(function (dados) {
            if (dados != null) {
                if (dados.situacao == 'true') {
                    $.post("lib/EntrarSessao.aspx", { "e": txtEmail.value, "s": txtSenha.value }, function (retorno) {
                        if (retorno.situacao == 'ok') {
                            window.location = "painelCliente.aspx";
                        }
                        else {
                            mensagemErro.innerHTML = "Email e/ou senha inválidos!";
                            mensagemErro.classList.remove("escondido");
                        }
                    }, 'json');
                }
                else {
                    mensagemErro.innerHTML = "Não foi possível";
                    mensagemErro.classList.remove("escondido");
                }
            }
        });
    
}

ddlEstado.onchange = function carregarCidades(e) {

    var estado = ddlEstado.selectedOptions[0].getAttribute('value');
/*    console.log(estado);*/
    ddlCidade.innerHTML = "";
/*    console.log(ddlCidade.childNodes);*/
    fetch('../lib/GerenciaCidade.aspx?f=' + estado).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "false") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "erro ao carregar itens!";
                erro.selected = true;

                ddlProfissao.appendChild(erro);
                return;
            }
            if (dados.situacao == "true" && dados.qtCidade == "0") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "nenhum item encontrado!";
                erro.selected = true;

                ddlCidade.appendChild(erro);
                return;
            }
            if (dados.length != 0) {


                var selecione = document.createElement('option');
                selecione.value = "0";
                selecione.text = "-- Selecione --";
                selecione.selected = true;
                selecione.disabled = true;

                ddlCidade.appendChild(selecione);

                for (var i = 0; i < dados.length; i++) {
                    var option = document.createElement('option');
                    option.value = dados[i]["Codigo"];
                    option.text = dados[i]["Nome"];

                    ddlCidade.appendChild(option);
                }
            }
        }
    })
}

if (ddlProfissao != null) {
    window.onload = function carregarProfissoes() {
        fetch('../lib/GerenciaProfissoes.aspx').then(function (resposta) {
            return resposta.json();
        }).then(function (dados) {
            if (dados != null) {
                if (dados.situacao == "false") {
                    var erro = document.createElement('option');
                    erro.value = "erro";
                    erro.text = "erro ao carregar itens!";
                    erro.selected = true;

                    ddlProfissao.appendChild(erro);
                    return;
                }
                if (dados.situacao == "true" && dados.qtProfissao == "0") {
                    var erro = document.createElement('option');
                    erro.value = "erro";
                    erro.text = "nenhum item encontrado!";
                    erro.selected = true;

                    ddlProfissao.appendChild(erro);
                    return;
                }
                if (dados.length != 0) {

                    var selecione = document.createElement('option');
                    selecione.value = "0";
                    selecione.text = "-- Selecione --";
                    selecione.selected = true;
                    selecione.disabled = true;

                    ddlProfissao.appendChild(selecione);

                    for (var i = 0; i <= dados.length; i++) {
                        var option = document.createElement('option');
                        option.value = dados[i]["Codigo"];
                        option.text = dados[i]["Nome"];

                        ddlProfissao.appendChild(option);
                    }
                }
            }
        })
    }
}

window.onload = function carregarEstados() {
    fetch('../lib/GerenciaEstado.aspx').then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "false") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "erro ao carregar itens!";
                erro.selected = true;

                ddlEstado.appendChild(erro);
                return;
            }
            if (dados.situacao == "true" && dados.qtProfissao == "0") {
                var erro = document.createElement('option');
                erro.value = "erro";
                erro.text = "nenhum item encontrado!";
                erro.selected = true;

                ddlEstado.appendChild(erro);
                return;
            }
            if (dados.length != 0) {
                var selecioneCidade = document.createElement('option');
                selecioneCidade.value = "0";
                selecioneCidade.text = "-- Selecione um Estado --";
                selecioneCidade.selected = true;
                selecioneCidade.disabled = true;

                ddlCidade.appendChild(selecioneCidade);

                console.log(dados);
                var selecione = document.createElement('option');
                selecione.value = "0";
                selecione.text = "-- Selecione --";
                selecione.selected = true;
                selecione.disabled = true;

                ddlEstado.appendChild(selecione);

                for (var i = 0; i <= dados.length; i++) {
                    var option = document.createElement('option');
                    option.value = dados[i]["Sigla"];
                    option.text = dados[i]["Nome"];

                    ddlEstado.appendChild(option);
                }
            }
        }
    })
}


