using System;

namespace CodeITAirlInes.Entites.Base
{
    public class TripulanteOficial : Tripulante
    {
        public TripulanteOficial(bool canDrive, params Type[] restricoes) : base(canDrive, restricoes) { }
    }
}
