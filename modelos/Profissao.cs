using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Profissao
    {
        
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public AreaAtuacao areaAtuacao { get; set; }

        public Profissao() { }
        public Profissao (int Codigo, string Nome, AreaAtuacao areaAtuacao)
        {
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.areaAtuacao = areaAtuacao;
        }
    }
}