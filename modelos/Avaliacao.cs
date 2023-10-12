using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Avaliacao : Banco
    {
        public Cliente Cliente { get; set; }
        public string EmailAutonomo { get; set; }
        public int CodigoProfissao { get; set; }
        public string Descricao { get; set; }
        public double Media { get; set; }
        public DateTime DataPostagem { get; set; }

        public Avaliacao() { }
        public Avaliacao(Cliente cliente, string emailAutonomo, int codigoProfissao, string descricao, double media)
        {
            this.Cliente = cliente;
            this.EmailAutonomo = emailAutonomo;
            this.CodigoProfissao = codigoProfissao;
            this.Descricao = descricao;
            this.Media = media;
            this.DataPostagem = DateTime.Now;
        }
    }   
}