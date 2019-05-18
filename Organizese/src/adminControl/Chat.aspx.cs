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

                if (!string.IsNullOrEmpty(website.Atendimento.id))
                {
                   DataRow[] dr = dt.Select($"ID={website.Atendimento.id}");

                    lblProtocol.Text = dr[0]["ID"].ToString();
                    lblNomeClie.Text = dr[0]["NOME_USER"].ToString();

                    rptMsg.DataSource = lnk.GetMsgChat(Convert.ToInt32(website.Atendimento.id));
                    rptMsg.DataBind();

                    txtMsg.Enabled = true;
                }
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

            lnk.gravarMsg(website.Atendimento.id, msg, "A");

            rptMsg.DataSource = lnk.GetMsgChat(Convert.ToInt32(website.Atendimento.id));
            rptMsg.DataBind();

            txtMsg.Text = string.Empty;
        }

        protected void timerChat_Tick(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();
            rptMsg.DataSource = lnk.GetMsgChat(Convert.ToInt32(website.Atendimento.id));
            rptMsg.DataBind();
            lbl.Text +=" | ";
        }
    }
}