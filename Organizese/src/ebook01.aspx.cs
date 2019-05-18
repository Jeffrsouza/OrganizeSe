using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.Threading;
using System.Web.Services;

namespace Organizese.src
{
    public partial class ebook01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                lnk.gravarVisista("ebook01");
            }
        }
        [WebMethod]
        public static void gravarEmailEbook01(string nome, string email)
        {
            LinkGeral lnk = new LinkGeral();
            bool cadastrado = lnk.validarEmail(email);
            if (!cadastrado) { lnk.gravarListaEmailDiv(nome, email, "Ebook01"); }
        }
    }
}