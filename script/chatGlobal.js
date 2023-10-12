CarregarChats();

/*const divPessoa = document.querySelectorAll(".principal");*/
const divChats = document.querySelector("#regiaoChats");
const divSemChat = document.querySelector(".SemAnuncios");
const janelaConversa = document.querySelector("#conversas");
var alternador = false;
var loop;
//const Chat = document.querySelector("#chat");


//for(indice = 0; indice < divPessoa.length; indice++)
//{
//    if(divPessoa[indice] != null) divPessoa[indice].addEventListener('click', abrirConversa);
//}


function abrirConversa() {
    for (var i = 0; i < this.classList.length; i++) {
        if (this.classList[i] == "ativo") {
            this.classList.remove('ativo')

            janelaConversa.removeChild(document.querySelector("#divInfoPessoa"))
            janelaConversa.removeChild(document.querySelector("#chat"));
            janelaConversa.removeChild(document.querySelector("#regiaoEnvio")); 

            alternador = false;
            return;
        }
    }

    this.classList.add('ativo');
    alternador = true;
    console.log(alternador);

    var divInfoPessoa = document.createElement('div');
    divInfoPessoa.classList.add('infoPessoa');
    divInfoPessoa.id = "divInfoPessoa";
    

    var h1 = document.createElement('h1');
    h1.textContent = this.querySelector('h3').textContent;

    var divStrong = document.createElement('div');

    var strong = document.createElement('strong');
    strong.textContent = "Prazo:";

    var p = document.createElement('p');

    var figure = document.createElement('figure');
    var imgAlerta = document.createElement('img');

    imgAlerta.src = "imagens/icones/alert_icon.png";

    var iptId = document.createElement('input');
    iptId.setAttribute('value', this.querySelector('#identificadorChat').getAttribute('value'));
    iptId.setAttribute('type', 'hidden');
    iptId.id = "identificadorChat";

    divInfoPessoa.appendChild(iptId);
    divInfoPessoa.appendChild(h1);

    p.appendChild(strong);
    p.textContent += " - - - - ";

    figure.appendChild(imgAlerta);

    divStrong.appendChild(p);

    divInfoPessoa.appendChild(divStrong);

    janelaConversa.appendChild(divInfoPessoa);


   /* var idAnuncio = this.querySelector('#identificadorAnuncio');*/
    var email = this.querySelector('#identificadorChat');
    CarregarConversa(/*idAnuncio.getAttribute('value'),*/ email.getAttribute('value'));     
}

function CarregarChats() {
    fetch('../lib/GerenciaChats.aspx').then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            console.log(dados);

            if (dados.situacao == "false") {
                return;
            }

            if (dados.situacao == "true" && dados.qtChats == "0") {
                return;
            }

            for (var i = 0; i < dados.length; i++) {

                var divPrincipal = document.createElement('div');
                divPrincipal.classList.add('principal');
                divPrincipal.setAttribute('style', 'position: relative');

                var imgNotificacao = document.createElement('img');
                imgNotificacao.classList.add('aviso_notificacao');
                imgNotificacao.src = "imagens/icones/aviso_Notificações.png";

                var figure = document.createElement('figure');
                var imgAuto = document.createElement('img');
                imgAuto.src = dados[i].Foto;

                var divInfo = document.createElement('div');
                var h3 = document.createElement('h3');
                h3.textContent = dados[i].Nome;

                var p = document.createElement('p');
                if (dados[i].Profissoes != null) {
                    var profissoes = dados[i].Profissoes.split(',');


                    for (t = 0; t < profissoes.length; t++) {
                        p.textContent = profissoes[t] + " - ";
                        if (profissoes[t] == profissoes[t - 1]) { break; }
                    }
                }
                

                p.textContent = p.textContent.substr(0, p.textContent.length - 3);

                divInfo.appendChild(h3);
                divInfo.appendChild(p);

                figure.appendChild(imgAuto);

                divPrincipal.appendChild(imgNotificacao);
                divPrincipal.appendChild(figure);
                divPrincipal.appendChild(divInfo);

                divChats.appendChild(divPrincipal);

                var iptHidden = document.createElement('input');
                iptHidden.setAttribute('value', dados[i].Email);
                iptHidden.setAttribute('type', 'hidden');
                iptHidden.id = "identificadorChat";

                //var iptHiddenAnuncio = document.createElement('input');
                //iptHiddenAnuncio.setAttribute('value', dados[i].cdAnuncio);
                //iptHiddenAnuncio.setAttribute('type', 'hidden');
                //iptHiddenAnuncio.id = "identificadorAnuncio";

                divPrincipal.appendChild(iptHidden);
                /*divPrincipal.appendChild(iptHiddenAnuncio);*/

                divPrincipal.addEventListener('click', abrirConversa);
                divPrincipal.addEventListener('click', looping);
            }

            divChats.classList.remove('escondido');
            divSemChat.classList.add('escondido');
            
        }
    })
}

function CarregarConversa(email) {
    fetch('../lib/CarregarConversas.aspx?e=' + email).then(function (resp) {
        return resp.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "false") {
                return;
            }

            if (dados.situacao == "true" && dados.qtMsg == "0") {
                var chat = document.createElement('div');
                chat.classList.add('chat');
                chat.id = "chat";

                var divEnvio = document.createElement('div');
                divEnvio.classList.add('enviarMsg');
                divEnvio.id = "regiaoEnvio";

                var iptMsg = document.createElement('input');
                iptMsg.setAttribute('type', 'text');
                iptMsg.classList.add('enviar');
                iptMsg.setAttribute('placeholder', 'Escreva aqui...');
                iptMsg.id = "iptNovaMsg";

                var btnEnviar = document.createElement('button');
                btnEnviar.id = "btnEnviar";
                btnEnviar.textContent = "Enviar";
                btnEnviar.addEventListener('click', EnviarMensagem);

                divEnvio.appendChild(iptMsg);
                divEnvio.appendChild(btnEnviar);

                janelaConversa.appendChild(chat)

                janelaConversa.appendChild(divEnvio);
            }

            var chat = document.createElement('div');
            chat.classList.add('chat');
            chat.id = "chat";

            for (var i = 0; i < dados.length; i++) {
                var div = document.createElement('div');
                if (dados[i].type == "Cliente") {
                    if (dados[i].Envio == "ClienteMsg") {
                        div.classList.add('msgEnviada');
                    }
                    if (dados[i].Envio == "AutonomoMsg") {
                        div.classList.add('msgRecebida');
                    }
                }

                if (dados[i].type == "Autonomo") {
                    if (dados[i].Envio == "ClienteMsg") {
                        div.classList.add('msgRecebida');
                    }
                    if (dados[i].Envio == "AutonomoMsg") {
                        div.classList.add('msgEnviada');
                    }
                }

                var p = document.createElement('p');
                p.textContent = dados[i].Mensagem;

                div.appendChild(p);

                chat.appendChild(div);

                janelaConversa.appendChild(chat);
            }

            var lastMsg = chat.lastChild;
            lastMsg.id = "lastMsg";

            var divEnvio = document.createElement('div');
            divEnvio.classList.add('enviarMsg');
            divEnvio.id = "regiaoEnvio";

            var iptMsg = document.createElement('input');
            iptMsg.setAttribute('type', 'text');
            iptMsg.classList.add('enviar');
            iptMsg.setAttribute('placeholder', 'Escreva aqui...');
            iptMsg.id = "iptNovaMsg";

            var btnEnviar = document.createElement('button');
            btnEnviar.id = "btnEnviar";
            btnEnviar.textContent = "Enviar";
            btnEnviar.addEventListener('click', EnviarMensagem);

            divEnvio.appendChild(iptMsg);
            divEnvio.appendChild(btnEnviar);

            janelaConversa.appendChild(divEnvio);

            location.href = "chatCliente.aspx#lastMsg";
        }
    })
}

function EnviarMensagem(e) {

    e.preventDefault();
    var iptMsg = document.querySelector("#iptNovaMsg").value;

    if (iptMsg == '') {
        return;
    }

    var emailD = this.parentNode.parentNode.querySelector("#identificadorChat").value;
    console.log(emailD);

    var URL = '../lib/EnviarMensagem.aspx?ed=' + emailD + '&msg=' + encodeURIComponent(iptMsg);
    //var newURL = encodeURIComponent(URL);

    fetch(URL).then(function (resp) {
        return resp.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "true") {
                janelaConversa.removeChild(document.querySelector("#chat"));
                janelaConversa.removeChild(document.querySelector("#regiaoEnvio")); 
                CarregarConversa(emailD);
            }
        }
    })
}


function looping() {
    if (alternador) {
        loop = setInterval(function () {
            var count = document.querySelector("#conversas").querySelector("#chat");
            var email = janelaConversa.querySelector("#divInfoPessoa").querySelector("#identificadorChat").getAttribute('value');
            fetch('../lib/CarregarConversas.aspx?e=' + email + '&count=' + count.childNodes.length).then(function (resp) {
                return resp.json();
            }).then(function (dados) {
                if (dados != null) {
                    if (dados.situacao == "true") {
                        //janelaConversa.removeChild(document.querySelector("#divInfoPessoa"))
                        janelaConversa.removeChild(document.querySelector("#chat"));
                        janelaConversa.removeChild(document.querySelector("#regiaoEnvio"));
                        CarregarConversa(email);
                    }
                }
            })
        }, 750);
    } else {

        clearInterval(loop);
        loop = null;
    }
}