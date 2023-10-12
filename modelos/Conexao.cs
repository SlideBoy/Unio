using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unio.modelos
{
    public class Conexao
    {
        public static string getConexao()
        {
            return "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Unio_BD";   
        }
    }
}