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

namespace Organizese.src
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            LinkGeral lnk = new LinkGeral();
            DataTable dt = lnk.Posts();
            RptPosts.DataSource = dt ;
            RptPosts.DataBind();
                //Thread.Sleep(10000);
                //modalPopUpEmail.Show();
            }

            ScriptManager.RegisterClientScriptBlock(
                  Page,
                  Page.GetType(),
                  "Mensagem",
                  "<script type='text/javascript'> $find(`modalPopUpEmail`).show();</script>",
                  false);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            bool ok = false;
            LinkGeral lnk = new LinkGeral(); 
            string nome = lnk.tratarStr(txtName.Text);
            string email = lnk.tratarStr(txtMail.Text);

            if (!chkOkEmail.Checked)
            {
                lblConfirmEmail.Text = "Por favor, aceite o recebimento de e-mails!";
            }

            if (!email.Contains("@") || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nome))
            {
                lblConfirmEmail.Text = "E-mail inválido."; 
            }
            else
            {
               ok =  lnk.gravarEmail(nome, email);
                lblConfirmEmail.Text = ok ? "E-mail gravado com sucesso!" : "Erro ao gravar e-mail. Revise os dados por favor";
            }

        }
    }
}