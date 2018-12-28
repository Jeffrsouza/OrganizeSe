using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Organizese.src
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();

            RptPosts.DataSource = lnk.Posts();
            RptPosts.DataBind();
        }
    }
}