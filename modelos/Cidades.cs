using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Cidades : Banco
    {
        public List<Cidade> CarregarCidades()
        {
            Conectar();

            List<Cidade> cidades = new List<Cidade>();
            MySqlDataReader dados = Consultar("carregarCidades", null);

            while (dados.Read())
            {
                Cidade cidade = new Cidade();
                cidade.Codigo = dados.GetInt32(0);
                cidade.Nome = dados.GetString(1);

                cidades.Add(cidade);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return cidades;

        }

        public List<Cidade> FiltrarCidades(string sigla)
        {

            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEstado", sigla));
            
            List<Cidade> cidades = new List<Cidade>();
            MySqlDataReader dados = Consultar("carregarCidadesComFiltro", parametros);

            while (dados.Read())
            {
                Cidade cidade = new Cidade();
                cidade.Codigo = dados.GetInt32(0);
                cidade.Nome = dados.GetString(1);

                cidades.Add(cidade);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return cidades;

        }
    }
}