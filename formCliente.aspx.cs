using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Unio.modelos;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

namespace Unio
{
    public partial class formCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            }
        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            // #region Validações

            // lblMsgErro.Visible = false;

            // if (inputNome.Text == null || inputNome.Text == "") {
            //     inputNome.Focus();
            //     lblMsgErro.Text = "O campo \"Nome Completo\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputEmail.Text == null || inputEmail.Text == "")
            // {
            //     inputEmail.Focus();
            //     lblMsgErro.Text = "O campo \"E-mail\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // string regexPattern = @"^[a-zA-Z0-9._%+-]+@+[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // if (!Regex.IsMatch(inputEmail.Text, regexPattern))
            // {
            //     inputEmail.Focus();
            //     lblMsgErro.Text = "E-mail inválido.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputSenha.Text == null || inputSenha.Text == "")
            // {
            //     lblMsgErro.Text = "O campo \"Senha\" não pode ser vazio.";
            //     inputSenha.Focus();
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // regexPattern = @"^(?=.*[A-Za-z]).{8}$";

            // if (!Regex.IsMatch(inputSenha.Text, regexPattern))
            // {
            //     lblMsgErro.Text = "O campo \"Senha\" deve conter no mínimo 8 caracteres com pelo menos uma letra.";
            //     inputSenha.Focus();
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputSenhaConfirmacao.Text == null || inputSenhaConfirmacao.Text == "")
            // {
            //     inputSenhaConfirmacao.Focus();
            //     lblMsgErro.Text = "A confirmação da senha não pode ser vazia.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputSenha.Text != inputSenhaConfirmacao.Text) 
            // {
            //     inputSenhaConfirmacao.Focus();
            //     lblMsgErro.Text = "As senhas devem ser idênticas.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputTelefone.Text == null || inputTelefone.Text == "")
            // {
            //     inputTelefone.Focus();
            //     lblMsgErro.Text = "o Campo \"Celular\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // regexPattern = @"^\d{11}$";

            // if (!Regex.IsMatch(inputTelefone.Text, regexPattern))
            // {
            //     inputTelefone.Focus();
            //     lblMsgErro.Text = "Telefone inválido.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (ddlEstado.SelectedIndex == 0)
            // {
            //     ddlEstado.Focus();
            //     lblMsgErro.Text = "o Campo \"Estado\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (ddlCidade.SelectedValue == null || ddlCidade.SelectedValue == "")
            // {
            //     ddlCidade.Focus();
            //     lblMsgErro.Text = "o Campo \"Cidade\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (ddlCidade.SelectedIndex == 0)
            // {
            //     ddlCidade.Focus();
            //     lblMsgErro.Text = "o Campo \"Cidade\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // if (inputCPF.Text == null || inputCPF.Text == "")
            // {
            //     inputCPF.Focus();
            //     lblMsgErro.Text = "o Campo \"CPF\" não pode ser vazio.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            // regexPattern = @"^\d{11}$";

            // if (!Regex.IsMatch(inputCPF.Text, regexPattern))
            // {
            //     inputCPF.Focus();
            //     lblMsgErro.Text = "CPF inválido.";
            //     lblMsgErro.Visible = true;
            //     return;
            // }

            
            // #endregion
            // Cliente cliente = new Cliente();
            // string[] dadosCliente = { inputEmail.Text, inputCPF.Text, inputNome.Text, inputSenha.Text, inputTelefone.Text, null, ddlEstado.Text };
            // bool retorno = cliente.CadastrarCliente(dadosCliente);

            // if (retorno)
            // {
            //     lblMsgErro.Text = "CPF ou Email inseridos já cadastrados em nosso sistema!";
            //     lblMsgErro.Visible = true;
            // }

        }
    }
}