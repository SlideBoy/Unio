using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Clientes : Banco
    {
        public List<Cliente> CarregarChats(string emailAutonomo)
        {
            Conectar();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailAutonomo", emailAutonomo));

            List<Cliente> clientes = new List<Cliente>();

            using (MySqlDataReader dados = Consultar("CarregarChatsAutonomo", parametros))
            {
                if (dados.HasRows)
                {
                    while(dados.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Email = dados.GetString(0);
                        cliente.PreencherDados();

                        clientes.Add(cliente);
                    }
                }
            }

            Desconectar();

            return clientes;
        }
    }
}