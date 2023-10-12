const iconNotificacao = document.querySelector("#sininho");
const Popup = document.querySelector(".popupNotificacao");
let indicativoPopupAberto = false;

let divNotificacao = document.querySelectorAll(".popupNotificacao div");

if(iconNotificacao!=null)iconNotificacao.addEventListener('click', abrirPopupNotificacao);
if(Popup!= null)Popup.addEventListener('mouseleave', fecharPopupNotificacao);

function abrirPopupNotificacao()
{
    if(indicativoPopupAberto == false)
    {
        Popup.classList.remove("escondido");
    }
    else{
        Popup.classList.add("escondido");
    }

    indicativoPopupAberto = !indicativoPopupAberto;
}

function fecharPopupNotificacao()
{
    Popup.classList.add("escondido");
    indicativoPopupAberto = false;
}

// function colorirDivs(){
//     for(indice = 0; indice<divNotificacao.length; indice++)
//     {
//         divNotificacao[indice].classList.remove("linhaImpar");
//     }
    
//     for(indice = 0; indice<divNotificacao.length; indice++)
//     {
        
//         if((indice+1) % 2 !=0)
//         {
//             divNotificacao[indice].classList.add("linhaImpar");
//         }
//     }
// }
