using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Threading;
using System.Web.Services;

namespace Organizese.src
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }
        [WebMethod]
        public static void gravarEmail(string nome, string email, string idPostsCad)
        {
            LinkGeral lnk = new LinkGeral();
            bool cadastrado = lnk.validarEmail(email);
            if (!cadastrado) { lnk.gravarListaEmail(nome, email, idPostsCad); }
        }
    }
}