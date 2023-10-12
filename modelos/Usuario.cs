using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Usuario : Banco
    {
        #region prop Usuario
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value.Length <= 200)
                {
                    _nome = value;
                }
                else
                {
                    return;
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length <= 50)
                {
                    _email = value;
                }
                else
                {
                    return;
                }
            }
        }

        private String _cpf;
        public String CPF
        {
            get { return _cpf; }
            set
            {
                if (value.Length <= 15)
                {
                    _cpf = value;
                }
                else
                {
                    return;
                }
            }
        }

        private string _telefone;
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                if (value.Length <= 16)
                {
                    _telefone = value;
                }
                else
                {
                    return;
                }
            }
        }

        private byte[] _foto;
        public byte[] Foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
            }
        }

        private Cidade _cidade;
        public Cidade Cidade
        {
            get { return _cidade; }
            set
            {
                _cidade = value;
            }
        }

        private Estado _estado;
        public Estado Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
            }
        }

        public Usuario() { }
        #endregion

        //TODO: Sobrescrever esse metodo nas classes das filhas para ela serem menos genericas, autonomo carregar um autonomo e cliente um cliente
        public Tuple<Autonomo, Cliente> CarregarUsuario(string email, string senha)
        {
            try
            {

                Conectar();

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vEmail", email));
                parametros.Add(new Parametro("vSenha", senha));

                MySqlDataReader dados = Consultar("buscarUsuario", parametros);
                if (dados != null)
                    if (dados.Read())
                    {
                        string resposta = dados.GetString(0);

                        if (resposta == "autonomo")
                        {
                            Autonomo autonomo = CarregarDadosAutonomo(dados);
                            return new Tuple<Autonomo, Cliente>(autonomo, null);
                        }

                        if (dados.GetString(0) == "cliente")
                        {
                            Cliente cliente = CarregarDadosCliente(dados);
                            return new Tuple<Autonomo, Cliente>(null, cliente);

                        }
                    }
            }

            catch
            {
                return new Tuple<Autonomo, Cliente>(null, null);
            }
            return new Tuple<Autonomo, Cliente>(null, null);
        }

        private Cliente CarregarDadosCliente(MySqlDataReader dados)
        {
            #region Cidade
            Cidade cidade = new Cidade();
            cidade.Codigo = dados.GetInt16(6);
            cidade.Nome = dados.GetString(5);
            #endregion

            Cliente cliente = new Cliente(
                dados.GetString(1),
                dados.GetString(2),
                dados.GetString(3),
                dados.GetString(4),
                cidade,
                (byte[]) dados[7]
            );

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return cliente;
        }

        private Autonomo CarregarDadosAutonomo(MySqlDataReader dados)
        {
            #region Cidade
            Cidade cidade = new Cidade();
            cidade.Codigo = dados.GetInt16(5);
            cidade.Nome = dados.GetString(6);
            #endregion

            #region Estado
            Estado estado = new Estado();
            estado.Sigla = dados.GetString(9);
            estado.Nome = dados.GetString(10);
            #endregion

            string[] NomeformaPagamento = dados.GetString(11).Split(',');
            string[] CodigoformaPagamento = dados.GetString(12).Split(',');

            List<FormaPagamento> FormasPagamento = new List<FormaPagamento>();

            for (int i = 0; i < NomeformaPagamento.Length; i++)
            {
                FormaPagamento formaPagamento = new FormaPagamento();

                formaPagamento.Nome = NomeformaPagamento[i];
                formaPagamento.Codigo = int.Parse(CodigoformaPagamento[i]);

                FormasPagamento.Add(formaPagamento);
            }

            string[] NomeProfissao = dados.GetString(13).Split(',');
            string[] CodigoProfissao = dados.GetString(14).Split(',');
            string[] NomeAreaAtuacao = dados.GetString(15).Split(',');
            string[] CodigoAreaAtuacao = dados.GetString(16).Split(',');

            List<AreaAtuacao> AreasAtuacoes = new List<AreaAtuacao>();
            List<Profissao> Profissoes = new List<Profissao>();

            for (int i = 0; i < NomeProfissao.Length; i++)
            {
                AreaAtuacao areaAtuacao = new AreaAtuacao(int.Parse(CodigoAreaAtuacao[i]), NomeAreaAtuacao[i]);
                Profissao profissao = new Profissao(int.Parse(CodigoProfissao[i]), NomeProfissao[i], areaAtuacao);
                AreasAtuacoes.Add(areaAtuacao);
                Profissoes.Add(profissao);
            }

            Emblema emblema = new Emblema();
            emblema.Nome = dados.GetString(19);
            emblema.Codigo = dados.GetInt32(18);

            Autonomo autonomo = new Autonomo();
            autonomo.Email = dados.GetString(1);
            autonomo.Nome = dados.GetString(2);
            autonomo.CPF = dados.GetString(3);
            autonomo.Telefone = dados.GetString(4);
            autonomo.Cidade = cidade;
            autonomo.Comentario = dados.GetString(7);
            autonomo.Congelado = dados.GetBoolean(8);
            autonomo.Estado = estado;
            autonomo.FormasPagamento = FormasPagamento;
            autonomo.Profissoes = Profissoes;
            autonomo.Emblema = emblema;
            autonomo.Foto = (byte[]) dados[20];

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return autonomo;
        }

        public void cadastrarUsuario(string[] dadosBasicos, string[] dadosAdicionais)
        {

            Conectar();

            List<Parametro> parametros = new List<Parametro>();

            if (this.GetType() == new Autonomo().GetType())
            {
                parametros.Add(new Parametro("vEmail", dadosBasicos[0]));
                parametros.Add(new Parametro("vCPF", dadosBasicos[1]));
                parametros.Add(new Parametro("vNome", dadosBasicos[2]));
                parametros.Add(new Parametro("vSenha", dadosBasicos[3]));
                parametros.Add(new Parametro("vTelefone", dadosBasicos[4]));
                parametros.Add(new Parametro("vFoto", dadosBasicos[5]));
                parametros.Add(new Parametro("vDescricao", dadosBasicos[6]));
                parametros.Add(new Parametro("vCidade", dadosBasicos[7]));

                Executar("cadastrarAutonomo", parametros);
                parametros.Clear();

                Conectar();
                parametros.Add(new Parametro("vEmail", dadosBasicos[0]));
                parametros.Add(new Parametro("vProfissao", dadosAdicionais[0]));

                Executar("cadastrarProfissaoAutonomo", parametros);

                string[] tipoAtendimento = dadosAdicionais[1].Split(',');

                foreach (string item in tipoAtendimento)
                {
                    Conectar();
                    parametros.Clear();

                    parametros.Add(new Parametro("vEmail", dadosBasicos[0]));
                    parametros.Add(new Parametro("vProfissao", dadosAdicionais[0]));
                    parametros.Add(new Parametro("vFormaAtendimento", item));

                    Executar("cadastrarAtendimentoAutonomo", parametros);
                }

                string[] formaPagamento = dadosAdicionais[2].Split(',');

                foreach (string item in formaPagamento)
                {
                    Conectar();
                    
                    parametros.Clear();

                    parametros.Add(new Parametro("vEmail", dadosBasicos[0]));
                    parametros.Add(new Parametro("vFormaPagamento", item));

                    Executar("cadastrarPagamentoAutonomo", parametros);
                }
            }
            if (this.GetType() == new Cliente().GetType())
            {
                Conectar();
                parametros.Add(new Parametro("vEmail", dadosBasicos[0]));
                parametros.Add(new Parametro("vCPF", dadosBasicos[1]));
                parametros.Add(new Parametro("vNome", dadosBasicos[2]));
                parametros.Add(new Parametro("vSenha", dadosBasicos[3]));
                parametros.Add(new Parametro("vTelefone", dadosBasicos[4]));
                parametros.Add(new Parametro("vFoto", dadosBasicos[5]));
                parametros.Add(new Parametro("vCidade", dadosBasicos[6]));

                Executar("cadastrarCliente", parametros);
            }
        }

        public bool ValidarUsuario(string email, string cpf)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();

            parametros.Add(new Parametro("vEmail", email));
            parametros.Add(new Parametro("vCPF", cpf));

            MySqlDataReader dados = Consultar("validarUsuario", parametros);
            if (dados.Read())
            {
                if(dados.GetString(0) == "ok")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return false;
        }
    } 
}