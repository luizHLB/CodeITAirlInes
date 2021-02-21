using CodeITAirlInes.Entites.Base;
using System;

namespace CodeITAirlInes.Entites.Cabine.Base
{
    public abstract class TripulanteCabine : TripulanteOficial
    {
        public TripulanteCabine(bool canDrive, params Type[] restricoes) : base(canDrive, restricoes) { }
    }
}
