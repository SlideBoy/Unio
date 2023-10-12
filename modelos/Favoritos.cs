using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Favoritos : Banco
    {
       public List<Autonomo> CarregarFavoritos(string emailCliente)
        {
            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", emailCliente));

            List<Autonomo> listFavs = new List<Autonomo>();
            using (MySqlDataReader dados = Consultar("CarregarFavoritos", parametros))
            {
                if (dados.HasRows)
                {
                    while(dados.Read())
                    {
                        Autonomo autonomo = new Autonomo();
                        autonomo.Email = dados.GetString(0);
                        autonomo.PreencherDados();

                        listFavs.Add(autonomo);
                    }
                }
            } 

            Desconectar();

            return listFavs;
        }

        public List<String> CarregarFavoritosPorArea(string emailCliente, string filtro)
        {
            Conectar();

            List<String> listFavsComFiltro = new List<String>();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailCliente", emailCliente));
            parametros.Add(new Parametro("vFiltro", filtro));

            using (MySqlDataReader dados = Consultar("FiltrarFavoritosPorArea", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        String line = $"{dados.GetString(0)},{dados.GetString(1)}";
                        listFavsComFiltro.Add(line);
                    }
                }
            }

            Desconectar();

            return listFavsComFiltro;
        }

        // TODO: function para comparação de autonoms favs

        public bool VerificaFavorito(string emailCliente, string emailAutonomo)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailC", emailCliente));
            parametros.Add(new Parametro("vEmailA", emailAutonomo));

            Boolean retorno = false;
            using (MySqlDataReader dados = Consultar("VerificarFavorito", parametros))
            {
                if (dados.HasRows)
                {
                    if (dados.Read())
                    {
                        if (dados.GetString(0) == "ok")
                        {
                            retorno = true;
                        }
                    }
                }
            }

            Desconectar();

            return retorno;
        }
        public void AdicionarFavorito(string emailAutonomo, string emailCliente)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailA", emailAutonomo));
            parametros.Add(new Parametro("vEmailC", emailCliente));

            Executar("AdicionarFavorito", parametros);
        }

        public void DeletarFavorito(string emailAutonomo, string emailCliente)
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailA", emailAutonomo));
            parametros.Add(new Parametro("vEmailC", emailCliente));

            Executar("DeletarFavorito", parametros);
        }

    }
}