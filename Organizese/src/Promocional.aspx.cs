using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class Promocional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                lnk.gravarVisista("Promo");
            }
        }

        [WebMethod]
        public static void gravarEmailPromo(string nome, string email)
        {
            LinkGeral lnk = new LinkGeral();
            lnk.gravarListaEmailPromo(nome, email, "0"); 
        }
    }
}