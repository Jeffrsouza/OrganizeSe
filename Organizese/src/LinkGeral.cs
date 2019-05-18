using System;
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
        #region Conexão
        /*
         * sig_freud    
         * Freud@1010
         */
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
        //private static string connString = "Database = ogsql; Server = localhost; Port = 3306;User Id = root; Password = Kant1010";

        //Produção
        private static string connString = "Database = ogolap; Data Source = ogolap.mysql.uhserver.com; Port = 3306;User Id = sig_freud; Password = Freud@1010";

        MySqlConnection connection = new MySqlConnection(connString);
        #endregion

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
                    " WHERE P.ID < (SELECT MAX(ID) FROM POSTS) " +
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

        #region Varios
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
            string ok = string.Empty;

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

        public void gravarVisista(string page)
        {
            try
            {
                DateTime data = DateTime.Now;
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO VISITAS (PAGE ,DATA) VALUES "
                    + "('" + page + "','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "')"
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
                MySqlCommand query = new MySqlCommand("SELECT ID FROM USUARIOS WHERE EMAIL='" + tratarStr(email) + "'", connection);
                connection.Open();
                dt.Load(query.ExecuteReader());
                cadastrado = (dt.Rows.Count > 0 && dt != null) ? true : false;
                connection.Close();

            }
            catch (Exception ex)
            {
                connection.Close();
                cadastrado = false;
            }
            return cadastrado;
        }

        public bool gravarListaEmail(string nome, string email, string idPostsCad)
        {
            int idPosts = 0;
            try { idPosts = Convert.ToInt32(idPostsCad); } catch { idPosts = 0; }

            bool ok = false;
            int id = proxid("USUARIOS");
            DateTime data = DateTime.Now;
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO USUARIOS (ID, NOME, EMAIL, TIPO, DTCAD, IDPOSTSCAD ) VALUES "
                    + "('" + id + "','" + nome + "','" + email + "','E','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idPosts + "')"
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

        public bool gravarListaEmailDiv(string nome, string email, string origem)
        {
            bool ok = false;
            int id = proxid("USUARIOS");
            DateTime data = DateTime.Now;
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO USUARIOS (ID, NOME, EMAIL, TIPO, DTCAD, IDPOSTSCAD, ORIGEM ) VALUES "
                    + "('" + id + "','" + nome + "','" + email + "','E','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "','0','" + origem + "')"
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

        public bool gravarListaEmailPromo(string nome, string email, string idPostsCad)
        {
            int idPosts = 0;
            try { idPosts = Convert.ToInt32(idPostsCad); } catch { idPosts = 0; }

            bool ok = false;
            int id = proxid("USUARIOS");
            DateTime data = DateTime.Now;
            try
            {
                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO USUARIOS (ID, NOME, EMAIL, TIPO, DTCAD, IDPOSTSCAD ) VALUES "
                    + "('" + id + "','" + nome + "','" + email + "','M','" + data.ToString("yyyy-MM-dd HH:mm:ss") + "','" + idPosts + "')"
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
                    (" DELETE FROM IMG WHERE IDPOSTS= " + id + "; DELETE FROM POSTS WHERE ID = " + id + ";"
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

        public bool gravarEmail(string nome, string email)
        {
            int id = proxid("USUARIOS");
            try
            {
                MySqlCommand query = new MySqlCommand(" INSERT INTO USUARIOS (ID, NOME, EMAIL) VALUES ('" + id + "','" + nome + "','" + email + "');", connection);
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

        public DataTable getEmails()
        {
            DataTable dtRetorno = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("NOME", typeof(String));
            dt.Columns.Add("EMAIL", typeof(String));
            dt.Columns.Add("DATA", typeof(String));
            dt.Columns.Add("TIPO", typeof(String));
            dt.Columns.Add("ID_POST", typeof(String));
            dt.Columns.Add("LINK", typeof(String));
            dt.Columns.Add("TITULO", typeof(String));
            dt.Columns.Add("ORIGEM", typeof(String));

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    US.ID, US.NOME,US.EMAIL, DATE_FORMAT(US.DTCAD,'%d/%m/%Y') AS DATA, US.TIPO,US.IDPOSTSCAD " +
                    "    , NULL AS LINK, P.TITULO, US.ORIGEM " +
                    "FROM " +
                    "   USUARIOS US " +
                    "   LEFT JOIN POSTS P " +
                    "   ON P.ID=US.IDPOSTSCAD " +
                    "   ORDER BY US.ID DESC "
                    , connection);
                dtRetorno.Load(query.ExecuteReader());

                if (dtRetorno.Rows.Count > 0 && dtRetorno != null)
                {
                    for (int i = 0; i < dtRetorno.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = dtRetorno.Rows[i]["ID"];
                        dr[1] = dtRetorno.Rows[i]["NOME"];
                        dr[2] = dtRetorno.Rows[i]["EMAIL"];
                        dr[3] = dtRetorno.Rows[i]["DATA"];
                        dr[4] = dtRetorno.Rows[i]["TIPO"];
                        dr[5] = dtRetorno.Rows[i]["IDPOSTSCAD"];
                        dr[6] = "http://www.organizeseop.com.br/src/unsubscribe.aspx?id=" + criptId(dtRetorno.Rows[i]["ID"].ToString(), true);
                        dr[7] = dtRetorno.Rows[i]["TITULO"];
                        dr[8] = dtRetorno.Rows[i]["ORIGEM"];
                        dt.Rows.Add(dr);
                    }
                }
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

        public DataTable getVisitas()
        {
            DataTable dtVisitas = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    "SELECT ID, PAGE , DATA FROM VISITAS ORDER BY ID"
                    , connection);
                dtVisitas.Load(query.ExecuteReader());


            }
            catch (Exception ex)
            {
                dtVisitas.Clear();
            }
            finally { connection.Close(); }
            return dtVisitas;
        }

        public bool cancelaEmail(string id)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(
                    " UPDATE USUARIOS SET TIPO = 'C' WHERE ID = " + criptId(id, false)
                    , connection);
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
            string[] letras = { "H", "J", "K", "L", "Z", "W", "X", "E", "C", "R", "Y", "N", "U", "M", "P", "A", "S", "D", "F", "G" };
            if (tipo)
            {
                int index = (Convert.ToInt32(id) * 37);
                int indexLetra = Convert.ToInt32(index.ToString().Substring(0, 1));
                retorno = letras[indexLetra] + index.ToString() + letras[indexLetra + 7];
            }
            else
            {
                retorno = (Convert.ToInt32(id.Substring(1, id.Length - 2)) / 37).ToString();
            }
            return retorno;
        }
        #endregion

        #region Métodos do Site
        public DataTable GetPosts()
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
                    " WHERE P.ID < (SELECT MAX(ID) FROM POSTS) " +
                    " ORDER BY DATA DESC, ID DESC " +
                    " LIMIT 3"
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

        public bool GravarUsuario(string nome, string sobrenome, string email, string cpf, string senha, string genero, string dtNasc)
        {
            bool ok = false;
            int id = proxid("USUARIOS");
            try
            {
                MySqlCommand query = new MySqlCommand(
                    " INSERT INTO USUARIOS " +
                    "   (ID, NOME, SOBRENOME, ENAIL,CPF, SENHA, TIPO, GENERO,DTNASC,DTCAD) " +
                    " VALUES " +
                    $"   ('{id}','{tratarStr(nome)}','{tratarStr(sobrenome)}','{tratarStr(email)}','{cpf}','{tratarStr(senha)}','{tratarStr(genero)}','{tratarStr(dtNasc)}','{ DateTime.Now.ToString("yyyy-MM-dd")}')"
                    , connection);
                connection.Open();
                query.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
            finally
            {
                connection.Close();
            }
            return ok;
        }

        public string[] Login(string email, string senha)
        {
            bool tipo = email.Contains("@") ? true : false;
            DataTable dt = new DataTable();
            string[] login = new string[3];
            string strQuery = string.Empty;

            strQuery = tipo
                ? $" SELECT ID, NOME FROM USUARIOS WHERE EMAIL = '{tratarStr(email)}' AND SENHA='{tratarStr(senha)}'"
                : $" SELECT ID, NOME FROM ADMIN WHERE NOME = '{tratarStr(email)}' AND SENHA='{tratarStr(senha)}'";
            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(strQuery, connection);
                dt.Load(query.ExecuteReader());
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        login[0] = dr["ID"].ToString();
                        login[1] = dr["NOME"].ToString();
                        login[2] = tipo ? "USUARIO" : "ADMIN";
                    }
                }
                else
                {
                    login[0] = string.Empty;
                }
            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return login;

        }
        #endregion

        #region Chat
        public DataTable GetMsgChat(int idProt)
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    C.ID, A.NOME AS NOME_ADMIN, " +
                    "    U.NOME AS NOME_USER, C.MSG, C.TIPO, " +
                    "    DATE_FORMAT(C.DATA,'%H:%i - %d/%m/%Y') AS DATA " +
                    " FROM " +
                    "   CHAT C " +
                    "   INNER JOIN ADMIN A ON A.ID = C.IDADMIN" +
                    "   INNER JOIN USUARIOS U ON U.ID = C.IDUSER" +
                    " WHERE 0=0 " +
                    $"   AND C.IDPROT={idProt}" +
                    " ORDER BY C.ID "
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

        public DataTable GetProtocol()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "    P.ID, A.NOME AS NOME_ADMIN, " +
                    "    U.NOME AS NOME_USER,  " +
                    "    P.EMAIL,  " +
                    "    DATE_FORMAT(P.DATA_INI,'%H:%i - %d/%m/%Y') AS DATA " +
                    " FROM " +
                    "   PROTOCOLO P " +
                    "   INNER JOIN ADMIN A ON A.ID = P.IDADMIN" +
                    "   INNER JOIN USUARIOS U ON U.ID = P.IDUSER " +
                    " WHERE 0=0 " +
                    " ORDER BY P.ID DESC "
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

        public void gravarMsg(string idProt, string msg, string tipo)
        {
            int id = proxid("CHAT");

            try
            {
                string idAdmin = string.Empty;
                string idUser = string.Empty;

                connection.Open();
                MySqlCommand qryInfo = new MySqlCommand($" SELECT  IDADMIN, IDUSER FROM PROTOCOLO WHERE ID={idProt}", connection);
                MySqlDataReader drInfo = qryInfo.ExecuteReader();
                if (drInfo.Read())
                {
                    idAdmin = drInfo["IDADMIN"].ToString();
                    idUser = drInfo["IDUSER"].ToString();
                }
                connection.Close();

                MySqlCommand query = new MySqlCommand
                    (" INSERT INTO CHAT (ID, IDPROT, IDADMIN, IDUSER, TIPO, MSG, DATA) VALUES "
                    + $"('{id}','{idProt}','{idAdmin} ','{idUser} ','{tipo}','{msg}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }')"
                    , connection);

                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Agenda
        public bool InserirAgenda(string idAdmin, DateTime data, string hora)
        {
            bool ok = false;
            int id = proxid("AGENDA");
            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " INSERT INTO AGENDA(ID, DATA, IDADMIN) VALUES " +
                    $" ({id}, '{data.ToString("yyyy-MM-dd")} {hora}', {idAdmin}) "
                    , connection);
                query.ExecuteNonQuery();
                connection.Close();
                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
            }
            finally
            {
                connection.Close();
            }
            return ok;
        }

        public DataTable CarregarAgenda(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "   A.ID, A.DATA, A.IDUSER, U.NOME " +
                    " FROM " +
                    "   AGENDA A " +
                    "   LEFT JOIN USUARIOS U ON A.IDUSER = U.ID " +
                    " WHERE DATA >= NOW() " +
                   $"   AND A.IDADMIN= '{id}' " +
                   "ORDER BY A.DATA"
                   , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public DataTable CarregarAtendimentos(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " SELECT " +
                    "   A.ID, A.DATA, A.IDUSER, U.NOME " +
                    " FROM " +
                    "   AGENDA A " +
                    "   LEFT JOIN USUARIOS U ON A.IDUSER = U.ID " +
                    " WHERE 0=0 " +
                    //"   AND DATA >= NOW() " +
                    "   AND A.IDUSER IS NOT NULL " +
                   $"   AND A.IDADMIN= '{id}' " +
                    " ORDER BY A.DATA "
                   , connection);
                dt.Load(query.ExecuteReader());

            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public bool IniciarAtendimento(string id)
        {
            bool ok = false;

            try
            {
                connection.Open();
                MySqlCommand query = new MySqlCommand($" SELECT ID FROM PROTOCOLO WHERE ID ={id}", connection);
                MySqlDataReader dr = query.ExecuteReader();

                int id_exist = 0;
                if (dr.Read()) id_exist = Convert.ToInt32(dr["ID"]);
                connection.Close();

                if (id_exist > 0)
                {
                    ok = true;
                }
                else
                {
                    #region Carrega Dados
                    string idAdmin = string.Empty;
                    string idUser = string.Empty;
                    string email = string.Empty;

                    connection.Open();
                    MySqlCommand qryLoadId = new MySqlCommand(
                        " SELECT " +
                        " 	A.IDADMIN, A.IDUSER, U.EMAIL " +
                        " FROM AGENDA A " +
                        " 	INNER JOIN USUARIOS U ON U.ID = A.IDUSER " +
                        "     INNER JOIN ADMIN AD ON AD.ID = A.IDADMIN " +
                        " WHERE 0=0 " +
                       $" 	AND A.ID ={id}"
                        , connection);
                    MySqlDataReader drLoadId = qryLoadId.ExecuteReader();
                    if (drLoadId.Read())
                    {
                        idAdmin = drLoadId["IDADMIN"].ToString();
                        idUser = drLoadId["IDUSER"].ToString();
                        email = drLoadId["EMAIL"].ToString();
                    }
                    connection.Close();
                    #endregion

                    #region Insert Protocolo        

                    MySqlCommand qryInsert = new MySqlCommand(
                        " INSERT INTO PROTOCOLO " +
                        "   (ID, IDADMIN, IDUSER, EMAIL, DATA_INI, STATUS) " +
                        " VALUES " +
                       $"   ('{proxid("PROTOCOLO")}','{idAdmin}','{idUser}','{email}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','A');"
                        , connection);
                    connection.Open();
                    qryInsert.ExecuteNonQuery();
                    connection.Close();
                    ok = true;
                    #endregion
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                ok= false;
            }
            finally
            {
                connection.Close();
            }
            return ok;
        }
        #endregion
    }
}
