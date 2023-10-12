using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Avaliacoes : Banco
    {
        public List<Avaliacao> CarregarAvaliacoes(string emailAutonomo)
        {
            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailAutonomo));

            List<Avaliacao> listAvaliacoes = new List<Avaliacao>();
            using (MySqlDataReader dados = Consultar("CarregarAvaliacao", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        if (dados.GetString(0) == null) {
                            return null;
                        }
                        
                        Avaliacao avaliacao = new Avaliacao();
                        avaliacao.EmailAutonomo = emailAutonomo;
                        //avaliacao.Cliente.Email = dados.GetString(0);
                        avaliacao.Cliente.Nome = dados.GetString(1);
                        avaliacao.CodigoProfissao = dados.GetInt16(2);
                        avaliacao.Descricao = dados.GetString(3);
                        avaliacao.Media = dados.GetDouble(4);
                        avaliacao.Cliente.Foto = (byte[]) dados[5];
                        listAvaliacoes.Add(avaliacao);
                    }
                }
            }

            Desconectar();

            return listAvaliacoes;

        }
    }
}