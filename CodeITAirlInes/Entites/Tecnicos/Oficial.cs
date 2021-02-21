using CodeITAirlInes.Entites.Cabine;
using CodeITAirlInes.Entites.Tecnicos.Base;

namespace CodeITAirlInes.Entites.Tecnicos
{
    public class Oficial : TripulanteTecnico
    {
        public Oficial() : base(false, typeof(ChefeVoo)) { }
    }
}
