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
            //MySqlConnection connection = new MySqlConnection("Database = ogolap; Data Source = mysql642.umbler.com; User Id = kant; Password = Ogsql1010");
            //MySqlCommand comando = new MySqlCommand("SELECT * FROM POSTS", connection);
            //DataTable tabela = new DataTable();

            //try
            //{
            //    connection.Open();
            //    gdvDados.DataSource = comando.ExecuteReader();
            //    gdvDados.DataBind();
            //    lblText.Text = "Try";
            //}
            //catch (Exception ex)
            //{
            //    lblText.Text = "Try" + ex.Message;
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }
    }
}