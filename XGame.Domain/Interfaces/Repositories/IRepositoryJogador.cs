using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AuthenticarJogador(AutenticarJogadorRequest request);

        Guid AdicionarJogador(Jogador jogador);
    }
}
