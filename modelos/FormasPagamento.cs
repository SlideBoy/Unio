using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class FormasPagamento : Banco
    {

        public List<FormaPagamento> CarregarFormasPagamento()
        {
            List<FormaPagamento> formasPagamento = new List<FormaPagamento>();

            Conectar();

            MySqlDataReader dados = Consultar("carregarFormasPagamento", null);
            while (dados.Read())
            {
                FormaPagamento formaPagamento = new FormaPagamento();
                formaPagamento.Codigo = dados.GetInt32(0);
                formaPagamento.Nome = dados.GetString(1);

                formasPagamento.Add(formaPagamento);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return formasPagamento;
        }
    }
}