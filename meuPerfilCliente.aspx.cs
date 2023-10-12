using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class meuPerfilCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }

            Cliente c = new Cliente();
            (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            arquivoImagem = "";
            foto = cliente.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            litInfosCliente.Text = $@"<div class='informacoes'>
                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                            <div class='info'>
                                                <h2>{cliente.Nome}</h2>
                                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {cliente.Cidade.Nome} </div>
                                            </div>                    
                                          </div>";
        }
    }
}