using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}