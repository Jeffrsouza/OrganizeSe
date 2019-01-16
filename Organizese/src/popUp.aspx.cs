using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Threading;
using System.Web.Services;


namespace Organizese.src
{
    public partial class popUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                lnk.gravarVisista("popUp");
            }
        }
        [WebMethod]
        public static void gravarEmail(string nome,string email )
        {
            LinkGeral lnk = new LinkGeral();
            bool cadastrado = lnk.validarEmail(email);
            if (!cadastrado) { lnk.gravarListaEmail(nome, email, "0"); }
        }
    }
}