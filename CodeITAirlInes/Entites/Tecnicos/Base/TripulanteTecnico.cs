using CodeITAirlInes.Entites.Base;
using System;

namespace CodeITAirlInes.Entites.Tecnicos.Base
{
    public abstract class TripulanteTecnico : TripulanteOficial
    {
        public TripulanteTecnico(bool canDrive, params Type[] restricoes) : base(canDrive, restricoes) { }
    }
}
