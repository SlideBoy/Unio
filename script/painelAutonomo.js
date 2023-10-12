let progresso = document.querySelector(".emblema .progresso");
let barraProgresso = document.querySelector(".emblema .barra div");

let progressoEstrelas = document.querySelector(".progressoAutonomo .progresso");
let barraProgressoEstrelas = document.querySelector(".avaliacao .barra div");

/*--------------------------------------------Eventos------------------------------------------------------*/

// document.addEventListener("DOMContentLoaded", progressoAutonomo)

/*--------------------------------------------Funções------------------------------------------------------*/

window.onload = function progressoAutonomo(){
    let porcentagemProgresso = 0;
    let porcentagemEstrelas = 0;

    let valor = progresso.getAttribute('valor');
    let valorMedia = progressoEstrelas.getAttribute('valor');


    if(valor < 100){
        porcentagemProgresso = ((valor/100)*100);
    }
    if(valor >= 100 && valor < 200){
        porcentagemProgresso = ((valor/200)*100);
    }
    if(valor >= 200){
        porcentagemProgresso = ((valor/300)*100);
    }
    barraProgresso.setAttribute("style", "width: " + porcentagemProgresso + "%");

    porcentagemEstrelas = ((valorMedia/5)*100);
    barraProgressoEstrelas.setAttribute("style", "width: " + porcentagemEstrelas + "%");

}



