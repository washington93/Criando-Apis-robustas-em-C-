using XGame.Domain.ValueObjects;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorRequest : IRequest
    {
        //public Nome Nome { get; set; }

        //public Email Email { get; set; }

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        

    }
}
