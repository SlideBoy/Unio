using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class AreasAtuacao : Banco
    {
        public List<AreaAtuacao> CarregarAreasAtuacao()
        {
            Conectar();

            List<AreaAtuacao> areasAtuacao = new List<AreaAtuacao>();

            using(MySqlDataReader dados = Consultar("CarregarAreaAtuacao", null))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        AreaAtuacao area = new AreaAtuacao();
                        area.Codigo = dados.GetInt32(0);
                        area.Nome = dados.GetString(1);

                        areasAtuacao.Add(area);
                    }
                }
            }

            Desconectar();

            return areasAtuacao;
        }
    }
}