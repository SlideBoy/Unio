using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Unio.modelos
{
    public class Mensagem : Banco
    {
        public int Envio { get; set; }
        public string EmailCliente { get; set; }
        public string EmailAutonomo { get;set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }

        public Mensagem() { }

        public Mensagem(int envio, string emailCliente, string emailAutonomo, string descricao, DateTime data, DateTime hora)
        {
            this.Envio = envio;
            this.EmailCliente = emailCliente;
            this.EmailAutonomo = emailAutonomo;
            this.Descricao = descricao;
            this.Data = data;
            this.Hora = hora;
        }

        public void EnviarMensagem()
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailA", this.EmailAutonomo));
            parametros.Add(new Parametro("vEmailC", this.EmailCliente));
            parametros.Add(new Parametro("vEnvio", this.Envio.ToString()));
            parametros.Add(new Parametro("vMensagem", this.Descricao));

            Executar("EnviarMensagem", parametros);
        }
    }
}