using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiftApi.ApiControllers.Attributes;
using LiftApi.ApiControllers.Dtos;
using LiftApi.Dataaksess;

namespace LiftApi.ApiControllers
{
    [AuthorizeLift]
    [RequireHttps]
    public class TreningsloggController : ApiController
    {
        private readonly LiftContext _context = new LiftContext();

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var result = _context.Treningsøkt.ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string brukerId)
        {
            try
            {
                var result = _context.Treningsøkt.Where(x => x.BrukerId == brukerId).ToList();
                var response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]TreningsøktDto treningsøktDto)
        {

            try
            {
                var treningsøkt = HelperMethods.MapTilTreningsøkt(treningsøktDto);

                // Lagre
                _context.Treningsøkt.Add(treningsøkt);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

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