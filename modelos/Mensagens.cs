using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Mensagens : Banco
    {
        public List<Mensagem> CarregarMensagens(string emailA, string emailC, string codigoAnuncio)
        {
            Conectar();

            List<Mensagem> listMensagens = new List<Mensagem>();
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailA", emailA));
            parametros.Add(new Parametro("vEmailC", emailC));
            parametros.Add(new Parametro("vCodigoAnuncio", codigoAnuncio));

            using(MySqlDataReader dados = Consultar("CarregarMensagens", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Mensagem mensagem = new Mensagem();
                        mensagem.Envio = dados.GetInt32(0);
                        //mensagem.EmailCliente = dados.GetString(1);
                        //mensagem.EmailAutonomo = dados.GetString(2);
                        mensagem.Data = dados.GetDateTime(1);
                        mensagem.Hora.AddHours(dados.GetTimeSpan(2).TotalHours);
                        mensagem.Descricao = dados.GetString(3);


                        listMensagens.Add(mensagem);
                    }
                }
            }

            Desconectar();
            return listMensagens;
        }
    }
}