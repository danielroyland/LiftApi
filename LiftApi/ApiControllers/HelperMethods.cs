using System;
using LiftApi.ApiControllers.Dtos;
using LiftApi.Enums;
using LiftApi.Models;

namespace LiftApi.ApiControllers
{
    public static class HelperMethods
    {
        public static Treningsøkt MapTilTreningsøkt(TreningsøktDto dto)
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
                    TeoretiskMaks = BeregnTeoretiskMaks(dto.Knebøy.AntallKg, dto.Knebøy.AntallReps)
                },
                Benkpress = new Løft
                {
                    TypeLøft = TypeLøft.Benkpress,
                    AntallKg = dto.Benkpress.AntallKg,
                    AntallReps = dto.Benkpress.AntallReps,
                    TeoretiskMaks = BeregnTeoretiskMaks(dto.Benkpress.AntallKg, dto.Benkpress.AntallReps)
                },
                Markløft = new Løft
                {
                    TypeLøft = TypeLøft.Markløft,
                    AntallKg = dto.Markløft.AntallKg,
                    AntallReps = dto.Markløft.AntallReps,
                    TeoretiskMaks = BeregnTeoretiskMaks(dto.Markløft.AntallKg, dto.Markløft.AntallReps)
                },

            };
        }

        public static double BeregnTeoretiskMaks(double vekt, int reps)
        {
            if (reps == 1)
            {
                return vekt;
            }

            return Math.Floor(vekt * ((0.03333 * reps) + 1));
        }
    }
}