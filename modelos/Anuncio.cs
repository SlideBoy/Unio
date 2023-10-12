using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Anuncio : Banco
    {
        #region Propriedades do Anuncio
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private Prazo _prazo;
        public Prazo Prazo
        {
            get { return _prazo; }
            set { _prazo = value; }
        }

        private AreaAtuacao _areaAtuacao;
        public AreaAtuacao AreaAtuacao
        {
            get { return _areaAtuacao; }
            set { _areaAtuacao = value; }
        }

        private EstadoAnuncio _estado;
        public EstadoAnuncio Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private DateTime _dataPublicacao;
        public DateTime DataPublicacao
        {
            get { return _dataPublicacao; }
            set { _dataPublicacao = value; }
        }

        private DateTime _horaPublicacao;
        public DateTime HoraPublicacao
        {
            get { return _horaPublicacao; }
            set { _horaPublicacao = value; }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private bool _oculto;
        public bool Oculto
        {
            get { return _oculto; }
            set { _oculto = value; }
        }

        private List<Autonomo> _destinatarios;
        public List<Autonomo> Destinatarios
        {
            get { return _destinatarios; }
            set { _destinatarios = value; }
        }

        //private List<Autonomo> _candidatados;
        //public List<Autonomo> Candidatados
        //{
        //    get { return _candidatados; }
        //    set { _candidatados = value; }
        //}

        #endregion

        #region Construtor do Anuncio
        public Anuncio(Cliente cliente, int codigo, Prazo prazo, DateTime dataPublicacao, DateTime horaPublicacao, string titulo, string descricao, bool oculto, AreaAtuacao areaAtuacao, EstadoAnuncio estado, List<Autonomo> Destinatarios) 
        {
            this.Cliente = cliente;
            this.Codigo = codigo;
            this.Prazo = prazo;
            this.DataPublicacao = dataPublicacao;
            this.HoraPublicacao = horaPublicacao;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Oculto = oculto;
            this.AreaAtuacao = areaAtuacao;
            this.Estado = estado;
            this.Destinatarios = Destinatarios;
        }

        public Anuncio() { }
        #endregion

        public void CriarNovoAnuncio()
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", this.Cliente.Email));
            parametros.Add(new Parametro("vTitulo", this.Titulo));
            parametros.Add(new Parametro("vDescricao", this.Descricao));
            parametros.Add(new Parametro("vAreaAtuacao", this.AreaAtuacao.Codigo.ToString()));
            parametros.Add(new Parametro("vPrazo", this.Prazo.Codigo.ToString()));

            Executar("CriarAnuncio", parametros);

            parametros.Clear();

            Conectar();

            if (this.Destinatarios != null)
            {
                foreach (Autonomo destinatario in this.Destinatarios)
                {
                    parametros.Clear();

                    parametros.Add(new Parametro("vEmailAutonomo", destinatario.Email));
                    parametros.Add(new Parametro("vEmailCliente", this.Cliente.Email));

                    Executar("PublicarAnuncio", parametros);

                    Conectar();
                }

                Desconectar();
            }
            else
            {
                parametros.Add(new Parametro("vAreaAtuacao", this.AreaAtuacao.Codigo.ToString()));

                List<String> emails = new List<String>();

                using (MySqlDataReader dados = Consultar("BuscarAutonomoAreaAtuacao", parametros))
                {
                    while (dados.Read())
                    {
                        emails.Add(dados.GetString(0));
                    }
                }

                foreach (String email in emails)
                {
                    parametros.Clear();

                    parametros.Add(new Parametro("vEmailAutonomo", email));
                    parametros.Add(new Parametro("vEmailCliente", this.Cliente.Email));

                    Executar("PublicarAnuncio", parametros);

                    Conectar();
                }

                Desconectar();
            }
        }

        public void EditarAnuncio(int codigo, string titulo, string descricao, int codigoPrazo, int codigoArea ) 
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            parametros.Add(new Parametro("vTitulo", titulo));
            parametros.Add(new Parametro("vDescricao", descricao));
            parametros.Add(new Parametro("vPrazo", codigoPrazo.ToString()));
            parametros.Add(new Parametro("vArea", codigoArea.ToString()));

            Executar("EditarAnuncio", parametros);
        }

        public void ConcluirAnuncio(int codigo)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            Executar("ConcluirAnuncio", parametros);
        }

        public void CancelarAnuncio(int codigo)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigo", codigo.ToString()));
            Executar("CancelarAnuncio", parametros);
        }
    }
}