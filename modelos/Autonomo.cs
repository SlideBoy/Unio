using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Autonomo : Usuario
    {
        #region prop Autonomo
        private DateTime _registro;

        public DateTime Registro {

            get { return _registro; }
            set { _registro = value; }

        }

        private string _comentario;

        public string Comentario { 
        
            get { return _comentario; }
            set { _comentario = value; }
        
        }

        private bool _congelado;
        
        public bool Congelado { 
            
            get { return _congelado; }
            set { _congelado = value; }
        
        }

        private List<Profissao> _profissoes;

        public List<Profissao> Profissoes
        {

            get { return _profissoes; }
            set { _profissoes = value; }

        }

        private List<FormaPagamento> _formasPagamento;
        public List<FormaPagamento> FormasPagamento
        {

            get { return _formasPagamento; }
            set { _formasPagamento = value; }

        }

        private Emblema _emblema;
        public Emblema Emblema
        {

            get { return _emblema; }
            set { _emblema = value; }

        }

        private double _avaliacao;
        public double Avaliacao
        {

            get { return _avaliacao; }
            set { _avaliacao = value; }

        }

        public Autonomo() { }
        //public Autonomo(string Email, string Nome, string CPF, string Telefone, Cidade Cidade, string Comentario, bool Congelado, Estado Estado, List<FormaPagamento> FormasPagamento, List<Profissao> Profissoes, Emblema Emblema) 
        //{ 
        //    this.Email  = Email;
        //    this.Nome = Nome;
        //    this.CPF = CPF;
        //    this.Telefone = Telefone;
        //    this.Cidade = Cidade;
        //    this.Comentario = Comentario;
        //    this.FormasPagamento = FormasPagamento;
        //    this.Profissoes = Profissoes;
        //    this.Emblema = Emblema;
        //}
        public Autonomo(string Email, string Nome, string CPF, string Telefone, Cidade Cidade, string Comentario, bool Congelado, DateTime registro, Estado Estado, List<FormaPagamento> FormasPagamento, List<Profissao> Profissoes, Emblema Emblema, byte[] Foto)
        {
            this.Email = Email;
            this.Nome = Nome;
            this.CPF = CPF;
            this.Telefone = Telefone;
            this.Cidade = Cidade;
            this.Comentario = Comentario;
            this.Congelado = Congelado;
            this.Registro = registro;
            this.FormasPagamento = FormasPagamento;
            this.Profissoes = Profissoes;
            this.Emblema = Emblema;
            this.Foto = Foto;
        }

        public Autonomo(string Email, string Nome, string CPF, string Telefone, Cidade Cidade, string Comentario, bool Congelado, DateTime registro, Estado Estado, List<FormaPagamento> FormasPagamento, List<Profissao> Profissoes, Emblema Emblema, byte[] Foto, double avaliacao)
        {
            this.Email = Email;
            this.Nome = Nome;
            this.CPF = CPF;
            this.Telefone = Telefone;
            this.Cidade = Cidade;
            this.Comentario = Comentario;
            this.Congelado = Congelado;
            this.Registro = registro;
            this.FormasPagamento = FormasPagamento;
            this.Profissoes = Profissoes;
            this.Emblema = Emblema;
            this.Foto = Foto;
            this.Avaliacao = avaliacao;
        }
        public Autonomo(DateTime registro, string comentario, bool congelado)
        {
            this._registro = registro;
            this._comentario = comentario;
            this._congelado = congelado;
        }
        #endregion

        public void PreencherDados()
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", this.Email));
            using (MySqlDataReader dados = Consultar("PreencherDados", parametros))
            {
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        Estado estado = new Estado();
                        estado.Nome = dados.GetString(9);
                        estado.Sigla = dados.GetString(8);

                        Cidade cidade = new Cidade();
                        cidade.Codigo = dados.GetInt32(4);
                        cidade.Nome = dados.GetString(5);

                        string[] codigoFormaPagamento = dados.GetString(11).Split(',');
                        string[] nomeFormaPagamento = dados.GetString(10).Split(',');

                        List<FormaPagamento> formasPagamento = new List<FormaPagamento>();

                        for (int i = 0; i < codigoFormaPagamento.Length; i++)
                        {
                            FormaPagamento formaPagamento = new FormaPagamento();

                            formaPagamento.Codigo = int.Parse(codigoFormaPagamento[i]);
                            formaPagamento.Nome = nomeFormaPagamento[i];

                            formasPagamento.Add(formaPagamento);
                        }

                        string[] codigoProfissao = dados.GetString(13).Split(',');
                        string[] nomeProfissao = dados.GetString(12).Split(',');

                        string[] codigoAreaAtuacao = dados.GetString(15).Split(',');
                        string[] nomeAreaAtuacao = dados.GetString(14).Split(',');


                        List<Profissao> profissoes = new List<Profissao>();

                        for (int i = 0; i < codigoProfissao.Length; i++)
                        {
                            AreaAtuacao areaAtuacao = new AreaAtuacao();

                            areaAtuacao.Codigo = int.Parse(codigoAreaAtuacao[i]);
                            areaAtuacao.Nome = nomeAreaAtuacao[i];

                            Profissao profissao = new Profissao();

                            profissao.Codigo = int.Parse(codigoProfissao[i]);
                            profissao.Nome = nomeProfissao[i];
                            profissao.areaAtuacao = areaAtuacao;

                            profissoes.Add(profissao);
                        }

                        Emblema emblema = new Emblema();
                        emblema.Codigo = dados.GetInt32(17);
                        emblema.Nome = dados.GetString(18);

                        this.Nome = dados.GetString(1);
                        this.CPF = dados.GetString(2);
                        this.Telefone = dados.GetString(3);
                        this.Cidade = cidade;
                        this.Registro = dados.GetDateTime(19);
                        //this.Registro = DateTime.Parse("2023-09-08 22:55:52");
                        this.Comentario = dados.GetString(6);
                        //this.Comentario = "Cavalo";
                        this.Congelado = dados.GetBoolean(7);
                        this.Profissoes = profissoes;
                        this.FormasPagamento = formasPagamento;
                        this.Estado = estado;
                        this.Emblema = emblema;
                        this.Foto = (byte[])dados[20];
                    }
                }
            }
        }
    }
}