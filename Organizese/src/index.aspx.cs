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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string paramUrl = Request.QueryString["id"];
                LinkGeral lnk = new LinkGeral();

                lnk.gravarVisista("post:"+paramUrl);

                DataTable dt = lnk.LoadPostsByEdit(Convert.ToInt32(paramUrl));
                RptPosts.DataSource = dt;
                RptPosts.DataBind();
                //Thread.Sleep(10000);
                //modalPopUpEmail.Show();
            }

            //ScriptManager.RegisterClientScriptBlock(
            //      Page,
            //      Page.GetType(),
            //      "Mensagem",
            //      "<script type='text/javascript'> $find(`modalPopUpEmail`).show();</script>",
            //      false);
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