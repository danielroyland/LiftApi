using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiftApi.ApiControllers.Attributes;
using LiftApi.Dataaksess;
using LiftApi.Models;

namespace LiftApi.ApiControllers
{
    [AuthorizeLift]
    [RequireHttps]
    public class BrukerController : ApiController
    {
        private readonly LiftContext _context = new LiftContext();

        public HttpResponseMessage Get()
        {
            try
            {
                var result = _context.Brukere.ToList();
                var response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(string brukerId)
        {
            try
            {
                var result = _context.Brukere.First(x => x.BrukerId == brukerId);
                var response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Bruker bruker)
        {
            try
            {
                _context.Brukere.Add(bruker);
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