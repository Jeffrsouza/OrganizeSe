using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//K@nt1010
namespace Organizese.src.website
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                DataTable dtBlog = lnk.GetPosts();
                rptBlog.DataSource = dtBlog;
                rptBlog.DataBind();
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string[] login = new string[2];
            bool ok = false;

            ok = string.IsNullOrEmpty(email) ? false : true;
            ok = string.IsNullOrEmpty(senha) ? false : true;

            if (ok)
            {
                LinkGeral lnk = new LinkGeral();
                login = lnk.Login(email, senha);
                if (!string.IsNullOrEmpty(login[0]))
                {
                    string url = login[2] == "ADMIN"
                        ? "http://www.organizeseop.com.br/adminControl/Home.aspx"
                        : "http://www.organizeseop.com.br/clientControl/Home.aspx";
                    Login.id = login[0];
                    Login.nome = login[1];
                    Login.tipo = login[2];
                    Response.Redirect(url);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(
                 Page,
                 Page.GetType(),
                 "Mensagem",
                 "<script type='text/javascript'> alert('Dados incorretos. Por favor, tente novamente!');</script>",
                 false);
            }
        }
    }
}