using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class FormasTrabalho : Banco
    {
        public List<FormaTrabalho> CarregarTipoAtendimentos()
        {
            List<FormaTrabalho> formasTrabalho = new List<FormaTrabalho>();

            Conectar();

            MySqlDataReader dados = Consultar("CarregarFormasTrabalho", null);
            while (dados.Read())
            {
                FormaTrabalho formaTrabalho = new FormaTrabalho();
                formaTrabalho.Codigo = dados.GetInt32(0);
                formaTrabalho.Nome = dados.GetString(1);

                formasTrabalho.Add(formaTrabalho);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return formasTrabalho;
        }
    }
}