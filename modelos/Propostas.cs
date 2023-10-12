using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Propostas : Banco
    {
        public List<Proposta> CarregarPropostas(string emailAutonomo, int codigoProfissao) {

            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailAutonomo));
            parametros.Add(new Parametro("vProfissao", codigoProfissao.ToString()));

            List<Proposta> propostas = new List<Proposta>();
            using (MySqlDataReader dados = Consultar("CarregarPropostas", parametros))
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

                        Cliente cliente = new Cliente(dados.GetString(0), dados.GetString(1), dados.GetString(2), dados.GetString(3), cidade, (byte[]) dados[21]);

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

                        DateTime dateTime = DateTime.Now;
                                                                                                                                                                                                                                    //TODO: Instanciar o autonomo pela sessão
                        Proposta proposta = new Proposta(cliente, dados.GetInt32(6), prazo, dateTime /*dados.GetDateTime(7)*/, dateTime /*dados.GetDateTime(8)*/, dados.GetString(9), dados.GetString(10), dados.GetBoolean(11), areaAtuacao, estadoAnuncio, null, dateTime /*dados.GetDateTime(18)*/, dateTime /*dados.GetDateTime(19)*/, dados.GetBoolean(20), true);

                        propostas.Add(proposta);

                    }
                
                } 
            }

            Desconectar();

            return propostas;

        }

        public List<Autonomo> CarregarCandidatos(string codigoAnuncio, string emailCliente)
        {
            List<Autonomo> listaCandidatos = new List<Autonomo>();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCodigoAnuncio", codigoAnuncio));
            parametros.Add(new Parametro("vEmail", emailCliente));

            Conectar();

            using (MySqlDataReader dados = Consultar("CarregarCandidatos", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Autonomo candidato = new Autonomo();
                        candidato.Email = dados.GetString(0);
                        candidato.PreencherDados();

                        listaCandidatos.Add(candidato);
                    }
                }
            }

            Desconectar();

            return listaCandidatos;
        }
    }
}