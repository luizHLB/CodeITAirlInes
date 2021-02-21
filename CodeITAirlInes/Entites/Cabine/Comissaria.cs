using CodeITAirlInes.Entites.Cabine.Base;
using CodeITAirlInes.Entites.Tecnicos;

namespace CodeITAirlInes.Entites.Cabine
{
    public class Comissaria : TripulanteCabine
    {
        public Comissaria() : base(false, typeof(Piloto)) { }
    }
}
