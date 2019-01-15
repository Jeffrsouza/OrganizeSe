﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Text;
using System.IO;

namespace Organizese.src
{
    #region Tipos de Usuários
    /*
     * E = Apenas Lista de e-mail 
     * F = Free
     * P = Premium
     *
    */
    #endregion

    public class LinkGeral
    {
        //Trata a string
        public string tratarStr(string @_varStr)
        {
            foreach (var chr in new string[] { "DROP ", "TRUNCATE ", "DELETE ", "UPDATE "/*, "(", ")", "-", "+", "!", "#", "$", "%", "&", "*", "[", "]", "{", "}", "/", ";" */})
            {
                @_varStr = @_varStr.Replace(chr, "");
            }

            return @_varStr;
        }

        //local
        //private static string connString = "Database = ogsql; Data Source = localhost; Port = 3306;User Id = root; Password = Kant1010";
        //Produção
        private static string connString = "Database = ogolap; Data Source = mysql642.umbler.com; Port = 41890;User Id = kant; Password = Ogsql1010";

        MySqlConnection connection = new MySqlConnection(connString);

        #region Carrega Page Blog
        public DataTable PostPrincipal()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    P.ID, P.TEXTO,P.TITULO, DATE_FORMAT(P.DATA,'%d/%m/%Y') AS DATAPOST, P.CATEGORIA, " +
                    "    IMG.NOME, CONVERT(IMG.ARQUIVO USING utf8) AS ARQUIVO " +
                    " FROM " +
                    "   POSTS P " +
                    "   LEFT JOIN IMG ON IMG.IDPOSTS = P.ID " +
                    " WHERE P.ID = (SELECT MAX(ID) FROM POSTS) "
                    , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataTable PostsSecundarios()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    P.ID, P.TEXTO,P.TITULO, DATE_FORMAT(P.DATA,'%d/%m/%Y') AS DATAPOST, P.CATEGORIA, " +
                    "    IMG.NOME, CONVERT(IMG.ARQUIVO USING utf8) AS ARQUIVO " +
                    " FROM " +
                    "   POSTS P " +
                    "   LEFT JOIN IMG ON IMG.IDPOSTS = P.ID " +
                    " WHERE P.ID < (SELECT MAX(ID) FROM POSTS) "+
                    " ORDER BY DATA DESC, ID DESC "
                    , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ezx)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        #endregion

        public DataTable Posts()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    P.ID, P.TEXTO,P.TITULO, DATE_FORMAT(P.DATA,'%d/%m/%Y') AS DATAPOST, P.CATEGORIA, " +
                    "    IMG.NOME, CONVERT(IMG.ARQUIVO USING utf8) AS ARQUIVO " +
                    "FROM " +
                    "   POSTS P " +
                    "   LEFT JOIN IMG ON IMG.IDPOSTS = P.ID " +
                    "   ORDER BY DATA DESC, ID DESC "
                    , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataTable LoadPostsByEdit()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    ID , CONCAT(DATE_FORMAT(DATA,'%d/%m/%Y') ,' - ', TITULO) AS POST " +
                    " FROM " +
                    "   POSTS " +
                    "   ORDER BY DATA DESC, ID DESC "
                    , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public DataTable LoadPostsByEdit(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    P.ID, P.TITULO, P.TEXTO, DATE_FORMAT(P.DATA,'%d/%m/%Y') AS DATAPOST, P.CATEGORIA, " +
                    "    IMG.NOME, CONVERT(IMG.ARQUIVO USING utf8) AS ARQUIVO " +
                    "FROM " +
                    "   POSTS P " +
                    "   LEFT JOIN IMG ON IMG.IDPOSTS = P.ID " +
                    "   WHERE P.ID= " + id +
                    "   ORDER BY DATA DESC "
                    , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public int proxid(string tabela)
        {
            int id = 0;
            MySqlCommand query = new MySqlCommand("SELECT (MAX(ID)+1) AS ID FROM " + tabela, connection);

            try
            {
                connection.Open();
                MySqlDataReader dr = query.ExecuteReader();
                if (dr.Read()) id = Convert.ToInt32(dr["ID"]);
                else id = 0;
            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                id = 0;
            }
            connection.Close();
            return id;
        }

        public bool gravarImagem(FileUpload fileUpload, int idPost, bool novo)
        {
            bool ok = false;

            int idImg = proxid("IMG");

            string fileName = fileUpload.PostedFile.FileName;
            string extensao = Path.GetExtension(fileUpload.PostedFile.FileName).ToLower();
            try
            {
                MySqlCommand queryCheck = new MySqlCommand("SELECT ID FROM IMG WHERE IDPOSTS = '" + idPost + "'", connection);

                DataTable dt = new DataTable();
                connection.Open();
                dt.Load(queryCheck.ExecuteReader());
                connection.Close();
                novo = dt.Rows.Count > 0 ? false : true;

                byte[] imageBytes = fileUpload.FileBytes;
                string gravar = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                string queryTip = novo
                    ? "INSERT INTO IMG (ID,IDPOSTS, NOME, ARQUIVO, ORDEM) VALUES " +
                    " ('" + idImg + "','" + idPost + "','" + fileName + "','" + gravar + "',0)"
                    : "UPDATE IMG SET NOME = '" + fileName + "', ARQUIVO = '" + gravar + "' WHERE IDPOSTS='" + idPost + "' AND ORDEM=0";

                MySqlCommand query = new MySqlCommand(queryTip, connection);
                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return ok;
        }

        public bool gravarPost(int id, string titulo, string texto, DateTime data, string categoria)
        {
            bool ok = false;

            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO POSTS (ID, TITULO,TEXTO,DATA,CATEGORIA) VALUES "
                    + "('" + id + "','" + titulo + "','" + texto + "','" + data.ToString("yyyy-MM-dd") + "' ,'" + categoria + "')"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            return ok;
        }

        public string updatePost(int id, string titulo, string texto, DateTime data, string categoria)
        {
            string ok = string.Empty ;

            try
            {
                MySqlCommand query = new MySqlCommand
                    (" UPDATE POSTS SET " +
                        " TITULO = '" + titulo + "'" +
                        " ,TEXTO =  '" + texto + "'" +
                        " ,DATA =  '" + data.ToString("yyyy-MM-dd") + "'" +
                        " ,CATEGORIA =  '" + categoria + "'" +
                        " WHERE ID =  '" + id + "'"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                ok = "ok";
            }
            catch (Exception ex)
            {
                connection.Close();
                ok = ex.Message;
            }
            return ok;
        }

        public void gravaAcesso(string host, string ipuser, string iprede, DateTime data)
        {
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO VISITORS (HOST,IPUSER ,IPREDE ,DATA) VALUES "
                    + "('" + host + "','" + ipuser + "','" + iprede + "','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "')"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

        public bool validarEmail(string email)
        {
            bool cadastrado = false;
            DataTable dt = new DataTable();

            try
            {
                MySqlCommand query = new MySqlCommand("SELECT ID FROM USUARIOS WHERE EMAIL='" + tratarStr(email) + "'",connection);
                connection.Open();
                dt.Load(query.ExecuteReader());
                cadastrado = (dt.Rows.Count > 0 && dt != null) ?  true:false;
                connection.Close();

            }
            catch(Exception ex)
            {
                connection.Close();
                cadastrado = false;
            }
            return cadastrado;
        }

        public bool gravarListaEmail(string nome, string email)
        {
            bool ok = false;
            int id = proxid("USUARIOS");
            DateTime data = DateTime.Now;
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO USUARIOS (ID, NOME, EMAIL, TIPO, DTCAD) VALUES "
                    + "('" + id + "','" + nome + "','" + email + "','E','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "')"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                ok = false;
            }
            return ok;
        }

        public bool deletePost(int id)
        {
            bool ok = false;
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" DELETE FROM IMG WHERE IDPOSTS= " + id + "; DELETE FROM POSTS WHERE ID = " + id+";"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                ok = false;
            }
            return ok;

        }
        
        public bool gravarEmail(string nome, string email, string idPost)
        {
            int id = proxid("USUARIOS");
            try
            {
                MySqlCommand query = new MySqlCommand(" INSERT INTO USUARIOS (ID, NOME, EMAIL, IDPOSTSCAD) VALUES ('" + id + "','" + nome + "','" + email + "','"+ idPost + "');", connection);
                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        public string criptId(string id, bool tipo)
        {
            string retorno = "";
            string[] letras = {"H", "J", "K", "L", "Z", "W", "X", "E", "C", "R","Y", "N", "U", "M", "P", "A", "S", "D", "F", "G" };
            if (tipo)
            {
                int index = (Convert.ToInt32(id) * 37);
                int indexLetra = Convert.ToInt32(index.ToString().Substring(0, 1));
                retorno = letras[indexLetra] + index.ToString()+ letras[indexLetra+7];
            }
            else
            {
                retorno = (Convert.ToInt32(id.Substring(1, id.Length - 2)) / 37).ToString();
            }
            return retorno;
        }

    }
}