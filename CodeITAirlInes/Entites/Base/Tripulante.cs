using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirlInes.Entites.Base
{
    public abstract class Tripulante
    {
        public Tripulante(bool canDrive)
        {
            CanDrive = canDrive;
        }

        public Tripulante(bool canDrive, params Type[] restricoes)
        {
            CanDrive = canDrive;
            Restricoes = restricoes?.ToList() ?? new List<Type>();
        }

        public bool CanDrive { get; set; }
        public IList<Type> Restricoes { get; set; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
