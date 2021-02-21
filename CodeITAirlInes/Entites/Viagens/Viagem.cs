using CodeITAirlInes.Entites.Base;
using System.Linq;

namespace CodeITAirlInes.Entites.Viagens
{
    public class Viagem
    {

        public Tripulante Motorista { get; private set; }
        public Tripulante Passageiro { get; private set; }

        public bool AdicionarMotorista(Tripulante motorista, out string message)
        {
            message = string.Empty;
            if (!motorista.CanDrive)
                message = $"{Motorista} não está autorizado a dirigir";

            if (string.IsNullOrEmpty(message))
            {
                Motorista = motorista;
                return false;
            }

            return true;
        }

        public bool AdicionarPassageiro<T>(T passageiro, out string message) where T : Tripulante
        {
            if (passageiro is TripulanteOficial)
                return AdicionarPassageiroOficial(passageiro, out message);

            return AdicionarPassageiroNaoOficial(passageiro, out message);

        }

        private bool AdicionarPassageiroOficial(Tripulante passageiro, out string message)
        {
            ValidarPassageiro(passageiro, out message);

            if (Motorista is TripulanteNaoOficial)
                message = $"Devido as normas, o passageiro(a): {passageiro} não está autorizado a estar no mesmo veiculo com o motorista: {Motorista}";

            if (string.IsNullOrEmpty(message))
            {
                Passageiro = passageiro;
                return false;
            }

            return true;
        }

        private bool AdicionarPassageiroNaoOficial(Tripulante passageiro, out string message)
        {
            ValidarPassageiro(passageiro, out message);

            if (Motorista is TripulanteOficial)
                message = $"Devido as normas, o passageiro(a): {passageiro} não está autorizado a estar no mesmo veiculo com o motorista: {Motorista}";

            if (string.IsNullOrEmpty(message))
            {
                Passageiro = passageiro;
                return false;
            }

            return true;

        }

        private void ValidarPassageiro(Tripulante passageiro, out string message)
        {
            message = string.Empty;
            if (passageiro.CanDrive)
                message = $"Não é recomendado que dois tripulante com permissão para dirigir estejam no mesmo carro";

            if (passageiro.Restricoes?.Any(a => Motorista.GetType() == a) == true)
                message = $"Devido as normas, o passageiro(a): {passageiro} não está autorizado a estar no mesmo veiculo com o motorista: {Motorista}";
        }
    }
}
