using System;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador()
        {
        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNotEmail(x => x.Email.Endereco, "Informe um e-mail válido.")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres.");



            //if (string.IsNullOrEmpty(Email))
            //{
            //    throw new Exception("Informe um e-mail.");
            //}

            //if (IsEmail(Email))
            //{
            //    throw new Exception("Informe um e-mail.");
            //}

            //if (string.IsNullOrEmpty(Senha))
            //{
            //    throw new Exception("Informe uma senha.");
            //}

            //if (Senha.Length <= 6)
            //{
            //    throw new Exception("Digite uma senha de no mínimo 6 caracteres.");
            //}
        }

        public Guid Id { get; set; }

        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; set; }

        public EnumSituacaoJogador Status { get; set; }


    }
}
