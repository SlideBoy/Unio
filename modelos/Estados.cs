using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Estados : Banco
    {
        public List<Estado> CarregarEstados()
        {
            Conectar();

            List<Estado> estados = new List<Estado>();
            MySqlDataReader dados = Consultar("carregarEstados", null);

            while (dados.Read())
            {
                Estado estado = new Estado();
                estado.Sigla = dados.GetString(0);
                estado.Nome = dados.GetString(1);

                estados.Add(estado);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return estados;

        }
    }
}