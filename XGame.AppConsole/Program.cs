using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;
using XGame.Domain.ValueObjects;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando ...");

            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do serviço");

            //AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei instancia do meu objeto request");
            //request.Email = "teste@dev.com";
            //request.Senha = "123456";

            //var response = service.AuthenticarJogador(request);

            var request = new AdicionarJogadorRequest()
            {
                Email = "washington.sr@dev.com",
                PrimeiroNome = "Washington",
                UltimoNome = "da Silva Ribeiro",
                Senha= "123456"
            };

            var response = service.AdicionarJogador(request);

            Console.WriteLine("Serviço é válido -> " + service.IsValid());

            service.Notifications.ToList().ForEach(XGame =>
            {
                Console.WriteLine(XGame.Message);
            });
            //if (service.IsInvalid())
            //{
            //    return response;
            //}

            Console.ReadKey();
        }
    }
}
