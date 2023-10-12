using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class meuPerfilAutonomo : System.Web.UI.Page
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
            litImgPerfil1.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

            //if (!IsPostBack)
            //{
            //    string emailAutonomo = "";

            //    if (Session["email"] != null)
            //    {
            //        emailAutonomo = Session["email"].ToString();
            //    }

            //    Autonomo a = new Autonomo();
            //    (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(emailAutonomo, Session["senha"].ToString());

            //    string arquivoImagem = "";
            //    //byte[] foto = null;
            //    byte[] foto = autonomo.Foto;
            //    //if (foto != null)
            //    //{
            //    string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            //    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;
            //    //}
            //    //else
            //    //{
            //    //    arquivoImagem = "../imagens/perfil_generico.png";
            //    //}

            //    litInfosAutonomo.Text = $@"<div class='informacoes'>
            //                                    <img id='imgAutonomo' src='{arquivoImagem}' alt=''>

            //                                    <div class='progressoAutonomo'>
            //                                        <p class='progresso' valor='4'>4,0</p>
            //                                        <div class='avaliacaoProgresso'>
            //                                            <div class='barra'>
            //                                                <div></div>
            //                                            </div>
            //                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
            //                                        </div>
            //                                    </div>
            //                                    <div class='info'>
            //                                        <h2>{autonomo.Nome}</h2>";

            //    foreach (Profissao profissao in autonomo.Profissoes)
            //    {
            //        ddlProfissao.Items.Add(new ListItem(profissao.Nome, profissao.Codigo.ToString()));
            //    }

            //    ddlProfissao.SelectedIndex = 0;

            //    litInfosAutonomo2.Text = $@"<div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome}</div>
            //                                    </div>                    
            //                              </div>";
            //}
        }
    }
}