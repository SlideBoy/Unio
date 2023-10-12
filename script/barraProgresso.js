let tamanhoBarra = document.querySelector(".barra div").clientWidth;
const progresso = document.querySelector(".barra div");
const formulario = document.querySelector(".slides");
const bntContinuar = document.querySelector(".btnContinuar");
const btnCriarPerfil = document.querySelector(".btnCriarPerfil");
const btnRetornarForm = document.querySelector(".seta_voltar");

if(btnContinuar != null) btnContinuar.addEventListener('click', avancarFormulario);
if(btnContinuar != null) btnContinuar.addEventListener('click', avancarBarraProgresso);
if(btnCriarPerfil != null) btnCriarPerfil.addEventListener('click', avancarBarraProgresso);
if(btnRetornarForm != null) btnRetornarForm.addEventListener('click', retornarFormulario);

function avancarFormulario(e)
{
    e.preventDefault();

    formulario.setAttribute("style", "margin-left: -100%");

    btnContinuar.classList.add("escondido");

    btnCriarPerfil.classList.remove("escondido");

    btnRetornarForm.classList.remove("escondido");
}

function avancarBarraProgresso(e)
{
    if (this.id != "btnCriarPerfil") {
        e.preventDefault();
    }
   
    tamanhoBarra = tamanhoBarra + 50;
    progresso.setAttribute("style", "width: " + tamanhoBarra + "%");
}

function retornarFormulario(e)
{
    e.preventDefault();

    formulario.setAttribute("style", "margin-right: 100%");

    btnContinuar.classList.remove("escondido");

    btnCriarPerfil.classList.add("escondido");

    btnRetornarForm.classList.add("escondido");
    
    tamanhoBarra = tamanhoBarra - 50;
    progresso.setAttribute("style", "width: " + tamanhoBarra + "%");

}