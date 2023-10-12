const IconAlerta = document.querySelector(".divInput figure img");
const Alerta = document.querySelector(".divAlert");

if(IconAlerta != null)IconAlerta.addEventListener('mouseover', acionarAlerta);
if(IconAlerta != null)IconAlerta.addEventListener('mouseout', removerAlerta);

function acionarAlerta(){
    Alerta.classList.remove("escondido");
}

function removerAlerta(){
    Alerta.classList.add("escondido");
}