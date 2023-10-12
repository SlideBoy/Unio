using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Proposta : Anuncio
    {

        #region Propriedades do Anuncio
        private Autonomo _autonomo;
        public Autonomo Autonomo
        {
            get { return _autonomo; }
            set { _autonomo = value; }
        }

        private DateTime _dataProposta;
        public DateTime DataProposta
        {
            get { return _dataProposta; }
            set { _dataProposta = value; }
        }

        private DateTime _horaProposta;
        public DateTime HoraProposta
        {
            get { return _horaProposta; }
            set { _horaProposta = value; }
        }

        private bool _escolhido;
        public bool Escolhido
        {
            get { return _escolhido; }
            set { _escolhido = value; }
        }

        private bool _finalizado;
        public bool Finalizado
        {
            get { return _finalizado; }
            set { _finalizado = value; }
        }

        //private byte[] _foto;
        //public byte[] Foto
        //{
        //get { return _foto; }
        //set
        //{
        //    _foto = value;
        //}}

        #endregion

        #region Construtor do Anuncio
        public Proposta(Cliente cliente, int codigo, Prazo prazo, DateTime dataPublicacao, DateTime horaPublicacao, string titulo, string descricao, bool oculto, AreaAtuacao areaAtuacao, EstadoAnuncio estado, Autonomo autonomo, DateTime dataProposta, DateTime horaProposta, bool escolhido, bool finalizado) : base(cliente, codigo, prazo, dataPublicacao, horaPublicacao, titulo, descricao, oculto, areaAtuacao, estado, null)
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
            this.Autonomo = autonomo;
            this.DataProposta = dataProposta;
            this.HoraProposta = horaProposta;
            this.Escolhido = escolhido;
            this.Finalizado = finalizado;
        }

        public Proposta()
        {

        }

        #endregion


        public bool AdicionarCandidato(string emailCandidato, string emailCliente, string codigoAnuncio)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vAnuncio", codigoAnuncio));
            parametros.Add(new Parametro("vEmailAutonomo", emailCandidato));
            parametros.Add(new Parametro("vEmailCliente", emailCliente));

            bool retorno = false;
            try
            {
                Executar("CandidatarAutonomo", parametros);
                retorno = true;
            }
            catch 
            {
                retorno = false;
            }

            return retorno;
        }

        public bool RemoverCandidato(string emailCandidato, string emailCliente, string codigoAnuncio)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vAnuncio", codigoAnuncio));
            parametros.Add(new Parametro("vEmailAutonomo", emailCandidato));
            parametros.Add(new Parametro("vEmailCliente", emailCliente));

            bool retorno = false;
            try
            {
                Executar("RemoverCandidatura", parametros);
                retorno = true;
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }

        public Boolean VerificarCandidatura(string email)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailAutonomo", email));
            parametros.Add(new Parametro("vCodigoAnuncio", this.Codigo.ToString()));

            Boolean retorno = false;

            using (MySqlDataReader dados = Consultar("VerificarCandidatura", parametros))
            {
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        if (dados.GetString(0) == "OK")
                        {
                            retorno = true;
                        }
                    }
                }
            }

            Desconectar();

            return retorno;
        }

        public bool ContratarAutonomo(string emailCandidato, string codigoAnuncio) {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailAutonomo", emailCandidato));
            parametros.Add(new Parametro("vCodigoAnuncio", codigoAnuncio));
            bool retorno = false;
            try
            {
                Executar("contratarAutonomo", parametros);
                retorno = true;
            }
            catch
            {
                retorno = false;
            }

            return retorno;
        }

        public int VerificarAnuncioContratado(string emailA, string emailC)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailA", emailA));
            parametros.Add(new Parametro("vEmailC", emailC));

            int r = 0;
            using (MySqlDataReader dados = Consultar("VerificarAnuncioContrato", parametros))
            {
                if (dados.Read())
                {
                    r = dados.GetInt32(0);
                }
            }

            Desconectar();

            return r;
        }
    }
}