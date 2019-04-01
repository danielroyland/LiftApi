using System;

namespace LiftApi.Models
{
    public class Treningsøkt
    {
        public int ID { get; set; }
        public DateTime Dato { get; set; }
        public string BrukerId { get; set; }
        public virtual Løft Knebøy { get; set; }
        public virtual Løft Benkpress { get; set; }
        public virtual Løft Markløft { get; set; }
    }
}