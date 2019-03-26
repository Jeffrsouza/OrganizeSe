using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using static Organizese.API.Models.Default;


namespace Organizese.API.Controllers
{
    public class GeralController : ApiController
    {
        #region GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #endregion
        #region GET api/<controller>/5
      
        [Route("api/GetTopFivePosts")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetTopFivePosts() =>
            new Classes.Default(Request).GetTopFivePosts();

        public string Get(int id)
        {
            return "value";
        }
        #endregion

        #region POST api/<controller>
        [Route("api/PostNewProtocol")]
        [HttpPost]
        public HttpResponseMessage PostNewProtocol(int idUser, string email) =>
         new Classes.Default(Request).NewProtocol(idUser,email);

        [Route("api/PostNewMsg")]
        [HttpPost]
        public HttpResponseMessage PostNewMsg([FromBody]Msg mensagem) =>
            !ModelState.IsValid
            ? Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState)
            : new Classes.Default(Request).NewMsg(mensagem);
        #endregion

        #region PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        #endregion

        #region DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion
    }

}

