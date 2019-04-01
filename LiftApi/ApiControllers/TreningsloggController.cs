using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiftApi.Dataaksess;
using LiftApi.Models;

namespace LiftApi.ApiControllers
{
    [AuthorizeLift]
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
        public HttpResponseMessage Post([FromBody]TreningsøktDto treningsøktDto)
        {
           
            // Map
            var treningsøkt = MapTilTreningsøkt(treningsøktDto);

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


        private static Treningsøkt MapTilTreningsøkt(TreningsøktDto dto)
        {
            return new Treningsøkt
            {
                BrukerId = dto.BrukerID,
                Dato = dto.Dato,
                Knebøy = new Løft
                {
                    TypeLøft = TypeLøft.Knebøy,
                    AntallKg = dto.Knebøy.AntallKg,
                    AntallReps = dto.Knebøy.AntallReps,
                    TeoretiskMaks = HelperMethods.BeregnTeoretiskMaks(dto.Knebøy.AntallKg, dto.Knebøy.AntallReps)
                },
                Benkpress = new Løft
                {
                    TypeLøft = TypeLøft.Benkpress,
                    AntallKg = dto.Benkpress.AntallKg,
                    AntallReps = dto.Benkpress.AntallReps,
                    TeoretiskMaks = HelperMethods.BeregnTeoretiskMaks(dto.Benkpress.AntallKg, dto.Benkpress.AntallReps)
                },
                Markløft = new Løft
                {
                    TypeLøft = TypeLøft.Markløft,
                    AntallKg = dto.Markløft.AntallKg,
                    AntallReps = dto.Markløft.AntallReps,
                    TeoretiskMaks = HelperMethods.BeregnTeoretiskMaks(dto.Markløft.AntallKg, dto.Markløft.AntallReps)
                },

            };
        }
    }

    public static class HelperMethods
    {
        public static double BeregnTeoretiskMaks(double vekt, int reps)
        {
            if (reps == 1)
            {
                return vekt;
            }

            return Math.Floor(vekt * ((0.03333 * reps) + 1));
        }
    }

    public class TreningsøktDto
    {
        public string BrukerID { get; set; }

        public DateTime Dato { get; set; }

        public LøftDto Benkpress { get; set; }

        public LøftDto Knebøy { get; set; }

        public LøftDto Markløft { get; set; }
    }

    public class LøftDto
    {
        public int AntallReps { get; set; }

        public double AntallKg { get; set; }
    }
}