using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Estado : Banco
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public Estado() { }
        public Estado(string Sigla, string Nome)
        {
            this.Sigla = Sigla;
            this.Nome = Nome;
        }

        public Estado CarregarEstado()
        {
            Conectar();

            MySqlDataReader dados = Consultar("carregarEstado", null);
            Estado estado = new Estado();
            if (dados.Read())
            {
                estado.Sigla = dados.GetString(0);
                estado.Nome = dados.GetString(1);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();
            return estado;
        
        }

        public Estado FiltrarEstado(string codigo)
        {

            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vCidade", codigo));

            List<Estado> estados = new List<Estado>();
            MySqlDataReader dados = Consultar("filtrarEstados", parametros);
            Estado estado = new Estado();
            if (dados.Read())
            {
                estado.Sigla = dados.GetString(0);
                estado.Nome = dados.GetString(1);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return estado;

        }
    }
}

