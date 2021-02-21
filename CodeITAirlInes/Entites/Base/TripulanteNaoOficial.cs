using System;

namespace CodeITAirlInes.Entites.Base
{
    public abstract class TripulanteNaoOficial : Tripulante
    {
        public TripulanteNaoOficial(bool canDrive, params Type[] restricoes) : base(canDrive, restricoes)
        {
            Restricoes.Add(typeof(TripulanteOficial));
        }
    }
}
