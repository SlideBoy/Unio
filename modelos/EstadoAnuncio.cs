using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class EstadoAnuncio
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public EstadoAnuncio() { }

        public EstadoAnuncio(int codigo, string nome) 
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}