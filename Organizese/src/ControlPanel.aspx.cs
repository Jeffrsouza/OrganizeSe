using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class ControlPanel2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                DataTable dt = lnk.getEmails();
                gvDados.DataSource = dt;
                gvDados.DataBind();
                carregarMsgChat();
            }
        }

        protected void timeChat_Tick(object sender, EventArgs e)
        {
            carregarMsgChat();
        }
        private void carregarMsgChat()
        {
            LinkGeral lnk = new LinkGeral();
            rptMsg.DataSource= lnk.GetMsgChat(1);
            rptMsg.DataBind();

            //gvProt.DataSource = lnk.GetProtocol();
            //gvProt.DataBind();
        }

        protected void gvProt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LinkGeral lnk = new LinkGeral();
            rptMsg.DataSource = lnk.GetMsgChat(1);
            rptMsg.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            /*
            string mensagem = txtMsg.Text;
            LinkGeral lnk = new LinkGeral();
            lnk.gravarMsg(mensagem);

            carregarMsgChat();

            txtMsg.Text=string.Empty;
            */

        }
    }
}