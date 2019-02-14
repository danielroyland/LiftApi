using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiftApi.Dataaksess;
using LiftApi.Models;

namespace LiftApi.ApiControllers
{
    public class BrukerController : ApiController
    {
        private readonly LiftContext _context = new LiftContext();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Bruker bruker)
        {
            _context.Brukere.Add(bruker);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}