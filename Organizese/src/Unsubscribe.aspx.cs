using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class Unsubscrib : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            string paramUrl = Request.QueryString["id"];
            LinkGeral lnk = new LinkGeral();
            bool retorno = lnk.cancelaEmail(paramUrl);
            lblRetorno.Visible =true;
            lblRetorno.Text = retorno ? "E-mail descadastrado com sucesso!" : "Encontramos algum problema em retirar seu a-mail do cadastro. Por favor encaminhe um e-mail para <b>leolink11@gmail.com</b>.";
        }
    }
}