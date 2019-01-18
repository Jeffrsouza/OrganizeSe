using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();

                lnk.gravarVisista("blog.aspx");

                DataTable dtPrincipal = lnk.PostPrincipal();
                RptPrincipal.DataSource = dtPrincipal;
                RptPrincipal.DataBind();

                DataTable dtSecundario = lnk.PostsSecundarios();
                RptSecundario.DataSource = dtSecundario;
                RptSecundario.DataBind();
            }
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