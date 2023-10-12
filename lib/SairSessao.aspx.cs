using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unio.lib
{
    public partial class SairSessao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            Session.Abandon();

            string retorno = "{'situacao':'ok'}";
            Response.Write(retorno.Replace('\'', '\"'));
            
        }
    }
}