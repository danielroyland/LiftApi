using LiftApi.Enums;

namespace LiftApi.Models
{
    public class Løft
    {
        public int ID { get; set; }
        public TypeLøft TypeLøft { get; set; }
        public int AntallReps { get; set; }
        public double AntallKg { get; set; }
        public double TeoretiskMaks { get; set; }
    }
}