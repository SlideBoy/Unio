using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class propostasRecebidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginAutonomo = "alan.lima@outlook.com";
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            if (Session["login"] != null)
            {
                loginAutonomo = Session["email"].ToString();
            }

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(loginAutonomo, Session["senha"].ToString());

            foto = autonomo.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";
        }
    }
}