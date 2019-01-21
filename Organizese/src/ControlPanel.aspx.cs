using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkGeral lnk = new LinkGeral();
                DataTable dt = lnk.getEmails();
                gvDados.DataSource = dt;
                gvDados.DataBind();
            }
        }
    }
}