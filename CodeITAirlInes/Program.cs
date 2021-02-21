using CodeITAirlInes.Entites.Base;
using CodeITAirlInes.Entites.Cabine;
using CodeITAirlInes.Entites.Cabine.Base;
using CodeITAirlInes.Entites.Outros;
using CodeITAirlInes.Entites.Tecnicos;
using CodeITAirlInes.Entites.Tecnicos.Base;
using CodeITAirlInes.Entites.Viagens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirlInes
{
    class Program
    {
        static void Main(string[] args)
        {
            var tripulacao = GerarTripulacao().ToList();

            Console.WriteLine($"A tripulção para embarcar consistem em {tripulacao.Count()} pessoas:");
            MostrarTripulacaoRestante(tripulacao);

            var viagens = GerarViagens(tripulacao);

            GerarResumo(viagens);
        }

        private static List<Viagem> GerarViagens(List<Tripulante> tripulacao)
        {
            var viagens = new List<Viagem>();
            while (tripulacao.Any())
            {
                var viagem = new Viagem();
                ObterMotorista(tripulacao, viagem);
                MostrarTripulacaoRestante(tripulacao);
                ObterPassageiro(tripulacao, viagem);
                MostrarTripulacaoRestante(tripulacao);
                viagens.Add(viagem);
            }

            return viagens;
        }

        private static void GerarResumo(List<Viagem> viagens)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("======== Resumo das Viagens ========");
            Console.WriteLine("====================================");

            viagens.ForEach(item =>
            {
                Console.WriteLine($"Viagem {viagens.IndexOf(item) + 1:00}");
                Console.WriteLine($"Motorista: {item.Motorista}");
                Console.WriteLine($"Passageiro(a): {item.Passageiro}");
                Console.WriteLine("--------------------------------");

            });
        }

        private static IEnumerable<Tripulante> GerarTripulacao()
        {
            var response = new List<Tripulante>();
            response.AddRange(GerarTripulacaoTecnica());
            response.AddRange(GerarTripulacaoCabine());
            response.AddRange(GerarTripulacaoNaoOficial());
            return response;
        }

        private static IEnumerable<TripulanteNaoOficial> GerarTripulacaoNaoOficial()
        {
            return new List<TripulanteNaoOficial> { new Policial(), new Presidiario() };
        }

        private static IEnumerable<TripulanteTecnico> GerarTripulacaoTecnica()
        {
            return new List<TripulanteTecnico> { new Piloto(), new Oficial(), new Oficial() };
        }

        private static IEnumerable<TripulanteCabine> GerarTripulacaoCabine()
        {
            return new List<TripulanteCabine> { new ChefeVoo(), new Comissaria(), new Comissaria() };
        }

        private static void MostrarTripulacaoRestante(List<Tripulante> tripulacao)
        {
            tripulacao.ForEach(f => Console.WriteLine($"({tripulacao.ToList().IndexOf(f) + 1}) - {f.ToString()}"));
        }

        private static int GerarPergunta(string pergunta, int tripulacaoRestante)
        {
            Console.WriteLine(pergunta);
            return ValidarResposta(pergunta, Console.ReadLine(), tripulacaoRestante);
        }

        private static int ValidarResposta(string pergunta, string resposta, int tripulacaoRestante)
        {
            if (!int.TryParse(resposta, out int result) || result <= 0 || result > tripulacaoRestante)
            {
                Console.WriteLine("Respota inválida");
                result = GerarPergunta(pergunta, tripulacaoRestante);
            }
            return result;
        }

        private static void ObterMotorista(List<Tripulante> tripulacao, Viagem viagem)
        {
            var motorista = tripulacao.ToArray()[GerarPergunta("Quem irá dirigir?", tripulacao.Count()) - 1];
            if(viagem.AdicionarMotorista(motorista, out var mensagem))
            {
                Console.WriteLine(mensagem);
                ObterMotorista(tripulacao, viagem);
            }
            tripulacao.Remove(viagem.Motorista);
        }

        private static void ObterPassageiro(List<Tripulante> tripulacao, Viagem viagem)
        {
            var passageiro = tripulacao.ToArray()[GerarPergunta("Quem irá de passageiro?", tripulacao.Count()) - 1];
            if(viagem.AdicionarPassageiro(passageiro, out var mensagem))
            {
                Console.WriteLine(mensagem);
                ObterPassageiro(tripulacao, viagem);
            }

            tripulacao.Remove(viagem.Passageiro);
            if (tripulacao.Any(a => a.GetType() == viagem.Passageiro.GetType()) && !tripulacao.Contains(viagem.Motorista))
                tripulacao.Add(viagem.Motorista);
        }
    }
}
