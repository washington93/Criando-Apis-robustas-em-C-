using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IRequest
    {
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
