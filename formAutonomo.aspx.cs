using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Unio.modelos;
using static System.Net.Mime.MediaTypeNames;

namespace Unio
{
    public partial class formAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Estados

                Estados estados = new Estados();
                List<Estado> listEstados = new List<Estado>();
                listEstados = estados.CarregarEstados();

                ddlEstado.Items.Add(new ListItem("-- Selecione --", "-1"));

                for (int i = 0; i < listEstados.Count; i++)
                {
                    string sigla = listEstados[i].Sigla.ToString();
                    string nome = listEstados[i].Nome;
                    ddlEstado.Items.Add(new ListItem(nome, sigla));
                }

                #endregion

                ddlCidade.Items.Add(new ListItem("-- Selecione o estado --", "-1"));

                #region Profissoes
                Profissoes profissoes = new Profissoes();
                List<Profissao> listProfissoes = new List<Profissao>();
                listProfissoes = profissoes.carregarProfissoes();

                ddlProfissao.Items.Add(new ListItem("-- Selecione --", "-1"));

                for (int i = 0; i < listProfissoes.Count; i++)
                {
                    string codigo = listProfissoes[i].Codigo.ToString();
                    string nome = listProfissoes[i].Nome;
                    ddlProfissao.Items.Add(new ListItem(nome, codigo));
                }
                #endregion

                FormasPagamento formasPagamento = new FormasPagamento();
                List<FormaPagamento> listFormaPagamentos = new List<FormaPagamento>();
                listFormaPagamentos = formasPagamento.CarregarFormasPagamento();



                foreach (FormaPagamento item in listFormaPagamentos)
                {
                    string codigo = item.Codigo.ToString();
                    string nome = item.Nome;
                    //nome = System.Text.RegularExpressions.Regex.Replace(nome, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
                    nome = $"<p> {nome} </p>";
                    Panel div = new Panel();


                    tbChkFormaPagamento.Items.Add(new ListItem(nome, codigo));
                }

                FormasTrabalho formasTrabalho = new FormasTrabalho();
                List<FormaTrabalho> listFormatrabalho = new List<FormaTrabalho>();
                listFormatrabalho = formasTrabalho.CarregarTipoAtendimentos();

                foreach (FormaTrabalho item in listFormatrabalho)
                {
                    string codigo = item.Codigo.ToString();
                    string nome = item.Nome;

                    nome = $"<p> {nome} </p>";

                    tbChkFormaAtendimento.Items.Add(new ListItem(nome, codigo));
                }
            }
        }


        protected void btnCriarPerfil_Click(object sender, EventArgs e)
        {
            // Autonomo autonomo = new Autonomo();
            // string profissao = ddlProfissao.SelectedValue;

            // string pagamentosConcat = "";
            // for (int i = 0; i < tbChkFormaPagamento.Items.Count; i++)
            // {
            //     ListItem box = tbChkFormaPagamento.Items[i];
            //     if (box.Selected)
            //     {
            //         pagamentosConcat += $"{box.Value},";
            //     }
            // }
            // pagamentosConcat = pagamentosConcat.TrimEnd(',');

            // string atendimentoConcat = "";
            // for (int i = 0; i < tbChkFormaAtendimento.Items.Count; i++)
            // {
            //     ListItem box = tbChkFormaAtendimento.Items[i];
            //     if (box.Selected)
            //     {
            //         atendimentoConcat += $"{box.Value},";
            //     }
            // }
            // atendimentoConcat = atendimentoConcat.TrimEnd(',');

            // string[] dadosAdicionais = { profissao, atendimentoConcat, pagamentosConcat };
            

            // string[] dadosBasicos = { inputEmail.Text, inputCPF.Text, inputNome.Text, inputSenha.Text, inputTelefone.Text, "", txtDescricaoProfissao.Text, ddlCidade.SelectedValue.ToString() };
            // bool retorno = autonomo.ValidarUsuario(dadosBasicos[0], dadosBasicos[1]);

            // if (retorno)
            // {
            //     lblMsgErro.Text = "CPF ou Email inseridos já cadastrados em nosso sistema!";
            //     lblMsgErro.Visible = true;

            //     return;
            // }

            // autonomo.cadastrarUsuario(dadosBasicos, dadosAdicionais);

            //bool retorno = autonomo.CadastrarAutonomo(dadosAutonomo);

            //if (retorno)
            //{
            //    lblMsgErro.Text = "CPF ou Email inseridos já cadastrados em nosso sistema!";
            //    lblMsgErro.Visible = true;
            //}
        }
    }
}