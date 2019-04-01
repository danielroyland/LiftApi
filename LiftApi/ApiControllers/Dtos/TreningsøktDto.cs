using System;

namespace LiftApi.ApiControllers.Dtos
{
    public class TreningsøktDto
    {
        public string BrukerID { get; set; }

        public DateTime Dato { get; set; }

        public LøftDto Benkpress { get; set; }

        public LøftDto Knebøy { get; set; }

        public LøftDto Markløft { get; set; }
    }
}