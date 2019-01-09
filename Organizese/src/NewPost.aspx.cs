using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;

namespace Organizese.src
{
    public partial class NewPost : System.Web.UI.Page
    {
        public static int edit, idPost;
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();

            if (!Page.IsPostBack)
            {
                ddlCat.Items.Clear();
                ddlCat.Items.Add("Estudos");
                ddlCat.Items.Add("Finaças");
                ddlCat.Items.Add("Empresarial");
                ddlCat.Items.Add("Pessoal");

                /*
                    string host = Dns.GetHostName();
                    string ipUser = Dns.GetHostAddresses(host)[2].ToString();
                    string ipRede = Dns.GetHostAddresses(host)[3].ToString();
                    lnk.gravaAcesso(host, ipUser, ipRede, DateTime.Now);
                */

                listPosts.Items.Clear();
                listPosts.DataSource = lnk.LoadPostsByEdit();
                listPosts.DataTextField = "POST";
                listPosts.DataValueField = "ID";
                listPosts.DataBind();
            }


        }

        protected void btnPost_Click(object sender, EventArgs e)
        {

            LinkGeral lnk = new LinkGeral();
            if (chkEdit.Checked)
            {

                #region Atualiza Postagem
                int idPostSel = Convert.ToInt32(lblIdPost.Text);
                string titulo = txtTitle.Text;
                string textoDigitado = txtBodyPost.Text;
                string texto = textoDigitado.Replace(Environment.NewLine, "<br/>");
                DateTime data = DateTime.Now;
                string categoria = ddlCat.SelectedValue;

               string updatePosted =  lnk.updatePost(idPost, titulo, texto, data, categoria);

                ScriptManager.RegisterClientScriptBlock(
                Page,
                Page.GetType(),
                "Mensagem",
                "<script type='text/javascript'> alert('"+ updatePosted + "');</script>",
                false);
                #endregion

                #region Grava Imagem
                if (fileUpload.PostedFile != null && !string.IsNullOrEmpty(fileUpload.PostedFile.FileName) && fileUpload.PostedFile.InputStream != null)
                {
                    string grvImagem = lnk.gravarImagem(fileUpload, idPost, false) ? "Imagem Gravada" : "Erro ao Gravar Imagem";
                }
                #endregion
                ScriptManager.RegisterClientScriptBlock(
                 Page,
                 Page.GetType(),
                 "Mensagem",
                 "<script type='text/javascript'> alert('Alterado com sucesso!');</script>",
                 false);

                //Response.Redirect("http://www.organizeseop.com.br/src/Index.aspx");

            }
            else
            {
                int idAtual = lnk.proxid("POSTS");

                #region grava Postagem
                string titulo = txtTitle.Text;
                string texto = txtBodyPost.Text.Replace(Environment.NewLine, "<br/>");
                DateTime data = DateTime.Now;
                string categoria = ddlCat.SelectedValue;

                lnk.gravarPost(idAtual, titulo, texto, data, categoria);

                #endregion

                #region Grava Imagem
                if (fileUpload.PostedFile != null && !string.IsNullOrEmpty(fileUpload.PostedFile.FileName) && fileUpload.PostedFile.InputStream != null)
                {
                    string grvImagem = lnk.gravarImagem(fileUpload, idAtual, true) ? "Imagem Gravada" : "Erro ao Gravar Imagem";
                }
                #endregion

                ScriptManager.RegisterClientScriptBlock(
                   Page,
                   Page.GetType(),
                   "Mensagem",
                   "<script type='text/javascript'> alert('Postado com sucesso!');</script>",
                   false);
                Response.Redirect("http://www.organizeseop.com.br/src/Index.aspx");
            }

        }

        protected void btnImg_Click(object sender, EventArgs e)
        {
            string connString = "Database = ogolap; Data Source = localhost; Port = 3306;User Id = root; Password = Kant1010";
            MySqlConnection connection = new MySqlConnection(connString);

            try
            {
                MySqlCommand query = new MySqlCommand(" SELECT ID, NOME, CONVERT(arquivo USING utf8) AS ARQUIVO FROM IMG", connection);

                connection.Open();
                MySqlDataReader myReader = query.ExecuteReader();

                if (myReader.Read())

                {
                    string nome = myReader["ID"].ToString();
                    string img = myReader["ARQUIVO"].ToString();

                    imagePost.ImageUrl = "data:image/png;base64," + img;

                    //Response.ContentType = myReader["NOME"].ToString();
                    //Response.BinaryWrite((byte[])myReader["ARQUIVO"]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

        protected void fileUpload_DataBinding(object sender, EventArgs e)
        {
            byte[] imageBytes = fileUpload.FileBytes;
            string gravar = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            imagePost.ImageUrl = "data:image/png;base64," + gravar;
        }

        protected void btnTeste_Click(object sender, EventArgs e)
        {

        }

        protected void listPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();
            idPost = Convert.ToInt32(listPosts.SelectedValue);

            DataTable dt = lnk.LoadPostsByEdit(idPost);
            foreach (DataRow dr in dt.Rows)
            {
                lblIdPost.Text = dr["ID"].ToString();
                txtTitle.Text = dr["TITULO"].ToString();
                txtBodyPost.Text = dr["TEXTO"].ToString();
                imagePost.ImageUrl = "data:image/png;base64," + dr["ARQUIVO"].ToString();
            }

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            lblIdPost.Text = txtTitle.Text = txtBodyPost.Text = string.Empty;
            btnDelete.Visible= lblIdPost.Visible = chkEdit.Checked = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();
            bool ok = lnk.deletePost(Convert.ToInt32(lblIdPost.Text));
            Response.Redirect("~/src/NewPost.aspx");
        }

        protected void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            edit = chkEdit.Checked ? 1 : 0;
            btnDelete.Visible = lblIdPost.Visible = listPosts.Enabled = listPosts.Visible = chkEdit.Checked;
        }

    }
}
