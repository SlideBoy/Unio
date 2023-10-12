using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Prazo
    {
        public int Codigo { get; set; }
        public string Nome  { get; set; }

        public Prazo(){
        
        }

        public Prazo(int codigo, string nome) {
        this.Codigo = codigo;
        this.Nome = nome;
        }
    }
}