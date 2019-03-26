using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Http;
using MySql.Data.MySqlClient;
using MySql.Data;
using static Organizese.API.Models.Default;

namespace Organizese.API.Classes
{
    public class Default
    {
        #region ConnString
        //local
        private static string connString = "Database = ogsql; Server = localhost; Port = 3306;User Id = root; Password = Kant1010";

        //Produção
        //private static string connString = "Database = ogolap; Data Source = mysql642.umbler.com; Port = 41890;User Id = kant; Password = Ogsql1010";

        MySqlConnection connection = new MySqlConnection(connString);
        #endregion

        private int proxid(string tabela)
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

        private HttpRequestMessage Request { get; set; }

        public Default(HttpRequestMessage req)
        {
            Request = req;
        }
        #region GET
        internal HttpResponseMessage GetTopFivePosts()
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

                List<Posts> ListPosts = new List<Posts>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListPosts.Add(new Posts
                        {
                            id = Convert.ToInt32(dr["ID"]),
                            texto = Convert.ToString(dr["TEXTO"]),
                            titulo = Convert.ToString(dr["TITULO"]),
                            data = Convert.ToString(dr["DATAPOST"]),
                            categoria = Convert.ToString(dr["CATEGORIA"]),
                            nome = Convert.ToString(dr["NOME"]),
                            arquivo = Convert.ToString(dr["ARQUIVO"]),
                        });
                    }
                return Request.CreateResponse(HttpStatusCode.OK, ListPosts);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foram encontradas postagens.");
                }
            }
            catch (Exception ex)
            {
                // lblText.Text = "Catch " + ex.Message;
                dt.Clear();
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Erro ao consultar postagens || "+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Post
        internal HttpResponseMessage NewProtocol(int idUser, string email)
        {
            try
            {
                int id = proxid("PROTOCOLO");

                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " INSERT INTO PROTOCOLO " +
                    "   (ID, IDADMIN, IDUSER, EMAIL, DATA_INI, DATA_FIM, STATUS, PONTOS) "+
                    " VALUES "+
                   $"   ({id},null,{idUser},'{email}', '{DateTime.Now.ToString("yyyy-MM-dd")}',null,'A',0 ); "
                    , connection);
                query.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = id, Message = "Protocolo aberto com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Erro ao abrir protocolo || " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        internal HttpResponseMessage NewMsg(Msg msg)
        {
            try
            {
                int id = proxid("CHAT");

                connection.Open();
                MySqlCommand query = new MySqlCommand(
                    " INSERT INTO CHAT " +
                    "   (ID, IDPROT, REMETENTE, DEST, MSG, DATA) " +
                    " VALUES " +
                   $"   ({id}, {msg.idProtocol},{msg.rem},{msg.dest},'{msg.texto}','{DateTime.Now.ToString("yyyy-MM-dd")}'); "
                    , connection);
                query.ExecuteNonQuery();
                connection.Close();

                return Request.CreateResponse(HttpStatusCode.OK, new { Id = id, Message = "Msg enviada com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Erro ao enviar msg || " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}