using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio.lib
{
    public partial class DeletarFavorito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!String.IsNullOrEmpty(Request["ia"]) && !String.IsNullOrEmpty(Request["ic"]))
            {
                Favoritos favoritos = new Favoritos();
                favoritos.DeletarFavorito(Request["ia"], Request["ic"]);
            }
        }
    }
}