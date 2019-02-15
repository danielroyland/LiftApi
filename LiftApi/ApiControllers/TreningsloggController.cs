using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiftApi.Dataaksess;
using LiftApi.Models;

namespace LiftApi.ApiControllers
{
    public class TreningsloggController : ApiController
    {
        private readonly LiftContext _context = new LiftContext();

        // GET api/<controller>
        public List<Treningsøkt> Get()
        {
            var res = _context.Treningsøkt.ToList();
            return res;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Treningsøkt treningsøkt)
        {
            // Beregn teoretisk maks

            // Lagre
            _context.Treningsøkt.Add(treningsøkt);
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