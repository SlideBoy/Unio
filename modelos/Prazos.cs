using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Prazos : Banco
    {
        public List<Prazo> CarregarPrazos()
        {
            Conectar();
            List<Prazo> listPrazos = new List<Prazo>();
            using (MySqlDataReader dados = Consultar("CarregarPrazos", null))
            {
                if(dados.HasRows)
                {
                    while(dados.Read()) 
                    { 
                        Prazo prazo = new Prazo();
                        prazo.Codigo = dados.GetInt32(0);
                        prazo.Nome = dados.GetString(1);

                        listPrazos.Add(prazo);
                    }
                }
            }

            Desconectar();

            return listPrazos;
        }
    }
}