using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.ValueObjects;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {
        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            Jogador jogador = new Jogador();
            jogador.Email = request.Email;
            jogador.Nome = request.Nome;
            jogador.Status = Enum.EnumSituacaoJogador.EmAndamento;

            Guid id = _repositoryJogador.AdicionarJogador(jogador);

            return new AdicionarJogadorResponse();
        }

        public AutenticarJogadorResponse AuthenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                throw new Exception("AutenticarJogadorRequest é Obrigatório.");
            }

            var email = new Email("paulo"); 

            var jogador = new Jogador(email, "123");

            AddNotifications(jogador);

            if (jogador.IsInvalid())
            {
                return null;
            }

            var response = _repositoryJogador.AuthenticarJogador(request);

            return response;
        }



        private bool IsEmail(string endereco)
        {
            return false;
        }
    }
}
