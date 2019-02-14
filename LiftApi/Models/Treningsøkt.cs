using System;

namespace LiftApi.Models
{
    public class Treningsøkt
    {
        public int ID { get; set; }
        public DateTime Dato { get; set; }
        public virtual Bruker Bruker { get; set; }
        public virtual Løft Knebøy { get; set; }
        public virtual Løft Benkpress { get; set; }
        public virtual Løft Markløft { get; set; }
    }

    public class Løft
    {
        public int ID { get; set; }
        public TypeLøft TypeLøft { get; set; }
        public int AntallReps { get; set; }
        public int AntallKg { get; set; }
        public double TeoretiskMaks { get; set; }
    }

    public enum TypeLøft
    {
        Knebøy,
        Benkpress,
        Markløft
    }
}