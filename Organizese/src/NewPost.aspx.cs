using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src
{
    public partial class NewPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCat.Items.Add("Estudos");
            ddlCat.Items.Add("Finaças");
            ddlCat.Items.Add("Empresarial");
            ddlCat.Items.Add("Pessoal");
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            LinkGeral lnk = new LinkGeral();

            int idPost = lnk.proxid("POSTS");

            #region grava Postagem
            string titulo = txtTitle.Text;
            string texto = txtBodyPost.Text.Replace(Environment.NewLine, "<br/>");
            DateTime data = DateTime.Now;
            string categoria = ddlCat.SelectedValue;

            lnk.gravarPost(idPost, titulo, texto, data, categoria);

            #endregion

            #region Grava Imagem
            if (fileUpload.PostedFile != null && !string.IsNullOrEmpty(fileUpload.PostedFile.FileName) && fileUpload.PostedFile.InputStream != null)
            {
                string grvImagem = lnk.gravarImagem(fileUpload, idPost) ? "Imagem Gravada" : "Erro ao Gravar Imagem";
            }
            #endregion

            

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
            string texto =  txtBodyPost.Text.Replace(Environment.NewLine, "<br/>");
            textoTest.Text = texto;
        }

        protected void btnNegrito_Click(object sender, EventArgs e)
        {
            //string texto = txtBodyPost.Text;
            //txtBodyPost.Text = texto + "<b>Insira o Texto em Negrito</b>";
        }

        protected void btnItalico_Click(object sender, EventArgs e)
        {
            //string texto = txtBodyPost.Text;
            //txtBodyPost.Text = texto + "<i>Insira o Texto em Italico</i>";
        }

        protected void btnSublinhado_Click(object sender, EventArgs e)
        {
            //string texto = txtBodyPost.Text;
            //txtBodyPost.Text = texto + "<u>Insira o Texto em Sublinhado</u>";
        }

        protected void btnLink_Click(object sender, EventArgs e)
        {
            //string texto = txtBodyPost.Text;
            //txtBodyPost.Text = texto + "<a href='coloque o link aqui'>Insira o Texto do Link</a>";
        }

        protected void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
