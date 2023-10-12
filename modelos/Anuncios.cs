using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Anuncios : Banco
    {
        public List<Anuncio> CarregarAnuncios(string emailAutonomo)
        {

            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailAutonomo));

            List<Anuncio> anuncios = new List<Anuncio>();
            using (MySqlDataReader dados = Consultar("CarregarAnuncios", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        #region Cidade
                        Cidade cidade = new Cidade();
                        cidade.Codigo = dados.GetInt16(4);
                        cidade.Nome = dados.GetString(5);
                        #endregion

                        Cliente cliente = new Cliente(dados.GetString(0), dados.GetString(1), dados.GetString(2), dados.GetString(3), cidade, null);

                        #region Prazo
                        Prazo prazo = new Prazo();
                        prazo.Codigo = dados.GetInt16(16);
                        prazo.Nome = dados.GetString(17);
                        #endregion

                        #region Área de Atuação
                        AreaAtuacao areaAtuacao = new AreaAtuacao();
                        areaAtuacao.Codigo = dados.GetInt16(12);
                        areaAtuacao.Nome = dados.GetString(13);
                        #endregion

                        #region Estado do Anúncio
                        EstadoAnuncio estadoAnuncio = new EstadoAnuncio();
                        estadoAnuncio.Codigo = dados.GetInt16(14);
                        estadoAnuncio.Nome = dados.GetString(15);
                        #endregion

                        #region Candidatos
                        //string[] emailCandidatos = dados.GetString(18).Split(',');
                        List<Autonomo> Candidatos = new List<Autonomo>();
                        //foreach (string email in emailCandidatos)
                        //{
                        //    Autonomo autonomo = new Autonomo();
                        //    autonomo.Email = email;

                        //    Candidatos.Add(autonomo);
                        //}
                        #endregion

                        DateTime dateTime = DateTime.Now;
                        Anuncio anuncio = new Anuncio(cliente, dados.GetInt32(6), prazo, dateTime /*dados.GetDateTime(7)*/, dateTime /*dados.GetDateTime(8)*/, dados.GetString(9), dados.GetString(10), dados.GetBoolean(11), areaAtuacao, estadoAnuncio, Candidatos/*, (byte[]) dados[18]*/);

                        anuncios.Add(anuncio);
                    }
                }
            }

            Desconectar();

            return anuncios;
        }

        public List<Anuncio> CarregarAnunciosCliente(string emailCliente)
        {

            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailCliente));

            List<Anuncio> anuncios = new List<Anuncio>();
            using (MySqlDataReader dados = Consultar("CarregarAnunciosCliente", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        #region Cidade
                        Cidade cidade = new Cidade();
                        cidade.Codigo = dados.GetInt16(4);
                        cidade.Nome = dados.GetString(5);
                        #endregion

                        Cliente cliente = new Cliente(dados.GetString(0), dados.GetString(1), dados.GetString(2), dados.GetString(3), cidade, null);

                        #region Prazo
                        Prazo prazo = new Prazo();
                        prazo.Codigo = dados.GetInt16(16);
                        prazo.Nome = dados.GetString(17);
                        #endregion

                        #region Área de Atuação
                        AreaAtuacao areaAtuacao = new AreaAtuacao();
                        areaAtuacao.Codigo = dados.GetInt16(12);
                        areaAtuacao.Nome = dados.GetString(13);
                        #endregion

                        #region Estado do Anúncio
                        EstadoAnuncio estadoAnuncio = new EstadoAnuncio();
                        estadoAnuncio.Codigo = dados.GetInt16(14);
                        estadoAnuncio.Nome = dados.GetString(15);
                        #endregion

                        #region Candidatos
                        //string[] emailCandidatos = dados.GetString(18).Split(',');
                        List<Autonomo> Candidatos = new List<Autonomo>();
                        //foreach (string email in emailCandidatos)
                        //{
                        //    Autonomo autonomo = new Autonomo();
                        //    autonomo.Email = email;

                        //    Candidatos.Add(autonomo);
                        //}
                        #endregion

                        DateTime dateTime = DateTime.Now;
                        Anuncio anuncio = new Anuncio(cliente, dados.GetInt32(6), prazo, dateTime /*dados.GetDateTime(7)*/, dateTime /*dados.GetDateTime(8)*/, dados.GetString(9), dados.GetString(10), dados.GetBoolean(11), areaAtuacao, estadoAnuncio, Candidatos/*, (byte[]) dados[18]*/);

                        anuncios.Add(anuncio);
                    }
                }
            }

            Desconectar();

            return anuncios;
        }

        public List<Anuncio> CarregarAnunciosComFiltro(string emailCliente, string filtro)
        {
            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailCliente));
            parametros.Add(new Parametro("vBusca", filtro));

            List<Anuncio> anuncios = new List<Anuncio>();
            using (MySqlDataReader dados = Consultar("CarregarAnunciosComFiltro", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        #region Cidade
                        Cidade cidade = new Cidade();
                        cidade.Codigo = dados.GetInt16(4);
                        cidade.Nome = dados.GetString(5);
                        #endregion

                        Cliente cliente = new Cliente(dados.GetString(0), dados.GetString(1), dados.GetString(2), dados.GetString(3), cidade, (byte[])dados[18]);

                        #region Prazo
                        Prazo prazo = new Prazo();
                        prazo.Codigo = dados.GetInt16(16);
                        prazo.Nome = dados.GetString(17);
                        #endregion

                        #region Área de Atuação
                        AreaAtuacao areaAtuacao = new AreaAtuacao();
                        areaAtuacao.Codigo = dados.GetInt16(12);
                        areaAtuacao.Nome = dados.GetString(13);
                        #endregion

                        #region Estado do Anúncio
                        EstadoAnuncio estadoAnuncio = new EstadoAnuncio();
                        estadoAnuncio.Codigo = dados.GetInt16(14);
                        estadoAnuncio.Nome = dados.GetString(15);
                        #endregion

                        #region Candidatos
                        //string[] emailCandidatos = dados.GetString(18).Split(',');
                        List<Autonomo> Candidatos = new List<Autonomo>();
                        //foreach (string email in emailCandidatos)
                        //{
                        //    Autonomo autonomo = new Autonomo();
                        //    autonomo.Email = email;

                        //    Candidatos.Add(autonomo);
                        //}
                        #endregion

                        DateTime dateTime = DateTime.Now;
                        Anuncio anuncio = new Anuncio(cliente, dados.GetInt32(6), prazo, dateTime /*dados.GetDateTime(7)*/, dateTime /*dados.GetDateTime(8)*/, dados.GetString(9), dados.GetString(10), dados.GetBoolean(11), areaAtuacao, estadoAnuncio, Candidatos/*, (byte[]) dados[18]*/);

                        anuncios.Add(anuncio);
                    }
                }
            }
            Desconectar();

            return anuncios;

        }
    }
}