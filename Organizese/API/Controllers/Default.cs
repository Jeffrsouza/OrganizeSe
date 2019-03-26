using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using static Organizese.API.Models.Default;

namespace Organizese.API.Controllers
{

    public class Default : ApiController
    {
        #region GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        #endregion
        #region GET api/<controller>/5
        [HttpGet]
        [Route("api/GetTopFivePosts")]
        public HttpResponseMessage GetTopFivePosts() =>
            new Classes.Default(Request).GetTopFivePosts();

        public string Get(int id)
        {
            return "value";
        }
        #endregion

        #region POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
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