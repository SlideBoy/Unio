using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class criacaoAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }

            Cliente c = new Cliente();
            (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            string arquivoImagem = "";
            byte[] foto = cliente.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            //if (!IsPostBack)
            //{
            //    //TODO: pegarLogin pela sessão

            //    string login = "alexandre.souza@outlook.com";

            //    //Literal litIdentificador = new Literal();
            //    //litIdentificador.Text = $"<input type='hidden' id='indentificadorCliente' value='{login}'/>";

            //    Prazos prazos = new Prazos();
            //    List<Prazo> listPrazo = prazos.CarregarPrazos();

            //    selectPrazo.Items.Add(new ListItem("-- Selecione --", "-1"));

            //    foreach (Prazo item in listPrazo)
            //    {
            //        selectPrazo.Items.Add(new ListItem(item.Nome, item.Codigo.ToString()));
            //    }

            //    AreasAtuacao areas = new AreasAtuacao();
            //    List<AreaAtuacao> listAreas = areas.CarregarAreasAtuacao();

            //    ddlAreaAtuacao.Items.Add(new ListItem("-- Selecione --", "-1"));

            //    foreach (AreaAtuacao item in listAreas)
            //    {
            //        ddlAreaAtuacao.Items.Add(new ListItem(item.Nome, item.Codigo.ToString()));
            //    }
            //}
        }

        protected void btnPublicarAnuncio_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtTitulo.Text))
            //{
            //    lblMsg.Text = "Por favor preeencha o(s) campo(s) em branco!";
            //    return;
            //}

            //if (String.IsNullOrEmpty(txtDescricao.Text))
            //{
            //    lblMsg.Text = "Por favor preeencha o(s) campo(s) em branco!";
            //    return;
            //}

            //if (selectPrazo.SelectedValue == "-1")
            //{
            //    lblMsg.Text = "Por favor selecione um prazo!";
            //    return;
            //}

            //if (ddlAreaAtuacao.SelectedValue == "-1")
            //{
            //    lblMsg.Text = "Por favor selecione uma area!";
            //    return;
            //}

            //Cliente cliente = new Cliente();
            //cliente.Email = Session["email"].ToString();

            //AreaAtuacao area = new AreaAtuacao();
            //area.Codigo = ddlAreaAtuacao.SelectedIndex;
            //area.Nome = ddlAreaAtuacao.SelectedValue;

            //Prazo prazo = new Prazo();
            //prazo.Codigo = selectPrazo.SelectedIndex;
            //prazo.Nome = selectPrazo.SelectedValue;

            //Anuncio anuncio = new Anuncio();
            //anuncio.Cliente = cliente;
            //anuncio.Titulo = txtTitulo.Text;
            //anuncio.Descricao = txtDescricao.Text;
            //anuncio.AreaAtuacao = area;
            //anuncio.Prazo = prazo;
            //anuncio.Destinatarios = null;

            //anuncio.CriarNovoAnuncio();
            //Response.Redirect("painelCliente.aspx");
        }

        protected void btnAutoFavorito_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(txtTitulo.Text))
            //{
            //    lblMsg.Text = "Por favor preeencha o(s) campo(s) em branco!";
            //    return;
            //}

            //if (!String.IsNullOrEmpty(txtDescricao.Text))
            //{
            //    lblMsg.Text = "Por favor preeencha o(s) campo(s) em branco!";
            //    return;
            //}

            //if (selectPrazo.SelectedValue == "-1")
            //{
            //    lblMsg.Text = "Por favor selecione um prazo!";
            //    return;
            //}

            //if (ddlAreaAtuacao.SelectedValue == "-1")
            //{
            //    lblMsg.Text = "Por favor selecione uma area!";
            //    return;
            //}

            //Favoritos carregaFavoritos = new Favoritos();
            //Cliente cliente = new Cliente();
            //cliente.Email = Session["email"].ToString();
            //cliente.Favoritos = carregaFavoritos.CarregarFavoritos(cliente.Email);


            //AreaAtuacao area = new AreaAtuacao();
            //area.Codigo = ddlAreaAtuacao.SelectedIndex;
            //area.Nome = ddlAreaAtuacao.SelectedValue;

            //Prazo prazo = new Prazo();
            //prazo.Codigo = selectPrazo.SelectedIndex;
            //prazo.Nome = selectPrazo.SelectedValue;

            //Anuncio anuncio = new Anuncio();
            //anuncio.Cliente = cliente;
            //anuncio.Titulo = txtTitulo.Text;
            //anuncio.Descricao = txtDescricao.Text;
            //anuncio.AreaAtuacao = area;
            //anuncio.Prazo = prazo;
            //anuncio.Destinatarios = cliente.Favoritos;

            //anuncio.CriarNovoAnuncio();
        }
    }
}