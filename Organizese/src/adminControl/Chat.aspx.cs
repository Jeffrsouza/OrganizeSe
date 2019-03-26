using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src.adminControl
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                DataTable dt = lnk.GetProtocol();
                gvProtocol.DataSource = dt;
                gvProtocol.DataBind();
            }
        }

        protected void gvProtocol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string param = e.CommandArgument.ToString();
            string[] parametro = param.Split(',');

            lblProtocol.Text = parametro[0];
            lblNomeClie.Text = parametro[1];

            if (e.CommandName == "loadChat")
            {
                LinkGeral lnk = new LinkGeral();
                DataTable dt = lnk.GetMsgChat(Convert.ToInt32(parametro[0]));
                rptMsg.DataSource = dt;
                rptMsg.DataBind();

                txtMsg.Enabled = true;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();
            string msg = txtMsg.Text;
            lnk.gravarMsg(msg);

            DataTable dt = lnk.GetMsgChat(Convert.ToInt32(lblProtocol.Text));
            rptMsg.DataSource = dt;
            rptMsg.DataBind();

            txtMsg.Text = string.Empty;
        }
    }
}