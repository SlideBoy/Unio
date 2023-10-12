
const btnContratar = document.querySelectorAll("#btnContratar");
for (let indice = 0; indice < btnContratar.length; indice++) {
    btnContratar[indice].addEventListener('click', contratar);
}

function contratar(e) {
    e.preventDefault();

    let cdAnuncio = document.querySelector("#identificadorAnuncio").getAttribute('value');
    let emailCandidato = this.parentNode.parentNode.querySelector("#identificadorCandidato").getAttribute('value');

    fetch('../lib/ContratarAutonomo.aspx?type=public&ec=' + emailCandidato + '&cd=' + cdAnuncio).then(function (resposta) {
        return resposta.json();
    }).then(function (dados) {
        if (dados != null) {
            if (dados.situacao == "ok") {
                window.location = "chatCliente.aspx";
            }
            else {
                window.location = "painelCliente.aspx";
            }
        }
    });
}