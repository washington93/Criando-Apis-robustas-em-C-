using System;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using XGame.Domain.Resources;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Extensions;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNotEmail(x => x.Email.Endereco, "Informe um e-mail válido.")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres.");

        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;



            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32,
                Message.X0_E_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES
                .ToFormat("Senha","3","50"));

            if (IsValid())
            {
                Senha = Senha.ConverToMD5();
            }


            AddNotifications(nome, email);
        }

        public Guid Id { get;private set; }

        public Nome Nome { get;private set; }

        public Email Email { get;private set; }

        public string Senha { get;private set; }

        public EnumSituacaoJogador Status { get;private set; }


    }
}
