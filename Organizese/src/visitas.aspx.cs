using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class visitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                LinkGeral lnk = new LinkGeral();
                gvVisitas.DataSource = lnk.getVisitas();
                gvVisitas.DataBind(); 
            }
        }
    }
}